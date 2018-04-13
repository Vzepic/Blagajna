namespace WindowsFormsApp1
{
    partial class Pregled
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.PregledZa_cb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.VrstaKnjizenja_cb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Iznos_tb = new System.Windows.Forms.TextBox();
            this.IznosOperator_cb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DatumOd_dtp = new System.Windows.Forms.DateTimePicker();
            this.DatumDo_dtp = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OznakaBlagajne_cb = new System.Windows.Forms.ComboBox();
            this.Konto_cb = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Prikaz_dgv = new System.Windows.Forms.DataGridView();
            this.Blagajna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Broj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Primitak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Izdatak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Podrijetlo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Konto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MjestoTroska = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temeljnica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trazi_bt = new System.Windows.Forms.Button();
            this.Print_bt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Prikaz_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pregled blagajne za:";
            // 
            // PregledZa_cb
            // 
            this.PregledZa_cb.FormattingEnabled = true;
            this.PregledZa_cb.Location = new System.Drawing.Point(136, 9);
            this.PregledZa_cb.Name = "PregledZa_cb";
            this.PregledZa_cb.Size = new System.Drawing.Size(291, 21);
            this.PregledZa_cb.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Vrsta knjiženja";
            // 
            // VrstaKnjizenja_cb
            // 
            this.VrstaKnjizenja_cb.FormattingEnabled = true;
            this.VrstaKnjizenja_cb.Items.AddRange(new object[] {
            "",
            "Početno stanje",
            "Uplatnica",
            "Isplatnica"});
            this.VrstaKnjizenja_cb.Location = new System.Drawing.Point(136, 36);
            this.VrstaKnjizenja_cb.Name = "VrstaKnjizenja_cb";
            this.VrstaKnjizenja_cb.Size = new System.Drawing.Size(291, 21);
            this.VrstaKnjizenja_cb.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(432, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Iznos";
            // 
            // Iznos_tb
            // 
            this.Iznos_tb.Location = new System.Drawing.Point(522, 7);
            this.Iznos_tb.Name = "Iznos_tb";
            this.Iznos_tb.Size = new System.Drawing.Size(266, 20);
            this.Iznos_tb.TabIndex = 3;
            this.Iznos_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // IznosOperator_cb
            // 
            this.IznosOperator_cb.FormattingEnabled = true;
            this.IznosOperator_cb.Items.AddRange(new object[] {
            "#",
            "=",
            ">",
            "=>",
            "<",
            "=<"});
            this.IznosOperator_cb.Location = new System.Drawing.Point(470, 7);
            this.IznosOperator_cb.Name = "IznosOperator_cb";
            this.IznosOperator_cb.Size = new System.Drawing.Size(46, 21);
            this.IznosOperator_cb.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Datum dokumenta od ";
            // 
            // DatumOd_dtp
            // 
            this.DatumOd_dtp.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DatumOd_dtp.Location = new System.Drawing.Point(136, 65);
            this.DatumOd_dtp.Name = "DatumOd_dtp";
            this.DatumOd_dtp.Size = new System.Drawing.Size(130, 20);
            this.DatumOd_dtp.TabIndex = 6;
            // 
            // DatumDo_dtp
            // 
            this.DatumDo_dtp.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DatumDo_dtp.Location = new System.Drawing.Point(297, 65);
            this.DatumDo_dtp.Name = "DatumDo_dtp";
            this.DatumDo_dtp.Size = new System.Drawing.Size(130, 20);
            this.DatumDo_dtp.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "do";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(432, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Blagajna";
            // 
            // OznakaBlagajne_cb
            // 
            this.OznakaBlagajne_cb.FormattingEnabled = true;
            this.OznakaBlagajne_cb.Location = new System.Drawing.Point(486, 34);
            this.OznakaBlagajne_cb.Name = "OznakaBlagajne_cb";
            this.OznakaBlagajne_cb.Size = new System.Drawing.Size(302, 21);
            this.OznakaBlagajne_cb.TabIndex = 5;
            // 
            // Konto_cb
            // 
            this.Konto_cb.FormattingEnabled = true;
            this.Konto_cb.Location = new System.Drawing.Point(486, 64);
            this.Konto_cb.Name = "Konto_cb";
            this.Konto_cb.Size = new System.Drawing.Size(302, 21);
            this.Konto_cb.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(433, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Konto";
            // 
            // Prikaz_dgv
            // 
            this.Prikaz_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Prikaz_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Blagajna,
            this.VK,
            this.Datum,
            this.Broj,
            this.Primitak,
            this.Izdatak,
            this.Podrijetlo,
            this.Konto,
            this.MjestoTroska,
            this.Temeljnica,
            this.Opis,
            this.ID});
            this.Prikaz_dgv.Location = new System.Drawing.Point(21, 107);
            this.Prikaz_dgv.Name = "Prikaz_dgv";
            this.Prikaz_dgv.RowHeadersVisible = false;
            this.Prikaz_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Prikaz_dgv.Size = new System.Drawing.Size(766, 258);
            this.Prikaz_dgv.TabIndex = 23;
            this.Prikaz_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Prikaz_dgv_CellClick);
            // 
            // Blagajna
            // 
            this.Blagajna.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Blagajna.FillWeight = 5F;
            this.Blagajna.HeaderText = "Blagajna";
            this.Blagajna.Name = "Blagajna";
            this.Blagajna.ReadOnly = true;
            // 
            // VK
            // 
            this.VK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VK.FillWeight = 5F;
            this.VK.HeaderText = "VK";
            this.VK.Name = "VK";
            this.VK.ReadOnly = true;
            // 
            // Datum
            // 
            this.Datum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Datum.DefaultCellStyle = dataGridViewCellStyle1;
            this.Datum.FillWeight = 10F;
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            // 
            // Broj
            // 
            this.Broj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Broj.FillWeight = 5F;
            this.Broj.HeaderText = "Broj";
            this.Broj.Name = "Broj";
            this.Broj.ReadOnly = true;
            // 
            // Primitak
            // 
            this.Primitak.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Primitak.FillWeight = 10F;
            this.Primitak.HeaderText = "Primitak";
            this.Primitak.Name = "Primitak";
            this.Primitak.ReadOnly = true;
            // 
            // Izdatak
            // 
            this.Izdatak.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Izdatak.FillWeight = 10F;
            this.Izdatak.HeaderText = "Izdatak";
            this.Izdatak.Name = "Izdatak";
            this.Izdatak.ReadOnly = true;
            // 
            // Podrijetlo
            // 
            this.Podrijetlo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Podrijetlo.FillWeight = 25F;
            this.Podrijetlo.HeaderText = "Komu / Od";
            this.Podrijetlo.Name = "Podrijetlo";
            this.Podrijetlo.ReadOnly = true;
            // 
            // Konto
            // 
            this.Konto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Konto.FillWeight = 5F;
            this.Konto.HeaderText = "Konto";
            this.Konto.Name = "Konto";
            this.Konto.ReadOnly = true;
            // 
            // MjestoTroska
            // 
            this.MjestoTroska.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MjestoTroska.FillWeight = 5F;
            this.MjestoTroska.HeaderText = "Mjesto troška";
            this.MjestoTroska.Name = "MjestoTroska";
            this.MjestoTroska.ReadOnly = true;
            // 
            // Temeljnica
            // 
            this.Temeljnica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Temeljnica.FillWeight = 5F;
            this.Temeljnica.HeaderText = "Temeljnica";
            this.Temeljnica.Name = "Temeljnica";
            this.Temeljnica.ReadOnly = true;
            // 
            // Opis
            // 
            this.Opis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Opis.FillWeight = 25F;
            this.Opis.HeaderText = "Opis";
            this.Opis.Name = "Opis";
            this.Opis.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Trazi_bt
            // 
            this.Trazi_bt.Location = new System.Drawing.Point(21, 381);
            this.Trazi_bt.Name = "Trazi_bt";
            this.Trazi_bt.Size = new System.Drawing.Size(93, 34);
            this.Trazi_bt.TabIndex = 9;
            this.Trazi_bt.Text = "Traži";
            this.Trazi_bt.UseVisualStyleBackColor = true;
            this.Trazi_bt.Click += new System.EventHandler(this.Trazi_bt_Click);
            // 
            // Print_bt
            // 
            this.Print_bt.Location = new System.Drawing.Point(136, 381);
            this.Print_bt.Name = "Print_bt";
            this.Print_bt.Size = new System.Drawing.Size(88, 34);
            this.Print_bt.TabIndex = 25;
            this.Print_bt.Text = "Izvjesće";
            this.Print_bt.UseVisualStyleBackColor = true;
            this.Print_bt.Click += new System.EventHandler(this.Print_bt_Click);
            // 
            // Pregled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Print_bt);
            this.Controls.Add(this.Trazi_bt);
            this.Controls.Add(this.Prikaz_dgv);
            this.Controls.Add(this.Konto_cb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.OznakaBlagajne_cb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DatumDo_dtp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DatumOd_dtp);
            this.Controls.Add(this.IznosOperator_cb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Iznos_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.VrstaKnjizenja_cb);
            this.Controls.Add(this.PregledZa_cb);
            this.Controls.Add(this.label1);
            this.Name = "Pregled";
            this.Text = "Pregled";
            this.Load += new System.EventHandler(this.Pregled_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Prikaz_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PregledZa_cb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox VrstaKnjizenja_cb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Iznos_tb;
        private System.Windows.Forms.ComboBox IznosOperator_cb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DatumOd_dtp;
        private System.Windows.Forms.DateTimePicker DatumDo_dtp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox OznakaBlagajne_cb;
        private System.Windows.Forms.ComboBox Konto_cb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView Prikaz_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Blagajna;
        private System.Windows.Forms.DataGridViewTextBoxColumn VK;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Broj;
        private System.Windows.Forms.DataGridViewTextBoxColumn Primitak;
        private System.Windows.Forms.DataGridViewTextBoxColumn Izdatak;
        private System.Windows.Forms.DataGridViewTextBoxColumn Podrijetlo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Konto;
        private System.Windows.Forms.DataGridViewTextBoxColumn MjestoTroska;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temeljnica;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opis;
        private System.Windows.Forms.Button Trazi_bt;
        private System.Windows.Forms.Button Print_bt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}