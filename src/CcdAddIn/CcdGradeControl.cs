using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;
using Microsoft.Win32;

namespace CcdAddIn {
    public partial class CcdGradeControl : UserControl {
        public CcdGradeControl() {
            InitializeComponent();

            string[] ccdGrades;
            string defaultGrade = string.Empty;
            string currentGrade = string.Empty;
            string xmlInputPath = string.Empty;
            string xsltInputPath = string.Empty;

            Dictionary<string, string[]> gradeMappings = new Dictionary<string, string[]>();
            Dictionary<string, string[]> gradeDefinitions = new Dictionary<string, string[]>();


            const string VSADDINPATH = "{0}\\Visual Studio 2008\\Addins";
            const string XMLINPUTPATH = "{0}\\{1}";
            const string XSLTINPUTPATH = "{0}\\{1}";
            const string OUTPUTHTMLFILENAME = "{0}\\CcdWerteSystem.html";
            const string OUTPUTHTMLFILEURI = "file:///{0}";


            RegistryKey key =
                Registry.CurrentUser.OpenSubKey(
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders");

            string userDocumentsPath = key.GetValue("Personal").ToString();

            //string userDocumentsPath = Environment.GetEnvironmentVariable("userprofile");

            string localAddInPath = string.Format(VSADDINPATH, userDocumentsPath);
            string localOutputHtmlFilePath = string.Format(OUTPUTHTMLFILENAME, localAddInPath);

            string assemblyPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            string configPath = string.Format("{0}\\CcdConfig.xml", assemblyPath);

            XDocument configDocument = XDocument.Load(configPath);
            var config = from d in configDocument.Descendants("Konfiguration") select d;
            if (config.Count() == 1) {
                defaultGrade = config.First().Attribute("standardGrad").Value;
                currentGrade = config.First().Attribute("aktiverGrad").Value;
                xmlInputPath = config.First().Attribute("xmlInput").Value;
                xsltInputPath = config.First().Attribute("xsltInput").Value;
            }

            string localXmlInputPath = string.Format(XMLINPUTPATH, localAddInPath, xmlInputPath);
            string localXsltInputPath = string.Format(XSLTINPUTPATH, localAddInPath, xsltInputPath);

            var mappings = from d in config.Descendants("Grad") select d;
            foreach (XElement el in mappings) {
                gradeMappings.Add(el.Attribute("farbe").Value, new[] { el.Attribute("rgb").Value });
            }


            try {
                XsltArgumentList xslArg = new XsltArgumentList();
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(localXsltInputPath);
                XPathDocument xpathdocument = new XPathDocument(localXmlInputPath);
                XmlTextWriter writer = new XmlTextWriter(localOutputHtmlFilePath, Encoding.UTF8);

                XsltArgumentList xsltArgumentList = new XsltArgumentList();
                xsltArgumentList.AddParam("Grad", string.Empty, currentGrade);
                xsltArgumentList.AddParam("RGB", string.Empty, gradeMappings[currentGrade][0]);

                //xslt.Transform(xpathdocument, xslArg, writer);
                xslt.Transform(xpathdocument, xsltArgumentList, writer);

                writer.Close();

                string localHtmlPath = string.Format(OUTPUTHTMLFILEURI, localOutputHtmlFilePath);
                gradeBrowser.Url = new Uri(localHtmlPath);

            }
            catch (Exception e) {
                Console.WriteLine(e);
            }


        }
    }
}
