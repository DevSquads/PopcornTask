using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace popCorn_task
{
    public partial class Form3 : Form
    {
        string p = " ";
        public Form3(string s)
        {
            InitializeComponent();
            p = s;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var str = File.ReadAllText(p);
            richTextBox1.Text = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 back = new Form2();
            back.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
