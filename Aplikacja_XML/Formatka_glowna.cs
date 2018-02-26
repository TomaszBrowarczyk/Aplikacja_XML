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
            decvar.addeducation.Clear();
            ReadXML();
        }

        private void ReadXML()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Filter = "XML Files(.xml)|*.xml";
        }
    }
}
