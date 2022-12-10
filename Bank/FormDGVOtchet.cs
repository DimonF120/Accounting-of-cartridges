using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Bank
{
    public partial class FormDGVOtchet : Form
    {
        string dbFile = "Bank.db";
        FormOtchet obj1 = (FormOtchet)System.Windows.Forms.Application.OpenForms["FormOtchet"];

        public FormDGVOtchet()
        {
            InitializeComponent();
            if (obj1.groupBox1.Text == "Введите номер заявки")
            {
                if (obj1.textBoxKatr.Text != "")
                {
                    DataSet ds = new DataSet();
                    string command = "SELECT * FROM Zayavki WHERE [N заявки] IN (" + obj1.textBoxKatr.Text + ")";
                    string connection = "DataSource=" + dbFile + ";Version=3;New=True;Compress=True";
                    SQLiteConnection conn = new SQLiteConnection(connection);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, conn);
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    app.Visible = true;
                    worksheet = (Worksheet)workbook.ActiveSheet;
                    worksheet.Name = "Отчёт";
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (j != 4)
                            {
                                worksheet.Columns.ColumnWidth = 18;
                                worksheet.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText.ToString();
                                worksheet.Cells[1, j + 1].Interior.Color = Color.Yellow;
                                worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                            else continue;
                            worksheet.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        }
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, 5].ColumnWidth = 0;
                        }
                    }

                }
                if (obj1.textBoxKatr.Text == "")
                {
                    DataSet ds = new DataSet();
                    string command = "SELECT * FROM Zayavki";
                    string connection = "DataSource=" + dbFile + ";Version=3;New=True;Compress=True";
                    SQLiteConnection conn = new SQLiteConnection(connection);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, conn);
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    app.Visible = true;
                    worksheet = (Worksheet)workbook.ActiveSheet;
                    worksheet.Name = "Отчёт";
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (j != 4)
                            {
                                worksheet.Columns.ColumnWidth = 18;
                                worksheet.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText.ToString();
                                worksheet.Cells[1, j + 1].Interior.Color = Color.Yellow;
                                worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                            else continue;
                            worksheet.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        }
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, 5].ColumnWidth = 0;
                        }
                    }
                }
            }
        }
    }
}