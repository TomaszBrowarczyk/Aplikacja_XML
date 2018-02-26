using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacja_XML
{
    public partial class Formatka_glowna : Form
    {
        public Formatka_glowna()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formatka_dodatkowa form_dod = new Formatka_dodatkowa();
            form_dod.ShowDialog();
        }
    }
}
