namespace WyszukiwanieForm
{
    partial class Logowanie
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginTextbox = new System.Windows.Forms.TextBox();
            this.HasloTextbox = new System.Windows.Forms.TextBox();
            this.LogowaniePrzycisk = new System.Windows.Forms.Button();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.HasloLabel = new System.Windows.Forms.Label();
            this.Zle_Haslo_Login = new System.Windows.Forms.Label();
            this.comboBox_Servers = new System.Windows.Forms.ComboBox();
            this.LabelSerwer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginTextbox
            // 
            this.LoginTextbox.Location = new System.Drawing.Point(100, 115);
            this.LoginTextbox.Name = "LoginTextbox";
            this.LoginTextbox.Size = new System.Drawing.Size(300, 20);
            this.LoginTextbox.TabIndex = 0;
            this.LoginTextbox.Visible = false;
            // 
            // HasloTextbox
            // 
            this.HasloTextbox.Location = new System.Drawing.Point(100, 180);
            this.HasloTextbox.Name = "HasloTextbox";
            this.HasloTextbox.PasswordChar = '*';
            this.HasloTextbox.Size = new System.Drawing.Size(300, 20);
            this.HasloTextbox.TabIndex = 1;
            this.HasloTextbox.Visible = false;
            // 
            // LogowaniePrzycisk
            // 
            this.LogowaniePrzycisk.Location = new System.Drawing.Point(200, 300);
            this.LogowaniePrzycisk.Name = "LogowaniePrzycisk";
            this.LogowaniePrzycisk.Size = new System.Drawing.Size(100, 40);
            this.LogowaniePrzycisk.TabIndex = 2;
            this.LogowaniePrzycisk.Text = "Login";
            this.LogowaniePrzycisk.UseVisualStyleBackColor = true;
            this.LogowaniePrzycisk.Visible = false;
            this.LogowaniePrzycisk.Click += new System.EventHandler(this.LogowaniePrzycisk_Click);
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Location = new System.Drawing.Point(59, 118);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(33, 13);
            this.LoginLabel.TabIndex = 3;
            this.LoginLabel.Text = "Login";
            this.LoginLabel.Visible = false;
            // 
            // HasloLabel
            // 
            this.HasloLabel.AutoSize = true;
            this.HasloLabel.Location = new System.Drawing.Point(59, 183);
            this.HasloLabel.Name = "HasloLabel";
            this.HasloLabel.Size = new System.Drawing.Size(34, 13);
            this.HasloLabel.TabIndex = 4;
            this.HasloLabel.Text = "Haslo";
            this.HasloLabel.Visible = false;
            // 
            // Zle_Haslo_Login
            // 
            this.Zle_Haslo_Login.AutoSize = true;
            this.Zle_Haslo_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Zle_Haslo_Login.ForeColor = System.Drawing.Color.Red;
            this.Zle_Haslo_Login.Location = new System.Drawing.Point(172, 210);
            this.Zle_Haslo_Login.Name = "Zle_Haslo_Login";
            this.Zle_Haslo_Login.Size = new System.Drawing.Size(156, 17);
            this.Zle_Haslo_Login.TabIndex = 5;
            this.Zle_Haslo_Login.Text = "*Bledny login lub haslo*";
            this.Zle_Haslo_Login.Visible = false;
            // 
            // comboBox_Servers
            // 
            this.comboBox_Servers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Servers.FormattingEnabled = true;
            this.comboBox_Servers.Location = new System.Drawing.Point(100, 44);
            this.comboBox_Servers.Name = "comboBox_Servers";
            this.comboBox_Servers.Size = new System.Drawing.Size(300, 21);
            this.comboBox_Servers.TabIndex = 6;
            this.comboBox_Servers.DropDownClosed += new System.EventHandler(this.comboBox_Servers_DropDownClosed);
            // 
            // LabelSerwer
            // 
            this.LabelSerwer.AutoSize = true;
            this.LabelSerwer.Location = new System.Drawing.Point(54, 47);
            this.LabelSerwer.Name = "LabelSerwer";
            this.LabelSerwer.Size = new System.Drawing.Size(40, 13);
            this.LabelSerwer.TabIndex = 8;
            this.LabelSerwer.Text = "Serwer";
            // 
            // Logowanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.LabelSerwer);
            this.Controls.Add(this.comboBox_Servers);
            this.Controls.Add(this.Zle_Haslo_Login);
            this.Controls.Add(this.HasloLabel);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.LoginTextbox);
            this.Controls.Add(this.HasloTextbox);
            this.Controls.Add(this.LogowaniePrzycisk);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "Logowanie";
            this.Text = "Logowanie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LogowaniePrzycisk;
        private System.Windows.Forms.TextBox HasloTextbox;
        private System.Windows.Forms.TextBox LoginTextbox;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label HasloLabel;
        private System.Windows.Forms.Label Zle_Haslo_Login;
        private System.Windows.Forms.ComboBox comboBox_Servers;
        private System.Windows.Forms.Label LabelSerwer;
    }
}

