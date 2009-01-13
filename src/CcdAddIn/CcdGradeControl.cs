using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CcdAddIn {
    public partial class CcdGradeControl : UserControl {
        public CcdGradeControl() {
            InitializeComponent();

            const string CCDXMLPATH = "file:///{0}/Desktop/test.htm";

            string userprofilepath = Environment.GetEnvironmentVariable("userprofile");
            string ccdGradePath = string.Format(CCDXMLPATH, userprofilepath);
            this.gradeBrowser.Url = new Uri(ccdGradePath);
        }
    }
}
