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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataDataSet.order' table. You can move, or remove it, as needed.
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            // disabling textBoxes so they won't be edited without choosing a type. 
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            // disabling checkBoxes so the user can choose between which type to choose. 
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Deleting the order and Reseting to the begining.
            richTextBox1.Clear();

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;


            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;

            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";

            label5.Text = " ";
            label13.Text = " ";

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Enabled == true)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox1.Text = "0";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Enabled == true)
            {
                textBox2.Enabled = true;
                
            }
            else
            {
                textBox2.Enabled = false;
                textBox2.Text = "0";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Enabled == true)
            {
                textBox3.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
                textBox3.Text = "0";
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Enabled == true)
            {
                textBox4.Enabled = true;
            }
            else
            {
                textBox4.Enabled = false;
                textBox4.Text = "0";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.Text = "";
            //textBox1.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //textBox2.Text = "";
            //textBox2.Focus();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //textBox3.Text = "";
            //textBox3.Focus();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //textBox4.Text = "";
            //textBox4.Focus();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // Printing the order details to the screen.
            richTextBox1.Clear();

            richTextBox1.AppendText("Your Order Details: " + Environment.NewLine);
            richTextBox1.AppendText("--------------------------------------------------" + Environment.NewLine);

            /////Calling the Add Function.
            addToOrder(checkBox1, textBox1);
            addToOrder(checkBox2, textBox2);
            addToOrder(checkBox3, textBox3);
            addToOrder(checkBox4, textBox4);

        }

        private void calculateTotal()
        {
            // Calculating the total price for the order.
            double t1 = 0, t2 = 0, t3 = 0, t4 = 0, tt = 0, sub_total = 0;
            if (checkBox1.Checked)
            {
                t1 = double.Parse(textBox1.Text) * 30.00;
            }
            if (checkBox2.Checked)
            {
                t2 = double.Parse(textBox2.Text) * 35.00;
            }
            if (checkBox3.Checked)
            {
                t3 = double.Parse(textBox3.Text) * 40.00;
            }
            if (checkBox4.Checked)
            {
                t4 = double.Parse(textBox4.Text) * 45.00;
            }
            ////////////////////////////////////////////////////////////////////////////////////////////
            tt = t1 + t2 + t3 + t4;
            sub_total = t1 + t2 + t3 + t4 + 10;

            label5.Text = tt.ToString();
            label13.Text = sub_total.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Reseting the old Values to start over.
            richTextBox1.Clear();

            label5.Text = " ";
            label13.Text = " ";

            richTextBox1.AppendText("Your Order Details: " + Environment.NewLine);
            richTextBox1.AppendText("--------------------------------------------------" + Environment.NewLine);

            /////Calling the Modify Function.
            modifyOrder(checkBox1, textBox1);
            modifyOrder(checkBox2, textBox2);
            modifyOrder(checkBox3, textBox3);
            modifyOrder(checkBox4, textBox4);
            ////////////////////////////////////////////////////////////////////////////////////////////
        }
        private void addToOrder(CheckBox C, TextBox B)

        {

            //A function to add the checked order to the screen and calculates the total automaticaly.
            if (C.Checked && B.Text != "0")
            {
                richTextBox1.AppendText(B.Text + " * " + C.Text + Environment.NewLine);
                calculateTotal();
            }
            else if (C.Checked && B.Text == "0")
            {
                MessageBox.Show("Please Enter The Correct Quantity.");
            }
            else if (C.Checked == false && B.Text != "0")
            {
                MessageBox.Show("Please RE-Check The Required Type.");
            }
        }
        private void modifyOrder(CheckBox C , TextBox B)
        
        {

            //A function to clear previous orders, adds modified ones and calculates the total automaticaly.
            if (C.Checked && B.Text != "0")
            {
                richTextBox1.AppendText(B.Text + " * " + C.Text + Environment.NewLine);
                calculateTotal();
            }
            else if (C.Checked && B.Text == "0")
            {
                MessageBox.Show("Please Enter The Correct Quantity.");
            }
            else
            {
                B.Enabled = false;
                B.Text = "0";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //If the user clicks on confirm without selecting anything.
            if (richTextBox1.Text.Length == 0)
            {
                MessageBox.Show("Please RE-Check your Order.");
            }
            else if (richTextBox1.Text.Count()<75)
            {
                MessageBox.Show("Please RE-Check your Order.");
            }
            else
            {
                //Typing order's date and details to the user and saving them in a text file.
                DateTime now = DateTime.Now;
                string str1 = "Order Date: " + now.ToString() + Environment.NewLine + Environment.NewLine + Environment.NewLine;

                //Making sure the user is finished with all thier edits.
                string message = "Do you need to make any edits to your order? ";
                string title = "Confirm";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    result = DialogResult.Cancel;
                }
                else if (result == DialogResult.No)
                {
                    //If it's the first order, The Order is saved in a newely created text file and confirmed.
                    var path = @"C:\Users\Public\Orders.txt";
                    if (!File.Exists(path))
                    {
                        Form3 done = new Form3(path);
                        File.WriteAllText(path, richTextBox1.Text);
                        File.AppendAllText(path, str1);
                        
                        done.Show();
                        this.Hide();
                    }
                    else
                    {
                        //else, The Order is saved in a the existing text file and confirmed.
                        Form3 done = new Form3(path);
                        File.AppendAllText(path, richTextBox1.Text);
                        File.AppendAllText(path, str1);

                        done.Show();
                        this.Hide();
                    }

                }

            }
        }
    }
}
