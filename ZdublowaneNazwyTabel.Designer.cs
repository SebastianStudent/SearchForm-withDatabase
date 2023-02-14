namespace WyszukiwanieForm
{
    partial class ZdublowaneNazwyTabel
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
            this.Uwaga = new System.Windows.Forms.Label();
            this.ZdublowaneTabeledataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ZdublowaneTabeledataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Uwaga
            // 
            this.Uwaga.AutoSize = true;
            this.Uwaga.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Uwaga.Location = new System.Drawing.Point(121, 44);
            this.Uwaga.Name = "Uwaga";
            this.Uwaga.Size = new System.Drawing.Size(255, 36);
            this.Uwaga.TabIndex = 0;
            this.Uwaga.Text = "Uwaga. Ta nazwa tabeli się powtarza!\r\nZaznacz, którą tabelę masz na myśli";
            // 
            // ZdublowaneTabeledataGridView
            // 
            this.ZdublowaneTabeledataGridView.AllowUserToAddRows = false;
            this.ZdublowaneTabeledataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ZdublowaneTabeledataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ZdublowaneTabeledataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ZdublowaneTabeledataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ZdublowaneTabeledataGridView.Location = new System.Drawing.Point(12, 111);
            this.ZdublowaneTabeledataGridView.Name = "ZdublowaneTabeledataGridView";
            this.ZdublowaneTabeledataGridView.ReadOnly = true;
            this.ZdublowaneTabeledataGridView.Size = new System.Drawing.Size(476, 327);
            this.ZdublowaneTabeledataGridView.TabIndex = 1;
            this.ZdublowaneTabeledataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ZdublowaneTabeledataGridView_CellDoubleClick);
            this.ZdublowaneTabeledataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ZdublowaneTabeledataGridView_CellFormatting);
            // 
            // ZdublowaneNazwyTabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.ZdublowaneTabeledataGridView);
            this.Controls.Add(this.Uwaga);
            this.Name = "ZdublowaneNazwyTabel";
            this.Text = "ZdublowaneNazwyTabel";
            ((System.ComponentModel.ISupportInitialize)(this.ZdublowaneTabeledataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Uwaga;
        private System.Windows.Forms.DataGridView ZdublowaneTabeledataGridView;
    }
}