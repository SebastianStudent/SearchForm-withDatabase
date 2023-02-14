using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WyszukiwanieForm
{
    public partial class WyszukiwaniePoLogowniu : Form
    {
        public static List<int[]> listaIndex;
        public static List<string[]> listaSchemat;
        public static int[] indexy;
        public static string[] schematyINazwy;
        private static int rowIndex = -1;
        public static int indexTabel;
        public static int znalezioneElementy;
        public static int znalezioneTabele;
        public static string wartoscztextboxa;
        public static int dlugoscztextboxa;
        public static string wyszukiwanieTabelTextBox;
        public static int dlugoscTabelTextBox;
        public WyszukiwaniePoLogowniu()
        {
            InitializeComponent();
            BazyDanychcomboBox.Items.Add("None");
            BazyDanychcomboBox.Text = "None";
        }

        private void SzukanieTylkoPoTabeliZdublowane(int dlugoscNazwaTabeli, int dlugoscTabelTextBox, int iloscTakichSamychTabel, string NazwaTabeli, string wyszukiwanieTabelTextBox)
        {
            string tempNazwaTabeli;
            if (dlugoscNazwaTabeli > dlugoscTabelTextBox)
            {
                tempNazwaTabeli = NazwaTabeli.Remove(dlugoscTabelTextBox);
                if (tempNazwaTabeli.Contains(wyszukiwanieTabelTextBox))
                {
                    TabeladataGridView.Rows[indexTabel].Cells[0].Style.BackColor = Color.LightGreen;
                    for (int i = 0; i < iloscTakichSamychTabel; i++)
                    {
                        string polecenieSQL = "WITH SchematyTabel AS (SELECT TABLE_SCHEMA, ROW_NUMBER() OVER (ORDER BY TABLE_SCHEMA) AS RowIndex FROM " + BazyDanychcomboBox.SelectedItem.ToString() + ".INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + TabeladataGridView.CurrentCell.Value + "') SELECT TABLE_SCHEMA FROM SchematyTabel WHERE RowIndex = " + i + "; ";
                        SqlCommand sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
                        SqlDataReader czytaj = sqlCommand.ExecuteReader();
                        string schematTabeli = "";
                        if (czytaj.Read())
                        {
                            schematTabeli = czytaj.GetValue(0).ToString();
                        }
                        czytaj.Close();
                        znalezioneTabele++;
                        schematyINazwy = new string[2];
                        schematyINazwy[0] = schematTabeli;
                        schematyINazwy[1] = TabeladataGridView.CurrentCell.Value.ToString();
                        listaSchemat.Add(schematyINazwy);
                        indexy = new int[3];
                        indexy[2] = TabeladataGridView.CurrentCell.RowIndex;
                        listaIndex.Add(indexy);
                    }
                }
            }
            else if (dlugoscNazwaTabeli == dlugoscTabelTextBox)
            {
                if (NazwaTabeli.Contains(wyszukiwanieTabelTextBox))
                {
                    TabeladataGridView.Rows[indexTabel].Cells[0].Style.BackColor = Color.LightGreen;
                    for (int i = 0; i < iloscTakichSamychTabel; i++)
                    {
                        string polecenieSQL = "WITH SchematyTabel AS (SELECT TABLE_SCHEMA, ROW_NUMBER() OVER (ORDER BY TABLE_SCHEMA) AS RowIndex FROM " + BazyDanychcomboBox.SelectedItem.ToString() + ".INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + TabeladataGridView.CurrentCell.Value + "') SELECT TABLE_SCHEMA FROM SchematyTabel WHERE RowIndex = " + i + "; ";
                        SqlCommand sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
                        SqlDataReader czytaj = sqlCommand.ExecuteReader();
                        string schematTabeli = "";
                        if (czytaj.Read())
                        {
                            schematTabeli = czytaj.GetValue(0).ToString();
                        }
                        czytaj.Close();
                        znalezioneTabele++;
                        schematyINazwy = new string[2];
                        schematyINazwy[0] = schematTabeli;
                        schematyINazwy[1] = TabeladataGridView.CurrentCell.Value.ToString();
                        listaSchemat.Add(schematyINazwy);
                        indexy = new int[3];
                        indexy[2] = TabeladataGridView.CurrentCell.RowIndex;
                        listaIndex.Add(indexy);
                    }
                }
            }
        }

        private void SzukanieTylkoPoTabeliPojedyncze(int dlugoscNazwaTabeli, int dlugoscTabelTextBox, string NazwaTabeli, string wyszukiwanieTabelTextBox, string schematTabeli)
        {
            string tempNazwaTabeli;
            if (dlugoscNazwaTabeli > dlugoscTabelTextBox)
            {
                tempNazwaTabeli = NazwaTabeli.Remove(dlugoscTabelTextBox);
                if (tempNazwaTabeli.Contains(wyszukiwanieTabelTextBox))
                {
                    TabeladataGridView.Rows[indexTabel].Cells[0].Style.BackColor = Color.LightGreen;
                    znalezioneTabele++;
                    schematyINazwy = new string[2];
                    schematyINazwy[0] = schematTabeli;
                    schematyINazwy[1] = TabeladataGridView.CurrentCell.Value.ToString();
                    listaSchemat.Add(schematyINazwy);
                    indexy = new int[3];
                    indexy[2] = TabeladataGridView.CurrentCell.RowIndex;
                    listaIndex.Add(indexy);
                }
            }
            else if (dlugoscNazwaTabeli == dlugoscTabelTextBox)
            {
                if (NazwaTabeli.Contains(wyszukiwanieTabelTextBox))
                {
                    TabeladataGridView.Rows[indexTabel].Cells[0].Style.BackColor = Color.LightGreen;
                    znalezioneTabele++;
                    schematyINazwy = new string[2];
                    schematyINazwy[0] = schematTabeli;
                    schematyINazwy[1] = TabeladataGridView.CurrentCell.Value.ToString();
                    listaSchemat.Add(schematyINazwy);
                    indexy = new int[3];
                    indexy[2] = TabeladataGridView.CurrentCell.RowIndex;
                    listaIndex.Add(indexy);
                }
            }
        }

        private void WiecejNizJednaTabela(int iloscTabel)
        {
            string polecenieSQL;
            SqlCommand sqlCommand;
            SqlDataReader czytaj;

            for (int i = 1; i <= iloscTabel; i++)
            {
                polecenieSQL = "WITH SchematyTabel AS (SELECT TABLE_SCHEMA, ROW_NUMBER() OVER (ORDER BY TABLE_SCHEMA) AS RowIndex FROM " + BazyDanychcomboBox.SelectedItem.ToString() + ".INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + TabeladataGridView.CurrentCell.Value + "') SELECT TABLE_SCHEMA FROM SchematyTabel WHERE RowIndex = " + i + "; ";
                sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
                czytaj = sqlCommand.ExecuteReader();
                string schematTabeli = "";
                if (czytaj.Read())
                {
                    schematTabeli = czytaj.GetValue(0).ToString();
                }
                czytaj.Close();
                int LiczbaKolumn = 0;
                polecenieSQL = "WITH IleKolumn AS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + TabeladataGridView.CurrentCell.Value + "' AND TABLE_SCHEMA = '" + schematTabeli + "') SELECT COUNT(*) FROM IleKolumn; ";
                sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
                czytaj = sqlCommand.ExecuteReader();

                if (czytaj.Read())
                {
                    LiczbaKolumn = Int32.Parse(czytaj.GetValue(0).ToString());
                }
                czytaj.Close();
                if (LiczbaKolumn > 0)
                {
                    StringBuilder finalnePolecenieSQL = new StringBuilder();
                    finalnePolecenieSQL.Append("SELECT ");

                    string nazwyKolumn = "";
                    int j = 1;

                    while (j <= LiczbaKolumn)
                    {

                        polecenieSQL = "WITH NazwyKolumn AS (SELECT COLUMN_NAME, ROW_NUMBER() OVER (ORDER BY COLUMN_NAME) AS RowIndex FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + TabeladataGridView.CurrentCell.Value + "' AND TABLE_SCHEMA = '" + schematTabeli + "' )SELECT COLUMN_NAME FROM NazwyKolumn WHERE RowIndex = " + j + "; ";
                        sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
                        czytaj = sqlCommand.ExecuteReader();
                        if (czytaj.Read())
                        {
                            nazwyKolumn = czytaj.GetString(0);
                        }
                        czytaj.Close();
                        j++;

                        polecenieSQL = "SELECT DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + TabeladataGridView.CurrentCell.Value + "' AND COLUMN_NAME = '" + nazwyKolumn + " '";
                        sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
                        czytaj = sqlCommand.ExecuteReader();

                        string typ_danej = "";
                        if (czytaj.Read())
                        {
                            typ_danej = czytaj.GetValue(0).ToString();
                        }
                        czytaj.Close();

                        switch (typ_danej)
                        {
                            case "date":
                                {
                                    finalnePolecenieSQL.Append(" CONVERT(VARCHAR(50)," + nazwyKolumn + ") AS " + nazwyKolumn + ",");
                                    break;
                                }
                            case "datetime":
                                {
                                    finalnePolecenieSQL.Append(" CONVERT(VARCHAR(50),CAST (" + nazwyKolumn + " AS BIGINT), 121) AS " + nazwyKolumn + ",");
                                    break;
                                }
                            case "timestamp":
                                {
                                    finalnePolecenieSQL.Append(" CONVERT(VARCHAR(50),CAST (" + nazwyKolumn + " AS BIGINT), 121) AS " + nazwyKolumn + ",");
                                    break;
                                }
                            case "time":
                                {
                                    finalnePolecenieSQL.Append(" CONVERT(VARCHAR(50)," + nazwyKolumn + ") AS " + nazwyKolumn + ",");
                                    break;
                                }
                            case "year":
                                {
                                    finalnePolecenieSQL.Append(" CONVERT(VARCHAR(50),CAST (" + nazwyKolumn + " AS BIGINT), 121) AS " + nazwyKolumn + ",");
                                    break;
                                }
                            case "image":
                                {
                                    finalnePolecenieSQL.Append("CONVERT(VARCHAR(max),CONVERT(varbinary(max)," + nazwyKolumn + ")) AS " + nazwyKolumn + ",");
                                    break;
                                }
                            case "binary":
                                {
                                    finalnePolecenieSQL.Append("CONVERT(VARCHAR(max)," + nazwyKolumn + ") AS " + nazwyKolumn + ",");
                                    break;
                                }
                            case "varbinary":
                                {
                                    finalnePolecenieSQL.Append("CONVERT(VARCHAR(max)," + nazwyKolumn + ") AS " + nazwyKolumn + ",");
                                    break;
                                }
                            default:
                                {
                                    if (nazwyKolumn.ToLower() == "group" || nazwyKolumn.ToLower() == "read")
                                    {
                                        nazwyKolumn = "'" + nazwyKolumn + "' AS '" + nazwyKolumn + "'";
                                    }
                                    finalnePolecenieSQL.Append(nazwyKolumn + ",");
                                    break;
                                }
                        }
                    }
                    finalnePolecenieSQL.Remove(finalnePolecenieSQL.Length - 1, 1);
                    finalnePolecenieSQL.Append(" FROM " + BazyDanychcomboBox.SelectedItem.ToString() + "." + schematTabeli + "." + TabeladataGridView.CurrentCell.Value);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(finalnePolecenieSQL.ToString(), Logowanie.sqlConnection);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    TabelaDoWyszukiwania.DataSource = dataTable;
                }
                if (checkedListBox_frazy.SelectedItem.ToString() == "Na początku")
                {
                    SzukanieNaPoczątku(LiczbaKolumn, schematTabeli);
                }
                else if (checkedListBox_frazy.SelectedItem.ToString() == "W środku")
                {
                    SzukanieSrodek(LiczbaKolumn, schematTabeli);
                }
                else if (checkedListBox_frazy.SelectedItem.ToString() == "Na końcu")
                {
                    SzukanieNaKońcu(LiczbaKolumn, schematTabeli);
                }
            }
        }

        private void SzukanieNaPoczątku(int LiczbaKolumn, string schematTabeli)
        {
            bool tabela = false;
            for (int indexKolumn = 0; indexKolumn < LiczbaKolumn; indexKolumn++)
            {
                for (int IndexRow = 0; IndexRow <= TabelaDoWyszukiwania.RowCount - 1; IndexRow++)
                {
                    if (TabelaDoWyszukiwania.Rows[IndexRow].Cells[indexKolumn].Value != null && TabelaDoWyszukiwania.Rows[IndexRow].Cells[indexKolumn].Value.ToString() != "")
                    {
                        try
                        {
                            string wartoscztabeli = TabelaDoWyszukiwania.Rows[IndexRow].Cells[indexKolumn].Value.ToString().ToLower();
                            wartoscztabeli = wartoscztabeli.Replace(" ", String.Empty);
                            if (wartoscztabeli.Length > dlugoscztextboxa)
                            {
                                string wycinekzawartosciztabeli = wartoscztabeli.Remove(dlugoscztextboxa);
                                if (wycinekzawartosciztabeli.Contains(wartoscztextboxa))
                                {
                                    TabeladataGridView.Rows[indexTabel].Cells[0].Style.BackColor = Color.LightGreen;
                                    znalezioneElementy++;
                                    tabela = true;
                                    indexy = new int[3];
                                    indexy[0] = indexKolumn;
                                    indexy[1] = IndexRow;
                                    indexy[2] = TabeladataGridView.CurrentCell.RowIndex;
                                    listaIndex.Add(indexy);
                                    schematyINazwy = new string[2];
                                    schematyINazwy[0] = schematTabeli;
                                    schematyINazwy[1] = TabeladataGridView.CurrentCell.Value.ToString();
                                    listaSchemat.Add(schematyINazwy);
                                }
                            }
                            else if (wartoscztabeli.Length == dlugoscztextboxa)
                            {
                                if (wartoscztabeli.Contains(wartoscztextboxa))
                                {
                                    TabeladataGridView.Rows[indexTabel].Cells[0].Style.BackColor = Color.LightGreen;
                                    znalezioneElementy++;
                                    tabela = true;
                                    indexy = new int[3];
                                    indexy[0] = indexKolumn;
                                    indexy[1] = IndexRow;
                                    indexy[2] = TabeladataGridView.CurrentCell.RowIndex;
                                    listaIndex.Add(indexy);
                                    schematyINazwy = new string[2];
                                    schematyINazwy[0] = schematTabeli;
                                    schematyINazwy[1] = TabeladataGridView.CurrentCell.Value.ToString();
                                    listaSchemat.Add(schematyINazwy);
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error algorytmu");
                        }
                    }
                }
            }
            if (tabela)
            {
                znalezioneTabele++;
            }
        }

        private void SzukanieSrodek(int LiczbaKolumn, string schematTabeli)
        {
            bool tabela = false;
            for (int indexKolumn = 0; indexKolumn < LiczbaKolumn; indexKolumn++)
            {
                for (int IndexRow = 0; IndexRow <= TabelaDoWyszukiwania.RowCount - 1; IndexRow++)
                {
                    if (TabelaDoWyszukiwania.Rows[IndexRow].Cells[indexKolumn].Value != null && TabelaDoWyszukiwania.Rows[IndexRow].Cells[indexKolumn].Value.ToString() != "")
                    {
                        try
                        {
                            string wartoscztabeli = TabelaDoWyszukiwania.Rows[IndexRow].Cells[indexKolumn].Value.ToString().ToLower();
                            wartoscztabeli = wartoscztabeli.Replace(" ", String.Empty);
                            if (wartoscztabeli.Length >= dlugoscztextboxa)
                            {
                                if (wartoscztabeli.Contains(wartoscztextboxa))
                                {
                                    TabeladataGridView.Rows[indexTabel].Cells[0].Style.BackColor = Color.LightGreen;
                                    znalezioneElementy++;
                                    tabela = true;
                                    indexy = new int[3];
                                    indexy[0] = indexKolumn;
                                    indexy[1] = IndexRow;
                                    indexy[2] = TabeladataGridView.CurrentCell.RowIndex;
                                    listaIndex.Add(indexy);
                                    schematyINazwy = new string[2];
                                    schematyINazwy[0] = schematTabeli;
                                    schematyINazwy[1] = TabeladataGridView.CurrentCell.Value.ToString();
                                    listaSchemat.Add(schematyINazwy);
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error algorytmu");
                        }
                    }
                }
            }
            if (tabela)
            {
                znalezioneTabele++;
            }
        }

        private void SzukanieNaKońcu(int LiczbaKolumn, string schematTabeli)
        {
            bool tabela = false;
            for (int indexKolumn = 0; indexKolumn < LiczbaKolumn; indexKolumn++)
            {
                for (int IndexRow = 0; IndexRow <= TabelaDoWyszukiwania.RowCount - 1; IndexRow++)
                {
                    if (TabelaDoWyszukiwania.Rows[IndexRow].Cells[indexKolumn].Value != null && TabelaDoWyszukiwania.Rows[IndexRow].Cells[indexKolumn].Value.ToString() != "")
                    {
                        try
                        {
                            string wartoscztabeli = TabelaDoWyszukiwania.Rows[IndexRow].Cells[indexKolumn].Value.ToString().ToLower();
                            wartoscztabeli = wartoscztabeli.Replace(" ", String.Empty);
                            if (wartoscztabeli.Length > dlugoscztextboxa)
                            {
                                string wycinekzawartosciztabeli = wartoscztabeli.Substring(wartoscztabeli.Length-dlugoscztextboxa);
                                if (wycinekzawartosciztabeli.Contains(wartoscztextboxa))
                                {
                                    TabeladataGridView.Rows[indexTabel].Cells[0].Style.BackColor = Color.LightGreen;
                                    znalezioneElementy++;
                                    tabela = true;
                                    indexy = new int[3];
                                    indexy[0] = indexKolumn;
                                    indexy[1] = IndexRow;
                                    indexy[2] = TabeladataGridView.CurrentCell.RowIndex;
                                    listaIndex.Add(indexy);
                                    schematyINazwy = new string[2];
                                    schematyINazwy[0] = schematTabeli;
                                    schematyINazwy[1] = TabeladataGridView.CurrentCell.Value.ToString();
                                    listaSchemat.Add(schematyINazwy);
                                }
                            }
                            else if (wartoscztabeli.Length == dlugoscztextboxa)
                            {
                                if (wartoscztabeli.Contains(wartoscztextboxa))
                                {
                                    TabeladataGridView.Rows[indexTabel].Cells[0].Style.BackColor = Color.LightGreen;
                                    znalezioneElementy++;
                                    tabela = true;
                                    indexy = new int[3];
                                    indexy[0] = indexKolumn;
                                    indexy[1] = IndexRow;
                                    indexy[2] = TabeladataGridView.CurrentCell.RowIndex;
                                    listaIndex.Add(indexy);
                                    schematyINazwy = new string[2];
                                    schematyINazwy[0] = schematTabeli;
                                    schematyINazwy[1] = TabeladataGridView.CurrentCell.Value.ToString();
                                    listaSchemat.Add(schematyINazwy);
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error algorytmu");
                        }
                    }
                }
            }
            if (tabela)
            {
                znalezioneTabele++;
            }
        }

        private void ExcelExport()
        {

        }

        private void BazyDanychcomboBox_DropDown(object sender, EventArgs e)
        {
            BazyDanychcomboBox.Items.Clear();
            BazyDanychcomboBox.Items.Add("None");

            short maxymalny_rozmiar = 1;
            string polecenieSQL = "SELECT COUNT(name) FROM sysdatabases WHERE sid != 0x01;";
            SqlCommand sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
            SqlDataReader czytaj = sqlCommand.ExecuteReader();
            if (czytaj.Read())
            {
                short liczbaBazDanych = short.Parse(czytaj.GetValue(0).ToString());
                czytaj.Close();
                if (liczbaBazDanych > 0)
                {
                    while (liczbaBazDanych > 0)
                    {
                        polecenieSQL = "WITH IndexyDoPokazania AS ( SELECT name, ROW_NUMBER() OVER(ORDER BY name DESC) AS RowIndex FROM sysdatabases WHERE sid != 0x01) SELECT name FROM IndexyDoPokazania WHERE RowIndex = " + liczbaBazDanych + "; ";
                        sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
                        czytaj = sqlCommand.ExecuteReader();
                        if (czytaj.Read())
                        {
                            maxymalny_rozmiar++;
                            BazyDanychcomboBox.MaxDropDownItems = maxymalny_rozmiar;
                            BazyDanychcomboBox.Items.Add(czytaj.GetValue(0).ToString());
                        }
                        czytaj.Close();
                        liczbaBazDanych--;
                    }
                }
            }
        }

        private void BazyDanychcomboBox_DropDownClosed(object sender, EventArgs e)
        {
            TabelaDoWyszukiwania.Visible = false;
            znalezioneTextBox.Visible = false;
            TabeladataGridView.Visible = false;
            TabeleLabel.Visible = false;
            if (BazyDanychcomboBox.SelectedIndex != -1 && BazyDanychcomboBox.SelectedItem.ToString() != "None")
            {
                Logowanie.sqlConnection.Close();
                try
                {
                    Logowanie.PolaczenieString = "Data Source = " + Logowanie.serverName + "\\" + Logowanie.instanceName + ";Initial Catalog = " + BazyDanychcomboBox.SelectedItem.ToString() + ";Integrated Security=True";
                    Logowanie.sqlConnection = new SqlConnection(Logowanie.PolaczenieString);
                    Logowanie.sqlConnection.Open();
                }
                catch
                {
                    if (Logowanie.instanceName != "")
                    {
                        Logowanie.PolaczenieString = "Data Source = " + Logowanie.serverName + "\\" + Logowanie.instanceName + ";Initial Catalog = " + BazyDanychcomboBox.SelectedItem.ToString() + ";Integrated Security=False;User ID = " + Logowanie.username + ";password = " + Logowanie.password;
                    }
                    else
                    {
                        Logowanie.PolaczenieString = "Data Source = " + Logowanie.serverName + ";Initial Catalog = " + BazyDanychcomboBox.SelectedItem.ToString() + ";Integrated Security=False;User ID = " + Logowanie.username + ";password = " + Logowanie.password;
                    }
                    Logowanie.sqlConnection = new SqlConnection(Logowanie.PolaczenieString);
                    Logowanie.sqlConnection.Open();
                }
            }
        }

        private void TabeladataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TabelaDoWyszukiwania.Visible = true;
            TabeladataGridView.Enabled = false;

            if (rowIndex < 0)
            {
                rowIndex = Int32.Parse(TabeladataGridView.CurrentCell.RowIndex.ToString());
            }
            else
            {
                TabeladataGridView.Rows[rowIndex].Cells[0].Style.BackColor = Color.White;
                rowIndex = Int32.Parse(TabeladataGridView.CurrentCell.RowIndex.ToString());
            }
            foreach (int[] gotoweindexy in listaIndex)
            {
                TabeladataGridView.Rows[gotoweindexy[2]].Cells[0].Style.BackColor = Color.LightGreen;
            }
            TabeladataGridView.CurrentCell.Style.BackColor = Color.LightCoral;

            string polecenieSQL = "SELECT COUNT(name) FROM " + BazyDanychcomboBox.SelectedItem.ToString() + ".INFORMATION_SCHEMA.TABLES,sysdatabases WHERE TABLE_NAME = '" + TabeladataGridView.CurrentCell.Value + "' AND name = '" + BazyDanychcomboBox.SelectedItem.ToString() + "';";
            SqlCommand sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
            SqlDataReader czytaj = sqlCommand.ExecuteReader();

            byte iloscTakichSamychTabel = 1;
            if (czytaj.Read())
            {
                iloscTakichSamychTabel = Convert.ToByte(czytaj.GetValue(0));
            }
            czytaj.Close();

            string schematTabeli = "";
            if (iloscTakichSamychTabel > 1)
            {
                ZdublowaneNazwyTabel zdublowaneTabele = new ZdublowaneNazwyTabel(BazyDanychcomboBox.SelectedItem.ToString(), TabeladataGridView.CurrentCell.Value.ToString());
                zdublowaneTabele.ShowDialog();
                schematTabeli = zdublowaneTabele.Get_typTabeli();
            }
            else
            {
                polecenieSQL = "SELECT TABLE_SCHEMA FROM " + BazyDanychcomboBox.SelectedItem.ToString() + ".INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + TabeladataGridView.CurrentCell.Value + "';";
                sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
                czytaj = sqlCommand.ExecuteReader();
                if (czytaj.Read())
                {
                    schematTabeli = czytaj.GetValue(0).ToString();
                }
                czytaj.Close();
            }

            polecenieSQL = "WITH IleKolumn AS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + TabeladataGridView.CurrentCell.Value + "' AND TABLE_SCHEMA = '" + schematTabeli + "') SELECT COUNT(*) FROM IleKolumn; ";
            sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
            czytaj = sqlCommand.ExecuteReader();
            short ileKolumn = 0;

            if (czytaj.Read())
            {
                ileKolumn = Convert.ToInt16(czytaj.GetValue(0));
            }
            czytaj.Close();
            if (ileKolumn > 0)
            {
                StringBuilder finalnePolecenieSQL = new StringBuilder();
                finalnePolecenieSQL.Append("SELECT ");

                string nazwyKolumn = "";
                int i = 1;
                SzukanieWynikow_progressBar.Visible = true;
                SzukanieWynikow_progressBar.Minimum = 0;
                SzukanieWynikow_progressBar.Maximum = ileKolumn;

                while (i <= ileKolumn)
                {
                    SzukanieWynikow_progressBar.Value = i;

                    polecenieSQL = "WITH NazwyKolumn AS (SELECT COLUMN_NAME, ROW_NUMBER() OVER (ORDER BY COLUMN_NAME) AS RowIndex FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + TabeladataGridView.CurrentCell.Value + "' AND TABLE_SCHEMA = '" + schematTabeli + "' )SELECT COLUMN_NAME FROM NazwyKolumn WHERE RowIndex = " + i + "; ";
                    sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
                    czytaj = sqlCommand.ExecuteReader();
                    if (czytaj.Read())
                    {
                        nazwyKolumn = czytaj.GetString(0);
                    }
                    czytaj.Close();
                    i++;


                    polecenieSQL = "SELECT DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + TabeladataGridView.CurrentCell.Value + "' AND COLUMN_NAME = '" + nazwyKolumn + " '";
                    sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
                    czytaj = sqlCommand.ExecuteReader();

                    string typ_danej = "";
                    if (czytaj.Read())
                    {
                        typ_danej = czytaj.GetValue(0).ToString();
                    }
                    czytaj.Close();

                    switch (typ_danej)
                    {
                        case "date":
                            {
                                finalnePolecenieSQL.Append(" CONVERT(VARCHAR(50)," + nazwyKolumn + ") AS " + nazwyKolumn + ",");
                                break;
                            }
                        case "datetime":
                            {
                                finalnePolecenieSQL.Append(" CONVERT(VARCHAR(50),CAST (" + nazwyKolumn + " AS BIGINT), 121) AS " + nazwyKolumn + ",");
                                break;
                            }
                        case "timestamp":
                            {
                                finalnePolecenieSQL.Append(" CONVERT(VARCHAR(50),CAST (" + nazwyKolumn + " AS BIGINT), 121) AS " + nazwyKolumn + ",");
                                break;
                            }
                        case "time":
                            {
                                finalnePolecenieSQL.Append(" CONVERT(VARCHAR(50)," + nazwyKolumn + ") AS " + nazwyKolumn + ",");
                                break;
                            }
                        case "year":
                            {
                                finalnePolecenieSQL.Append(" CONVERT(VARCHAR(50),CAST (" + nazwyKolumn + " AS BIGINT), 121) AS " + nazwyKolumn + ",");
                                break;
                            }
                        case "image":
                            {
                                finalnePolecenieSQL.Append("CONVERT(VARCHAR(max),CONVERT(varbinary(max)," + nazwyKolumn + ")) AS " + nazwyKolumn + ",");
                                break;
                            }
                        case "binary":
                            {
                                finalnePolecenieSQL.Append("CONVERT(VARCHAR(max)," + nazwyKolumn + ") AS " + nazwyKolumn + ",");
                                break;
                            }
                        case "varbinary":
                            {
                                finalnePolecenieSQL.Append("CONVERT(VARCHAR(max)," + nazwyKolumn + ") AS " + nazwyKolumn + ",");
                                break;
                            }
                        default:
                            {
                                if (nazwyKolumn.ToLower() == "group" || nazwyKolumn.ToLower() == "read")
                                {
                                    nazwyKolumn = "'" + nazwyKolumn + "' AS '" + nazwyKolumn + "'";
                                }
                                finalnePolecenieSQL.Append(nazwyKolumn + ",");
                                break;
                            }
                    }
                }
                finalnePolecenieSQL.Remove(finalnePolecenieSQL.Length - 1, 1);
                finalnePolecenieSQL.Append(" FROM " + BazyDanychcomboBox.SelectedItem.ToString() + "." + schematTabeli + "." + TabeladataGridView.CurrentCell.Value);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(finalnePolecenieSQL.ToString(), Logowanie.sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                TabelaDoWyszukiwania.DataSource = dataTable;
                SzukanieWynikow_progressBar.Visible = false;


                if (wartoscztextboxa != "")
                {
                    int j = 0;
                    int count = 0;
                    int firstIndex = 0;
                    bool checkFirstIndex = true;
                    foreach (string[] gotoweschematy in listaSchemat)
                    {
                        if (schematTabeli.Contains(gotoweschematy[0]) && TabeladataGridView.CurrentCell.Value.ToString().Contains(gotoweschematy[1]))
                        {
                            count++;
                            if (checkFirstIndex)
                            {
                                checkFirstIndex = false;
                                firstIndex = j;
                            }
                        }
                        j++;
                    }
                    if (count > 0)
                    {
                        j = 0;
                        foreach (int[] gotoweindexy in listaIndex)
                        {
                            if (!checkFirstIndex)
                            {
                                if (gotoweindexy[2] == TabeladataGridView.CurrentCell.RowIndex && j >= firstIndex && j < firstIndex+count)
                                {
                                    TabelaDoWyszukiwania.Rows[gotoweindexy[1]].Cells[gotoweindexy[0]].Style.BackColor = Color.LightBlue;
                                }
                            }
                            j++;
                        }
                    }
                }

                foreach (DataGridViewColumn column in TabelaDoWyszukiwania.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            else
            {
                SzukanieWynikow_progressBar.Visible = false;
                TabelaDoWyszukiwania.Visible = false;
                MessageBox.Show("PUSTA TABELA. BRAK COLUMN I DANYCH!");
            }
            TabeladataGridView.Enabled = true;
            TabeladataGridView.ClearSelection();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Wyszukaj_Click(object sender, EventArgs e)
        {
            if (BazyDanychcomboBox.SelectedIndex != -1 && BazyDanychcomboBox.SelectedItem.ToString() != "None")
            {
                Button_Wyszukaj.Enabled = false;
                znalezioneTextBox.Visible = false;
                TabeladataGridView.Visible = false;
                TabeladataGridView.Enabled = false;
                TabelaDoWyszukiwania.Visible = false;
                BazyDanychcomboBox.Enabled = false;
                WyszukiwanieTextBox.Enabled = false;
                WyszukiwanieTabelTextBox.Enabled = false;
                TabelaDoWyszukiwania.Visible = false;
                TabeleLabel.Visible = false;

                if (WyszukiwanieTextBox.Text.Replace(" ", "") == "" && WyszukiwanieTabelTextBox.Text.Replace(" ", "") == "")
                {
                    BazyDanychcomboBox.Enabled = true;
                    WyszukiwanieTextBox.Enabled = true;
                    WyszukiwanieTabelTextBox.Enabled = true;
                    MessageBox.Show("Nie wpisano nic!");
                    return;
                }
                if (checkedListBox_frazy.SelectedIndex == -1)
                {
                    MessageBox.Show("Nie wybrano żadnej opcji");
                    return;
                }

                string polecenieSQL = "SELECT COUNT( TABLE_NAME ) FROM " + BazyDanychcomboBox.SelectedItem.ToString() + ".INFORMATION_SCHEMA.TABLES;";
                SqlCommand sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
                SqlDataReader czytaj = sqlCommand.ExecuteReader();
                if (czytaj.Read())
                {
                    czytaj.Close();
                }
                else
                {
                    czytaj.Close();
                    MessageBox.Show("Ta baza danych nie posiada zadnych tabel!");
                    return;
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT DISTINCT TABLE_NAME FROM " + BazyDanychcomboBox.SelectedItem.ToString() + ".INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME", Logowanie.sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                TabeladataGridView.DataSource = dataTable;
                TabeladataGridView.Visible = true;
                TabeleLabel.Visible = true;
                int liczbaTabel = TabeladataGridView.Rows.Count;
                SzukanieWynikow_progressBar.Minimum = 0;
                SzukanieWynikow_progressBar.Maximum = liczbaTabel;
                SzukanieWynikow_progressBar.Visible = true;
                znalezioneElementy = 0;
                znalezioneTabele = 0;
                listaIndex = new List<int[]>();
                listaSchemat = new List<string[]>();
                wyszukiwanieTabelTextBox = WyszukiwanieTabelTextBox.Text.ToLower().Replace(" ", "");
                dlugoscTabelTextBox = wyszukiwanieTabelTextBox.Length;
                wartoscztextboxa = WyszukiwanieTextBox.Text.ToString().ToLower().Replace(" ", "");
                dlugoscztextboxa = wartoscztextboxa.Length;
                checkedListBox_frazy.Enabled = false;

                for (int i = 0; i < liczbaTabel; i++)
                {
                    TabeladataGridView.CurrentCell.Style.BackColor = Color.White;
                    TabeladataGridView.ClearSelection();
                    TabeladataGridView.CurrentCell = TabeladataGridView[0, i];
                }
                for (indexTabel = 0; indexTabel < liczbaTabel; indexTabel++)
                {
                    TabeladataGridView.ClearSelection();
                    TabeladataGridView.CurrentCell = TabeladataGridView[0, indexTabel];
                    SzukanieWynikow_progressBar.Value = indexTabel;
                    int LiczbaKolumn = 0;
                    string NazwaTabeli = TabeladataGridView.CurrentCell.Value.ToString().ToLower().Replace(" ", "");
                    int dlugoscNazwaTabeli = NazwaTabeli.Length;

                    polecenieSQL = "SELECT COUNT(name) FROM " + BazyDanychcomboBox.SelectedItem.ToString() + ".INFORMATION_SCHEMA.TABLES,sysdatabases WHERE TABLE_NAME = '" + TabeladataGridView.CurrentCell.Value + "' AND name = '" + BazyDanychcomboBox.SelectedItem.ToString() + "';";
                    sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
                    czytaj = sqlCommand.ExecuteReader();
                    byte iloscTakichSamychTabel = 1;

                    if (czytaj.Read())
                    {
                        iloscTakichSamychTabel = Convert.ToByte(czytaj.GetValue(0));
                    }
                    czytaj.Close();

                    string schematTabeli = "";
                    if (iloscTakichSamychTabel > 1)
                    {
                        if (wartoscztextboxa == "")
                        {
                            SzukanieTylkoPoTabeliZdublowane(dlugoscNazwaTabeli, dlugoscTabelTextBox, iloscTakichSamychTabel, NazwaTabeli, wyszukiwanieTabelTextBox);
                            continue;
                        }
                        else if (wyszukiwanieTabelTextBox == "")
                        {
                            WiecejNizJednaTabela(iloscTakichSamychTabel);
                            continue;
                        }
                        else
                        {
                            string tempNazwaTabeli;
                            if (dlugoscNazwaTabeli > dlugoscTabelTextBox)
                            {
                                tempNazwaTabeli = NazwaTabeli.Remove(dlugoscTabelTextBox);
                                if (tempNazwaTabeli.Contains(wyszukiwanieTabelTextBox))
                                {
                                    WiecejNizJednaTabela(iloscTakichSamychTabel);
                                    continue;
                                }
                            }
                            else if (dlugoscNazwaTabeli == dlugoscTabelTextBox)
                            {
                                if (NazwaTabeli.Contains(wyszukiwanieTabelTextBox))
                                {
                                    WiecejNizJednaTabela(iloscTakichSamychTabel);
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        polecenieSQL = "SELECT TABLE_SCHEMA FROM " + BazyDanychcomboBox.SelectedItem.ToString() + ".INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + TabeladataGridView.CurrentCell.Value + "';";
                        sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
                        czytaj = sqlCommand.ExecuteReader();
                        if (czytaj.Read())
                        {
                            schematTabeli = czytaj.GetValue(0).ToString();
                        }
                        czytaj.Close();
                    }
                    if (wartoscztextboxa == "")
                    {
                        SzukanieTylkoPoTabeliPojedyncze(dlugoscNazwaTabeli, dlugoscTabelTextBox, NazwaTabeli, wyszukiwanieTabelTextBox, schematTabeli);
                        continue;
                    }

                    polecenieSQL = "WITH IleKolumn AS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + TabeladataGridView.CurrentCell.Value + "' AND TABLE_SCHEMA = '" + schematTabeli + "') SELECT COUNT(*) FROM IleKolumn; ";
                    sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
                    czytaj = sqlCommand.ExecuteReader();

                    if (czytaj.Read())
                    {
                        LiczbaKolumn = Int32.Parse(czytaj.GetValue(0).ToString());
                    }
                    czytaj.Close();
                    if (LiczbaKolumn > 0)
                    {
                        StringBuilder finalnePolecenieSQL = new StringBuilder();
                        finalnePolecenieSQL.Append("SELECT ");

                        string nazwyKolumn = "";
                        int i = 1;

                        while (i <= LiczbaKolumn)
                        {

                            polecenieSQL = "WITH NazwyKolumn AS (SELECT COLUMN_NAME, ROW_NUMBER() OVER (ORDER BY COLUMN_NAME) AS RowIndex FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + TabeladataGridView.CurrentCell.Value + "' AND TABLE_SCHEMA = '" + schematTabeli + "' )SELECT COLUMN_NAME FROM NazwyKolumn WHERE RowIndex = " + i + "; ";
                            sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
                            czytaj = sqlCommand.ExecuteReader();
                            if (czytaj.Read())
                            {
                                nazwyKolumn = czytaj.GetString(0);
                            }
                            czytaj.Close();
                            i++;

                            polecenieSQL = "SELECT DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + TabeladataGridView.CurrentCell.Value + "' AND COLUMN_NAME = '" + nazwyKolumn + " '";
                            sqlCommand = new SqlCommand(polecenieSQL, Logowanie.sqlConnection);
                            czytaj = sqlCommand.ExecuteReader();

                            string typ_danej = "";
                            if (czytaj.Read())
                            {
                                typ_danej = czytaj.GetValue(0).ToString();
                                czytaj.Close();
                            }
                            else
                            {
                                czytaj.Close();
                            }

                            switch (typ_danej)
                            {
                                case "date":
                                    {
                                        finalnePolecenieSQL.Append(" CONVERT(VARCHAR(50)," + nazwyKolumn + ") AS " + nazwyKolumn + ",");
                                        break;
                                    }
                                case "datetime":
                                    {
                                        finalnePolecenieSQL.Append(" CONVERT(VARCHAR(50),CAST (" + nazwyKolumn + " AS BIGINT), 121) AS " + nazwyKolumn + ",");
                                        break;
                                    }
                                case "timestamp":
                                    {
                                        finalnePolecenieSQL.Append(" CONVERT(VARCHAR(50),CAST (" + nazwyKolumn + " AS BIGINT), 121) AS " + nazwyKolumn + ",");
                                        break;
                                    }
                                case "time":
                                    {
                                        finalnePolecenieSQL.Append(" CONVERT(VARCHAR(50)," + nazwyKolumn + ") AS " + nazwyKolumn + ",");
                                        break;
                                    }
                                case "year":
                                    {
                                        finalnePolecenieSQL.Append(" CONVERT(VARCHAR(50),CAST (" + nazwyKolumn + " AS BIGINT), 121) AS " + nazwyKolumn + ",");
                                        break;
                                    }
                                case "image":
                                    {
                                        finalnePolecenieSQL.Append("CONVERT(VARCHAR(max),CONVERT(varbinary(max)," + nazwyKolumn + ")) AS " + nazwyKolumn + ",");
                                        break;
                                    }
                                case "binary":
                                    {
                                        finalnePolecenieSQL.Append("CONVERT(VARCHAR(max)," + nazwyKolumn + ") AS " + nazwyKolumn + ",");
                                        break;
                                    }
                                case "varbinary":
                                    {
                                        finalnePolecenieSQL.Append("CONVERT(VARCHAR(max)," + nazwyKolumn + ") AS " + nazwyKolumn + ",");
                                        break;
                                    }
                                default:
                                    {
                                        if (nazwyKolumn.ToLower() == "group" || nazwyKolumn.ToLower() == "read")
                                        {
                                            nazwyKolumn = "'" + nazwyKolumn + "' AS '" + nazwyKolumn + "'";
                                        }
                                        finalnePolecenieSQL.Append(nazwyKolumn + ",");
                                        break;
                                    }
                            }
                        }
                        finalnePolecenieSQL.Remove(finalnePolecenieSQL.Length - 1, 1);
                        finalnePolecenieSQL.Append(" FROM " + BazyDanychcomboBox.SelectedItem.ToString() + "." + schematTabeli + "." + TabeladataGridView.CurrentCell.Value);

                        sqlDataAdapter = new SqlDataAdapter(finalnePolecenieSQL.ToString(), Logowanie.sqlConnection);
                        dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        TabelaDoWyszukiwania.DataSource = dataTable;
                    }
                    if (wyszukiwanieTabelTextBox == "")
                    {
                        if (checkedListBox_frazy.SelectedItem.ToString() == "Na początku")
                        {
                            SzukanieNaPoczątku(LiczbaKolumn, schematTabeli);
                        }
                        else if (checkedListBox_frazy.SelectedItem.ToString() == "W środku")
                        {
                            SzukanieSrodek(LiczbaKolumn, schematTabeli);
                        }
                        else if (checkedListBox_frazy.SelectedItem.ToString() == "Na końcu")
                        {
                            SzukanieNaKońcu(LiczbaKolumn, schematTabeli);
                        }
                    }
                    else
                    {
                        string tempNazwaTabeli;
                        if (dlugoscNazwaTabeli > dlugoscTabelTextBox)
                        {
                            tempNazwaTabeli = NazwaTabeli.Remove(dlugoscTabelTextBox);
                            if (tempNazwaTabeli.Contains(wyszukiwanieTabelTextBox))
                            {
                                if (checkedListBox_frazy.SelectedItem.ToString() == "Na początku")
                                {
                                    SzukanieNaPoczątku(LiczbaKolumn, schematTabeli);
                                }
                                else if (checkedListBox_frazy.SelectedItem.ToString() == "W środku")
                                {
                                    SzukanieSrodek(LiczbaKolumn, schematTabeli);
                                }
                                else if (checkedListBox_frazy.SelectedItem.ToString() == "Na końcu")
                                {
                                    SzukanieNaKońcu(LiczbaKolumn, schematTabeli);
                                }
                            }
                        }
                        else if (dlugoscNazwaTabeli == dlugoscTabelTextBox)
                        {
                            if (NazwaTabeli.Contains(wyszukiwanieTabelTextBox))
                            {
                                if (checkedListBox_frazy.SelectedItem.ToString() == "Na początku")
                                {
                                    SzukanieNaPoczątku(LiczbaKolumn, schematTabeli);
                                }
                                else if (checkedListBox_frazy.SelectedItem.ToString() == "W środku")
                                {
                                    SzukanieSrodek(LiczbaKolumn, schematTabeli);
                                }
                                else if (checkedListBox_frazy.SelectedItem.ToString() == "Na końcu")
                                {
                                    SzukanieNaKońcu(LiczbaKolumn, schematTabeli);
                                }
                            }
                        }
                    }
                }
                TabeladataGridView.Enabled = true;
                foreach (DataGridViewColumn column in TabeladataGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                if (wyszukiwanieTabelTextBox == "")
                {
                    znalezioneTextBox.Text = "Znalezione frazy: " + znalezioneElementy + " w " + znalezioneTabele + " tabelach";
                }
                else if (wartoscztextboxa == "")
                {
                    znalezioneTextBox.Text = "Znalezione tabele:" + znalezioneTabele;
                }
                else
                {
                    znalezioneTextBox.Text = "Znalezione frazy: " + znalezioneElementy + " w " + znalezioneTabele + " tabelach";
                }

                ExcelExport();

                znalezioneTextBox.Visible = true;
                BazyDanychcomboBox.Enabled = true;
                SzukanieWynikow_progressBar.Visible = false;
                WyszukiwanieTextBox.Enabled = true;
                WyszukiwanieTabelTextBox.Enabled = true;
                checkedListBox_frazy.Enabled = true;
                Button_Wyszukaj.Enabled = true;
            }
            else
            {
                MessageBox.Show("Nie wybrano bazy danych");
            }
        }

        private void checkedListBox_frazy_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_frazy.Items.Count; i++)
            {
                if (checkedListBox_frazy.SelectedIndex != i)
                {
                    checkedListBox_frazy.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }
    }
}