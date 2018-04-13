using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Blagajna : Form
    {
        public int BrojBlagajni = new int();
        public string NazivFirme;
        public string AdresaFirme;
        public bool StatusMjestatroska = new bool(); //varijable iz parametarske tablice

        public int ID = new int();
        /*public int VrstaKnjizenja = new int();
        public int OznakaBlagajne = new int();
        public int BrojDokumenta = new int();
        public DateTime DatumDokumenta = new DateTime();
        public double Iznos = new double();
        public string Osoba;
        public string OpisOsoba;
        public string Opis;
        public string Konto;
        public string BrojFakture;
        public string MjestoTroska;*/

        Database Baza = new Database();

        public Blagajna()
        {
            InitializeComponent();
        }

        private void InicijalizirajPolja(int VK)
        {
            VrstaKnjizenja_cb.SelectedIndex = VK;
            VrstaKnjizenja_cb.AutoCompleteSource = AutoCompleteSource.ListItems;
            VrstaKnjizenja_cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            BrojDokumenta_tb.Text = Baza.DohvatiBrojDokumenta(OznakaBlagajne_cb.SelectedIndex.ToString().PadLeft(2, '0'), VrstaKnjizenja_cb.SelectedIndex.ToString().PadLeft(2, '0')).ToString().PadLeft(4, '0');

            PrimioUplatio_cb.SelectedIndex = -1;

            OpisOsobe_tb.Clear();

            Opis_tb.Clear();

            Konto_cb.Items.Clear();
            Konto_cb.Text = "";

            Iznos_tb.Clear();

            MjestoTroska_lbl.Visible = false;
            MjestoTroska_cb.Visible = false;

            BrojFakture_lbl.Visible = false;
            BrojFakture_tb.Visible = false;

        }
        

        private void Blagajna_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("hr-HR");
            Baza.OpenConn("", "nova_apl17", "", "");//stavi local

            //ucitaj iz parametarske tablice podatke
            BrojBlagajni = 2;
            StatusMjestatroska = true;
            NazivFirme = "Ro-ze d.o.o";
            AdresaFirme = "Jukiceva 36";
            
            for(int i=0;i<BrojBlagajni;i++)
            {
                OznakaBlagajne_cb.Items.Add("Blagajna " + i.ToString());
            }
            OznakaBlagajne_cb.SelectedIndex = 0;

            Datum_dtp.Value = DateTime.Today;
            Datum_dtp.Format = DateTimePickerFormat.Custom;
            Datum_dtp.CustomFormat = "dd.MM.yyyy";

            InicijalizirajPolja(2);

            PrimioUplatio_cb.Items.AddRange(Baza.DohvatiOsobe().ToArray());

            MjestoTroska_cb.Items.AddRange(Baza.DohvatiMjestoTroska().ToArray());
        }

        private void Iznos_tb_Leave(object sender, EventArgs e)
        {
            if (Iznos_tb.Text != "")
                {
                    if (Convert.ToDouble(Iznos_tb.Text) == 0)
                    {
                        MessageBox.Show("Iznos ne smije biti 0");
                        Iznos_tb.Text = "";
                        Iznos_tb.Focus();
                        return;
                    }
                    Iznos_tb.Text = string.Format("{0:#,###.00}", Convert.ToDouble(Iznos_tb.Text));
                }
            else
            {
                MessageBox.Show("Iznos ne smije biti prazan");
                Iznos_tb.Focus();
            }
        }

        private void Iznos_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)13)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void VrstaKnjizenja_cb_Leave(object sender, EventArgs e)
        {
            int VrstaKnjizenja=Baza.DohvatiBrojDokumenta(OznakaBlagajne_cb.SelectedIndex.ToString().PadLeft(2,'0'),VrstaKnjizenja_cb.SelectedIndex.ToString().PadLeft(2,'0'));
            BrojDokumenta_tb.Text = VrstaKnjizenja.ToString().PadLeft(4, '0');
            
        }

        private void Konto_cb_Leave(object sender, EventArgs e)
        {
            int BrojZnamenkiKonta = Konto_cb.Text.Length;
            if (BrojZnamenkiKonta<4)
            {
                PrikazKonta Prikazi = new PrikazKonta(Konto_cb.Text);
                Prikazi.ShowDialog();
                Konto_cb.Text = Prikazi.KontoZaPrikaz;
                if((Konto_cb.Text[0]=='4' || Konto_cb.Text[0] == '7') && StatusMjestatroska)
                {
                    MjestoTroska_lbl.Visible = true;
                    MjestoTroska_cb.Visible = true;
                }// provjeri sta se kad prikazuje
            }
            else if (BrojZnamenkiKonta<8)
            {
                //kontroliram da li postoji u kontnom planu
            }
            else if (BrojZnamenkiKonta==8)
            {
                //kontroliram da li postoji u kontnom planu i veze na salda konti sa prve 2 12 ili 22
            }
        }

        private void Pregled_bt_Click(object sender, EventArgs e)
        {
            Pregled Pregledi = new Pregled();
            Pregledi.BrojBlagajni = this.BrojBlagajni;
            Pregledi.ImeFirme = this.NazivFirme;
            Pregledi.AdresaFirme = this.AdresaFirme;
            Pregledi.ShowDialog();
            if (Pregledi.Povrat.Count != 0)
            {
                OznakaBlagajne_cb.SelectedIndex = Convert.ToInt32(Pregledi.Povrat[0].ToString());
                VrstaKnjizenja_cb.SelectedIndex = Convert.ToInt32(Pregledi.Povrat[1].ToString());
                Datum_dtp.Value = Convert.ToDateTime(Pregledi.Povrat[2].ToString());
                BrojDokumenta_tb.Text = Pregledi.Povrat[3].ToString();
                Iznos_tb.Text = Pregledi.Povrat[4].ToString();
                PrimioUplatio_cb.Text = Pregledi.Povrat[5].ToString();
                Konto_cb.Text = Pregledi.Povrat[6].ToString();
                MjestoTroska_cb.Text = Pregledi.Povrat[7].ToString();
                Opis_tb.Text = Pregledi.Povrat[8].ToString();
                ID = Convert.ToInt32(Pregledi.Povrat[9]);
            }
        }

        private void Spremi_bt_Click(object sender, EventArgs e)
        {
            string Greska = Baza.UnesiUBazu(ID, OznakaBlagajne_cb.SelectedIndex.ToString().PadLeft(2, '0'), VrstaKnjizenja_cb.SelectedIndex.ToString().PadLeft(2, '0'), BrojDokumenta_tb.Text, Datum_dtp.Value, Convert.ToDouble(Iznos_tb.Text), PrimioUplatio_cb.Text, OpisOsobe_tb.Text, Opis_tb.Text, Konto_cb.Text, BrojFakture_tb.Text, MjestoTroska_cb.Text, "0000");
            InicijalizirajPolja(VrstaKnjizenja_cb.SelectedIndex);
            Iznos_tb.Focus();
        }

        private void Blagajna_FormClosing(object sender, FormClosingEventArgs e)
        {
            Baza.Renumeriraj();
            Baza.CloseConn();
        }
    }
}
