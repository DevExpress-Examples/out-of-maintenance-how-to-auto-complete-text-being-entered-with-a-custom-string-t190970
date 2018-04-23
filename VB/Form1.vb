Imports System
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports DevExpress.XtraEditors

Namespace AutoCompleteMaskManager
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits XtraForm

		Private textEdit1 As AutoCompleteMaskManager.MyTextEditWithCustomAutocomplete
		Private simpleButton1 As DevExpress.XtraEditors.SimpleButton
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.textEdit1 = New AutoCompleteMaskManager.MyTextEditWithCustomAutocomplete()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			DirectCast(Me.textEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()



			Me.textEdit1.Location = New System.Drawing.Point(16, 16)
			Me.textEdit1.Name = "textEdit1"



			Me.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Custom
			Me.textEdit1.Size = New System.Drawing.Size(280, 20)
			Me.textEdit1.TabIndex = 0



			Me.simpleButton1.Location = New System.Drawing.Point(200, 56)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(96, 24)
			Me.simpleButton1.TabIndex = 1
			Me.simpleButton1.Text = "Button"



			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(312, 94)
			Me.Controls.Add(Me.simpleButton1)
			Me.Controls.Add(Me.textEdit1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			DirectCast(Me.textEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
		End Sub

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Public Shared Sub Main()
			SkinManager.EnableFormSkins()
			Application.Run(New Form1())
		End Sub
	End Class
End Namespace
