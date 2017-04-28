Imports Gridset

Public Class Cell

    Dim mValue As Integer
    Dim mRow As Gridset
    Dim mCol As Gridset
    Dim mSquare As Gridset

    Dim mNValue As Integer
    Dim mPossibleValues = New Integer() {}
    Dim mNext As Integer     ' Iterator: zero-based index of next possible value to return

    Dim mUniqueID As Integer

    Public Sub New(_NValue As Integer)
        Me.New(0, _NValue)
    End Sub

    Public Sub New(_Value As Integer, _NValue As Integer)

        Static uniqueID As Integer = 0

        mRow = Nothing
        mCol = Nothing
        mSquare = Nothing
        mValue = _Value
        mNValue = _NValue
        mNext = 0

        mUniqueID = uniqueID
        uniqueID = uniqueID + 1
    End Sub

    Public Sub Copy(ByRef _Cell As Cell)
        mValue = _Cell.mValue
        mNValue = _Cell.mNValue
        mUniqueID = _Cell.mUniqueID
    End Sub

    Public Function GetValue() As Integer
        GetValue = mValue
    End Function

    Public Sub SetValue(_Value As Integer)
        If (_Value >= 0 And _Value <= mNValue) Then
            mValue = _Value

            ' if the value is non-zero (representing an actual value), clear all
            ' possible values
            If (mValue > 0) Then
                Array.Clear(mPossibleValues, 0, mPossibleValues.Length)
            End If
        End If
    End Sub

    Public Sub SetRow(ByRef _Row As Gridset)
        mRow = _Row
    End Sub

    Public Sub SetCol(ByRef _Col As Gridset)
        mCol = _Col
    End Sub

    Public Sub SetSquare(ByRef _Square As Gridset)
        mSquare = _Square
    End Sub

    Public Sub SetAllPossibleValues()

        ' Only set the possible values if this cell's current value has not
        ' been defined. If the current value has been defined, it is presumed
        ' that there is no need to determine possible values.
        If (mValue = 0) Then

            ' First, clear all possible values for this cell
            Array.Clear(mPossibleValues, 0, mPossibleValues.Length)

            ' For each possible value: if the value is not already present in
            ' any of the cells in the row, column, or square to which this 
            ' cell belongs, then the value is a possible value that can be
            ' assigned to this cell
            For PossibleValue As Integer = 1 To mNValue
                If IsNothing(mRow) = False And
                        mRow.IsValuePresent(PossibleValue) = False And
                        IsNothing(mCol) = False And
                        mCol.IsValuePresent(PossibleValue) = False And
                        IsNothing(mSquare) = False And
                        mSquare.IsValuePresent(PossibleValue) = False Then
                    Array.Resize(mPossibleValues, mPossibleValues.Length + 1)
                    mPossibleValues(mPossibleValues.Length - 1) = PossibleValue
                End If
            Next
        End If

    End Sub

    Public Function GetFirstPossibleValue() As Integer

        ' If this cell's value is defined, or if there are no possible values,
        ' return zero
        If mValue <> 0 Or mPossibleValues.Length() = 0 Then
            Return 0
        End If

        ' Otherwise, return the first element of the possible values set, and
        ' initialize the possible value iterator
        GetFirstPossibleValue = mPossibleValues(mNext)
        mNext = mNext + 1
    End Function

    Public Function GetNextPossibleValue() As Integer

        ' If thie cells's value is defined, or if there are no possible values,
        ' or if the iterator is NULL, or if we have exceeded all possible values,
        ' return 0
        If mValue! = 0 Or mPossibleValues.Length() = 0 Or mNext < 0 Or mNext = mPossibleValues.Length() Then
            Return 0
        End If

        GetNextPossibleValue = mPossibleValues(mNext)
        mNext = mNext + 1
    End Function

    Public Function IsValuePossible(_PossibleValue As Integer) As Boolean

        ' Return whether the value is in the list of possible values for
        ' this cell
        If Array.IndexOf(mPossibleValues, _PossibleValue) < 0 Then
            IsValuePossible = False
        Else
            IsValuePossible = True
        End If

    End Function

    Public Function FindUniquePossibleValueFromGridset(ByRef _GridSet As Gridset) As Integer

        ' If the Indicated GridSet is not defined, or if this cell already has
        ' a defined value, return 0
        If _GridSet Is Nothing Or mValue <> 0 Then
            Return 0
        End If

        ' Iterate through the list of possible values for this cell
        Dim val As Integer
        For Each val In mPossibleValues

            ' if this possible value is not present in the other cells of the 
            ' specified GridSet, then it is unique
            If (_GridSet.IsPossibleValuePresent(Me, val)) Then
                Return (val)
            End If
        Next

        Return (0)
    End Function


    Public Shared Operator <>(_Cell1 As Cell, _Cell2 As Cell)
        If _Cell1.mUniqueID <> _Cell2.mUniqueID Then
            Return True
        End If
        Return False
    End Operator

    Public Shared Operator =(_Cell1 As Cell, _Cell2 As Cell)
        If _Cell1.mUniqueID = _Cell2.mUniqueID Then
            Return True
        End If
        Return False
    End Operator
End Class
