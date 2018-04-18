using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Pregled : Form
    {
        Database BazaZaPregled = new Database();
        public List<object> Povrat = new List<object>();
        public int BrojBlagajni = new int();
        public string ImeFirme;
        public string AdresaFirme;

        public Pregled()
        {
            InitializeComponent();
        }

        private void Pregled_Load(object sender, EventArgs e)
        {
            BazaZaPregled = new Database();
            BazaZaPregled.OpenConn("", "nova_apl17", "", "");
            //BazaZaPregled.OpenConn("ZERO\\NOWY", "nova_apl17", "Vjeko", "Vzepic3101");

            OznakaBlagajne_cb.Items.Add("");
            for (int i=0;i<BrojBlagajni;i++)
            {
                OznakaBlagajne_cb.Items.Add("Blagajna " + i.ToString());
            }
            OznakaBlagajne_cb.SelectedIndex = 0;

            VrstaKnjizenja_cb.SelectedIndex = 0;

            PregledZa_cb.Items.AddRange(BazaZaPregled.DohvatiOsobe().ToArray());

            IznosOperator_cb.SelectedIndex = 0;

            Iznos_tb.Text = "0";

            DatumOd_dtp.Value = BazaZaPregled.DohvatiMinDatum();
        }

        private void Trazi_bt_Click(object sender, EventArgs e)
        {
            Prikaz_dgv.Rows.Clear();
            DataTable Prikaz = BazaZaPregled.DohvatiZaPregled(OznakaBlagajne_cb.Text!=""?(OznakaBlagajne_cb.SelectedIndex-1).ToString().PadLeft(2, '0'):"", VrstaKnjizenja_cb.Text!=""? (VrstaKnjizenja_cb.SelectedIndex-1).ToString().PadLeft(2, '0'):"", DatumOd_dtp.Value, DatumDo_dtp.Value, IznosOperator_cb.Text, Convert.ToDouble(Iznos_tb.Text), PregledZa_cb.Text, Konto_cb.Text);
            foreach (DataRow Row in Prikaz.Rows)
            {
                Prikaz_dgv.Rows.Add(Row["OznakaBlagajne"].ToString().Trim(),Row["VrstaKnjizenja"].ToString().Trim(), Row["DatumDokumenta"].ToString().Trim(), Row["BrojDokumenta"].ToString().Trim(), Row["VrstaKnjizenja"].ToString().Trim()=="00"|| Row["VrstaKnjizenja"].ToString().Trim()=="01"? Row["Iznos"].ToString().Trim():"", Row["VrstaKnjizenja"].ToString().Trim() == "02" ? Row["Iznos"].ToString().Trim() : "", Row["Osoba"].ToString().Trim(), Row["Konto"].ToString().Trim(), Row["MjestoTroska"].ToString().Trim(), Row["BrojTemeljnice"].ToString().Trim(), Row["Opis"].ToString().Trim(), Row["id_gbbla"].ToString().Trim());
            }


        }

        private void Print_bt_Click(object sender, EventArgs e)
        {
            DataTable BlagajnaBaza_tbl = BazaZaPregled.DohvatiZaPregled(OznakaBlagajne_cb.Text != "" ? (OznakaBlagajne_cb.SelectedIndex - 1).ToString().PadLeft(2, '0') : "", VrstaKnjizenja_cb.Text != "" ? (VrstaKnjizenja_cb.SelectedIndex - 1).ToString().PadLeft(2, '0') : "", DatumOd_dtp.Value, DatumDo_dtp.Value, IznosOperator_cb.Text, Convert.ToDouble(Iznos_tb.Text), PregledZa_cb.Text, Konto_cb.Text);
            DataTable BlagajnaSaldo_tbl = BazaZaPregled.DohvatiSaldo(DatumOd_dtp.Value);

            BlagajnaBaza_tbl.TableName = "BlagajnaBaza_tbl";
            BlagajnaSaldo_tbl.TableName = "BlagajnaSaldo_tbl";
            DataSet Prikaz = new DataSet();
            Prikaz.Tables.Add(BlagajnaBaza_tbl);
            Prikaz.Tables.Add(BlagajnaSaldo_tbl);
            

            ReportForm Izvjesce = new ReportForm("C:\\Users\\Fooler\\Desktop\\Mama posao\\Blagajna\\Blagajna\\WindowsFormsApp1\\IzvjestajSaBazom.rpt", Prikaz, this.ImeFirme,this.AdresaFirme,this.DatumOd_dtp.Value,this.DatumDo_dtp.Value);

            /*double saldo = 0;
            string blagajna="";

            foreach (DataRow red in Prikaz.Rows)
            {
                if(red[0].ToString()!=blagajna)
                {
                    saldo = 0;
                    blagajna = red[0].ToString();
                }
                if(red.ItemArray[1].ToString()=="00")
                {
                    red[1]= "POC";
                    saldo += Convert.ToDouble(red[4]);
                }
                else if (red.ItemArray[1].ToString() == "01")
                {
                    red.ItemArray[1] = "UPL";
                    saldo += Convert.ToDouble(red[4]);
                }
                else if (red.ItemArray[1].ToString() == "02")
                {
                    red[1] = "ISP";
                    saldo -= Convert.ToDouble(red[4]);
                }

                ZaReport.Tables[0].Rows.Add(red[1], red[2], red[3], red[5], red[7], red[8], red[1] == "POC" || red[1] == "UPL" ? red[4]:"", red[1] == "ISP"?red[4]:"",saldo.ToString(),red[0]);
            }
            //ReportForm Izvjesce = new ReportForm("C:\\Users\\Fooler\\Desktop\\Mama posao\\Test\\Blagajna\\WindowsFormsApp1\\IzvjestajSaBazom.rpt", ZaReport.Tables[0],this.ImeFirme);
            ReportForm Izvjesce = new ReportForm("C:\\Users\\Fooler\\Desktop\\Mama posao\\Test\\Blagajna\\WindowsFormsApp1\\IzvjestajSaBazom.rpt", Prikaz, this.ImeFirme);*/
            Izvjesce.ShowDialog();
        }

        private void Prikaz_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[1].Value.ToString());
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[2].Value.ToString());
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[3].Value.ToString());
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[4].Value.ToString() != "" ? Convert.ToDouble(Prikaz_dgv.Rows[e.RowIndex].Cells[4].Value.ToString()) : Convert.ToDouble(Prikaz_dgv.Rows[e.RowIndex].Cells[5].Value.ToString()));
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[6].Value.ToString());
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[7].Value.ToString());
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[9].Value.ToString());
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[10].Value.ToString());
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[11].Value.ToString());
            BazaZaPregled.CloseConn();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable BlagajnaBaza_tbl = BazaZaPregled.DohvatiZaPregled(OznakaBlagajne_cb.Text != "" ? (OznakaBlagajne_cb.SelectedIndex - 1).ToString().PadLeft(2, '0') : "", VrstaKnjizenja_cb.Text != "" ? (VrstaKnjizenja_cb.SelectedIndex - 1).ToString().PadLeft(2, '0') : "", DatumOd_dtp.Value, DatumDo_dtp.Value, IznosOperator_cb.Text, Convert.ToDouble(Iznos_tb.Text), PregledZa_cb.Text, Konto_cb.Text);
            DataTable BlagajnaSaldo_tbl = BazaZaPregled.DohvatiSaldo(DatumOd_dtp.Value);

            BlagajnaBaza_tbl.TableName = "BlagajnaBaza_tbl";
            BlagajnaSaldo_tbl.TableName = "BlagajnaSaldo_tbl";
            DataSet Prikaz = new DataSet();
            Prikaz.Tables.Add(BlagajnaBaza_tbl);
            Prikaz.Tables.Add(BlagajnaSaldo_tbl);

            ReportForm Izvjesce = new ReportForm("C:\\Users\\Fooler\\Desktop\\Mama posao\\Blagajna\\Blagajna\\WindowsFormsApp1\\IspisBroja.rpt", Prikaz, this.ImeFirme, this.AdresaFirme, this.DatumOd_dtp.Value, this.DatumDo_dtp.Value);
            Izvjesce.ShowDialog();
        }
    }
}
