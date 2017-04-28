<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PuzzleSelector
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pbxPuzzle = New System.Windows.Forms.PictureBox()
        Me.btnSelectImage = New System.Windows.Forms.Button()
        Me.btnDrawLines = New System.Windows.Forms.Button()
        Me.btnShowCellDimensions = New System.Windows.Forms.Button()
        Me.btnGetNumbers = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnClearImage = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbHeight = New System.Windows.Forms.TextBox()
        Me.tbWidth = New System.Windows.Forms.TextBox()
        Me.dgvPuzzle = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnGetCellBitmaps = New System.Windows.Forms.Button()
        Me.btnScaleCellBitmaps = New System.Windows.Forms.Button()
        Me.pbBigCell = New System.Windows.Forms.PictureBox()
        Me.pbCell = New System.Windows.Forms.PictureBox()
        Me.btnParseNumbersViaGaussian = New System.Windows.Forms.Button()
        Me.btnSolve = New System.Windows.Forms.Button()
        Me.btnReadUVARFiles = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbRow = New System.Windows.Forms.TextBox()
        Me.tbCol = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnUvarParse = New System.Windows.Forms.Button()
        Me.tbCellValue = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbPixelThreshold = New System.Windows.Forms.TextBox()
        Me.tbFindNumberThreshold = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbPixelCol = New System.Windows.Forms.TextBox()
        Me.tbPixelRow = New System.Windows.Forms.TextBox()
        Me.tbPixelIntensity = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnReadProbFiles = New System.Windows.Forms.Button()
        Me.btnParseNumbersViaProb = New System.Windows.Forms.Button()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.rtbLog = New System.Windows.Forms.RichTextBox()
        Me.btnProbParse = New System.Windows.Forms.Button()
        CType(Me.pbxPuzzle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvPuzzle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBigCell, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCell, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbxPuzzle
        '
        Me.pbxPuzzle.Location = New System.Drawing.Point(10, 10)
        Me.pbxPuzzle.Name = "pbxPuzzle"
        Me.pbxPuzzle.Size = New System.Drawing.Size(400, 400)
        Me.pbxPuzzle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxPuzzle.TabIndex = 0
        Me.pbxPuzzle.TabStop = False
        '
        'btnSelectImage
        '
        Me.btnSelectImage.Location = New System.Drawing.Point(446, 10)
        Me.btnSelectImage.Name = "btnSelectImage"
        Me.btnSelectImage.Size = New System.Drawing.Size(93, 44)
        Me.btnSelectImage.TabIndex = 1
        Me.btnSelectImage.Text = "Select Image"
        Me.btnSelectImage.UseVisualStyleBackColor = True
        '
        'btnDrawLines
        '
        Me.btnDrawLines.Location = New System.Drawing.Point(446, 112)
        Me.btnDrawLines.Name = "btnDrawLines"
        Me.btnDrawLines.Size = New System.Drawing.Size(93, 42)
        Me.btnDrawLines.TabIndex = 2
        Me.btnDrawLines.Text = "Draw Lines"
        Me.btnDrawLines.UseVisualStyleBackColor = True
        '
        'btnShowCellDimensions
        '
        Me.btnShowCellDimensions.Location = New System.Drawing.Point(446, 160)
        Me.btnShowCellDimensions.Name = "btnShowCellDimensions"
        Me.btnShowCellDimensions.Size = New System.Drawing.Size(93, 42)
        Me.btnShowCellDimensions.TabIndex = 3
        Me.btnShowCellDimensions.Text = "Show Cell Dimensions"
        Me.btnShowCellDimensions.UseVisualStyleBackColor = True
        '
        'btnGetNumbers
        '
        Me.btnGetNumbers.Location = New System.Drawing.Point(446, 304)
        Me.btnGetNumbers.Name = "btnGetNumbers"
        Me.btnGetNumbers.Size = New System.Drawing.Size(93, 42)
        Me.btnGetNumbers.TabIndex = 4
        Me.btnGetNumbers.Text = "Find Numbers"
        Me.btnGetNumbers.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pbxPuzzle)
        Me.Panel1.Location = New System.Drawing.Point(7, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(420, 420)
        Me.Panel1.TabIndex = 5
        '
        'btnClearImage
        '
        Me.btnClearImage.Location = New System.Drawing.Point(446, 62)
        Me.btnClearImage.Name = "btnClearImage"
        Me.btnClearImage.Size = New System.Drawing.Size(93, 44)
        Me.btnClearImage.TabIndex = 6
        Me.btnClearImage.Text = "Clear Image"
        Me.btnClearImage.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 445)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "HEIGHT:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(110, 445)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "WIDTH:"
        '
        'tbHeight
        '
        Me.tbHeight.Enabled = False
        Me.tbHeight.Location = New System.Drawing.Point(62, 443)
        Me.tbHeight.Name = "tbHeight"
        Me.tbHeight.Size = New System.Drawing.Size(42, 20)
        Me.tbHeight.TabIndex = 9
        '
        'tbWidth
        '
        Me.tbWidth.Enabled = False
        Me.tbWidth.Location = New System.Drawing.Point(156, 443)
        Me.tbWidth.Name = "tbWidth"
        Me.tbWidth.Size = New System.Drawing.Size(42, 20)
        Me.tbWidth.TabIndex = 10
        '
        'dgvPuzzle
        '
        Me.dgvPuzzle.AllowUserToDeleteRows = False
        Me.dgvPuzzle.AllowUserToResizeColumns = False
        Me.dgvPuzzle.AllowUserToResizeRows = False
        Me.dgvPuzzle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPuzzle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9})
        Me.dgvPuzzle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvPuzzle.Location = New System.Drawing.Point(554, 18)
        Me.dgvPuzzle.Name = "dgvPuzzle"
        Me.dgvPuzzle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPuzzle.Size = New System.Drawing.Size(268, 222)
        Me.dgvPuzzle.TabIndex = 11
        '
        'Column1
        '
        Me.Column1.HeaderText = "1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 25
        '
        'Column2
        '
        Me.Column2.HeaderText = "2"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 25
        '
        'Column3
        '
        Me.Column3.HeaderText = "3"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 25
        '
        'Column4
        '
        Me.Column4.HeaderText = "4"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 25
        '
        'Column5
        '
        Me.Column5.HeaderText = "5"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 25
        '
        'Column6
        '
        Me.Column6.HeaderText = "6"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 25
        '
        'Column7
        '
        Me.Column7.HeaderText = "7"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 25
        '
        'Column8
        '
        Me.Column8.HeaderText = "8"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 25
        '
        'Column9
        '
        Me.Column9.HeaderText = "9"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 25
        '
        'btnGetCellBitmaps
        '
        Me.btnGetCellBitmaps.Location = New System.Drawing.Point(446, 208)
        Me.btnGetCellBitmaps.Name = "btnGetCellBitmaps"
        Me.btnGetCellBitmaps.Size = New System.Drawing.Size(93, 42)
        Me.btnGetCellBitmaps.TabIndex = 12
        Me.btnGetCellBitmaps.Text = "Get Cell" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Bitmaps"
        Me.btnGetCellBitmaps.UseVisualStyleBackColor = True
        '
        'btnScaleCellBitmaps
        '
        Me.btnScaleCellBitmaps.Location = New System.Drawing.Point(446, 256)
        Me.btnScaleCellBitmaps.Name = "btnScaleCellBitmaps"
        Me.btnScaleCellBitmaps.Size = New System.Drawing.Size(93, 42)
        Me.btnScaleCellBitmaps.TabIndex = 13
        Me.btnScaleCellBitmaps.Text = "Scale Cell Bitmaps"
        Me.btnScaleCellBitmaps.UseVisualStyleBackColor = True
        '
        'pbBigCell
        '
        Me.pbBigCell.Location = New System.Drawing.Point(7, 7)
        Me.pbBigCell.Name = "pbBigCell"
        Me.pbBigCell.Size = New System.Drawing.Size(109, 109)
        Me.pbBigCell.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbBigCell.TabIndex = 14
        Me.pbBigCell.TabStop = False
        '
        'pbCell
        '
        Me.pbCell.Location = New System.Drawing.Point(5, 6)
        Me.pbCell.Name = "pbCell"
        Me.pbCell.Size = New System.Drawing.Size(28, 28)
        Me.pbCell.TabIndex = 15
        Me.pbCell.TabStop = False
        '
        'btnParseNumbersViaGaussian
        '
        Me.btnParseNumbersViaGaussian.Location = New System.Drawing.Point(845, 73)
        Me.btnParseNumbersViaGaussian.Name = "btnParseNumbersViaGaussian"
        Me.btnParseNumbersViaGaussian.Size = New System.Drawing.Size(93, 42)
        Me.btnParseNumbersViaGaussian.TabIndex = 16
        Me.btnParseNumbersViaGaussian.Text = "Parse Numbers via Gaussian"
        Me.btnParseNumbersViaGaussian.UseVisualStyleBackColor = True
        '
        'btnSolve
        '
        Me.btnSolve.Location = New System.Drawing.Point(845, 127)
        Me.btnSolve.Name = "btnSolve"
        Me.btnSolve.Size = New System.Drawing.Size(93, 42)
        Me.btnSolve.TabIndex = 17
        Me.btnSolve.Text = "SOLVE"
        Me.btnSolve.UseVisualStyleBackColor = True
        '
        'btnReadUVARFiles
        '
        Me.btnReadUVARFiles.Location = New System.Drawing.Point(845, 18)
        Me.btnReadUVARFiles.Name = "btnReadUVARFiles"
        Me.btnReadUVARFiles.Size = New System.Drawing.Size(93, 44)
        Me.btnReadUVARFiles.TabIndex = 18
        Me.btnReadUVARFiles.Text = "READ u,var FILES"
        Me.btnReadUVARFiles.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.pbBigCell)
        Me.Panel2.Location = New System.Drawing.Point(236, 438)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(125, 125)
        Me.Panel2.TabIndex = 19
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.pbCell)
        Me.Panel3.Location = New System.Drawing.Point(383, 438)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(41, 41)
        Me.Panel3.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 479)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "CELL:"
        '
        'tbRow
        '
        Me.tbRow.Enabled = False
        Me.tbRow.Location = New System.Drawing.Point(62, 476)
        Me.tbRow.Name = "tbRow"
        Me.tbRow.Size = New System.Drawing.Size(42, 20)
        Me.tbRow.TabIndex = 22
        '
        'tbCol
        '
        Me.tbCol.Enabled = False
        Me.tbCol.Location = New System.Drawing.Point(156, 476)
        Me.tbCol.Name = "tbCol"
        Me.tbCol.Size = New System.Drawing.Size(42, 20)
        Me.tbCol.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(71, 499)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "row"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(166, 499)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "col"
        '
        'btnUvarParse
        '
        Me.btnUvarParse.Location = New System.Drawing.Point(376, 497)
        Me.btnUvarParse.Name = "btnUvarParse"
        Me.btnUvarParse.Size = New System.Drawing.Size(47, 36)
        Me.btnUvarParse.TabIndex = 26
        Me.btnUvarParse.Text = "uvar Parse"
        Me.btnUvarParse.UseVisualStyleBackColor = True
        '
        'tbCellValue
        '
        Me.tbCellValue.Enabled = False
        Me.tbCellValue.Location = New System.Drawing.Point(406, 543)
        Me.tbCellValue.Name = "tbCellValue"
        Me.tbCellValue.Size = New System.Drawing.Size(42, 20)
        Me.tbCellValue.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(875, 222)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "PixelThreshold (0-255):"
        '
        'tbPixelThreshold
        '
        Me.tbPixelThreshold.Location = New System.Drawing.Point(996, 219)
        Me.tbPixelThreshold.Name = "tbPixelThreshold"
        Me.tbPixelThreshold.Size = New System.Drawing.Size(42, 20)
        Me.tbPixelThreshold.TabIndex = 29
        Me.tbPixelThreshold.Text = "75"
        '
        'tbFindNumberThreshold
        '
        Me.tbFindNumberThreshold.Location = New System.Drawing.Point(955, 176)
        Me.tbFindNumberThreshold.Name = "tbFindNumberThreshold"
        Me.tbFindNumberThreshold.Size = New System.Drawing.Size(26, 20)
        Me.tbFindNumberThreshold.TabIndex = 30
        Me.tbFindNumberThreshold.Text = "3"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(894, 179)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "More than"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(894, 199)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 13)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "% of pixels exceed threshold"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 520)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "PIXEL:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(166, 538)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(21, 13)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "col"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(71, 538)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "row"
        '
        'tbPixelCol
        '
        Me.tbPixelCol.Enabled = False
        Me.tbPixelCol.Location = New System.Drawing.Point(156, 515)
        Me.tbPixelCol.Name = "tbPixelCol"
        Me.tbPixelCol.Size = New System.Drawing.Size(42, 20)
        Me.tbPixelCol.TabIndex = 35
        '
        'tbPixelRow
        '
        Me.tbPixelRow.Enabled = False
        Me.tbPixelRow.Location = New System.Drawing.Point(62, 515)
        Me.tbPixelRow.Name = "tbPixelRow"
        Me.tbPixelRow.Size = New System.Drawing.Size(42, 20)
        Me.tbPixelRow.TabIndex = 34
        '
        'tbPixelIntensity
        '
        Me.tbPixelIntensity.Enabled = False
        Me.tbPixelIntensity.Location = New System.Drawing.Point(145, 559)
        Me.tbPixelIntensity.Name = "tbPixelIntensity"
        Me.tbPixelIntensity.Size = New System.Drawing.Size(42, 20)
        Me.tbPixelIntensity.TabIndex = 38
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(23, 562)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 13)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Pixel intensity (0-255):"
        '
        'btnReadProbFiles
        '
        Me.btnReadProbFiles.Location = New System.Drawing.Point(962, 18)
        Me.btnReadProbFiles.Name = "btnReadProbFiles"
        Me.btnReadProbFiles.Size = New System.Drawing.Size(93, 44)
        Me.btnReadProbFiles.TabIndex = 40
        Me.btnReadProbFiles.Text = "READ Prob FILES"
        Me.btnReadProbFiles.UseVisualStyleBackColor = True
        '
        'btnParseNumbersViaProb
        '
        Me.btnParseNumbersViaProb.Location = New System.Drawing.Point(962, 73)
        Me.btnParseNumbersViaProb.Name = "btnParseNumbersViaProb"
        Me.btnParseNumbersViaProb.Size = New System.Drawing.Size(93, 42)
        Me.btnParseNumbersViaProb.TabIndex = 41
        Me.btnParseNumbersViaProb.Text = "Parse Numbers via Prob"
        Me.btnParseNumbersViaProb.UseVisualStyleBackColor = True
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(962, 127)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(93, 42)
        Me.btnTest.TabIndex = 42
        Me.btnTest.Text = "TEST"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'rtbLog
        '
        Me.rtbLog.Location = New System.Drawing.Point(554, 256)
        Me.rtbLog.Name = "rtbLog"
        Me.rtbLog.Size = New System.Drawing.Size(501, 323)
        Me.rtbLog.TabIndex = 44
        Me.rtbLog.Text = ""
        '
        'btnProbParse
        '
        Me.btnProbParse.Location = New System.Drawing.Point(429, 499)
        Me.btnProbParse.Name = "btnProbParse"
        Me.btnProbParse.Size = New System.Drawing.Size(47, 36)
        Me.btnProbParse.TabIndex = 45
        Me.btnProbParse.Text = "prob Parse"
        Me.btnProbParse.UseVisualStyleBackColor = True
        '
        'PuzzleSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1081, 594)
        Me.Controls.Add(Me.btnProbParse)
        Me.Controls.Add(Me.rtbLog)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.btnParseNumbersViaProb)
        Me.Controls.Add(Me.btnReadProbFiles)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.tbPixelIntensity)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tbPixelCol)
        Me.Controls.Add(Me.tbPixelRow)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbFindNumberThreshold)
        Me.Controls.Add(Me.tbPixelThreshold)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbCellValue)
        Me.Controls.Add(Me.btnUvarParse)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbCol)
        Me.Controls.Add(Me.tbRow)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnReadUVARFiles)
        Me.Controls.Add(Me.btnSolve)
        Me.Controls.Add(Me.btnParseNumbersViaGaussian)
        Me.Controls.Add(Me.btnScaleCellBitmaps)
        Me.Controls.Add(Me.btnGetCellBitmaps)
        Me.Controls.Add(Me.dgvPuzzle)
        Me.Controls.Add(Me.tbWidth)
        Me.Controls.Add(Me.tbHeight)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClearImage)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnGetNumbers)
        Me.Controls.Add(Me.btnShowCellDimensions)
        Me.Controls.Add(Me.btnDrawLines)
        Me.Controls.Add(Me.btnSelectImage)
        Me.Name = "PuzzleSelector"
        Me.Text = "PuzzleSelector"
        CType(Me.pbxPuzzle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvPuzzle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBigCell, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCell, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbxPuzzle As PictureBox
    Friend WithEvents btnSelectImage As Button
    Friend WithEvents btnDrawLines As Button
    Friend WithEvents btnShowCellDimensions As Button
    Friend WithEvents btnGetNumbers As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnClearImage As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbHeight As TextBox
    Friend WithEvents tbWidth As TextBox
    Friend WithEvents dgvPuzzle As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents btnGetCellBitmaps As Button
    Friend WithEvents btnScaleCellBitmaps As Button
    Friend WithEvents pbBigCell As PictureBox
    Friend WithEvents pbCell As PictureBox
    Friend WithEvents btnParseNumbersViaGaussian As Button
    Friend WithEvents btnSolve As Button
    Friend WithEvents btnReadUVARFiles As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents tbRow As TextBox
    Friend WithEvents tbCol As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnUvarParse As Button
    Friend WithEvents tbCellValue As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tbPixelThreshold As TextBox
    Friend WithEvents tbFindNumberThreshold As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents tbPixelCol As TextBox
    Friend WithEvents tbPixelRow As TextBox
    Friend WithEvents tbPixelIntensity As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnReadProbFiles As Button
    Friend WithEvents btnParseNumbersViaProb As Button
    Friend WithEvents btnTest As Button
    Friend WithEvents rtbLog As RichTextBox
    Friend WithEvents btnProbParse As Button
End Class
