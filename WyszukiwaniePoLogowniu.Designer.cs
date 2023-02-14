namespace WyszukiwanieForm
{
    partial class WyszukiwaniePoLogowniu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabelaDoWyszukiwania = new System.Windows.Forms.DataGridView();
            this.BazyDanychcomboBox = new System.Windows.Forms.ComboBox();
            this.BazyDanychLabel = new System.Windows.Forms.Label();
            this.WyszukiwanieLabel = new System.Windows.Forms.Label();
            this.WyszukiwanieTextBox = new System.Windows.Forms.TextBox();
            this.TabeladataGridView = new System.Windows.Forms.DataGridView();
            this.znalezioneTextBox = new System.Windows.Forms.Label();
            this.SzukanieWynikow_progressBar = new System.Windows.Forms.ProgressBar();
            this.TabeleLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.WyszukiwanieTabelTextBox = new System.Windows.Forms.TextBox();
            this.WyszukiwanieTableLabel = new System.Windows.Forms.Label();
            this.Button_Wyszukaj = new System.Windows.Forms.Button();
            this.checkedListBox_frazy = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.TabelaDoWyszukiwania)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabeladataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TabelaDoWyszukiwania
            // 
            this.TabelaDoWyszukiwania.AllowUserToAddRows = false;
            this.TabelaDoWyszukiwania.AllowUserToDeleteRows = false;
            this.TabelaDoWyszukiwania.BackgroundColor = System.Drawing.SystemColors.Control;
            this.TabelaDoWyszukiwania.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TabelaDoWyszukiwania.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TabelaDoWyszukiwania.Location = new System.Drawing.Point(50, 110);
            this.TabelaDoWyszukiwania.Name = "TabelaDoWyszukiwania";
            this.TabelaDoWyszukiwania.ReadOnly = true;
            this.TabelaDoWyszukiwania.Size = new System.Drawing.Size(860, 340);
            this.TabelaDoWyszukiwania.TabIndex = 0;
            this.TabelaDoWyszukiwania.Visible = false;
            // 
            // BazyDanychcomboBox
            // 
            this.BazyDanychcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BazyDanychcomboBox.FormattingEnabled = true;
            this.BazyDanychcomboBox.Location = new System.Drawing.Point(125, 28);
            this.BazyDanychcomboBox.Name = "BazyDanychcomboBox";
            this.BazyDanychcomboBox.Size = new System.Drawing.Size(280, 21);
            this.BazyDanychcomboBox.TabIndex = 1;
            this.BazyDanychcomboBox.DropDown += new System.EventHandler(this.BazyDanychcomboBox_DropDown);
            this.BazyDanychcomboBox.DropDownClosed += new System.EventHandler(this.BazyDanychcomboBox_DropDownClosed);
            // 
            // BazyDanychLabel
            // 
            this.BazyDanychLabel.AutoSize = true;
            this.BazyDanychLabel.Location = new System.Drawing.Point(49, 31);
            this.BazyDanychLabel.Name = "BazyDanychLabel";
            this.BazyDanychLabel.Size = new System.Drawing.Size(70, 13);
            this.BazyDanychLabel.TabIndex = 2;
            this.BazyDanychLabel.Text = "Bazy Danych";
            // 
            // WyszukiwanieLabel
            // 
            this.WyszukiwanieLabel.AutoSize = true;
            this.WyszukiwanieLabel.Location = new System.Drawing.Point(16, 59);
            this.WyszukiwanieLabel.Name = "WyszukiwanieLabel";
            this.WyszukiwanieLabel.Size = new System.Drawing.Size(103, 13);
            this.WyszukiwanieLabel.TabIndex = 3;
            this.WyszukiwanieLabel.Text = "Wyszukiwanie Frazy";
            // 
            // WyszukiwanieTextBox
            // 
            this.WyszukiwanieTextBox.Location = new System.Drawing.Point(125, 56);
            this.WyszukiwanieTextBox.Name = "WyszukiwanieTextBox";
            this.WyszukiwanieTextBox.Size = new System.Drawing.Size(280, 20);
            this.WyszukiwanieTextBox.TabIndex = 4;
            // 
            // TabeladataGridView
            // 
            this.TabeladataGridView.AllowUserToAddRows = false;
            this.TabeladataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.TabeladataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.TabeladataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TabeladataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TabeladataGridView.Location = new System.Drawing.Point(930, 100);
            this.TabeladataGridView.MultiSelect = false;
            this.TabeladataGridView.Name = "TabeladataGridView";
            this.TabeladataGridView.ReadOnly = true;
            this.TabeladataGridView.Size = new System.Drawing.Size(242, 349);
            this.TabeladataGridView.TabIndex = 6;
            this.TabeladataGridView.Visible = false;
            this.TabeladataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TabeladataGridView_CellDoubleClick);
            // 
            // znalezioneTextBox
            // 
            this.znalezioneTextBox.AutoSize = true;
            this.znalezioneTextBox.ForeColor = System.Drawing.Color.Coral;
            this.znalezioneTextBox.Location = new System.Drawing.Point(499, 91);
            this.znalezioneTextBox.Name = "znalezioneTextBox";
            this.znalezioneTextBox.Size = new System.Drawing.Size(59, 13);
            this.znalezioneTextBox.TabIndex = 7;
            this.znalezioneTextBox.Text = "Znalezione";
            this.znalezioneTextBox.Visible = false;
            // 
            // SzukanieWynikow_progressBar
            // 
            this.SzukanieWynikow_progressBar.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.SzukanieWynikow_progressBar.Location = new System.Drawing.Point(180, 258);
            this.SzukanieWynikow_progressBar.Name = "SzukanieWynikow_progressBar";
            this.SzukanieWynikow_progressBar.Size = new System.Drawing.Size(600, 35);
            this.SzukanieWynikow_progressBar.TabIndex = 8;
            this.SzukanieWynikow_progressBar.Visible = false;
            // 
            // TabeleLabel
            // 
            this.TabeleLabel.AutoSize = true;
            this.TabeleLabel.Location = new System.Drawing.Point(1008, 84);
            this.TabeleLabel.Name = "TabeleLabel";
            this.TabeleLabel.Size = new System.Drawing.Size(95, 13);
            this.TabeleLabel.TabIndex = 5;
            this.TabeleLabel.Text = "Tabele do Wyboru";
            this.TabeleLabel.Visible = false;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 5);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 9;
            this.BackButton.Text = "<";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // WyszukiwanieTabelTextBox
            // 
            this.WyszukiwanieTabelTextBox.Location = new System.Drawing.Point(125, 84);
            this.WyszukiwanieTabelTextBox.Name = "WyszukiwanieTabelTextBox";
            this.WyszukiwanieTabelTextBox.Size = new System.Drawing.Size(280, 20);
            this.WyszukiwanieTabelTextBox.TabIndex = 10;
            // 
            // WyszukiwanieTableLabel
            // 
            this.WyszukiwanieTableLabel.AutoSize = true;
            this.WyszukiwanieTableLabel.Location = new System.Drawing.Point(18, 87);
            this.WyszukiwanieTableLabel.Name = "WyszukiwanieTableLabel";
            this.WyszukiwanieTableLabel.Size = new System.Drawing.Size(101, 13);
            this.WyszukiwanieTableLabel.TabIndex = 11;
            this.WyszukiwanieTableLabel.Text = "Wyszukiwanie tabel";
            // 
            // Button_Wyszukaj
            // 
            this.Button_Wyszukaj.Location = new System.Drawing.Point(411, 84);
            this.Button_Wyszukaj.Name = "Button_Wyszukaj";
            this.Button_Wyszukaj.Size = new System.Drawing.Size(68, 20);
            this.Button_Wyszukaj.TabIndex = 12;
            this.Button_Wyszukaj.Text = "Wyszukaj";
            this.Button_Wyszukaj.UseVisualStyleBackColor = true;
            this.Button_Wyszukaj.Click += new System.EventHandler(this.Button_Wyszukaj_Click);
            // 
            // checkedListBox_frazy
            // 
            this.checkedListBox_frazy.BackColor = System.Drawing.SystemColors.ControlLight;
            this.checkedListBox_frazy.FormattingEnabled = true;
            this.checkedListBox_frazy.Items.AddRange(new object[] {
            "Na początku",
            "W środku",
            "Na końcu"});
            this.checkedListBox_frazy.Location = new System.Drawing.Point(411, 27);
            this.checkedListBox_frazy.Name = "checkedListBox_frazy";
            this.checkedListBox_frazy.Size = new System.Drawing.Size(89, 49);
            this.checkedListBox_frazy.TabIndex = 13;
            this.checkedListBox_frazy.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_frazy_SelectedIndexChanged);
            // 
            // WyszukiwaniePoLogowniu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 461);
            this.Controls.Add(this.checkedListBox_frazy);
            this.Controls.Add(this.Button_Wyszukaj);
            this.Controls.Add(this.WyszukiwanieTableLabel);
            this.Controls.Add(this.WyszukiwanieTabelTextBox);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.SzukanieWynikow_progressBar);
            this.Controls.Add(this.znalezioneTextBox);
            this.Controls.Add(this.TabeladataGridView);
            this.Controls.Add(this.TabeleLabel);
            this.Controls.Add(this.WyszukiwanieTextBox);
            this.Controls.Add(this.WyszukiwanieLabel);
            this.Controls.Add(this.BazyDanychLabel);
            this.Controls.Add(this.BazyDanychcomboBox);
            this.Controls.Add(this.TabelaDoWyszukiwania);
            this.Name = "WyszukiwaniePoLogowniu";
            this.Text = "WyszukiwaniePoLogowniu";
            ((System.ComponentModel.ISupportInitialize)(this.TabelaDoWyszukiwania)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabeladataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TabelaDoWyszukiwania;
        private System.Windows.Forms.ComboBox BazyDanychcomboBox;
        private System.Windows.Forms.Label BazyDanychLabel;
        private System.Windows.Forms.Label WyszukiwanieLabel;
        private System.Windows.Forms.TextBox WyszukiwanieTextBox;
        private System.Windows.Forms.DataGridView TabeladataGridView;
        private System.Windows.Forms.Label znalezioneTextBox;
        private System.Windows.Forms.ProgressBar SzukanieWynikow_progressBar;
        private System.Windows.Forms.Label TabeleLabel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.TextBox WyszukiwanieTabelTextBox;
        private System.Windows.Forms.Label WyszukiwanieTableLabel;
        private System.Windows.Forms.Button Button_Wyszukaj;
        private System.Windows.Forms.CheckedListBox checkedListBox_frazy;
    }
}