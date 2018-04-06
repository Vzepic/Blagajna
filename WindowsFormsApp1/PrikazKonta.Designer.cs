namespace WindowsFormsApp1
{
    partial class PrikazKonta
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
            this.PrikazKonta_dgv = new System.Windows.Forms.DataGridView();
            this.Konto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NazivKonta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.PrikazKonta_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // PrikazKonta_dgv
            // 
            this.PrikazKonta_dgv.AllowUserToAddRows = false;
            this.PrikazKonta_dgv.AllowUserToDeleteRows = false;
            this.PrikazKonta_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PrikazKonta_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Konto,
            this.NazivKonta});
            this.PrikazKonta_dgv.Location = new System.Drawing.Point(4, 4);
            this.PrikazKonta_dgv.Name = "PrikazKonta_dgv";
            this.PrikazKonta_dgv.ReadOnly = true;
            this.PrikazKonta_dgv.RowHeadersVisible = false;
            this.PrikazKonta_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PrikazKonta_dgv.Size = new System.Drawing.Size(541, 276);
            this.PrikazKonta_dgv.TabIndex = 0;
            this.PrikazKonta_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PrikazKonta_dgv_CellDoubleClick);
            // 
            // Konto
            // 
            this.Konto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Konto.FillWeight = 30F;
            this.Konto.HeaderText = "Konto";
            this.Konto.Name = "Konto";
            this.Konto.ReadOnly = true;
            // 
            // NazivKonta
            // 
            this.NazivKonta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NazivKonta.FillWeight = 70F;
            this.NazivKonta.HeaderText = "Naziv konta";
            this.NazivKonta.Name = "NazivKonta";
            this.NazivKonta.ReadOnly = true;
            // 
            // PrikazKonta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 282);
            this.Controls.Add(this.PrikazKonta_dgv);
            this.Name = "PrikazKonta";
            this.Text = "PrikazKonta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrikazKonta_FormClosing);
            this.Load += new System.EventHandler(this.PrikazKonta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PrikazKonta_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PrikazKonta_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Konto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NazivKonta;
    }
}