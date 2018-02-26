using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml;
using System.IO;


namespace Aplikacja_XML
{
    public partial class Formatka_glowna : Form
    {
        public Formatka_glowna()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Formatka_dodatkowa form_dod = new Formatka_dodatkowa();
            form_dod.ShowDialog();

            ListViewItem lst = new ListViewItem(decvar.added);
            listView1.Items.Add(lst);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            createXML();
        }

        XmlDocument xmldoc = new XmlDocument();
        XmlElement ElmntRoot;

        private void createXML()
        {
            xmldoc.RemoveAll();
            xmldoc.AppendChild(xmldoc.CreateProcessingInstruction("xml", "version='1.0'"));

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = Application.StartupPath + "\\Przyklad_XML.xml";

            ElmntRoot = xmldoc.CreateElement("Przyklad");

            foreach (ListViewItem item in listView1.Items)
            {
                XmlElement element1 = null;
                element1 = xmldoc.CreateElement("Dodaj pozycję");

                XmlElement child1 = null;
                child1 = xmldoc.CreateElement("Imię");
                child1.InnerText = item.SubItems[0].Text;
                element1.AppendChild(child1);
            }

            xmldoc.AppendChild(ElmntRoot);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            decvar.addbooks.Clear();
            ReadXML();
        }

        private enum XMLState
        {
            Empty,
            Book,
            Details
        }

        string elname;
        string[] addBook = new string[6];


        private void ReadXML()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Filter = "XML Files(.xml)|*.xml";

            if (DialogResult.OK == ofd.ShowDialog(this))
            {
                
                XmlTextReader xtr = new XmlTextReader(ofd.FileName);
                XMLState state = new XMLState();
                state = XMLState.Empty;

                while (xtr.Read())
                {
                    switch (xtr.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (xtr.Name == "Book")
                            {
                                state = XMLState.Book;
                            }

                              
                            if (xtr.Name == "Imię")
                            {
                                switch (state)
                                {
                                    case XMLState.Book:
                                        addBook[0] = xtr.ReadString();
                                        if (xtr.ReadString() == null)
                                        {
                                            addBook[0] = "";
                                        }
                                        break;
                                }
                                
                            }
                    }
                }

            }

        }

        //Transforming XML to HTML using XSLTransform
        /*
        private void button4_Click(object sender, EventArgs e)
        {
            string xmlfile = Application.StartupPath + "\\Przyklad_XML.xml";
            //Sending data from cs to XSL
            string logo = Application.StartupPath + "//" + "1rightarrow-32.png";

            XsltArgumentList xslArgs = new XsltArgumentList();
            xslArgs.AddParam("logo", "", logo);

            XslTransform xslt = new XslTransform();
            xslt.Load("sample-stylesheet.xsl");
            XPathDocument xpath = new XPathDocument(xmlfile);
            XmlTextWriter xwriter = new XmlTextWriter(xmlfile + ".html", Encoding.UTF8);
            xslt.Transform(xpath, xslArgs, xwriter, null);
            xwriter.Close();

            MessageBox.Show("HTML file created.", "Przyklad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start(xmlfile + ".html")

        }
        */
        
    }
}
