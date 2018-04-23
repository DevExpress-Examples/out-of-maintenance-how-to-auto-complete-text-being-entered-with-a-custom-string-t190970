Imports System
Imports DevExpress.Data.Mask
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Mask

Namespace AutoCompleteMaskManager
	<System.ComponentModel.DesignerCategory("")>
	Public Class MyTextEditWithCustomAutocomplete
		Inherits TextEdit

		Protected Overrides Function CreateMaskManager(ByVal mask As MaskProperties) As MaskManager
			Dim maskManager As MaskManager
			If mask.MaskType = MaskType.Custom Then
				maskManager = New MyAutoCompleteMaskManager(New CustomMaskManagerCommon(New MaskManagerPlainTextState(String.Empty, 0, 0)))
			Else
				maskManager = MyBase.CreateMaskManager(mask)
			End If
			Return maskManager
		End Function
	End Class
End Namespace
