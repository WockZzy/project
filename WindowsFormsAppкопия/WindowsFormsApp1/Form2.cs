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
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {



        public Form2()
        {
            InitializeComponent();
            
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


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void guna2CustomRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            string login = Convert.ToString(textBox1.Text);
            string password = Convert.ToString(textBox2.Text);
            string mail = Convert.ToString(textBox3.Text);
            int id = Convert.ToInt32(textBox4.Text);


            Regex reg = new Regex(@"\b[^_+.+][-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}\b", RegexOptions.IgnoreCase);
            MatchCollection mc = reg.Matches(mail);

            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database5.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение


            OleDbCommand MyOleDbComm2 = new OleDbCommand();
            dbConnection.Open();

            MyOleDbComm2.CommandText = "Select логин from LogPas " +
                                       " Where LogPas.логин='" + textBox1.Text + "'";
            MyOleDbComm2.Connection = dbConnection;

            var result = MyOleDbComm2.ExecuteScalar();

            dbConnection.Close();

            OleDbCommand MyOleDbComm1 = new OleDbCommand();
            dbConnection.Open();

            MyOleDbComm1.CommandText = "Select пароль from LogPas " +
                                       " Where LogPas.пароль='" + textBox2.Text + "'";
            MyOleDbComm1.Connection = dbConnection;

            var result1 = MyOleDbComm1.ExecuteScalar();

            dbConnection.Close();


            if (mc.Count > 0 && result == null && result1 == null && login != "admin" && password != "admin")
            {

                dbConnection.Open();//открываем соеденение
                string query = "INSERT INTO LogPas VALUES (" + id + ", '" + login + "', '" + password + "', '" + mail + "')";//строка запроса
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);//команда

                //Выполняем запрос
                if (dbCommand.ExecuteNonQuery() != 1)
                    MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
                else
                    MessageBox.Show("Данные добавлены!", "Внимание!");

                //Закрываем соеденение с БД
                dbConnection.Close();

            }

            else
            {
                MessageBox.Show("Данные введен не верно или такой пользователь уже существует!");

            }


        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Owner = this;
            frm1.Show();
            Hide();
        }
    }
}
