using System;
using System.Data.SQLite;   
using System.Windows.Forms;

namespace Bank
{
    public partial class FormPoisk : Form
    {
        SQLiteConnection conn;
        string dbFile = "Bank.db";
        FormMenu obj1 = (FormMenu)Application.OpenForms["FormMenu"];

        public FormPoisk()
        {
            InitializeComponent();
            textBoxPoisk.Select();
            conn = new SQLiteConnection("DataSource=" + dbFile + ";Version=3;FailIfMissing=False");
            conn.Open();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonKatr_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < obj1.dataGridView1.RowCount; i++)
            {
               
                    if (obj1.dataGridView1.Rows[i].Cells[0].Value == null)
                        break;
                    if (textBoxPoisk.Text == obj1.dataGridView1.Rows[i].Cells[0].Value.ToString())
                    {
                        obj1.dataGridView1.CurrentCell = obj1.dataGridView1.Rows[i].Cells[0];
                        obj1.dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
            }
            this.Close();
        }

        private void FormPoisk_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
    }
}