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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            //Проверим количество выбранных строк
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }

            //Запомним выбранную строку
            int index = dataGridView1.SelectedRows[0].Index;

            //Проверим данные в таблицы
            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //Считаем данные
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string godp = dataGridView2.Rows[index].Cells[2].Value.ToString();
            string godo = dataGridView2.Rows[index].Cells[3].Value.ToString();


            //Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database5.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = "INSERT INTO people VALUES ('" + id + "', '" + name + "')";//строка запроса
            string query2 = "INSERT INTO people2 VALUES ('" + godp + "', '" + godo + "')";
            OleDbCommand bCommand = new OleDbCommand(query, dbConnection);//команда
            OleDbCommand bCommand2 = new OleDbCommand(query2, dbConnection);

            //Выполняем запрос
            if (bCommand.ExecuteNonQuery() != 1 && bCommand2.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
                MessageBox.Show("Данные добавлены!", "Внимание!");

            //Закрываем соеденение с БД
            dbConnection.Close();
        }

        
        private void guna2GradientButton7_Click(object sender, EventArgs e)
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

        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {

            //Проверим количество выбранных строк
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }

            //Запомним выбранную строку
            int index = dataGridView1.SelectedRows[0].Index;

            //Проверим данные в таблицы
            if (dataGridView1.Rows[index].Cells[0].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //Считаем данные
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();

            //Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database5.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = "DELETE FROM people WHERE Код = " + id;//строка запроса
            
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);//команда
            

            //Выполняем запрос
            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
            {
                MessageBox.Show("Данные удалены!", "Внимание!");
                //Удаляем данные из таблицы в форме
                dataGridView1.Rows.RemoveAt(index);
            }

            //Закрываем соеденение с БД
            dbConnection.Close();
            
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database5.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT * FROM people2 WHERE годпостепления  >= #" + DateTime.Parse(textBox1.Text).ToString("yyyy'/'MM'/'dd") + "# AND годпостепления <= #" + "#";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Ошибка");
            }
            else
            {
                while (dbReader.Read())
                {
                    dataGridView1.Rows.Add(dbReader["Код"], dbReader["ФИО"], dbReader["годпоступления"], dbReader["годокончания"]);
                }
            }

            dbReader.Close();
            dbConnection.Close();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Owner = this;
            frm4.Show();
            Hide();
        }
    }
}
