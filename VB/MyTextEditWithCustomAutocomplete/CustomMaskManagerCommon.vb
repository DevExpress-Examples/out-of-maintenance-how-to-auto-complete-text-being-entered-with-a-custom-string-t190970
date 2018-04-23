Imports System
Imports DevExpress.Data.Mask

Namespace AutoCompleteMaskManager
	Public Class CustomMaskManagerCommon
		Inherits MaskManagerCommon(Of MaskManagerPlainTextState)

		Public Sub New(ByVal initialState As MaskManagerPlainTextState)
			MyBase.New(initialState)
		End Sub


		Protected Overrides Function CreateStateForApply(ByVal editText As String, ByVal cursorPosition As Integer, ByVal selectionAnchor As Integer) As MaskManagerPlainTextState
			Return New MaskManagerPlainTextState(editText, cursorPosition, selectionAnchor)
		End Function

		Protected Overrides Function GetEmptyState() As MaskManagerPlainTextState
			Return MaskManagerPlainTextState.Empty
		End Function

		Protected Overrides Function GetCursorPosition(ByVal state As MaskManagerPlainTextState) As Integer
			Return state.CursorPosition
		End Function

		Protected Overrides Function GetDisplayText(ByVal state As MaskManagerPlainTextState) As String
			Dim editText As String = GetEditText(state)
			Return editText
		End Function

		Protected Overrides Function GetEditText(ByVal state As MaskManagerPlainTextState) As String
			Return state.EditText
		End Function

		Protected Overrides Function GetSelectionAnchor(ByVal state As MaskManagerPlainTextState) As Integer
			Return state.SelectionAnchor
		End Function

		Public Overrides Function Backspace() As Boolean
			If IsSelection Then
				Return Insert(String.Empty)
			End If
			Dim head As String = GetCurrentEditText().Substring(0, DisplayCursorPosition)
			Dim tail As String = GetCurrentEditText().Substring(DisplayCursorPosition)
			If head.Length < 1 Then
				Return False
			End If
			Return Apply(New MaskManagerPlainTextState(head.Substring(0, head.Length - 1) & tail, DisplayCursorPosition - 1, DisplayCursorPosition - 1), StateChangeType.Delete)
		End Function

		Public Overrides Function Delete() As Boolean
			If IsSelection Then
				Return Insert(String.Empty)
			End If
			Dim head As String = GetCurrentEditText().Substring(0, DisplayCursorPosition)
			Dim tail As String = GetCurrentEditText().Substring(DisplayCursorPosition)
			If tail.Length < 1 Then
				Return False
			End If
			Return Apply(New MaskManagerPlainTextState(head & tail.Substring(1), DisplayCursorPosition, DisplayCursorPosition), StateChangeType.Delete)
		End Function

		Public Overrides Function Insert(ByVal insertion As String) As Boolean
			Dim changeType As StateChangeType = If(insertion.Length = 0 AndAlso IsSelection, StateChangeType.Delete, StateChangeType.Insert)

			Dim head As String = GetCurrentEditText().Substring(0, DisplaySelectionStart)

			Dim tail As String = GetCurrentEditText().Substring(DisplaySelectionEnd)

			Dim newText As String = head & insertion & tail


			Const SampleAutocompleteText As String = "_SampleAutocompleteText"


            If changeType = StateChangeType.Insert AndAlso tail.Length = 0 AndAlso insertion.Length = 1 Then
                Dim autocompletedText As String = newText & SampleAutocompleteText

                Return Apply(New MaskManagerPlainTextState(autocompletedText, newText.Length, autocompletedText.Length), changeType)
            Else
                Dim cursorPosition As Integer = (head & insertion).Length
                Return Apply(New MaskManagerPlainTextState(newText, cursorPosition, cursorPosition), changeType)
            End If
		End Function

		Public Overrides Sub SelectAll()
			CursorEnd(False)
			CursorHome(True)
		End Sub
	End Class
End Namespace
