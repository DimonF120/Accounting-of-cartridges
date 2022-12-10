using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Bank
{
    public partial class FormKartridj : Form
    {
        static SQLiteConnection connection1;
        static SQLiteCommand command1;
        string dbFile = "Bank.db";
        FormMenu obj1 = (FormMenu)Application.OpenForms["FormMenu"];

        static public bool Connect(string fileDb)
        {
            try
            {
                connection1 = new SQLiteConnection("DataSource=" + fileDb + ";Version=3;FailIfMissing=False");
                connection1.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public FormKartridj()
        {
            InitializeComponent();
            dataGridViewKatridj.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewKatridj.ReadOnly = true;
            if (Connect(dbFile))
            {
                command1 = new SQLiteCommand(connection1)
                {
                    CommandText = "CREATE TABLE IF NOT EXISTS Kartridj(Наименование Varchar(50));"
                };
                command1.ExecuteNonQuery();
            }
        }
        private void FormKatridj_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string command = "Select * From Kartridj";
            string connection = "DataSource=" + dbFile + ";Version=3;New=True;Compress=True";
            SQLiteConnection conn = new SQLiteConnection(connection);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, conn);
            adapter.Fill(ds);
            dataGridViewKatridj.DataSource = ds.Tables[0].DefaultView;
        }

        public void LoadData()
        {
            DataSet ds = new DataSet();
            string command = "Select * From Kartridj";
            string connection = "DataSource=" + dbFile + ";Version=3;New=True;Compress=True";
            SQLiteConnection conn = new SQLiteConnection(connection);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, conn);
            adapter.Fill(ds);
            dataGridViewKatridj.DataSource = ds.Tables[0].DefaultView;
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            FormEditKatridj f = new FormEditKatridj();
            f.Text = "Добавление картриджа";
            f.buttonKatr.Text = "Добавить";
            f.ShowDialog();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            string str1 = "SELECT COUNT(*) FROM Kartridj";
            command1 = new SQLiteCommand(str1, connection1);
            object result1 = command1.ExecuteScalar();
            int kartridj = Convert.ToInt32(result1);
            if (kartridj == 0)
                MessageBox.Show("Нет данных для редактирования. Добавте новые записи", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                FormEditKatridj f = new FormEditKatridj();
                f.Text = "Редактирование картриджа";
                f.buttonKatr.Text = "Сохранить";
                f.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string str1 = "SELECT COUNT(*) FROM Kartridj";
            command1 = new SQLiteCommand(str1, connection1);
            object result1 = command1.ExecuteScalar();
            int kartridj = Convert.ToInt32(result1);
            if (kartridj == 0)
                MessageBox.Show("Нет данных для удаления", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                string s = dataGridViewKatridj.CurrentRow.Cells[0].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Вы точно хотите удалить эту запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    string zapros = "DELETE FROM Kartridj WHERE Наименование ='" + s + "';";
                    command1 = new SQLiteCommand(zapros, connection1);
                    command1.ExecuteNonQuery();
                    string zapros1 = "ALTER TABLE Zayavki DROP [" + s + "];";
                    command1 = new SQLiteCommand(zapros1, connection1);
                    command1.ExecuteNonQuery();
                    LoadData();
                    dataGridViewKatridj.Update();
                    dataGridViewKatridj.Refresh();
                    obj1.LoadData();
                    obj1.dataGridView1.Update();
                    obj1.dataGridView1.Refresh();
                }
            }
        }

        private void FormKartridj_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection1.Close();
        }
    }
}