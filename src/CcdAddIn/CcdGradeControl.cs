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


            const string VSADDINPATH = "{0}\\Documents\\Visual Studio 2008\\Addins";
            const string XMLINPUTPATH = "{0}\\{1}";
            const string XSLTINPUTPATH = "{0}\\{1}";
            const string OUTPUTHTMLFILENAME = "{0}\\CcdWerteSystem.html";
            const string OUTPUTHTMLFILEURI = "file:///{0}";

            string userprofilepath = Environment.GetEnvironmentVariable("userprofile");

            string localAddInPath = string.Format(VSADDINPATH, userprofilepath);
            string localOutputHtmlFilePath = string.Format(OUTPUTHTMLFILENAME, localAddInPath);

            string assemblyPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            string configPath = string.Format("{0}\\CcdConfig.xml", assemblyPath);

            XDocument configDocument = XDocument.Load(configPath);
            var config = from d in configDocument.Descendants("Konfiguration") select d;
            if(config.Count() == 1) {
                defaultGrade = config.First().Attribute("standardGrad").Value;
                currentGrade = config.First().Attribute("aktiverGrad").Value;
                xmlInputPath = config.First().Attribute("xmlInput").Value;
                xsltInputPath = config.First().Attribute("xsltInput").Value;
            }

            string localXmlInputPath = string.Format(XMLINPUTPATH, localAddInPath, xmlInputPath);
            string localXsltInputPath = string.Format(XSLTINPUTPATH, localAddInPath, xsltInputPath);

            var mappings = from d in config.Descendants("Grad") select d;
            foreach (XElement el in mappings) {
                gradeMappings.Add(el.Attribute("farbe").Value, new[] { el.Attribute("rgb").Value});
            }


            try {
                XsltArgumentList xslArg = new XsltArgumentList();
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(localXsltInputPath);
                XPathDocument xpathdocument = new XPathDocument(localXmlInputPath);
                XmlTextWriter writer = new XmlTextWriter(localOutputHtmlFilePath, null);
                //xslt.Transform(xpathdocument, xslArg, writer);
                xslt.Transform(xpathdocument, writer);

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
