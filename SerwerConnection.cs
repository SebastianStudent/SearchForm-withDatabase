using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WyszukiwanieForm
{
    public partial class SerwerConnection : Form
    {
        public SerwerConnection()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Logowanie.username = UsernameTextBox.Text;
            Logowanie.password = PasswordTextBox.Text;
            this.Close();
        }
    }
}
