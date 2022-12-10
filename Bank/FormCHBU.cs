using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Bank
{
    public partial class FormCHBU : Form
    {
        static SQLiteConnection connection1;
        static SQLiteCommand command1;
        string dbFile = "Bank.db";

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

        public FormCHBU()
        {
            InitializeComponent();
            dataGridViewCHBU.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCHBU.ReadOnly = true;
            if (Connect(dbFile))
            {
                command1 = new SQLiteCommand(connection1)
                {
                    CommandText = "CREATE TABLE IF NOT EXISTS CHBU(Наименование Varchar(50));"
                };
                command1.ExecuteNonQuery();
            }
        }

        private void FormCHBU_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string command = "Select * From CHBU";
            string connection = "DataSource=" + dbFile + ";Version=3;New=True;Compress=True";
            SQLiteConnection conn = new SQLiteConnection(connection);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, conn);
            adapter.Fill(ds);
            dataGridViewCHBU.DataSource = ds.Tables[0].DefaultView;
        }

        public void LoadData()
        {
            DataSet ds = new DataSet();
            string command = "Select * From CHBU";
            string connection = "DataSource=" + dbFile + ";Version=3;New=True;Compress=True";
            SQLiteConnection conn = new SQLiteConnection(connection);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, conn);
            adapter.Fill(ds);
            dataGridViewCHBU.DataSource = ds.Tables[0].DefaultView;
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            FormEditCHBU f = new FormEditCHBU();
            f.Text = "Добавление ЦБУ";
            f.buttonCHBU.Text = "Добавить";
            f.ShowDialog();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            string str = "SELECT COUNT(*) FROM CHBU";
            command1 = new SQLiteCommand(str, connection1);
            object result = command1.ExecuteScalar();
            int chbu = Convert.ToInt32(result);
            if (chbu == 0)
                MessageBox.Show("Нет данных для редактирования. Добавте новые записи", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                FormEditCHBU f = new FormEditCHBU();
                f.Text = "Редактирование ЦБУ";
                f.buttonCHBU.Text = "Сохранить";
                f.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string str = "SELECT COUNT(*) FROM CHBU";
            command1 = new SQLiteCommand(str, connection1);
            object result = command1.ExecuteScalar();
            int chbu = Convert.ToInt32(result);
            if (chbu == 0)
                MessageBox.Show("Нет данных для удаления", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                string s = dataGridViewCHBU.CurrentRow.Cells[0].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Вы точно хотите удалить эту запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    string zapros = "DELETE FROM CHBU WHERE Наименование ='" + s + "';";
                    command1 = new SQLiteCommand(zapros, connection1);
                    command1.ExecuteNonQuery();
                    LoadData();
                    dataGridViewCHBU.Update();
                    dataGridViewCHBU.Refresh();
                }
            }
        }

        private void FormCHBU_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection1.Close();
        }
    }
}