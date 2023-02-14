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
    public partial class ZdublowaneNazwyTabel : Form
    {
        private string typTabeli;

        public void Set_typTabeli(string typ)
        {
            typTabeli = typ;
        }
        public string Get_typTabeli()
        {
            return typTabeli;
        }
        public ZdublowaneNazwyTabel(string BD, string NT)
        {
            InitializeComponent();
            string nazwaBazyDanych = BD;
            string nazwaTabeli = NT;

            string polecenieSQL = "SELECT name,TABLE_SCHEMA, TABLE_NAME FROM " + nazwaBazyDanych + ".INFORMATION_SCHEMA.TABLES, sysdatabases WHERE TABLE_NAME = '" + nazwaTabeli + "' AND name = '" + nazwaBazyDanych + "';";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(polecenieSQL, Logowanie.sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            ZdublowaneTabeledataGridView.DataSource = dataTable;
        }

        private void ZdublowaneTabeledataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ZdublowaneTabeledataGridView.CurrentRow.Index > -1 && e.RowIndex > -1)
            {
                Set_typTabeli(ZdublowaneTabeledataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
                this.Close();
            }
        }

        private void ZdublowaneTabeledataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int index = 0; index < ZdublowaneTabeledataGridView.Rows.Count; index++)
            {
                foreach (string[] gotoweschematy in WyszukiwaniePoLogowniu.listaSchemat)
                {
                    if (ZdublowaneTabeledataGridView.Rows[index].Cells[1].Value.ToString() == gotoweschematy[0] && ZdublowaneTabeledataGridView.Rows[index].Cells[2].Value.ToString() == gotoweschematy[1])
                    {
                        ZdublowaneTabeledataGridView.Rows[index].Cells[2].Style.BackColor = Color.LightGreen;
                        break;
                    }
                }
            }
        }
    }
}
