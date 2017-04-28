Imports Cell
Imports Gridset



Public Class Grid

    Public Const DEFAULT_SIZE = 9

    Dim mNValue As Integer
    Dim mCells(,) As Cell = New Cell(,) {}
    Dim mRows() As Gridset = New Gridset() {}
    Dim mCols() As Gridset = New Gridset() {}
    Dim mSquares() As Gridset = New Gridset() {}

    Public Function GetNValue() As Integer
        Return mNValue
    End Function

    Public Sub New()
        i_Grid(DEFAULT_SIZE)
    End Sub

    Public Sub New(_NValue As Integer)
        i_Grid(_NValue)
    End Sub

    Public Sub New(ByRef _Grid As Grid)
        Dim NValue As Integer = _Grid.GetNValue()

        ' Invoke initialization function
        i_Grid(NValue)

        ' Copy cell values.
        '
        ' Note that it is not necessary to copy the possible values for those
        ' cells without nonzero values, as the possible values will be defined
        ' when needed
        For row As Integer = 0 To NValue - 1
            For col As Integer = 0 To NValue - 1
                mCells(row, col).Copy(_Grid.mCells(row, col))
            Next
        Next

    End Sub

    Public Sub Copy(ByRef _Grid As Grid)
        For row As Integer = 0 To mNValue - 1
            For col As Integer = 0 To mNValue - 1
                mCells(row, col).Copy(_Grid.mCells(row, col))
            Next
        Next
    End Sub


    Public Sub SetCellValue(_Row As Integer, _Col As Integer, _Value As Integer)
        mCells(_Row, _Col).SetValue(_Value)
    End Sub


    Public Function GetCellValue(_Row As Integer, _Col As Integer) As Integer
        Return (mCells(_Row, _Col).GetValue())
    End Function

    Public Function Solve() As Boolean

        ' first check if the grid is already solved; if so, return true
        If IsSolved() Then
            Return True
        End If

        ' SOLUTION ALGORITHM:
        '
        ' Iterate through this loop until either the grid is solved, or
        ' the end of the loop is reached without having made any modifications
        ' to the grid
        Dim continueLoop As Boolean

        Do

            '           Console.WriteLine("========> ALGORITHM LOOP START")
            continueLoop = False

            ' 1. UPDATE LIST OF POSSIBLE VALUES
            '
            '    Go through every cell that does not already have a value, and
            '    populate that cell's list of possible values.
            For row As Integer = 0 To mNValue - 1
                For col As Integer = 0 To mNValue - 1
                    If mCells(row, col).GetValue() = 0 Then
                        mCells(row, col).SetAllPossibleValues()
                        '                        Console.WriteLine("  CELL(" & row & "," & col & ") POSSIBLE VALUES SET")
                    End If
                Next
            Next

            ' 2. SEARCH FOR UNIQUE POSSIBLE VALUES AMONG GRIDSETS
            '
            '    For each Gridset (row, column, and square): find out if there
            '    is a cell with a unique possible value, that does not exist
            '    in the other cells for that Gridset.
            '
            '    If so: assign that unique possible value to the cell, and
            '    restart the algorithm loop.
            For index As Integer = 0 To mNValue - 1
                Dim searchCell As Cell
                Dim newValue As Integer

                If mRows(index).FindUniquePossibleValue(searchCell, newValue) = True Then
                    searchCell.SetValue(newValue)
                    '               Console.WriteLine("  CELL(row=" & index & ") VALUE SET TO " & newValue)
                    continueLoop = True
                    Exit For
                End If

                If mCols(index).FindUniquePossibleValue(searchCell, newValue) = True Then
                    searchCell.SetValue(newValue)
                    '                   Console.WriteLine("  CELL(col=" & index & ") VALUE SET TO " & newValue)
                    continueLoop = True
                    Exit For
                End If

                If mSquares(index).FindUniquePossibleValue(searchCell, newValue) = True Then
                    searchCell.SetValue(newValue)
                    '                   Console.WriteLine("  CELL(square=" & index & ") VALUE SET TO " & newValue)
                    continueLoop = True
                    Exit For
                End If
            Next

            If continueLoop Then
                Continue Do
            End If

            ' 3. ARBITRARILY CHOOSE A POSSIBLE VALUE
            '   
            '    If we get to this point, and the grid is not solved, there are no
            '    more values that can deterministically be assigned to cells.
            '    This means we have to choose from among the possible values to 
            '    assign to a cell.
            ' 
            '    We choose the first cell that does nto have a defined value,
            '    and we loop through each of its defined values. For each defined
            '    value, we create a duplicate grid, define the cell to contain 
            '    that value, and attempt to solve the frid (i.e., we recursively
            '    call Solve() on the duplicate grid).
            '
            '    If successful, the duplicate grid will actually contain the 
            '    solved cell values, so we copy it into our grid.
            ' 
            '    If we loop through all of the cells' possible values without
            '    successfully solving the temporary grid, we quit, and assume
            '    something is wrong with our algorithm.
            '
            '    UPDATE: OR we have an unsolveable puzzle.

            If IsSolved() = False Then
                '                Console.WriteLine("  DANGER DANGER DANGER: DECISION TIME!!!!!!")

                Dim quit As Boolean = False

                For row As Integer = 0 To mNValue - 1
                    For col As Integer = 0 To mNValue - 1
                        If mCells(row, col).GetValue() = 0 Then

                            Dim tryValue As Integer = mCells(row, col).GetFirstPossibleValue()

                            Do While (tryValue <> 0 And quit = False)
                                Dim newGrid As Grid = New Grid(Me)

                                '                                Console.WriteLine("  CELL(" & row & "," & col & "): TRYING VALUE " & tryValue)
                                newGrid.mCells(row, col).SetValue(tryValue)

                                If newGrid.Solve() = True Then

                                    ' SUCCESS, the grid is solved.
                                    '
                                    ' Save the new grid value to the current grid, and break
                                    ' out of this loop and quit.
                                    Console.WriteLine("  SUCCESS!!!! IT WORKED!")
                                    Copy(newGrid)
                                    quit = True
                                    Exit Do
                                Else
                                    '                                   Console.WriteLine(" FAILURE!")
                                End If

                                tryValue = mCells(row, col).GetNextPossibleValue()

                            Loop

                        End If
                        If quit = True Then
                            Exit For
                        End If

                    Next
                    If quit = True Then
                        Exit For
                    End If
                Next
            End If

        Loop While continueLoop = True

        Return IsSolved()

    End Function



    Public Function IsSolved() As Boolean

        ' Verify all rows
        Dim rowset As Gridset
        For Each rowset In mRows
            If rowset.IsSolved() = False Then
                Return False
            End If
        Next

        ' Verify all columns
        Dim colset As Gridset
        For Each colset In mCols
            If colset.IsSolved() = False Then
                Return False
            End If
        Next

        ' verify all squares
        Dim squareset As Gridset
        For Each squareset In mSquares
            If squareset.IsSolved() = False Then
                Return False
            End If
        Next

        Return True
    End Function





    Private Sub i_Grid(_NValue As Integer)

        Dim row, col As Integer

        mNValue = _NValue

        ' Allocate N x N pointers to cells, as well as the cells themselves
        ReDim mCells(0 To mNValue - 1, 0 To mNValue - 1)

        For row = 0 To mNValue - 1
            For col = 0 To mNValue - 1
                mCells(row, col) = New Cell(mNValue)
            Next
        Next

        ' Create rows
        '
        ' Add cells to each row, and also configure each cell so it knows
        ' what row it belongs to!
        ReDim mRows(0 To mNValue - 1)
        For row = 0 To mNValue - 1
            mRows(row) = New Gridset()
            For col = 0 To mNValue - 1
                mRows(row).AddCell(mCells(row, col))
                mCells(row, col).SetRow(mRows(row))
            Next
        Next

        ' Create columns
        '
        ' Add cells to each column, and also configure each cell so it knows
        ' what column it belongs to!
        ReDim mCols(0 To mNValue - 1)
        For col = 0 To mNValue - 1
            mCols(col) = New Gridset()
            For row = 0 To mNValue - 1
                mCols(col).AddCell(mCells(row, col))
                mCells(row, col).SetCol(mCols(col))
            Next
        Next

        ' Create squares; we ASSUME this mNValue is a perfect square
        '
        ' Add cells to each square, and also configure each cell so it
        ' knows which square it belongs to!
        ReDim mSquares(0 To mNValue - 1)
        Dim mNValueRoot As Integer = Math.Sqrt(mNValue)
        Dim squareCounter As Integer = 0
        For row = 0 To mNValue - 1 Step mNValueRoot
            For col = 0 To mNValue - 1 Step mNValueRoot
                mSquares(squareCounter) = New Gridset()

                For innerRow As Integer = 0 To mNValueRoot - 1
                    For innerCol As Integer = 0 To mNValueRoot - 1
                        mSquares(squareCounter).AddCell(mCells(row + innerRow, col + innerCol))
                        mCells(row + innerRow, col + innerCol).SetSquare(mSquares(squareCounter))
                    Next
                Next

                squareCounter = squareCounter + 1
            Next
        Next
    End Sub

End Class
