using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database5.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT * FROM people3";
            OleDbCommand bCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = bCommand.ExecuteReader();

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Ошибка");
            }
            else
            {
                while (dbReader.Read())
                {
                    dataGridView1.Rows.Add(dbReader["Код"], dbReader["подробнаяинформацияостдентах"], dbReader["ФИОстудента"]);
                }
            }


            dbReader.Close();
            dbConnection.Close();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Owner = this;
            frm3.Show();
            Hide();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)

        {
            Application.Exit();
        }

    }
}
