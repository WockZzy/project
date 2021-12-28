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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
                string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database5.mdb";
                OleDbConnection dbConnection = new OleDbConnection(connectionString);

                dbConnection.Open();
                string query = "SELECT * FROM people";
            
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
                    dataGridView1.Rows.Add(dbReader["Код"], dbReader["ФИО"], dbReader["пол"], dbReader["Дата_рождения"], dbReader["адрес_проживания"], dbReader["телефон"], dbReader["сведения_о_родителях"], dbReader["рабочий_телефон_родителей"]);
                }
                }


                dbReader.Close();
                dbConnection.Close();
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
                dataGridView1.Rows[index].Cells[3].Value == null ||
                dataGridView1.Rows[index].Cells[4].Value == null ||
                dataGridView1.Rows[index].Cells[5].Value == null ||
                dataGridView1.Rows[index].Cells[6].Value == null ||
                dataGridView1.Rows[index].Cells[7].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //Считаем данные
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string pol = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string data = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string adres = dataGridView1.Rows[index].Cells[4].Value.ToString();
            string telefon = dataGridView1.Rows[index].Cells[5].Value.ToString();
            string svedorod = dataGridView1.Rows[index].Cells[6].Value.ToString();
            string telefonrod = dataGridView1.Rows[index].Cells[7].Value.ToString();

            //Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database5.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = "INSERT INTO people VALUES ('" + id + "', '" + name + "', '" + pol + "', '" + data + "', '" + adres + "', " + telefon + ", '" + svedorod + "', " + telefonrod + ")";//строка запроса
            OleDbCommand bCommand = new OleDbCommand(query, dbConnection);//команда

            //Выполняем запрос
            if (bCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
                MessageBox.Show("Данные добавлены!", "Внимание!");

            //Закрываем соеденение с БД
            dbConnection.Close();
        }

        private void guna2GradientButton9_Click(object sender, EventArgs e)
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
                dataGridView1.Rows[index].Cells[3].Value == null ||
                dataGridView1.Rows[index].Cells[4].Value == null ||
                dataGridView1.Rows[index].Cells[5].Value == null ||
                dataGridView1.Rows[index].Cells[6].Value == null ||
                dataGridView1.Rows[index].Cells[7].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //Считаем данные
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string pol = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string data = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string adres = dataGridView1.Rows[index].Cells[4].Value.ToString();
            string telefon = dataGridView1.Rows[index].Cells[5].Value.ToString();
            string svedorod = dataGridView1.Rows[index].Cells[6].Value.ToString();
            string telefonrod = dataGridView1.Rows[index].Cells[7].Value.ToString();

            //Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database5.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = "UPDATE people SET ФИО='" + name + "',пол='" + pol + "',Дата_рождения='" + data + "',адрес_проживания='" + adres + "',телефон=" + telefon + ",сведения_о_родителях='" + svedorod + "',рабочий_телефон_родителей=" + telefonrod + " WHERE Код = " + id;//строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);//команда

            //Выполняем запрос
            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
                MessageBox.Show("Данные добавлены!", "Внимание!");

            //Закрываем соеденение с БД
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
            string query = "DELETE FROM people2 WHERE Код = " + id;//строка запроса
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        
            Form7 frm7 = new Form7();
            frm7.Owner = this;
            frm7.Show();
            Hide();
        }



        

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Owner = this;
            frm1.Show();
            Hide();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
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
            string query = "DELETE FROM people2 WHERE Код = " + id;//строка запроса
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

        private void guna2GradientButton4_Click(object sender, EventArgs e)
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
                dataGridView2.Rows[index].Cells[2].Value == null ||
                dataGridView2.Rows[index].Cells[3].Value == null ||
                dataGridView2.Rows[index].Cells[4].Value == null ||
                dataGridView2.Rows[index].Cells[5].Value == null ||
                dataGridView2.Rows[index].Cells[6].Value == null ||
                dataGridView2.Rows[index].Cells[7].Value == null ||
                dataGridView2.Rows[index].Cells[8].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //Считаем данные
            string id = dataGridView2.Rows[index].Cells[0].Value.ToString();
            string kyrs = dataGridView2.Rows[index].Cells[1].Value.ToString();
            string gruppa = dataGridView2.Rows[index].Cells[2].Value.ToString();
            string spec = dataGridView2.Rows[index].Cells[3].Value.ToString();
            string otdel = dataGridView2.Rows[index].Cells[4].Value.ToString();
            string vid = dataGridView2.Rows[index].Cells[5].Value.ToString();
            string nomerbeleta = dataGridView2.Rows[index].Cells[6].Value.ToString();
            string godp = dataGridView2.Rows[index].Cells[7].Value.ToString();
            string godo = dataGridView2.Rows[index].Cells[8].Value.ToString();

            //Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database5.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = "UPDATE people2 SET курс=" + kyrs + ",группа=" + gruppa + ",специальность='" + spec + "',отделение='" + otdel + "',вид='" + vid + "',номерстуденческогобилета=" + nomerbeleta + ",годпоступления='" + godp + "',годокончания='" + godo + "' WHERE Код = " + id;//строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);//команда

            //Выполняем запрос
            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
                MessageBox.Show("Данные добавлены!", "Внимание!");

            //Закрываем соеденение с БД
            dbConnection.Close();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
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
                dataGridView2.Rows[index].Cells[2].Value == null ||
                dataGridView2.Rows[index].Cells[3].Value == null ||
                dataGridView2.Rows[index].Cells[4].Value == null ||
                dataGridView2.Rows[index].Cells[5].Value == null ||
                dataGridView2.Rows[index].Cells[6].Value == null ||
                dataGridView2.Rows[index].Cells[7].Value == null ||
                dataGridView2.Rows[index].Cells[8].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //Считаем данные
            string id = dataGridView2.Rows[index].Cells[0].Value.ToString();
            string kyrs = dataGridView2.Rows[index].Cells[1].Value.ToString();
            string gruppa = dataGridView2.Rows[index].Cells[2].Value.ToString();
            string spec = dataGridView2.Rows[index].Cells[3].Value.ToString();
            string otdel = dataGridView2.Rows[index].Cells[4].Value.ToString();
            string vid = dataGridView2.Rows[index].Cells[5].Value.ToString();
            string nomerbeleta = dataGridView2.Rows[index].Cells[6].Value.ToString();
            string godp = dataGridView2.Rows[index].Cells[7].Value.ToString();
            string godo = dataGridView2.Rows[index].Cells[8].Value.ToString();

            //Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database5.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = "INSERT INTO people2 VALUES (" + id + ", " + kyrs + ", " + gruppa + ", '" + spec + "', '" + otdel + "', '" + vid + "', " + nomerbeleta + ", '" + godp + "', '" + godo + "')";//строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);//команда

            //Выполняем запрос
            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
                MessageBox.Show("Данные добавлены!", "Внимание!");

            //Закрываем соеденение с БД
            dbConnection.Close();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database5.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT * FROM people2";
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
                    dataGridView2.Rows.Add(dbReader["Код"], dbReader["курс"], dbReader["группа"], dbReader["специальность"], dbReader["отделение"], dbReader["вид"], dbReader["номерстуденческогобилета"], dbReader["годпоступления"], dbReader["годокончания"]);
                }
            }


            dbReader.Close();
            dbConnection.Close();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Owner = this;
            frm1.Show();
            Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
