using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace CcdAddIn
{
    public partial class CcdGradeControl : UserControl
    {
        public CcdGradeControl()
        {
            try
            {
                #region Initialisierung
                InitializeComponent();

                string defaultGrade = string.Empty;
                string currentGrade = string.Empty;
                string xmlInputPath = string.Empty;
                string xsltInputPath = string.Empty;

                Dictionary<string, string[]> gradeMappings = new Dictionary<string, string[]>();
                Dictionary<string, string[]> gradeDefinitions = new Dictionary<string, string[]>();

                // den pfad merken, von dem das _aktuelle_ AddIn ( also "ICH" ) geldaen wurde
                string VSADDINPATH = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

                // eigentlich kommt _nur_ der XmlTextWriter mit Uri-Pfaden nicht klar
                // sei's drum, sieht auch "huebscher" aus im Debug-Log ;)
                VSADDINPATH = CcdAddInUtil.NormalizePath(VSADDINPATH);

                const string XMLINPUTPATH = "{0}\\{1}";
                const string XSLTINPUTPATH = "{0}\\{1}";
                const string OUTPUTHTMLFILENAME = "{0}\\CcdWerteSystem.html";
                const string OUTPUTHTMLFILEURI = "file:///{0}";
                string localOutputHtmlFilePath = string.Format(OUTPUTHTMLFILENAME, VSADDINPATH);
                #endregion

                #region konfigurationsdatei laden und werte auslesen
                string configPath = string.Format("{0}\\CcdConfig.xml", VSADDINPATH);
                CcdAddInDebug.WriteLine(string.Format("CcdAddIn :: Load '{0} ...'", configPath));
                XDocument configDocument = XDocument.Load(configPath);
                var config = from d in configDocument.Descendants("Konfiguration") select d;
                if (config.Count() == 1)
                {
                    defaultGrade = config.First().Attribute("standardGrad").Value;
                    currentGrade = config.First().Attribute("aktiverGrad").Value;
                    xmlInputPath = config.First().Attribute("xmlInput").Value;
                    xsltInputPath = config.First().Attribute("xsltInput").Value;
                }
                #endregion

                #region einlesen der datenbasis aus XmlInput datei
                string localXmlInputPath = string.Format(XMLINPUTPATH, VSADDINPATH, xmlInputPath);
                string localXsltInputPath = string.Format(XSLTINPUTPATH, VSADDINPATH, xsltInputPath);
                CcdAddInDebug.WriteLine(string.Format("CcdAddIn :: Load '{0} ...'", localXmlInputPath));
                XDocument xmlInput = XDocument.Load(localXmlInputPath);
                var grades = from g in xmlInput.Descendants("Grad")
                             where (string)g.Attribute("farbe").Value == currentGrade
                             select g;

                string rgb = string.Empty;
                if (grades.Count() == 1)
                {
                    rgb = grades.First().Attribute("RGB").Value;
                }
                #endregion

                #region XmlInput datei per XSLT-Transformation in ein HTML-Dokument umwandeln
                XsltArgumentList xslArg = new XsltArgumentList();
                XslCompiledTransform xslt = new XslCompiledTransform();

                CcdAddInDebug.WriteLine(string.Format("CcdAddIn :: Load '{0} ...'", localXsltInputPath));
                xslt.Load(localXsltInputPath);

                XPathDocument xpathdocument = new XPathDocument(localXmlInputPath);

                CcdAddInDebug.WriteLine(string.Format("CcdAddIn :: Create '{0} ...'", localOutputHtmlFilePath));

                XmlTextWriter writer = new XmlTextWriter(localOutputHtmlFilePath, Encoding.UTF8);
                XsltArgumentList xsltArgumentList = new XsltArgumentList();
                xsltArgumentList.AddParam("AktuellerGrad", string.Empty, currentGrade);
                xsltArgumentList.AddParam("RGB", string.Empty, rgb);
                xslt.Transform(xpathdocument, xsltArgumentList, writer);
                writer.Close();
                #endregion

                #region generiertes HTML-Dokument im Browser-Control anzeigen
                string localHtmlPath = string.Format(OUTPUTHTMLFILEURI, localOutputHtmlFilePath);
                CcdAddInDebug.WriteLine(string.Format("CcdAddIn :: Load '{0} ...'", localHtmlPath));
                gradeBrowser.Url = new Uri(localHtmlPath);
                #endregion

            }
            catch (Exception e)
            {
                CcdAddInDebug.WriteLine(e);
            }
        }

    } // class

} // namespace
