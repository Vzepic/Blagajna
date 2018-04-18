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
        

        public ReportForm(string path,DataSet source,string ImeFirme,string AdresaFirme)
        {          
            InitializeComponent();
            cryRpt.Load(path);
            cryRpt.SetDataSource(source);
            cryRpt.SetParameterValue("NazivFirme", ImeFirme);
            cryRpt.SetParameterValue("AdresaFirme", AdresaFirme);
            Izvjesce_crv.ReportSource = cryRpt;
            //cryRpt.SetParameterValue("NazivFirme", ImeFirme);
            //Izvjesce_crv.RefreshReport();
        }
    }
}
