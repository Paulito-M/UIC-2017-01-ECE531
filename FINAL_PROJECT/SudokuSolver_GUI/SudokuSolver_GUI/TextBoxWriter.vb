Imports System.Windows.Forms
Imports System.Text

Public Class TextBoxWriter
    Inherits System.IO.TextWriter

    Private mControl As TextBoxBase
    Private mStrBuilder As StringBuilder

    Public Overrides ReadOnly Property Encoding As Encoding
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Sub New(ByVal _control As RichTextBox)
        mControl = _control
        AddHandler mControl.HandleCreated, New EventHandler(AddressOf OnHandleCreated)
    End Sub

    Public Overrides Sub Write(ByVal _ch As Char)
        Write(_ch.ToString())
    End Sub

    Public Overrides Sub Write(ByVal _s As String)
        If (mControl.IsHandleCreated) Then
            AppendText(_s)
        Else
            BufferText(_s)
        End If
    End Sub

    Public Overrides Sub WriteLine(ByVal _s As String)
        Write(_s + Environment.NewLine)
    End Sub

    Private Sub BufferText(ByVal _s As String)
        If (mStrBuilder Is Nothing) Then
            mStrBuilder = New StringBuilder()
        End If

        mStrBuilder.Append(_s)

    End Sub

    Private Sub AppendText(ByVal _s As String)
        If (mStrBuilder Is Nothing = False) Then
            mControl.AppendText(mStrBuilder.ToString())
            mStrBuilder = Nothing
        End If
        mControl.AppendText(_s)
    End Sub

    Private Sub OnHandleCreated(ByVal _sender As Object, ByVal _e As EventArgs)
        If (mStrBuilder Is Nothing = False) Then
            mControl.AppendText(mStrBuilder.ToString())
            mStrBuilder = Nothing
        End If
    End Sub
End Class
