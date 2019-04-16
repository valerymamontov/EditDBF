using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace EditDBF
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            #region текстовое описание для логотипа и о работе программы
            tBMIAC.Text = "Медицинский" +
                Environment.NewLine +
                "информационно-аналитический центр" +
                Environment.NewLine +
                "Калужской области";
            tBDesc.Text = "Описание:" +
                Environment.NewLine + Environment.NewLine +
                "ТФОМС Калужской области присылает DBF-файл, который содержит сведения о полисах физических лиц. " +
                "По умолчанию этот файл имеет название \"rnsu.DBF\" и лежит в папке DLO на диске C." +
                Environment.NewLine + Environment.NewLine +
                "В этом DBF-файле полис записан одной строкой и его нужно разделить на \"серию\" и \"номер\", чтобы затем отправить эти данные в сервис \"ДЛО\"." +
                Environment.NewLine + Environment.NewLine +
                "Программа делит полисы и создаёт новый файл." +
                Environment.NewLine +
                "Новый файл с названием \"SNILS_POLIS.DBF\" следует сохранить в папку DLO на диске C." +
                Environment.NewLine + Environment.NewLine +
                "Чтобы начать работу с программой, нажмите кнопку \"Выбрать файл\"." +
                Environment.NewLine + Environment.NewLine +
                "Если появилась ошибка, что \"Поставщик VFPOLEDB.1 " +
                " не зарегистрирован на локальном компьютере\", то необходимо скачать и установить дополнительный файл. Ссылка - " +
                Environment.NewLine +
                "https://www.microsoft.com/en-us/download/details.aspx?id=14839" +
                Environment.NewLine + Environment.NewLine +
                "Если произошли другие ошибки, то просто перезапустите программу.";
            #endregion
        }

        private void btnOpenDBF_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDBF = new OpenFileDialog();
            openDBF.Multiselect = false;
            openDBF.DefaultExt = ".dbf";
            openDBF.Filter = "Database files|*.dbf";

            if (openDBF.ShowDialog() == DialogResult.OK)
            {
                string openDBFfileName;
                if (openDBF.FileName.IndexOf(" ") > 0)
                {
                    MessageBox.Show("В пути к файлу содержатся пробелы!" + "\n" + 
                    "Поэтому файл будет перемещён во временную директорию и только потом открыт!" + "\n" + 
                    "Нажмите \"ОК\" и дождитесь открытия файла!", "Предупреждение");
                    Directory.CreateDirectory("C:\\Windows\\Temp\\CopyDBF\\");
                    openDBFfileName = "C:\\Windows\\Temp\\CopyDBF\\" + DateTime.Now.ToShortDateString().Replace(".", "") + ".dbf";

                    try
                    {
                        File.Copy(openDBF.FileName, openDBFfileName, true);
                    }
                    catch (IOException copyStatus)
                    {
                        MessageBox.Show("oops... Что-то пошло не так" + "\n" + copyStatus.Message);
                    }
                }
                else
                {
                    openDBFfileName = openDBF.FileName;
                }

                string oleConnSettings = String.Format("Provider=VFPOLEDB.1;Data Source={0};", openDBFfileName);

                OleDbConnection oleConn = new OleDbConnection(oleConnSettings);
                oleConn.Open();

                string query = "SELECT * FROM " + Path.GetFileNameWithoutExtension(openDBFfileName);
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, oleConn);
                DataSet dsDBFopen = new DataSet();
                adapter.Fill(dsDBFopen);
                dataGridView1.DataSource = dsDBFopen.Tables[0];
                tBcountRows1.Text = dataGridView1.Rows.Count.ToString();

                oleConn.Close();

                MessageBox.Show("Теперь нажмите кнопку \"Обработать\"", "Сообщение");
            }
        }

        private void btnEditDBF_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) MessageBox.Show("Обрабатывать нечего... " +
                "Выберите корректный DBF-файл и запустите его обработку", "Предупреждение");
            if (dataGridView1.Rows.Count > 0)
            {
                OleDbConnection oleConn = new OleDbConnection(String.Format("Provider=VFPOLEDB.1;Data Source={0};Extended Properties=dBASE IV;",
                    Path.GetTempPath()));
                oleConn.Open();
                OleDbCommand oleCmd = oleConn.CreateCommand();
                oleCmd.CommandText = "CREATE TABLE newTable (" +
                "sn_pol c(20) not null," +
                "ss c(20) not null," +
                "ser_pol c(20) not null," +
                "num_pol c(20) not null)";
                oleCmd.ExecuteNonQuery();
               
                DataSet dsDBFnew = new DataSet();
                DataTable newTable = new DataTable();

                dsDBFnew.Tables.Add(newTable);

                newTable.Columns.Add("SN_POL", typeof(string));
                newTable.Columns.Add("SS", typeof(string));
                newTable.Columns.Add("SER_POL", typeof(string));
                newTable.Columns.Add("NUM_POL", typeof(string));

                DataRow row;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string POLIS = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                    POLIS = POLIS.Trim();
                    string SER_POL = "";
                    string NUM_POL = "";
                    int countSpaces = POLIS.Length - POLIS.Replace(" ", "").Length; // подсчитывает число пробелов в строке
                    int indexOfNumb = POLIS.IndexOf("№");                           // есть ли знак номера в строке

                    #region Группа условий
                    // первое условие
                    if (POLIS == "")
                    {
                        SER_POL = "0";
                        NUM_POL = "0";
                    }

                    // второе условие
                    if (POLIS.Length > 0 && countSpaces == 0)
                    {
                        SER_POL = "0";
                        NUM_POL = POLIS;
                    }

                    // третье условие
                    if (countSpaces > 0)
                    {
                        if (countSpaces == 1)
                        {
                            string[] myArray = POLIS.Split(' ');
                            SER_POL = myArray[0];
                            NUM_POL = myArray[1];
                        }
                        if (countSpaces == 1 && indexOfNumb == 0)
                        {
                            string[] myArray = POLIS.Split(' ');
                            SER_POL = "0";
                            NUM_POL = myArray[1];
                        }
                        if (countSpaces == 2 && indexOfNumb == 0)
                        {
                            string[] myArray = POLIS.Split(' ');
                            SER_POL = myArray[1];
                            NUM_POL = myArray[2];
                        }
                        if (countSpaces == 2 && indexOfNumb > 0 )
                        {
                            string[] myArray = POLIS.Split(' ');
                            SER_POL = myArray[0];
                            NUM_POL = myArray[2];
                        }
                        if (countSpaces > 2 && indexOfNumb > 0)
                        {
                            string[] myArray = POLIS.Replace(" № ", " ").Trim().Split(' ');
                            SER_POL = myArray[1];
                            NUM_POL = myArray[2];
                        }
                    }
                    #endregion

                    ///----- добавление записей в пустую Таблицу нового ДатаСета -----///
                    row = newTable.NewRow();
                    row["SN_POL"] = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                    row["SS"] = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                    row["SER_POL"] = SER_POL;
                    row["NUM_POL"] = NUM_POL;
                    newTable.Rows.Add(row);

                    ///----- заполнение DBF-файла данными -----///
                    oleCmd.CommandText = String.Format("INSERT INTO newTable (" +
                    "[sn_pol], " +
                    "[ss], " +
                    "[ser_pol], " +
                    "[num_pol]) VALUES ('{0}', '{1}', '{2}', '{3}')",
                    Convert.ToString(dsDBFnew.Tables[0].Rows[i][0]),
                    Convert.ToString(dsDBFnew.Tables[0].Rows[i][1]),
                    Convert.ToString(dsDBFnew.Tables[0].Rows[i][2]),
                    Convert.ToString(dsDBFnew.Tables[0].Rows[i][3]));
                    oleCmd.ExecuteNonQuery();

                }
                oleConn.Close();

                dataGridView2.DataSource = dsDBFnew.Tables[0];
                tBcountRows2.Text = dataGridView2.Rows.Count.ToString();
                MessageBox.Show("Файл успешно обработан!!!" + "\n" + "Чтобы сохранить новый файл, нажмите кнопку \"Сохранить\"", "Сообщение");
            }

        }

        private void btnSaveDBF_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0) MessageBox.Show("Выберите корректный DBF-файл " +
                "и запустите его обработку, только потом его можно будет сохранить", "Предупреждение");
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveDBF = new SaveFileDialog();
                saveDBF.Filter = "Database files|*.dbf";
                saveDBF.Title = "Сохранить файл";
                saveDBF.FileName = "SNILS_POLIS.dbf";
                saveDBF.DefaultExt = ".dbf";

                if (saveDBF.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(Path.GetTempPath().ToString() + "newTable.dbf", saveDBF.FileName, true);
                        MessageBox.Show("Файл успешно сохранён! Можно закрыть программу!", "Сообщение");
                    }
                    catch (IOException copyStatus)
                    {
                        MessageBox.Show("oops..." + "\n" + copyStatus.Message, "Ошибка");
                    }
                }
            }
        }
    }
}
