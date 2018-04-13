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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Blagajna));
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
            this.label7 = new System.Windows.Forms.Label();
            this.OpisOsobe_tb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Opis_tb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Konto_cb = new System.Windows.Forms.ComboBox();
            this.BrojFakture_lbl = new System.Windows.Forms.Label();
            this.BrojFakture_tb = new System.Windows.Forms.TextBox();
            this.Spremi_bt = new System.Windows.Forms.Button();
            this.MjestoTroska_cb = new System.Windows.Forms.ComboBox();
            this.MjestoTroska_lbl = new System.Windows.Forms.Label();
            this.Pregled_bt = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OznakaBlagajne_cb
            // 
            this.OznakaBlagajne_cb.FormattingEnabled = true;
            this.OznakaBlagajne_cb.Location = new System.Drawing.Point(490, 91);
            this.OznakaBlagajne_cb.Name = "OznakaBlagajne_cb";
            this.OznakaBlagajne_cb.Size = new System.Drawing.Size(134, 21);
            this.OznakaBlagajne_cb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Blagajna";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vrsta knjiženja";
            // 
            // VrstaKnjizenja_cb
            // 
            this.VrstaKnjizenja_cb.FormattingEnabled = true;
            this.VrstaKnjizenja_cb.Items.AddRange(new object[] {
            "Početno stanje",
            "Uplatnica",
            "Isplatnica"});
            this.VrstaKnjizenja_cb.Location = new System.Drawing.Point(109, 89);
            this.VrstaKnjizenja_cb.Name = "VrstaKnjizenja_cb";
            this.VrstaKnjizenja_cb.Size = new System.Drawing.Size(93, 21);
            this.VrstaKnjizenja_cb.TabIndex = 1;
            this.VrstaKnjizenja_cb.Leave += new System.EventHandler(this.VrstaKnjizenja_cb_Leave);
            // 
            // BrojDokumenta_tb
            // 
            this.BrojDokumenta_tb.Location = new System.Drawing.Point(322, 89);
            this.BrojDokumenta_tb.Name = "BrojDokumenta_tb";
            this.BrojDokumenta_tb.Size = new System.Drawing.Size(67, 20);
            this.BrojDokumenta_tb.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Broj dokumenta";
            // 
            // Datum_dtp
            // 
            this.Datum_dtp.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.Datum_dtp.Location = new System.Drawing.Point(141, 131);
            this.Datum_dtp.Name = "Datum_dtp";
            this.Datum_dtp.Size = new System.Drawing.Size(132, 20);
            this.Datum_dtp.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Datum dokumenta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(282, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Iznos";
            // 
            // Iznos_tb
            // 
            this.Iznos_tb.Location = new System.Drawing.Point(322, 129);
            this.Iznos_tb.Name = "Iznos_tb";
            this.Iznos_tb.Size = new System.Drawing.Size(94, 20);
            this.Iznos_tb.TabIndex = 4;
            this.Iznos_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Iznos_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Iznos_tb_KeyPress);
            this.Iznos_tb.Leave += new System.EventHandler(this.Iznos_tb_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Primio/Uplatio";
            // 
            // PrimioUplatio_cb
            // 
            this.PrimioUplatio_cb.FormattingEnabled = true;
            this.PrimioUplatio_cb.Location = new System.Drawing.Point(109, 185);
            this.PrimioUplatio_cb.Name = "PrimioUplatio_cb";
            this.PrimioUplatio_cb.Size = new System.Drawing.Size(224, 21);
            this.PrimioUplatio_cb.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(358, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Opis osobe";
            // 
            // OpisOsobe_tb
            // 
            this.OpisOsobe_tb.Location = new System.Drawing.Point(439, 184);
            this.OpisOsobe_tb.Name = "OpisOsobe_tb";
            this.OpisOsobe_tb.Size = new System.Drawing.Size(338, 20);
            this.OpisOsobe_tb.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(360, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Opis";
            // 
            // Opis_tb
            // 
            this.Opis_tb.Location = new System.Drawing.Point(439, 231);
            this.Opis_tb.Name = "Opis_tb";
            this.Opis_tb.Size = new System.Drawing.Size(338, 20);
            this.Opis_tb.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Konto";
            // 
            // Konto_cb
            // 
            this.Konto_cb.FormattingEnabled = true;
            this.Konto_cb.Location = new System.Drawing.Point(109, 230);
            this.Konto_cb.Name = "Konto_cb";
            this.Konto_cb.Size = new System.Drawing.Size(108, 21);
            this.Konto_cb.TabIndex = 8;
            this.Konto_cb.Leave += new System.EventHandler(this.Konto_cb_Leave);
            // 
            // BrojFakture_lbl
            // 
            this.BrojFakture_lbl.AutoSize = true;
            this.BrojFakture_lbl.Cursor = System.Windows.Forms.Cursors.Default;
            this.BrojFakture_lbl.Location = new System.Drawing.Point(223, 234);
            this.BrojFakture_lbl.Name = "BrojFakture_lbl";
            this.BrojFakture_lbl.Size = new System.Drawing.Size(61, 13);
            this.BrojFakture_lbl.TabIndex = 22;
            this.BrojFakture_lbl.Text = "Broj fakture";
            this.BrojFakture_lbl.Visible = false;
            // 
            // BrojFakture_tb
            // 
            this.BrojFakture_tb.Location = new System.Drawing.Point(285, 231);
            this.BrojFakture_tb.Name = "BrojFakture_tb";
            this.BrojFakture_tb.Size = new System.Drawing.Size(48, 20);
            this.BrojFakture_tb.TabIndex = 9;
            this.BrojFakture_tb.Visible = false;
            // 
            // Spremi_bt
            // 
            this.Spremi_bt.Location = new System.Drawing.Point(656, 273);
            this.Spremi_bt.Name = "Spremi_bt";
            this.Spremi_bt.Size = new System.Drawing.Size(121, 40);
            this.Spremi_bt.TabIndex = 23;
            this.Spremi_bt.Text = "Spremi";
            this.Spremi_bt.UseVisualStyleBackColor = true;
            this.Spremi_bt.Click += new System.EventHandler(this.Spremi_bt_Click);
            // 
            // MjestoTroska_cb
            // 
            this.MjestoTroska_cb.FormattingEnabled = true;
            this.MjestoTroska_cb.Location = new System.Drawing.Point(109, 270);
            this.MjestoTroska_cb.Name = "MjestoTroska_cb";
            this.MjestoTroska_cb.Size = new System.Drawing.Size(224, 21);
            this.MjestoTroska_cb.TabIndex = 10;
            this.MjestoTroska_cb.Visible = false;
            // 
            // MjestoTroska_lbl
            // 
            this.MjestoTroska_lbl.AutoSize = true;
            this.MjestoTroska_lbl.Location = new System.Drawing.Point(28, 273);
            this.MjestoTroska_lbl.Name = "MjestoTroska_lbl";
            this.MjestoTroska_lbl.Size = new System.Drawing.Size(74, 13);
            this.MjestoTroska_lbl.TabIndex = 24;
            this.MjestoTroska_lbl.Text = "Mjesto Troška";
            this.MjestoTroska_lbl.Visible = false;
            // 
            // Pregled_bt
            // 
            this.Pregled_bt.Location = new System.Drawing.Point(439, 273);
            this.Pregled_bt.Name = "Pregled_bt";
            this.Pregled_bt.Size = new System.Drawing.Size(121, 40);
            this.Pregled_bt.TabIndex = 26;
            this.Pregled_bt.Text = "Pregled";
            this.Pregled_bt.UseVisualStyleBackColor = true;
            this.Pregled_bt.Click += new System.EventHandler(this.Pregled_bt_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(209, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(373, 29);
            this.label10.TabIndex = 27;
            this.label10.Text = "UNOS UPLATNICA/ISPLATNICA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(656, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // Blagajna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 351);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Pregled_bt);
            this.Controls.Add(this.MjestoTroska_cb);
            this.Controls.Add(this.MjestoTroska_lbl);
            this.Controls.Add(this.Spremi_bt);
            this.Controls.Add(this.BrojFakture_lbl);
            this.Controls.Add(this.BrojFakture_tb);
            this.Controls.Add(this.Konto_cb);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Blagajna_FormClosing);
            this.Load += new System.EventHandler(this.Blagajna_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox OpisOsobe_tb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Opis_tb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox Konto_cb;
        private System.Windows.Forms.Label BrojFakture_lbl;
        private System.Windows.Forms.TextBox BrojFakture_tb;
        private System.Windows.Forms.Button Spremi_bt;
        private System.Windows.Forms.ComboBox MjestoTroska_cb;
        private System.Windows.Forms.Label MjestoTroska_lbl;
        private System.Windows.Forms.Button Pregled_bt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

