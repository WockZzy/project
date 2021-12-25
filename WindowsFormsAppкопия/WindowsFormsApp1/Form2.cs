using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {



        public Form2()
        {
            InitializeComponent();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {

            string mail = Convert.ToString(textBox3.Text);

            string login = Convert.ToString(textBox1.Text);

            string password = Convert.ToString(textBox2.Text);

            int check = 0;
            

            string[] lines = File.ReadAllLines("login.txt");


            Regex reg = new Regex(@"\b[^_+.+][-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}\b", RegexOptions.IgnoreCase);
            MatchCollection mc = reg.Matches(mail);

            for (int i = 0; i < lines.Length; i++)
            {
                if (login == lines[i])
                {
                    MessageBox.Show("Такой пользователь уже зарегестрирован!");

                    login = null;
                    password = null;
                    textBox1.Text = null;
                    textBox2.Text = null;

                    Form2 frm2 = new Form2();
                    frm2.Owner = this;
                    frm2.Show();
                    Hide();
                }

            }

            if (mc.Count > 0 && login != "" && password != "" && login != null && password != null)
            {
                for(int i = 0; i < lines.Length; i++)
                {
                    if (login != lines[i])
                    {
                        check = 1;
                    }
                }
                
                if(check == 1)
                {
                    MessageBox.Show("Регистрация прошла успешно!");

                    File.AppendAllText("password.txt", password + Environment.NewLine);


                    File.AppendAllText("login.txt", login + Environment.NewLine);

                    Form2 frm2 = new Form2();
                    frm2.Owner = this;
                    frm2.Show();
                    Hide();
                }


            }


            else if(mc.Count == 0)
            {
                MessageBox.Show("Почта указана не верно либо поле пустое!");
            }


            else if(login == "")
            {
                MessageBox.Show("Поле логина не должно быть пустым!");
            }

            else if(password == "")
            {
                MessageBox.Show("Поле пароля не должно быть пустым!");
            }

            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Owner = this;
            frm1.Show();
            Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
