using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bank
{
    public partial class FormEditZayavki : Form
    {
        SQLiteConnection conn;
        SQLiteCommand cmd;
        SQLiteDataReader dataReader;
        string fileDb = "Bank.db";
        FormMenu obj1 = (FormMenu)Application.OpenForms["FormMenu"];

        public FormEditZayavki()
        {
            InitializeComponent();
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "TIF файлы|*.tif|TIFF файлы|*.tiff|PDF файлы|*.pdf|PNG файлы|*.png|JPG файлы|*.jpg|GIF файлы|*.gif|BMP файлы|*.bmp";
            conn = new SQLiteConnection("DataSource=" + fileDb + ";Version=3;New=True;Compress=True");
            cmd = new SQLiteCommand("SELECT * FROM CHBU", conn);
            conn.Open();
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                comboBoxCHBU.Items.Add((string)reader["Наименование"]);
            cmd = new SQLiteCommand("SELECT * FROM Kartridj", conn);
            IDataReader reader1 = cmd.ExecuteReader();
            while (reader1.Read())
                comboBoxKartridj.Items.Add((string)reader1["Наименование"]);
        }

        public Boolean Dublicat()
        {
            cmd = new SQLiteCommand();
            cmd.Connection = conn;
            int za = (int)numericUpDownZayavki.Value;
            string zapros = "SELECT * FROM Zayavki WHERE [N заявки] =" + za +"";
            cmd.CommandText = zapros;
            dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                MessageBox.Show("Такой N заявки уже есть. Введите другую", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }

        private void FormEditZayavki_Load(object sender, EventArgs e)
        {
            numericUpDownZayavki.Select();
            if (this.Text=="Редактирование заявки")
            {
                numericUpDownZayavki.Value = Convert.ToInt32(obj1.dataGridView1.CurrentRow.Cells[0].Value);
                comboBoxCHBU.Text = obj1.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                dateTimePickerPodach.Value = Convert.ToDateTime(obj1.dataGridView1.CurrentRow.Cells[2].Value);
                dateTimePickerPost.Value = Convert.ToDateTime(obj1.dataGridView1.CurrentRow.Cells[3].Value);
                this.buttonDobav.Text = "Сохранить";
                this.buttonEdit.Text = "Сохранить";
                buttonPhoto.Enabled = true;
            }
        }

        private void buttonDobav_Click(object sender, EventArgs e)
        {
            if (this.Text == "Добавление заявки")
            {
                if (!string.IsNullOrEmpty(comboBoxCHBU.Text))
                {
                    int za = (int)numericUpDownZayavki.Value;
                    if (Dublicat())
                        return;
                    string ch = Convert.ToString(comboBoxCHBU.Text);
                    string dpd = Convert.ToString(dateTimePickerPodach.Value.ToShortDateString());
                    string dps = Convert.ToString(dateTimePickerPost.Value.ToShortDateString());
                    string zapros = "INSERT INTO Zayavki([N заявки], [Населённый пункт], [Дата подачи заявки], [Дата поступления])" +
                        "VALUES(" + za + ",'" + ch + "','" + dpd + "','" + dps + "')";
                    cmd = new SQLiteCommand(zapros, conn);
                    cmd.ExecuteNonQuery();
                    obj1.LoadData();
                    obj1.dataGridView1.Update();
                    obj1.dataGridView1.Refresh();
                    this.buttonEdit.Text = "Сохранить";
                    this.buttonPhoto.Enabled = true;
                }
                else MessageBox.Show("Не выбран ЦБУ","",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (this.Text == "Редактирование заявки")
            {
                if (!string.IsNullOrEmpty(comboBoxCHBU.Text))
                {
                    int z1 = Convert.ToInt32(obj1.dataGridView1.CurrentRow.Cells[0].Value);
                    int za = (int)numericUpDownZayavki.Value;
                    string ch = Convert.ToString(comboBoxCHBU.Text);
                    string dpd = Convert.ToString(dateTimePickerPodach.Value.ToShortDateString());
                    string dps = Convert.ToString(dateTimePickerPost.Value.ToShortDateString());
                    string zapros = "UPDATE Zayavki SET [N заявки]=" + za + ", [Населённый пункт]='" + ch + "', [Дата подачи заявки]='" + dpd + "', [Дата поступления]='" + dps + "' WHERE [N заявки] = " + z1 + ";";
                    cmd = new SQLiteCommand(zapros, conn);
                    cmd.ExecuteNonQuery();
                    obj1.LoadData();
                    obj1.dataGridView1.Update();
                    obj1.dataGridView1.Refresh();
                }
                else MessageBox.Show("Не выбран ЦБУ","", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (this.Text == "Добавление заявки" && this.buttonEdit.Text=="Добавить")
            {
                if (!string.IsNullOrEmpty(comboBoxCHBU.Text) || !string.IsNullOrEmpty(comboBoxKartridj.Text))
                {
                    int za = (int)numericUpDownZayavki.Value;
                    if (Dublicat())
                        return;
                    string ch = Convert.ToString(comboBoxCHBU.Text);
                    string dpd = Convert.ToString(dateTimePickerPodach.Value.ToShortDateString());
                    string dps = Convert.ToString(dateTimePickerPost.Value.ToShortDateString());
                    string kat = Convert.ToString(comboBoxKartridj.Text);
                    int kol = (int)numericUpDownKolvo.Value;
                    string zapros = "INSERT INTO Zayavki([N заявки], [Населённый пункт], [Дата подачи заявки], [Дата поступления], [" + kat + "])" +
                        "VALUES(" + za + ",'" + ch + "','" + dpd + "','" + dps + "'," + kol + ")";
                    cmd = new SQLiteCommand(zapros, conn);
                    cmd.ExecuteNonQuery();
                    buttonEdit.Text = "Сохранить";
                    buttonDobav.Text = "Сохранить";
                    buttonPhoto.Enabled = true;
                }
                else MessageBox.Show("Не выбран ЦБУ или картридж", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (this.Text == "Редактирование заявки" || this.buttonEdit.Text=="Сохранить")
            {
                if (!string.IsNullOrEmpty(comboBoxKartridj.Text))
                {

                    int z1 = 0;
                    if (this.Text == "Добавление заявки")
                    {
                        z1 = Convert.ToInt32(numericUpDownZayavki.Value);
                    }
                    else z1 = Convert.ToInt32(obj1.dataGridView1.CurrentRow.Cells[0].Value);
                    int za = (int)numericUpDownZayavki.Value;
                    string ch = Convert.ToString(comboBoxCHBU.Text);
                    string dpd = Convert.ToString(dateTimePickerPodach.Value.ToShortDateString());
                    string dps = Convert.ToString(dateTimePickerPost.Value.ToShortDateString());
                    string kat = Convert.ToString(comboBoxKartridj.Text);
                    int kol = (int)numericUpDownKolvo.Value;
                    string zapros = "UPDATE Zayavki SET [N заявки]="+za+ ", [Населённый пункт]='"+ch+ "', [Дата подачи заявки]='"+dpd+ "', [Дата поступления]='"+dps+"', ["+kat+"]="+kol+ " WHERE [N заявки] = "+z1+";";
                    cmd = new SQLiteCommand(zapros, conn);
                    cmd.ExecuteNonQuery();
                }
                else MessageBox.Show("Не выбран ЦБУ или картридж", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            obj1.LoadData();
            obj1.dataGridView1.Update();
            obj1.dataGridView1.Refresh();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKartridj.Text!="")
                this.buttonEdit.Enabled = true;
            else buttonEdit.Enabled = false;
        }

        private void FormEditZayavki_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void buttonPhoto_Click(object sender, EventArgs e)
        {
            // Конвертируем изображение в байты byte[]
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
               return;
            string imgPath = openFileDialog1.FileName;

            FileInfo _imgInfo = new FileInfo(imgPath);
            long _numBytes = _imgInfo.Length;
            FileStream _fileStream = new FileStream(imgPath, FileMode.Open, FileAccess.Read); // читаем изображение
            BinaryReader _binReader = new BinaryReader(_fileStream);
            byte[] _imageBytes = _binReader.ReadBytes((int)_numBytes); // изображение в байтах

            string imgFormat = Path.GetExtension(imgPath).Replace(".", "").ToLower(); // запишем в переменную расширение изображения в нижнем регистре, не забыв удалить точку перед расширением, получим «png»
            string imgName = Path.GetFileName(imgPath).Replace(Path.GetExtension(imgPath), ""); // запишем в переменную имя файла, не забыв удалить расширение с точкой, получим «image-01»

            // записываем информацию в базу данных
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + fileDb + "; Version=3;"))
            {
                // в запросе есть переменные, они начинаются на @, обратите на это внимание
                int i = (int)numericUpDownZayavki.Value;
                if (i > 0)
                {
                    string commandText = "UPDATE Zayavki SET[Фото заявки] = @image WHERE [N заявки]="+i+"";
                    SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                    Command.Parameters.AddWithValue("@image", _imageBytes); // присваиваем переменной значение
                    Connect.Open();
                    Command.ExecuteNonQuery();
                    Connect.Close();
                }
            }
            obj1.LoadData();
        }

        private void dateTimePickerPost_ValueChanged(object sender, EventArgs e)
        {
            string s = Convert.ToString(dateTimePickerPodach.Value.Date);
            if (dateTimePickerPodach.Value.Date > dateTimePickerPost.Value.Date)
            {
                MessageBox.Show("Дата поступления не может быть раньше даты подачи. Выберите дату после даты подачи", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePickerPost.Value = Convert.ToDateTime(s);
                return;
            }
        }
    }
}