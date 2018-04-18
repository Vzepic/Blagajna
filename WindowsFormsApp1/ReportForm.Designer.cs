namespace WindowsFormsApp1
{
    partial class ReportForm
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
            this.Izvjesce_crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // Izvjesce_crv
            // 
            this.Izvjesce_crv.ActiveViewIndex = -1;
            this.Izvjesce_crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Izvjesce_crv.Cursor = System.Windows.Forms.Cursors.Default;
            this.Izvjesce_crv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Izvjesce_crv.Location = new System.Drawing.Point(0, 0);
            this.Izvjesce_crv.Name = "Izvjesce_crv";
            this.Izvjesce_crv.Size = new System.Drawing.Size(831, 642);
            this.Izvjesce_crv.TabIndex = 0;
            this.Izvjesce_crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 642);
            this.Controls.Add(this.Izvjesce_crv);
            this.Name = "ReportForm";
            this.Text = "Izvješće";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer Izvjesce_crv;
        
    }
}