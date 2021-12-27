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
using System.Data.OleDb;

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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            Form2 frm = new Form2();
            frm.Owner = this; //Передаём вновь созданной форме её владельца.
            frm.Show();
            Hide();


        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            string admin = "admin";
            string adminPass = "admin";

            var log = Convert.ToString(textBox1.Text);

            var pas = Convert.ToString(textBox2.Text);


            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database5.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);


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

            if (log == admin && pas == adminPass)
            {
                Form4 frm4 = new Form4();
                frm4.Owner = this;
                frm4.Show();
                Hide();

            }

            else if (result == null && result1 == null || result == null || result1 == null)
            {
                MessageBox.Show("Данные введены не верно!");

            }

            else
            {
                MessageBox.Show($"Добро пожаловать,{result}!");
                Form3 frm3 = new Form3();
                frm3.Owner = this;
                frm3.Show();
                Hide();
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
