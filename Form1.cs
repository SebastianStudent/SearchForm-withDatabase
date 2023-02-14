using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace WyszukiwanieForm
{
    public partial class Logowanie : Form
    {
        public static string PolaczenieString;
        public static string serverName;
        public static string instanceName;
        public static string username;
        public static string password;
        SqlDataSourceEnumerator instance;
        private static DataTable table;
        public static SqlConnection sqlConnection;
        public Logowanie()
        {
            InitializeComponent();
            instance = SqlDataSourceEnumerator.Instance;
            table = instance.GetDataSources();
            int maxSize = 0;


            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    if (col.ColumnName == "ServerName")
                    {
                        maxSize++;
                        comboBox_Servers.MaximumSize = MaximumSize;
                        serverName = row[col].ToString();
                    }
                    else if (col.ColumnName == "InstanceName")
                    {
                        comboBox_Servers.Items.Add(serverName + " " + row[col]);
                        break;
                    }
                }
            }
        }
        private void LogowaniePrzycisk_Click(object sender, EventArgs e)
        {
            StringBuilder strExeFilePath = new StringBuilder(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string fileName = Path.GetFileName(strExeFilePath.ToString());
            strExeFilePath.Remove(strExeFilePath.Length - fileName.Length, fileName.Length);
            strExeFilePath.Append("LogPlik.txt");
            string LogPlik_Sciezka = @strExeFilePath.ToString();
            if (!File.Exists(LogPlik_Sciezka))
            {
                MessageBox.Show("Brakuje pliku z hasłami !!!");
            }
            else
            {
                if (!(LoginTextbox.Text == "" || LoginTextbox.Text == null || HasloTextbox.Text == "" || HasloTextbox.Text == null))
                {
                    List<string> list_loginsANDpasswords = new List<string>();
                    string oneloginANDpassword = "";
                    try
                    {
                        FileStream readSourceStream = new FileStream(LogPlik_Sciezka, FileMode.Open, FileAccess.Read, FileShare.None);
                        StreamReader sr = new StreamReader(readSourceStream);
                        while (!sr.EndOfStream)
                        {
                            oneloginANDpassword = sr.ReadLine();
                            list_loginsANDpasswords.Add(oneloginANDpassword);
                        }
                        sr.Close();
                        readSourceStream.Close();
                        if (list_loginsANDpasswords.Count == 0)
                        {
                            MessageBox.Show("Plik jest pusty");
                        }
                        else
                        {
                            foreach (string container in list_loginsANDpasswords)
                            {
                                if (container.Replace(" ", "") == "" || container == null)
                                {
                                    MessageBox.Show("Błąd w pliku! Musi tam być przerwa, którą nie obsługuje program.");
                                    return;
                                }
                            }
                            bool check = false;
                            /* LOGINY I HASŁA SĄ ZASZYFROWANE
                             * login: password:
                             * admin admin123
                             * yes  no
                             * 123 321
                             * admin zaq1@WSX
                             */
                            foreach (string container in list_loginsANDpasswords)
                            {
                                if (container.Replace(" ", "") == LoginTextbox.Text.GetHashCode().ToString() + HasloTextbox.Text.GetHashCode().ToString())
                                {
                                    check = true;
                                    break;
                                }
                            }
                            if (check)
                            {
                                try
                                {
                                    WyszukiwaniePoLogowniu tabela = new WyszukiwaniePoLogowniu();
                                    LoginTextbox.Text = null;
                                    HasloTextbox.Text = null;
                                    comboBox_Servers.SelectedIndex = -1;
                                    LoginLabel.Visible = false;
                                    LoginTextbox.Visible = false;
                                    HasloLabel.Visible = false;
                                    HasloTextbox.Visible = false;
                                    LogowaniePrzycisk.Visible = false;
                                    Zle_Haslo_Login.Visible = false;
                                    this.Hide();
                                    tabela.ShowDialog();
                                    serverName = "";
                                    instanceName = "";
                                    username = "";
                                    password = "";
                                    PolaczenieString = "";
                                    this.Show();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Problem z : " + ex);
                                }
                            }
                            else
                            {
                                Zle_Haslo_Login.Visible = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Problem z FileStreamem lub StreamReaderem: " + ex);
                    }
                }
                else
                {
                    Zle_Haslo_Login.Visible = true;
                }
            }
        }
        private void comboBox_Servers_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox_Servers.SelectedIndex != -1)
            {
                bool check = false;
                foreach (DataRow row in table.Rows)
                {
                    if (check)
                    {
                        break;
                    }
                    foreach (DataColumn col in table.Columns)
                    {
                        string nazwaSerwera = comboBox_Servers.SelectedItem.ToString();
                        nazwaSerwera = nazwaSerwera.Remove(nazwaSerwera.IndexOf(" "));
                        if (col.ColumnName == "ServerName" && row[col].ToString() == nazwaSerwera)
                        {
                            serverName = row[col].ToString();
                            check = true;
                        }
                        else if (col.ColumnName == "InstanceName" && check)
                        {
                            instanceName = row[col].ToString();
                            break;
                        }
                    }
                }

                LoginLabel.Visible = true;
                LoginTextbox.Visible = true;
                HasloLabel.Visible = true;
                HasloTextbox.Visible = true;
                LogowaniePrzycisk.Visible = true;
                try
                {
                    PolaczenieString = "Data Source = " + serverName + "\\" + instanceName + ";Initial Catalog = master;Integrated Security=True";
                    sqlConnection = new SqlConnection(PolaczenieString);
                    sqlConnection.Open();
                }
                catch
                {
                    SerwerConnection serwerConnection = new SerwerConnection();
                    serwerConnection.ShowDialog();
                    if (instanceName != "")
                    {
                        PolaczenieString = "Data Source = " + serverName + "\\" + instanceName + ";Initial Catalog = master;Integrated Security=False;User ID = " + username + ";password = " + password;
                    }
                    else
                    {
                        PolaczenieString = "Data Source = " + serverName + ";Initial Catalog = master;Integrated Security=False;User ID = " + username + ";password = " + password;
                    }
                    sqlConnection = new SqlConnection(PolaczenieString);
                    try
                    {
                        sqlConnection.Open();
                    }
                    catch
                    {
                        LoginLabel.Visible = false;
                        LoginTextbox.Visible = false;
                        HasloLabel.Visible = false;
                        HasloTextbox.Visible = false;
                        LogowaniePrzycisk.Visible = false;
                        MessageBox.Show("Login ERROR");
                    }
                }
            }
            else
            {
                LoginLabel.Visible = false;
                LoginTextbox.Visible = false;
                HasloLabel.Visible = false;
                HasloTextbox.Visible = false;
                LogowaniePrzycisk.Visible = false;
            }
        }
    }
}
