using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Bank
{
    public partial class FormEditKatridj : Form
    {
        SQLiteConnection conn;
        SQLiteCommand cmd;
        SQLiteDataReader dataReader;
        string fileDb = "Bank.db";
        FormKartridj obj = (FormKartridj) Application.OpenForms["FormKartridj"];
        FormMenu obj1 = (FormMenu)Application.OpenForms["FormMenu"];
        string s;

        public FormEditKatridj()
        {
            InitializeComponent();
            conn = new SQLiteConnection("DataSource=" + fileDb + ";Version=3;New=True;Compress=True");
            conn.Open();
        }

        private void FormEditKatridj_Load(object sender, EventArgs e)
        {
            textBoxKatr.Select();
            if (this.Text == "Редактирование картриджа")
            {
                textBoxKatr.Text = obj.dataGridViewKatridj.CurrentRow.Cells[0].Value.ToString();
                s = obj.dataGridViewKatridj.CurrentRow.Cells[0].Value.ToString();
            }
        }

        public Boolean Dublicat()
        {
            cmd = new SQLiteCommand();
            cmd.Connection = conn;
            string name = textBoxKatr.Text;
            name = name.Substring(0, 1).ToUpper() + name.Remove(0, 1).ToLower();
            string zapros = "SELECT * FROM Kartridj WHERE Наименование ='" + name + "'";
            cmd.CommandText = zapros;
            dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                MessageBox.Show("Такой картридж уже есть. Введите другой", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        private void buttonKatr_Click(object sender, EventArgs e)
        { 
            if (this.Text == "Добавление картриджа")
            {
                string name = textBoxKatr.Text;
                if (textBoxKatr.Text != "")
                {
                    name = name.Substring(0, 1).ToUpper() + name.Remove(0, 1).ToLower();
                    if (Dublicat())
                        return;
                    string zapros = "INSERT INTO Kartridj(Наименование) VALUES('" + name + "')";
                    cmd = new SQLiteCommand(zapros, conn);
                    cmd.ExecuteNonQuery();
                    string zapros1 = "ALTER TABLE Zayavki ADD ["+name+"] Integer;";
                    cmd = new SQLiteCommand(zapros1, conn);
                    cmd.ExecuteNonQuery();
                    textBoxKatr.Clear();
                }
                else MessageBox.Show("Вы не ввели наименование картриджа. Попробуйте ещё раз", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (this.Text == "Редактирование картриджа")
            {
                string name = textBoxKatr.Text;
                if (textBoxKatr.Text != "")
                {
                    name = name.Substring(0, 1).ToUpper() + name.Remove(0, 1).ToLower();
                    if (Dublicat())
                        return;
                    string zapros = "UPDATE Kartridj SET Наименование = '" + name + "' WHERE Наименование='" + s + "';";
                    cmd = new SQLiteCommand(zapros, conn);
                    cmd.ExecuteNonQuery();
                    string zapros1 = "ALTER TABLE Zayavki RENAME COLUMN [" + s + "] TO [" + name + "];";
                    cmd = new SQLiteCommand(zapros1, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    this.Close();
                }
                else MessageBox.Show("Вводная строка пуста", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            obj.LoadData();
            obj.dataGridViewKatridj.Update();
            obj.dataGridViewKatridj.Refresh();
            obj1.LoadData();
            obj1.dataGridView1.Update();
            obj1.dataGridView1.Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }

        private void FormEditKatridj_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
    }
}