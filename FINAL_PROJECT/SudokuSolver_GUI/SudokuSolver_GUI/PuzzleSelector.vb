Public Class PuzzleSelector

    Declare Function SS_GetCellValue Lib "SudokuSolver_DLL.dll" _
        Alias "?GetCellValue@Solver@Sudoku@@SGHHH@Z" (ByVal _row As Integer, ByVal _col As Integer) As Integer
    Declare Sub SS_Initialize Lib "SudokuSolver_DLL.dll" _
        Alias "?Initialize@Solver@Sudoku@@SGXXZ" ()
    Declare Function SS_IsSolved Lib "SudokuSolver_DLL.dll" _
        Alias "?IsSolved@Solver@Sudoku@@SGHXZ" () As Integer
    Declare Sub SS_SetCellValue Lib "SudokuSolver_DLL.dll" _
        Alias "?SetCellValue@Solver@Sudoku@@SGXHHH@Z" (ByVal _row As Integer, ByVal _col As Integer, ByVal _val As Integer)
    Declare Function SS_Solve Lib "SudokuSolver_DLL.dll" _
       Alias "?Solve@Solver@Sudoku@@SGHXZ" () As Integer

    Public Class Cell
        Public lcol, rcol As Integer
        Public trow, brow As Integer
        Public bm As Bitmap
        Public value As Integer
        Private totalIntensity As Integer
        Public Sub New()
            lcol = -1
            rcol = -1
            bm = Nothing
            value = -1
            totalIntensity = -1
        End Sub


        Public Function bmHasANumber() As Boolean
            ' walk through each of the 28x28 pixels; if the intensity threshold is below the
            ' pixel threshold, it is ON

            Dim pixelIntensityThreshold As Integer = CInt(PuzzleSelector.tbPixelThreshold.Text)
            If (totalIntensity < 0) Then
                totalIntensity = 0
                Dim row, col As Integer
                For row = 0 To 27
                    For col = 0 To 27
                        If bm.GetPixel(col, row).R <= pixelIntensityThreshold Then
                            totalIntensity = totalIntensity + 1
                        End If
                    Next
                Next
            End If

            ' total Intensity = # of pixels on
            ' see if this meets or exceeds the findNumberThreshold
            If (totalIntensity >= CInt(PuzzleSelector.tbFindNumberThreshold.Text) / 100 * 28 * 28) Then
                bmHasANumber = True
            Else
                bmHasANumber = False
            End If
        End Function
        '----------------------------------------------------------------------------------------------------
        ' DESCRIPTION:
        '   Returns true if indicated coordinates are inside the cell
        '----------------------------------------------------------------------------------------------------
        Public Function CoordsInCell(_x As Integer, _y As Integer) As Boolean
            CoordsInCell = ((_x >= lcol) And (_x <= rcol) And (_y >= trow) And (_y <= brow))
            Return CoordsInCell
        End Function
    End Class

    Private writer As TextBoxWriter = Nothing

    ' CellPuzzle is 9 x 9 indexed from 0 to 8
    Dim CellPuzzle(8, 8) As Cell

    Dim gCurCellRow As Integer
    Dim gCurCellCol As Integer

    ' Gaussian mean, variance of all pixels in raw (ie inverse video) format
    ' digits 0 through 9, grid of 28x28 indexed from 0 to 27
    Dim gGaussian_Mean(9, 27, 27) As Single
    Dim gGaussian_Variance(9, 27, 27) As Single

    ' Bernoulli probabilities of pixels ON
    ' digits 0 through 9, grid of 28x28 indexed from 0 to 27
    Dim gProb_On(9, 27, 27) As Single

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim row As String() = New String() {"", "", "", "", "", "", "", "", ""}
        dgvPuzzle.Rows.Add(row)
        dgvPuzzle.Rows.Add(row)
        dgvPuzzle.Rows.Add(row)
        dgvPuzzle.Rows.Add(row)
        dgvPuzzle.Rows.Add(row)
        dgvPuzzle.Rows.Add(row)
        dgvPuzzle.Rows.Add(row)
        dgvPuzzle.Rows.Add(row)
        dgvPuzzle.ClearSelection()
        dgvPuzzle.CurrentCell = Nothing
        For x As Integer = 0 To 8
            For y As Integer = 0 To 8
                CellPuzzle(x, y) = New Cell()
            Next
        Next

        Dim g As Gridset = New Gridset()

        SS_Initialize()
    End Sub

    '------------------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------------------
    Private Sub btnSelectImage_Click(sender As Object, e As EventArgs) Handles btnSelectImage.Click
        Dim ofDialog1 As New OpenFileDialog

        If ofDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            pbxPuzzle.ImageLocation = ofDialog1.FileName

            For x As Integer = 0 To 8
                For y As Integer = 0 To 8
                    CellPuzzle(x, y) = New Cell
                    dgvPuzzle.Rows(x).Cells(y).Style.BackColor = Color.White
                    dgvPuzzle.ClearSelection()
                Next
            Next

        End If
    End Sub
    '------------------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------------------
    Private Sub btnClearImage_Click(sender As Object, e As EventArgs) Handles btnClearImage.Click
        Console.WriteLine("btnClearImage_Click()")
        pbxPuzzle.Image = Nothing
    End Sub

    '------------------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------------------
    Private Sub drawLine(ByRef _bm As Bitmap, _pixel As Integer, _isRow As Boolean)
        Dim X, Y As Integer
        If _isRow Then
            For X = 0 To _bm.Width - 1
                _bm.SetPixel(X, _pixel, Color.Lime)
            Next
        Else
            For Y = 0 To _bm.Height - 1
                _bm.SetPixel(_pixel, Y, Color.Lime)
            Next
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------------------
    Private Sub convertToGrayscale(ByRef _bm As Bitmap)
        Dim X, Y As Integer
        Dim pixelval As Integer

        For X = 0 To _bm.Width - 1
            For Y = 0 To _bm.Height - 1
                pixelval = (CInt(_bm.GetPixel(X, Y).R) + CInt(_bm.GetPixel(X, Y).G) + CInt(_bm.GetPixel(X, Y).B)) / 3
                _bm.SetPixel(X, Y, Color.FromArgb(pixelval, pixelval, pixelval))
            Next
        Next
    End Sub
    '------------------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------------------
    Private Sub getHorizontalLines()
        ' print dimensions of the image
        If IsNothing(pbxPuzzle.Image) Then
            Return
        End If


        tbHeight.Text = pbxPuzzle.Image.Height
        tbWidth.Text = pbxPuzzle.Image.Width

        Dim X, Y As Integer
        X = pbxPuzzle.Image.Width
        Y = pbxPuzzle.Image.Height
        Console.WriteLine("IMAGE DIMENSIONS: WIDTH X=" & X & " HEIGHT Y=" & Y)

        ' convert to bitmap

        Dim bmImage = New Bitmap(pbxPuzzle.Image)

        ' convert bitmap to grayscale
        convertToGrayscale(bmImage)

        ' traipse through the rows, sum all the pixel values
        ' draw a line in the bitmap if we are at a grid line
        ' assume if the row is less than 153% intensity or 153/255 ) , it's a gridline
        Dim threshold As Integer = bmImage.Width * 153
        Dim gridLineEnabled = True
        Dim currentGridRow = 0
        Dim c As Integer

        Try


            For Y = 0 To bmImage.Height - 1
                Dim pixelval As Integer = 0
                For X = 0 To bmImage.Width - 1
                    pixelval = pixelval + bmImage.GetPixel(X, Y).R
                Next
                ' the grid lines are those rows with the smallest values.
                If pixelval < threshold Then
                    drawLine(bmImage, Y, True)
                    ' if we are transitioning from gridLineEnabled from False to True, we have identified
                    ' the brow of the currentGridRow as the PREVIOUS row
                    If gridLineEnabled = False Then
                        gridLineEnabled = True
                        For c = 0 To 8
                            CellPuzzle(currentGridRow, c).brow = Y - 1
                        Next
                        currentGridRow = currentGridRow + 1
                    End If
                    Console.WriteLine(" ROW " & Y & ": GREEN")
                Else
                    ' if we are transitioning gridLineEnabled from True to False, we have identified the
                    ' trow of the currentGridRow as the current row
                    ' therefore populate that field 
                    If gridLineEnabled Then
                        gridLineEnabled = False
                        For c = 0 To 8
                            CellPuzzle(currentGridRow, c).trow = Y
                        Next
                    End If
                End If
            Next

        Catch ex As Exception

        End Try
        ' traipse through the columns, sum all the pixel values
        threshold = bmImage.Height * 153
        gridLineEnabled = True
        Dim currentGridCol = 0

        Try


            For X = 0 To bmImage.Width - 1
                Dim pixelval As Integer = 0
                For Y = 0 To bmImage.Height - 1
                    pixelval = pixelval + bmImage.GetPixel(X, Y).R
                Next
                ' the grid lines are those columns with the smallest values.
                If pixelval < threshold Then
                    drawLine(bmImage, X, False)
                    ' if we are transitioning from gridLineEnabled from False to True, we have identified
                    'the rcol  of the currentGridCol as the PREVIOUS col
                    If gridLineEnabled = False Then
                        gridLineEnabled = True
                        For c = 0 To 8
                            CellPuzzle(c, currentGridCol).rcol = X - 1
                        Next
                        currentGridCol = currentGridCol + 1
                    End If
                    Console.WriteLine("  COL " & X & ": GREEN")
                Else
                    ' if we are transitioning gridLineEnabled from True to False, we have identified the
                    ' lcol of the currentGridCol as the current col
                    ' therefore populate that field
                    If gridLineEnabled Then
                        gridLineEnabled = False
                        For c = 0 To 8
                            CellPuzzle(c, currentGridCol).lcol = X
                        Next
                    End If
                End If

            Next
        Catch ex As Exception

        End Try
        pbxPuzzle.Image = bmImage
    End Sub
    '------------------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------------------
    Private Sub btnDrawLines_Click(sender As Object, e As EventArgs) Handles btnDrawLines.Click
        Console.WriteLine("btnDrawLines_Click()")
        getHorizontalLines()
    End Sub

    Private Sub btnShowCellDimensions_Click(sender As Object, e As EventArgs) Handles btnShowCellDimensions.Click
        Console.WriteLine("btnGetCellDimensions_Click()")
        Dim row, col As Integer
        For row = 0 To 8
            For col = 0 To 8
                Console.WriteLine("CELL(" & row & "," & col & "):" _
                 & CellPuzzle(row, col).trow & "," _
                 & CellPuzzle(row, col).lcol & " " _
                 & CellPuzzle(row, col).trow & "," _
                 & CellPuzzle(row, col).rcol & " " _
                 & CellPuzzle(row, col).brow & "," _
                 & CellPuzzle(row, col).lcol & " " _
                 & CellPuzzle(row, col).brow & "," _
                 & CellPuzzle(row, col).rcol & " ")
            Next
            ' Console.WriteLine()
        Next
    End Sub

    Private Sub btnGetCellBitmaps_Click(sender As Object, e As EventArgs) Handles btnGetCellBitmaps.Click
        Console.WriteLine("btnGetCellBitmaps_Click()")
        Dim row, col As Integer
        For row = 0 To 8
            For col = 0 To 8
                Dim newBm As Bitmap = New Bitmap(pbxPuzzle.Image)
                CellPuzzle(row, col).bm = newBm.Clone(New Rectangle(
                  CellPuzzle(row, col).lcol,
                  CellPuzzle(row, col).trow,
                  CellPuzzle(row, col).rcol - CellPuzzle(row, col).lcol + 1,
                  CellPuzzle(row, col).brow - CellPuzzle(row, col).trow + 1),
                  pbxPuzzle.Image.PixelFormat)

            Next
        Next
        Console.WriteLine("OK, we have extracted all the bitmaps. Click on large bitmap to select a cell.")

    End Sub

    Private Sub btnScaleCellBitmaps_Click(sender As Object, e As EventArgs) Handles btnScaleCellBitmaps.Click
        Console.WriteLine("btnScaleCellBitmaps_Click()")
        Dim row, col As Integer
        For row = 0 To 8
            For col = 0 To 8
                Dim newBm As New Bitmap(28, 28)
                Dim graphics_dst As Graphics = Graphics.FromImage(newBm)
                graphics_dst.DrawImage(New Bitmap(CellPuzzle(row, col).bm), 0, 0, 28, 28)
                CellPuzzle(row, col).bm = newBm
            Next
        Next
        Console.WriteLine("OK, we have scaled all the bitmaps. Click on large bitmap to select a cell.")


    End Sub

    Private Sub btnGetNumbers_Click(sender As Object, e As EventArgs) Handles btnGetNumbers.Click
        Console.WriteLine("btnGetNumbers_Click()")
        ' for each cell, determine if it contains a number
        ' if cell is > 10% populated with black pixels (ie if it is
        ' < 90% white), consider it populated with a number
        Dim row, col As Integer
        For row = 0 To 8
            For col = 0 To 8
                If (CellPuzzle(row, col).bmHasANumber) Then
                    ' put something in the data grid view
                    dgvPuzzle.Rows(row).Cells(col).Style.BackColor = Color.White
                Else
                    dgvPuzzle.Rows(row).Cells(col).Style.BackColor = Color.LightGray
                End If
                Console.Write(CellPuzzle(row, col).bmHasANumber & " ")
            Next
            Console.WriteLine()
        Next
    End Sub

    Private Function ParseNumberViaGaussian(_cell As Cell) As Integer
        Dim pixelThreshold As Integer = CInt(tbPixelThreshold.Text)

        If _cell.bmHasANumber = False Then
            ParseNumberViaGaussian = -1
            Return ParseNumberViaGaussian
        End If

        ' calculate the log probabilities for all possible digits
        Dim logpDigits(9) As Single

        For digit = 0 To 9
            logpDigits(digit) = 0.0

            For row As Integer = 0 To 27
                For col As Integer = 0 To 27

                    ' Recall that the mean, variance data were for inverted images,
                    ' ie 0 = OFF, 0xFF = ON
                    ' The scanned digit bitmaps have 0 = ON, 0xFF = OFF
                    ' We therefore invert the bitmap data here, to be consistent with
                    ' the Gaussian statistics
                    Dim pixelVal As Integer = 255 - _cell.bm.GetPixel(col, row).R

                    ' HACK HACK HACK: if pixelVal is enabled, rail it
                    If (pixelVal < 150) Then
                        pixelVal = 0
                    Else
                        pixelVal = 255
                    End If
                    'logpDigits(digit) = logpDigits(digit) +
                    'Math.Log(1.0 / Math.Sqrt(2 * Math.PI * gGaussian_Variance(digit, row, col))) -
                    'Math.Pow((pixelVal - gGaussian_Mean(digit, row, col)), 2.0) / (2 * gGaussian_Variance(digit, row, col))
                    If (gGaussian_Variance(digit, row, col) = 0) Then
                        gGaussian_Variance(digit, row, col) = 0.000001
                    End If
                    Dim t1 As Single = Math.Log(1.0 / Math.Sqrt(2 * Math.PI * gGaussian_Variance(digit, row, col)))
                    'Dim t1 As Single = 1.0 / Math.Sqrt(2 * Math.PI * gGaussian_Variance(digit, row, col))
                    Dim t2 As Single = Math.Pow((pixelVal - gGaussian_Mean(digit, row, col)), 2.0) / (2 * gGaussian_Variance(digit, row, col))
                    logpDigits(digit) = logpDigits(digit) + t1 - t2

                Next
            Next
        Next

                ' most likely digit is the one with the highest log probability
                Dim maxLogP As Single = -999999999999

        For digit = 0 To 9
            If logpDigits(digit) >= maxLogP Then
                ParseNumberViaGaussian = digit
                maxLogP = logpDigits(digit)
            End If
        Next
    End Function
    Private Sub btnParseNumbersViaGaussian_Click(sender As Object, e As EventArgs) Handles btnParseNumbersViaGaussian.Click
        Console.WriteLine("btnParseNumbersViaGaussian_Click()")
        For row As Integer = 0 To 8
            For col As Integer = 0 To 8
                Dim val As Integer = ParseNumberViaGaussian(CellPuzzle(row, col))
                If (val > 0) Then
                    dgvPuzzle.Rows(row).Cells(col).Value = val
                End If
            Next
        Next
    End Sub
    Private Function ParseNumberViaProb(_cell As Cell) As Integer
        Dim pixelThreshold As Integer = CInt(tbPixelThreshold.Text)
        If _cell.bmHasANumber = False Then
            ParseNumberViaProb = -1
            Return ParseNumberViaProb
        End If

        'calculate the log probabilities for all possible digits
        Dim logpDigits(9) As Single

        For digit = 0 To 9
            logpDigits(digit) = 0.0
            For row As Integer = 0 To 27
                For col As Integer = 0 To 27
                    If (_cell.bm.GetPixel(col, row).R) < pixelThreshold Then
                        logpDigits(digit) = logpDigits(digit) + Math.Log(gProb_On(digit, row, col))
                    Else
                        logpDigits(digit) = logpDigits(digit) + Math.Log(1.0 - gProb_On(digit, row, col))
                    End If
                Next
            Next
        Next
        ' most likely digit is the one with the highest log probability
        Dim maxLogP As Single = -9999999999

        For digit = 0 To 9
            If logpDigits(digit) >= maxLogP Then
                ParseNumberViaProb = digit
                maxLogP = logpDigits(digit)
            End If
        Next
    End Function
    Private Sub btnParseNumbersViaProb_Click(sender As Object, e As EventArgs) Handles btnParseNumbersViaProb.Click
        Console.WriteLine("btnParseNumbersViaProb_Click()")
        For row As Integer = 0 To 8
            For col As Integer = 0 To 8
                Dim val As Integer = ParseNumberViaProb(CellPuzzle(row, col))
                If (val > 0) Then
                    dgvPuzzle.Rows(row).Cells(col).Value = val
                End If
            Next
        Next
    End Sub

    Private Function SS_Solve_Wrapper() As Boolean

        ' Populate the SS grid with all zeros
        For row As Integer = 0 To 8
            For col As Integer = 0 To 8
                SS_SetCellValue(row, col, 0)
            Next
        Next

        ' Populate the SS grid with the DGV values
        For row As Integer = 0 To 8
            For col As Integer = 0 To 8
                If (String.IsNullOrEmpty(dgvPuzzle.Rows(row).Cells(col).Value)) Then
                    SS_SetCellValue(row, col, -1)
                Else
                    SS_SetCellValue(row, col, dgvPuzzle.Rows(row).Cells(col).Value)
                End If

            Next
        Next

        ' Request to solve; return value
        If (SS_Solve() = 0) Then
            Console.WriteLine("COULD NOT SOLVE")
            Return False
        Else
            For row As Integer = 0 To 8
                For col As Integer = 0 To 8
                    dgvPuzzle.Rows(row).Cells(col).Value = SS_GetCellValue(row, col)
                Next
            Next
            Console.WriteLine("SOLVED")
            Return True
        End If
    End Function

    Private Sub btnSolve_Click(sender As Object, e As EventArgs) Handles btnSolve.Click
        Console.WriteLine("btnSolve_Click()")
        SS_Solve_Wrapper()
    End Sub


    Private Sub btnReadUVARFiles_Click(sender As Object, e As EventArgs) Handles btnReadUVARFiles.Click
        Console.WriteLine("btnReadUVARFiles_Click()")
        For digit As Integer = 0 To 9

            ' create the two filenames
            Dim MeanFile As String = "pgmap" & digit.ToString() & "_MEAN.csv"
            Dim VarFile As String = "pgmap" & digit.ToString() & "_VAR.csv"

            Dim MeanLines() As String = System.IO.File.ReadAllLines(MeanFile)
            Dim VarLines() As String = System.IO.File.ReadAllLines(VarFile)

            For row As Integer = 0 To 27

                Dim MeanLine() As String = Split(MeanLines(row), ",")
                Dim VarLine() As String = Split(VarLines(row), ",")

                For col As Integer = 0 To 27
                    gGaussian_Mean(digit, row, col) = Convert.ToSingle(MeanLine(col))
                    gGaussian_Variance(digit, row, col) = Convert.ToSingle(VarLine(col))
                    '           If gGaussian_Variance(digit, row, col) = 0 Then
                    '           gGaussian_Variance(digit, row, col) = 0.001
                    ' End If
                Next
            Next
        Next

    End Sub
    Private Sub btnReadProbFiles_Click(sender As Object, e As EventArgs) Handles btnReadProbFiles.Click
        Console.WriteLine("btnReadProbFiles_Click()")
        For digit As Integer = 0 To 9
            ' create the filename
            Dim OnFile As String = "ppmap" & digit.ToString() & ".csv"
            Dim OnLines() As String = System.IO.File.ReadAllLines(OnFile)

            For row As Integer = 0 To 27
                Dim OnLine() As String = Split(OnLines(row), ",")
                For col As Integer = 0 To 27
                    gProb_On(digit, row, col) = Convert.ToSingle(OnLine(col))
                Next
            Next
        Next

    End Sub


    Private Sub pbxPuzzle_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxPuzzle.MouseDown
        Console.WriteLine("MouseDown event:X=" & e.X.ToString() & " Y=" & e.Y.ToString())

        ' scale the PictureBox coordinates to the image coordinates
        Dim newX As Integer = e.X / pbxPuzzle.Width * pbxPuzzle.Image.Width
        Dim newY As Integer = e.Y / pbxPuzzle.Height * pbxPuzzle.Image.Height

        For row As Integer = 0 To 8
            For col As Integer = 0 To 8
                If CellPuzzle(row, col).CoordsInCell(newX, newY) Then
                    tbRow.Text = row.ToString()
                    tbCol.Text = col.ToString()

                    pbBigCell.Image = CellPuzzle(row, col).bm
                    pbBigCell.Show()
                    pbCell.Image = CellPuzzle(row, col).bm
                    pbCell.Show()

                    gCurCellCol = col
                    gCurCellRow = row

                    Return
                End If
            Next
        Next
    End Sub



    Private Sub btnUvarParse_Click(sender As Object, e As EventArgs) Handles btnUvarParse.Click
        ' try to identify the number selected
        tbCellValue.Text = ParseNumberViaGaussian(CellPuzzle(CInt(tbRow.Text), CInt(tbCol.Text)))
    End Sub

    Private Sub pbBigCell_MouseDown(sender As Object, e As MouseEventArgs) Handles pbBigCell.MouseDown
        Console.WriteLine("Pixel select event:X=" & e.X.ToString() & " Y=" & e.Y.ToString())

        'scale the PictureBox coordinates to the image coordinates
        Dim newX As Integer = e.X / pbBigCell.Width * pbBigCell.Image.Width
        Dim newY As Integer = e.Y / pbBigCell.Height * pbBigCell.Image.Height


        tbPixelRow.Text = newY.ToString()
        tbPixelCol.Text = newX.ToString()

        tbPixelIntensity.Text = CellPuzzle(gCurCellRow, gCurCellCol).bm.GetPixel(newX, newY).R

        Console.WriteLine(" RGB=" & CellPuzzle(gCurCellRow, gCurCellCol).bm.GetPixel(newX, newY).R & " " & CellPuzzle(gCurCellRow, gCurCellCol).bm.GetPixel(newX, newY).G & " " & CellPuzzle(gCurCellRow, gCurCellCol).bm.GetPixel(newX, newY).B)
    End Sub

    Private Sub dgvPuzzle_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvPuzzle.KeyDown
        Console.WriteLine("GRID EDIT: keycode = " & e.KeyCode)
        If e.KeyCode >= 48 And e.KeyCode <= 57 Then
            Dim digit As Integer = CInt(e.KeyCode) - 48
            dgvPuzzle.CurrentCell.Value = digit.ToString()
        ElseIf e.KeyCode = 32 Then
            dgvPuzzle.CurrentCell.Value = ""
        End If

        'End If
    End Sub

    Private Sub dgvPuzzle_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPuzzle.CellContentDoubleClick
        Console.WriteLine("CELL DBL CLICK")
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        Console.WriteLine("btnTest_Click()")
        'Dim goodPuzzle(,) As Integer = New Integer(8, 8) {{4, 3, 5, 2, 6, 9, 7, 8, 1}, {6, 8, 2, 5, 7, 1, 4, 9, 3}, {1, 9, 7, 8, 3, 4, 5, 6, 2}, {8, 2, 6, 1, 9, 5, 3, 4, 7}, {3, 7, 4, 6, 8, 2, 9, 1, 5}, {9, 5, 1, 7, 4, 3, 6, 2, 8}, {5, 1, 9, 3, 2, 6, 8, 7, 4}, {2, 4, 8, 9, 5, 7, 1, 3, 6}, {7, 6, 3, 4, 1, 8, 2, 5, 9}}
        Dim goodPuzzle(,) As Integer = New Integer(8, 8) {{4, 3, 5, 2, 6, 0, 7, 8, 1}, {6, 8, 2, 5, 7, 1, 0, 9, 3}, {1, 9, 7, 8, 0, 4, 5, 6, 2}, {8, 2, 6, 1, 9, 5, 3, 4, 7}, {3, 7, 4, 6, 8, 2, 9, 1, 5}, {9, 5, 1, 7, 4, 3, 6, 2, 8}, {5, 1, 9, 3, 2, 6, 8, 7, 4}, {2, 4, 8, 9, 5, 7, 1, 3, 6}, {7, 6, 3, 4, 1, 8, 2, 5, 9}}

        'Load the DGV with known values that can be solved
        For row As Integer = 0 To 8
            For col As Integer = 0 To 8
                dgvPuzzle.Rows(row).Cells(col).Value = goodPuzzle(row, col)

            Next
        Next
        '
        ' try solving this thing
        SS_Solve_Wrapper()

    End Sub

    Private Sub PuzzleSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
        writer = New TextBoxWriter(rtbLog)
        Console.SetOut(writer)
    End Sub

    Private Sub rtbLog_TextChanged(sender As Object, e As EventArgs) Handles rtbLog.TextChanged
        rtbLog.SelectionStart = rtbLog.Text.Length
        rtbLog.ScrollToCaret()
    End Sub

    Private Sub dgvPuzzle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPuzzle.CellContentClick
        Console.WriteLine("CELL SINGLE CLICK")
    End Sub

    Private Sub btnProbParse_Click(sender As Object, e As EventArgs) Handles btnProbParse.Click
        ' try to identify the number selected
        tbCellValue.Text = ParseNumberViaProb(CellPuzzle(CInt(tbRow.Text), CInt(tbCol.Text)))
    End Sub
End Class