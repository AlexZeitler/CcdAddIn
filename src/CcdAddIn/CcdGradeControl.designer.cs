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
            this.gradeGroupBox = new System.Windows.Forms.GroupBox();
            this.gradeBrowser = new System.Windows.Forms.WebBrowser();
            this.gradeColorPanel = new System.Windows.Forms.Panel();
            this.gradeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradeGroupBox
            // 
            this.gradeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gradeGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.gradeGroupBox.Controls.Add(this.gradeBrowser);
            this.gradeGroupBox.Controls.Add(this.gradeColorPanel);
            this.gradeGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradeGroupBox.Location = new System.Drawing.Point(3, 3);
            this.gradeGroupBox.Name = "gradeGroupBox";
            this.gradeGroupBox.Size = new System.Drawing.Size(235, 484);
            this.gradeGroupBox.TabIndex = 0;
            this.gradeGroupBox.TabStop = false;
            this.gradeGroupBox.Text = "Roter Grad";
            // 
            // gradeBrowser
            // 
            this.gradeBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gradeBrowser.Location = new System.Drawing.Point(6, 74);
            this.gradeBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.gradeBrowser.Name = "gradeBrowser";
            this.gradeBrowser.ScrollBarsEnabled = false;
            this.gradeBrowser.Size = new System.Drawing.Size(222, 404);
            this.gradeBrowser.TabIndex = 5;
            this.gradeBrowser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // gradeColorPanel
            // 
            this.gradeColorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gradeColorPanel.BackColor = System.Drawing.Color.Black;
            this.gradeColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gradeColorPanel.Location = new System.Drawing.Point(6, 20);
            this.gradeColorPanel.Name = "gradeColorPanel";
            this.gradeColorPanel.Size = new System.Drawing.Size(223, 48);
            this.gradeColorPanel.TabIndex = 4;
            // 
            // CcdGradeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.gradeGroupBox);
            this.Name = "CcdGradeControl";
            this.Size = new System.Drawing.Size(241, 490);
            this.gradeGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gradeGroupBox;
        private System.Windows.Forms.Panel gradeColorPanel;
        private System.Windows.Forms.WebBrowser gradeBrowser;

    }
}
