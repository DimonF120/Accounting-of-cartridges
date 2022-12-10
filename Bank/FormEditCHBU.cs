using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Bank
{
    public partial class FormEditCHBU : Form
    {
        SQLiteConnection conn;
        SQLiteCommand cmd;
        SQLiteDataReader dataReader;
        string fileDb = "Bank.db";
        FormCHBU obj = (FormCHBU) Application.OpenForms["FormCHBU"];
        string s;

        public FormEditCHBU()
        {
            InitializeComponent();
            conn = new SQLiteConnection("DataSource=" + fileDb + ";Version=3;New=True;Compress=True");
            conn.Open();
        }

        private void FormEditCHBU_Load(object sender, EventArgs e)
        {
            textBoxCHBU.Select();
            if (this.Text == "Редактирование ЦБУ")
            { 
                textBoxCHBU.Text = obj.dataGridViewCHBU.CurrentRow.Cells[0].Value.ToString();
                s = obj.dataGridViewCHBU.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }

        public Boolean Dublicat()
        {
            cmd = new SQLiteCommand();
            cmd.Connection = conn;
            string name = textBoxCHBU.Text;
            name = name.Substring(0, 1).ToUpper() + name.Remove(0, 1).ToLower();
            string zapros = "SELECT * FROM CHBU WHERE Наименование ='" + name + "'";
            cmd.CommandText = zapros;
            dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                MessageBox.Show("Такой ЦБУ уже есть. Введите другой", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        private void buttonCHBU_Click_1(object sender, EventArgs e)
        {
            if (this.Text=="Добавление ЦБУ")
            {
                string name = textBoxCHBU.Text;
                if (textBoxCHBU.Text != "")
                {
                    name = name.Substring(0,1).ToUpper() + name.Remove(0,1).ToLower();
                    if (Dublicat())
                        return;
                    string zapros = "INSERT INTO CHBU(Наименование) VALUES('" + name + "')";
                    cmd = new SQLiteCommand(zapros, conn);
                    cmd.ExecuteNonQuery();
                    obj.LoadData();
                    obj.dataGridViewCHBU.Update();
                    obj.dataGridViewCHBU.Refresh();
                    textBoxCHBU.Clear();
                }
                else MessageBox.Show("Вы не ввели наименование ЦБУ. Попробуйте ещё раз", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(this.Text=="Редактирование ЦБУ")
            {
                string name = textBoxCHBU.Text;
                if (textBoxCHBU.Text != "")
                {
                    name = name.Substring(0, 1).ToUpper() + name.Remove(0, 1).ToLower();
                    if (Dublicat())
                        return;
                    string zapros = "UPDATE CHBU SET Наименование = '" + name + "' WHERE Наименование='" + s + "';";
                    cmd = new SQLiteCommand(zapros, conn);
                    cmd.ExecuteNonQuery();
                    obj.LoadData();
                    obj.dataGridViewCHBU.Update();
                    obj.dataGridViewCHBU.Refresh();
                    conn.Close();
                    this.Close();
                }
                else MessageBox.Show("Вводная строка пуста", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormEditCHBU_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
    }
}