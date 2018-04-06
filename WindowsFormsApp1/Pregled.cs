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

        public Pregled()
        {
            InitializeComponent();
        }

        private void Pregled_Load(object sender, EventArgs e)
        {
            BazaZaPregled = new Database();
            BazaZaPregled.OpenConn("", "nova_apl17", "", "");

            for(int i=0;i<BrojBlagajni;i++)
            {
                OznakaBlagajne_cb.Items.Add("Blagajna " + i.ToString());
            }
            OznakaBlagajne_cb.SelectedIndex = 0;

            VrstaKnjizenja_cb.SelectedIndex = 0;
            //BazaZaPregled.OpenConn("ZERO\\NOWY", "nova_apl17", "Vjeko", "Vzepic3101");
        }

        private void Trazi_bt_Click(object sender, EventArgs e)
        {
            DataTable Prikaz = BazaZaPregled.DohvatiZaPregled(OznakaBlagajne_cb.SelectedIndex.ToString().PadLeft(2, '0'), VrstaKnjizenja_cb.SelectedIndex.ToString().PadLeft(2, '0'), DatumOd_dtp.Value, DatumDo_dtp.Value, IznosOperator_cb.Text, Convert.ToDouble(Iznos_tb.Text), PregledZa_cb.Text, Konto_cb.Text);
            foreach (DataRow Row in Prikaz.Rows)
            {
                Prikaz_dgv.Rows.Add(Row["OznakaBlagajne"].ToString().Trim(),Row["VrstaKnjizenja"].ToString().Trim(), Row["DatumDokumenta"].ToString().Trim(), Row["BrojDokumenta"].ToString().Trim(), Row["VrstaKnjizenja"].ToString().Trim()=="00"|| Row["VrstaKnjizenja"].ToString().Trim()=="01"? Row["Iznos"].ToString().Trim():"", Row["VrstaKnjizenja"].ToString().Trim() == "02" ? "-"+Row["Iznos"].ToString().Trim() : "", Row["Osoba"].ToString().Trim(), Row["Konto"].ToString().Trim(), Row["MjestoTroska"].ToString().Trim(), Row["BrojTemeljnice"].ToString().Trim(), Row["Opis"].ToString().Trim(), Row["id_gbbla"].ToString().Trim());
            }


        }

        private void Prikaz_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[1].Value.ToString());
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[2].Value.ToString());
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[3].Value.ToString());
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[4].Value.ToString()!=""? Convert.ToDouble(Prikaz_dgv.Rows[e.RowIndex].Cells[4].Value.ToString()) : Convert.ToDouble(Prikaz_dgv.Rows[e.RowIndex].Cells[5].Value.ToString())*-1);
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[6].Value.ToString());
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[7].Value.ToString());
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[9].Value.ToString());
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[10].Value.ToString());
            Povrat.Add(Prikaz_dgv.Rows[e.RowIndex].Cells[11].Value.ToString());
            BazaZaPregled.CloseConn();
            this.Close();
        }

        private void Print_bt_Click(object sender, EventArgs e)
        {
            DataTable Prikaz = BazaZaPregled.DohvatiZaPregled(OznakaBlagajne_cb.Text, VrstaKnjizenja_cb.Text, DatumOd_dtp.Value, DatumDo_dtp.Value, IznosOperator_cb.Text, Convert.ToDouble(Iznos_tb.Text), PregledZa_cb.Text, Konto_cb.Text);

            ReportForm Izvjesce = new ReportForm("C:\\Users\\sržepić\\source\\repos\\Blagajna\\WindowsFormsApp1\\IzvjestaqjBlagajne.rpt", Prikaz);
            Izvjesce.ShowDialog();
        }
    }
}
