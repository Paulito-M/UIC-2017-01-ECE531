Imports Cell

Public Class Gridset

    Dim mCells = New Cell() {}

    Public Sub New()

    End Sub

    Public Sub AddCell(ByRef _Cell As Cell)
        Array.Resize(mCells, mCells.Length + 1)
        mCells(mCells.Length - 1) = _Cell
    End Sub

    Public Function IsValuePresent(_Value As Integer) As Boolean

        Dim cell As Cell
        For Each cell In mCells
            If cell.GetValue() = _Value Then
                Return True
            End If
        Next

        Return False

    End Function

    Public Function IsPossibleValuePresent(ByRef _Cell As Cell, _Value As Integer) As Boolean

        ' Walk through each Cell in the GridSet...
        Dim cell As Cell
        For Each cell In mCells
            If cell <> _Cell And cell.IsValuePossible(_Value) = True Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Function FindUniquePossibleValue(ByRef _Cell As Cell, ByRef _Value As Integer) As Boolean

        ' Walk through each Cell in the GridSet...
        Dim cell As Cell
        For Each cell In mCells

            ' ...for each cell, determine if it contains a possible value that
            ' is unique within the GridSet...
            Dim uniqueValue As Integer = cell.FindUniquePossibleValueFromGridset(Me)

            If uniqueValue <> 0 Then

                ' FOUND!
                '
                ' Return the cell, and the value
                _Cell = cell
                _Value = uniqueValue

                Return True
            End If
        Next

        Return False

    End Function

    Public Function IsSolved() As Boolean

        Dim result As Boolean = True

        ' The GridSet is solved if all of the cells in the grid are populated
        ' with the positive integers from 1 to N, where N is the number of
        ' cells in the GridSet
        '
        ' We 'simply' (LOL) search for the presence of each integer, terminating if
        ' the first integer is not found.

        For searchValue As Integer = 1 To mCells.Length

            Dim cellResult As Boolean = False

            Dim cell As Cell
            For Each cell In mCells
                If cell.GetValue() = searchValue Then
                    cellResult = True
                    Exit For
                End If
            Next

            If cellResult = False Then
                result = False
            End If

            If result = False Then
                Exit For
            End If
        Next

        Return result
    End Function

End Class

