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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_download_Click(object sender, EventArgs e)
        {
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database5.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT * FROM people";
            string query2 = "SELECT * FROM people2";
            OleDbCommand bCommand = new OleDbCommand(query, dbConnection);
            OleDbCommand bCommand2 = new OleDbCommand(query2, dbConnection);
            OleDbDataReader dbReader = bCommand.ExecuteReader();
            OleDbDataReader dbReader2 = bCommand2.ExecuteReader();

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Ошибка");
            }
            else
            {
                while (dbReader.Read() && dbReader2.Read())
                {
                    dataGridView2.Rows.Add(dbReader["Код"], dbReader["ФИО"], dbReader2["годпоступления"], dbReader2["годокончания"]);
                }
            }
            if (dbReader2.HasRows == false)
            {
                MessageBox.Show("Ошибка");
            }
            else
            {
                while (dbReader2.Read())
                {
                    dataGridView2.Rows.Add(dbReader2["годпоступления"], dbReader2["годокончания"]);
                }
            }


            dbReader.Close();
            dbReader2.Close();
            dbConnection.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
