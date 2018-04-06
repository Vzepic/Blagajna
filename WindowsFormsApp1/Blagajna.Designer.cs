namespace WindowsFormsApp1
{
    partial class Blagajna
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
            this.components = new System.ComponentModel.Container();
            this.OznakaBlagajne_cb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.VrstaKnjizenja_cb = new System.Windows.Forms.ComboBox();
            this.BrojDokumenta_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Datum_dtp = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Iznos_tb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PrimioUplatio_cb = new System.Windows.Forms.ComboBox();
            this.nova_apl17DataSet = new WindowsFormsApp1.nova_apl17DataSet();
            this.komitentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.komitentTableAdapter = new WindowsFormsApp1.nova_apl17DataSetTableAdapters.komitentTableAdapter();
            this.label7 = new System.Windows.Forms.Label();
            this.OpisOsobe_tb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Opis_tb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.MjestoTroska_cb = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Konto_cb = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BrojFakture_tb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nova_apl17DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.komitentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OznakaBlagajne_cb
            // 
            this.OznakaBlagajne_cb.FormattingEnabled = true;
            this.OznakaBlagajne_cb.Location = new System.Drawing.Point(142, 106);
            this.OznakaBlagajne_cb.Name = "OznakaBlagajne_cb";
            this.OznakaBlagajne_cb.Size = new System.Drawing.Size(266, 21);
            this.OznakaBlagajne_cb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Blagajna";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vrsta knjiženja";
            // 
            // VrstaKnjizenja_cb
            // 
            this.VrstaKnjizenja_cb.FormattingEnabled = true;
            this.VrstaKnjizenja_cb.Location = new System.Drawing.Point(142, 152);
            this.VrstaKnjizenja_cb.Name = "VrstaKnjizenja_cb";
            this.VrstaKnjizenja_cb.Size = new System.Drawing.Size(266, 21);
            this.VrstaKnjizenja_cb.TabIndex = 2;
            // 
            // BrojDokumenta_tb
            // 
            this.BrojDokumenta_tb.Location = new System.Drawing.Point(142, 191);
            this.BrojDokumenta_tb.Name = "BrojDokumenta_tb";
            this.BrojDokumenta_tb.Size = new System.Drawing.Size(266, 20);
            this.BrojDokumenta_tb.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Broj dokumenta";
            // 
            // Datum_dtp
            // 
            this.Datum_dtp.Location = new System.Drawing.Point(142, 230);
            this.Datum_dtp.Name = "Datum_dtp";
            this.Datum_dtp.Size = new System.Drawing.Size(266, 20);
            this.Datum_dtp.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Datum dokumenta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Iznos";
            // 
            // Iznos_tb
            // 
            this.Iznos_tb.Location = new System.Drawing.Point(142, 266);
            this.Iznos_tb.Name = "Iznos_tb";
            this.Iznos_tb.Size = new System.Drawing.Size(266, 20);
            this.Iznos_tb.TabIndex = 8;
            this.Iznos_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Iznos_tb.TextChanged += new System.EventHandler(this.Iznos_tb_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Primio/Uplatio";
            // 
            // PrimioUplatio_cb
            // 
            this.PrimioUplatio_cb.DataSource = this.komitentBindingSource;
            this.PrimioUplatio_cb.DisplayMember = "naziv_1";
            this.PrimioUplatio_cb.FormattingEnabled = true;
            this.PrimioUplatio_cb.Location = new System.Drawing.Point(142, 306);
            this.PrimioUplatio_cb.Name = "PrimioUplatio_cb";
            this.PrimioUplatio_cb.Size = new System.Drawing.Size(266, 21);
            this.PrimioUplatio_cb.TabIndex = 11;
            // 
            // nova_apl17DataSet
            // 
            this.nova_apl17DataSet.DataSetName = "nova_apl17DataSet";
            this.nova_apl17DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // komitentBindingSource
            // 
            this.komitentBindingSource.DataMember = "komitent";
            this.komitentBindingSource.DataSource = this.nova_apl17DataSet;
            this.komitentBindingSource.CurrentChanged += new System.EventHandler(this.komitentBindingSource_CurrentChanged);
            // 
            // komitentTableAdapter
            // 
            this.komitentTableAdapter.ClearBeforeFill = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Opis osobe";
            // 
            // OpisOsobe_tb
            // 
            this.OpisOsobe_tb.Location = new System.Drawing.Point(142, 349);
            this.OpisOsobe_tb.Name = "OpisOsobe_tb";
            this.OpisOsobe_tb.Size = new System.Drawing.Size(266, 20);
            this.OpisOsobe_tb.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 390);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Opis";
            // 
            // Opis_tb
            // 
            this.Opis_tb.Location = new System.Drawing.Point(142, 387);
            this.Opis_tb.Name = "Opis_tb";
            this.Opis_tb.Size = new System.Drawing.Size(266, 20);
            this.Opis_tb.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 429);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Konto";
            // 
            // MjestoTroska_cb
            // 
            this.MjestoTroska_cb.DataSource = this.komitentBindingSource;
            this.MjestoTroska_cb.DisplayMember = "naziv_1";
            this.MjestoTroska_cb.FormattingEnabled = true;
            this.MjestoTroska_cb.Location = new System.Drawing.Point(142, 470);
            this.MjestoTroska_cb.Name = "MjestoTroska_cb";
            this.MjestoTroska_cb.Size = new System.Drawing.Size(266, 21);
            this.MjestoTroska_cb.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 473);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Konto";
            // 
            // Konto_cb
            // 
            this.Konto_cb.FormattingEnabled = true;
            this.Konto_cb.Location = new System.Drawing.Point(142, 429);
            this.Konto_cb.Name = "Konto_cb";
            this.Konto_cb.Size = new System.Drawing.Size(266, 21);
            this.Konto_cb.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Cursor = System.Windows.Forms.Cursors.Default;
            this.label11.Location = new System.Drawing.Point(423, 432);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Broj fakture";
            // 
            // BrojFakture_tb
            // 
            this.BrojFakture_tb.Location = new System.Drawing.Point(490, 429);
            this.BrojFakture_tb.Name = "BrojFakture_tb";
            this.BrojFakture_tb.Size = new System.Drawing.Size(263, 20);
            this.BrojFakture_tb.TabIndex = 21;
            // 
            // Blagajna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 551);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.BrojFakture_tb);
            this.Controls.Add(this.Konto_cb);
            this.Controls.Add(this.MjestoTroska_cb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Opis_tb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.OpisOsobe_tb);
            this.Controls.Add(this.PrimioUplatio_cb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Iznos_tb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Datum_dtp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BrojDokumenta_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.VrstaKnjizenja_cb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OznakaBlagajne_cb);
            this.Name = "Blagajna";
            this.Text = "Blagajna Ro-ze 2018";
            this.Load += new System.EventHandler(this.Blagajna_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nova_apl17DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.komitentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox OznakaBlagajne_cb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox VrstaKnjizenja_cb;
        private System.Windows.Forms.TextBox BrojDokumenta_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker Datum_dtp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Iznos_tb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox PrimioUplatio_cb;
        private nova_apl17DataSet nova_apl17DataSet;
        private System.Windows.Forms.BindingSource komitentBindingSource;
        private nova_apl17DataSetTableAdapters.komitentTableAdapter komitentTableAdapter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox OpisOsobe_tb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Opis_tb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox MjestoTroska_cb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox Konto_cb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox BrojFakture_tb;
    }
}

