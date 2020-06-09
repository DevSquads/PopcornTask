using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace popCorn_task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Hiding the password characters.
            textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Getting the User Details from a precreated SQL database.
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ayash\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter da = new SqlDataAdapter("select count (*) from LOGIN where user_name ='" + textBox1.Text + "' and password = '" + textBox2.Text + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Form2 newWindow = new Form2();
                newWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("wrong user name or password");
            }
        }
    }
}
