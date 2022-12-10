using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Bank
{
    public partial class FormMenu : Form
    {
        static SQLiteConnection connection1;
        static SQLiteCommand command1;
        string dbFile = "Bank.db";
        FormEditZayavki f;
        FormPoisk f1;

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

        public FormMenu()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            if (Connect(dbFile))
            {
                command1 = new SQLiteCommand(connection1)
                {
                    CommandText = "CREATE TABLE IF NOT EXISTS Zayavki([N заявки] Integer, [Населённый пункт] Varchar(50), [Дата подачи заявки] TEXT, [Дата поступления] TEXT, [Фото заявки] BLOB);" +
                    "CREATE TABLE IF NOT EXISTS Kartridj(Наименование Varchar(50));" +
                    "CREATE TABLE IF NOT EXISTS CHBU(Наименование Varchar(50));"
                };
                command1.ExecuteNonQuery();
            }
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            btnInsert.Select();
            DataSet ds = new DataSet();
            string command = "SELECT * FROM Zayavki";
            string connection = "DataSource=" + dbFile + ";Version=3;New=True;Compress=True";
            SQLiteConnection conn = new SQLiteConnection(connection);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            dataGridView1.Columns["Фото заявки"].Visible = false;
            LoadImage();
        }

        public void LoadData()
        {
            DataSet ds = new DataSet();
            string command = "SELECT * FROM Zayavki";
            string connection = "DataSource=" + dbFile + ";Version=3;New=True;Compress=True";
            SQLiteConnection conn = new SQLiteConnection(connection);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            dataGridView1.Columns["Фото заявки"].Visible = false;
            LoadImage();
        }

        void LoadImage()
        {
            string str = "SELECT COUNT(*) FROM Zayavki";
            command1 = new SQLiteCommand(str, connection1);
            object result = command1.ExecuteScalar();
            int a = Convert.ToInt32(result);
            if (a == 0)
                return;
            else
            {
                int i1 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                if (i1 > 0)
                {
                    if (i1 > 0)
                    {
                        string zapros = "SELECT [Фото заявки] FROM Zayavki WHERE [N заявки] =" + i1;
                        SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(new SQLiteCommand(zapros, connection1));
                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds);
                        if (ds.Tables[0].Rows.Count == 1)
                        {
                            Byte[] data = new Byte[0];
                            data = (ds.Tables[0].Rows[0]["Фото заявки"]) == DBNull.Value ? new byte[0] : (Byte[])(ds.Tables[0].Rows[0]["Фото заявки"]);
                            if (data.Length != 0)
                            {
                                MemoryStream ms = new MemoryStream(data);
                                pictureBox1.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
        }

        private void цБУToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormCHBU f = new FormCHBU();
            f.ShowDialog();
        }

        private void картриджиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKartridj f = new FormKartridj();
            f.ShowDialog();
        }

        private void отчётToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string str = "SELECT COUNT(*) FROM Zayavki";
            command1 = new SQLiteCommand(str, connection1);
            object result = command1.ExecuteScalar();
            int a = Convert.ToInt32(result);
            if (a == 0)
                MessageBox.Show("Нет данных для формирования отчета", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                FormOtchet f = new FormOtchet();
                f.ShowDialog();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string str = "SELECT COUNT(*) FROM Zayavki";
            command1 = new SQLiteCommand(str, connection1);
            object result = command1.ExecuteScalar();
            int a = Convert.ToInt32(result);
            if (a == 0)
                MessageBox.Show("Нет данных для поиска","", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (f1 == null || f1.IsDisposed)
                {
                    f1 = new FormPoisk();
                    f1.Show();
                }
                else f1.Select();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string str = "SELECT COUNT(*) FROM CHBU";
            command1 = new SQLiteCommand(str, connection1);
            object result = command1.ExecuteScalar();
            int chbu = Convert.ToInt32(result);
            string str1 = "SELECT COUNT(*) FROM Kartridj";
            command1 = new SQLiteCommand(str1, connection1);
            object result1 = command1.ExecuteScalar();
            int kartridj = Convert.ToInt32(result1);
            if (chbu == 0 && kartridj == 0)
                MessageBox.Show("Заполните справочники ЦБУ и картриджей", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (chbu == 0 && kartridj != 0)
                MessageBox.Show("Заполните справочники ЦБУ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (kartridj == 0 && chbu != 0)
                MessageBox.Show("Заполните справочники картриджей", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (kartridj != 0 && chbu != 0)
            {
                if (f == null || f.IsDisposed)
                {
                    f = new FormEditZayavki();
                    f.Text = "Добавление заявки";
                    f.Show();
                }
                else f.Select();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string str = "SELECT COUNT(*) FROM Zayavki";
            command1 = new SQLiteCommand(str, connection1);
            object result = command1.ExecuteScalar();
            int a = Convert.ToInt32(result);
            if (a == 0)
                MessageBox.Show("Нет данных для редактирования", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (f == null || f.IsDisposed)
                {
                    f = new FormEditZayavki();
                    f.Text = "Редактирование заявки";
                    f.Show();
                }
                else f.Select();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string str = "SELECT COUNT(*) FROM Zayavki";
            command1 = new SQLiteCommand(str, connection1);
            object result = command1.ExecuteScalar();
            int a = Convert.ToInt32(result);
            if (a == 0)
                MessageBox.Show("Нет данных для удаления", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else {
                int i1 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                if (i1 > 0)
                {
                    DialogResult result1 = MessageBox.Show("Вы точно хотите удалить эту запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result1 == DialogResult.Yes)
                    {
                        string zapros = "DELETE FROM Zayavki Where [N заявки] =" + i1;
                        command1 = new SQLiteCommand(zapros, connection1);
                        command1.ExecuteNonQuery();
                        MessageBox.Show("Запись удалена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }  
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i1 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            if (i1 > 0)
            {
                string zapros = "SELECT [Фото заявки] FROM Zayavki WHERE [N заявки] =" + i1;
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(new SQLiteCommand(zapros, connection1));
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    Byte[] data = new Byte[0];
                    data = (ds.Tables[0].Rows[0]["Фото заявки"]) == DBNull.Value ? new byte[0] : (Byte[])(ds.Tables[0].Rows[0]["Фото заявки"]);
                    if (data.Length != 0)
                    {
                        MemoryStream ms = new MemoryStream(data);
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                    else if (data.Length == 0)
                        pictureBox1.Image = null;
                }
            }
        }

        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection1.Close();
        }
    }
}