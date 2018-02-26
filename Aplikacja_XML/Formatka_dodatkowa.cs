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
    public partial class Formatka_dodatkowa : Form
    {
        public Formatka_dodatkowa()
        {
            InitializeComponent();
        }

    
      
        private void button1_Click(object sender, EventArgs e)
        {
            decvar.added[0] = textBox1.Text;
            decvar.added[1] = textBox2.Text;
            decvar.added[2] = textBox3.Text;
            decvar.added[3] = textBox4.Text;
            decvar.added[4] = textBox5.Text;
            decvar.added[5] = textBox6.Text;
            
            this.Close();
        }

    }
}
