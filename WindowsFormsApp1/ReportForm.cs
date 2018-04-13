using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace WindowsFormsApp1
{
    public partial class ReportForm : Form
    {
        ReportDocument cryRpt = new ReportDocument();
        

        public ReportForm(string path,DataTable source,string ImeFirme)
        {
            cryRpt.Load(path);
            cryRpt.SetDataSource(source);
            cryRpt.SetParameterValue("ImeFirme", ImeFirme);
            InitializeComponent();
            Izvjesce_crv.ReportSource = cryRpt;
            Izvjesce_crv.RefreshReport();
        }
    }
}
