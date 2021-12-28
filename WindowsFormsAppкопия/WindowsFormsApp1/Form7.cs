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
            if (dataGridView2.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }

            //Запомним выбранную строку
            int index = dataGridView2.SelectedRows[0].Index;

            //Проверим данные в таблицы
            if (dataGridView2.Rows[index].Cells[0].Value == null ||
                dataGridView2.Rows[index].Cells[1].Value == null ||
                dataGridView2.Rows[index].Cells[2].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //Считаем данные
            string id = dataGridView2.Rows[index].Cells[0].Value.ToString();
            string name = dataGridView2.Rows[index].Cells[1].Value.ToString();
            string godp = dataGridView2.Rows[index].Cells[2].Value.ToString();
            


            //Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database5.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = "INSERT INTO people4 VALUES ('" + id + "', '" + name + "', '" + godp + "')";//строка запроса
           
            OleDbCommand bCommand = new OleDbCommand(query, dbConnection);//команда
            
            //Выполняем запрос
            if (bCommand.ExecuteNonQuery() != 1)
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
            string query = "SELECT * FROM people4";
            
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
                    dataGridView2.Rows.Add(dbReader["Код"], dbReader["ФИОстудента"], dbReader["годпоступления"]);
                }
            }
            


            dbReader.Close();
            dbConnection.Close();
        }

        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {

            //Проверим количество выбранных строк
            if (dataGridView2.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }

            //Запомним выбранную строку
            int index = dataGridView2.SelectedRows[0].Index;

            //Проверим данные в таблицы
            if (dataGridView2.Rows[index].Cells[0].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //Считаем данные
            string id = dataGridView2.Rows[index].Cells[0].Value.ToString();

            //Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database5.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = "DELETE FROM people4 WHERE Код = " + id;//строка запроса
            
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);//команда
            

            //Выполняем запрос
            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
            {
                MessageBox.Show("Данные удалены!", "Внимание!");
                //Удаляем данные из таблицы в форме
                dataGridView2.Rows.RemoveAt(index);
            }

            //Закрываем соеденение с БД
            dbConnection.Close();
            
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database5.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

           
            dbConnection.Open();
            string query = "SELECT * FROM people4 WHERE годпоступления >= #" + DateTime.Parse(textBox1.Text).ToString("yyyy'/'MM'/'dd") + "# AND годпоступления <= #" + DateTime.Parse(textBox2.Text).ToString("yyyy'/'MM'/'dd") + "#";
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
                    dataGridView1.Rows.Add(dbReader["Код"], dbReader["ФИОстудента"], dbReader["годпоступления"]);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

       async private void panel1_MouseEnter(object sender, EventArgs e)
        {
            while (panel1.Location.Y != 300)
            {
                await Task.Delay(1);
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + (50 - panel1.Location.Y) / 20);
                if (panel1.Location.Y <= 300)
                {
                    panel1.Location = new Point(panel1.Location.X, 300);
                }
            }
        }

       async private void panel2_MouseEnter(object sender, EventArgs e)
        {
            while (panel1.Location.Y != 420)
            {
                await Task.Delay(1);
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y - (200 - panel1.Location.Y) / 20);
                if (panel1.Location.Y >= 420)
                {
                    panel1.Location = new Point(panel1.Location.X, 420);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
