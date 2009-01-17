namespace CcdAddIn {
    partial class CcdGradeControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gradeBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // gradeBrowser
            // 
            this.gradeBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradeBrowser.Location = new System.Drawing.Point(0, 0);
            this.gradeBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.gradeBrowser.Name = "gradeBrowser";
            this.gradeBrowser.ScrollBarsEnabled = false;
            this.gradeBrowser.Size = new System.Drawing.Size(305, 316);
            this.gradeBrowser.TabIndex = 5;
            this.gradeBrowser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // CcdGradeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.gradeBrowser);
            this.Name = "CcdGradeControl";
            this.Size = new System.Drawing.Size(305, 316);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser gradeBrowser;


    }
}
