Imports System
Imports DevExpress.Data.Mask

Namespace AutoCompleteMaskManager
	Public Class MyAutoCompleteMaskManager
		Inherits MaskManagerSelectAllEnhancer(Of MaskManagerCommon(Of MaskManagerPlainTextState))

		Public Sub New(ByVal nested As MaskManagerCommon(Of MaskManagerPlainTextState))
			MyBase.New(nested)
		End Sub
	End Class
End Namespace
