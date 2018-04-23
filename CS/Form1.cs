using System;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraEditors;

namespace AutoCompleteMaskManager {
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : XtraForm {
        private AutoCompleteMaskManager.MyTextEditWithCustomAutocomplete textEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1() {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing ) {
            if ( disposing ) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.textEdit1 = new AutoCompleteMaskManager.MyTextEditWithCustomAutocomplete();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();



            this.textEdit1.Location = new System.Drawing.Point(16, 16);
            this.textEdit1.Name = "textEdit1";



            this.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Custom;
            this.textEdit1.Size = new System.Drawing.Size(280, 20);
            this.textEdit1.TabIndex = 0;



            this.simpleButton1.Location = new System.Drawing.Point(200, 56);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(96, 24);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Button";



            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(312, 94);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.textEdit1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            SkinManager.EnableFormSkins();
            Application.Run(new Form1());
        }
    }
}
