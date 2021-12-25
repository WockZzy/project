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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }




        Form2 form2 = new Form2();
        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string admin = "admin";
                string adminPass = "admin";

                string login = "";
                string password = "";

                int check = 0;

                string log = Convert.ToString(textBox1.Text);

                string pas = Convert.ToString(textBox2.Text);


                string[] lines = File.ReadAllLines("login.txt");

                string[] lines1 = File.ReadAllLines("password.txt");

                for (int i = 0; i < lines.Length; i++)
                {
                    if (log == lines[i] && pas == lines1[i])
                    {

                        Form3 frm3 = new Form3();
                        frm3.Owner = this;
                        frm3.Show();
                        Hide();
                    }

                    else if (log == admin && pas == adminPass)
                    {
                        Form4 frm4 = new Form4();
                        frm4.Owner = this;
                        frm4.Show();
                        Hide();
                    }
                }

                if (log == "")
                {
                    MessageBox.Show("Поле логина не должно быть пустым!");
                    check = 0;
                }

                else if (pas == "")
                {
                    MessageBox.Show("Поле пароля не должно быть пустым!");
                    check = 0;
                }


                else if (check == lines.Length)
                {
                    if (log == admin && adminPass == pas)
                    {

                    }

                    else
                    {
                        MessageBox.Show("Данные указаны не верно!");
                        check = 0;
                    }

                }
            }

            catch
            {

            }







        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form2 frm = new Form2();
            frm.Owner = this; //Передаём вновь созданной форме её владельца.
            frm.Show();
            Hide();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
