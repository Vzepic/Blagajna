using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PrikazKonta : Form
    {
        public string KontoZaPrikaz;

        public PrikazKonta(string Konto)
        {
            InitializeComponent();
            KontoZaPrikaz = Konto;
        }

        private void PrikazKonta_Load(object sender, EventArgs e)
        {
            Database BazaZaKonto = new Database();
            BazaZaKonto.OpenConn("", "nova_apl17", "", "");

            List<string> PopisKonta = BazaZaKonto.DohvatiKonto(KontoZaPrikaz);
            for(int i = 0;i<PopisKonta.Count;i++)
            {
                PrikazKonta_dgv.Rows.Add(PopisKonta[i], PopisKonta[i + 1]);
                i++;
            }
            BazaZaKonto.CloseConn();
        }

        private void PrikazKonta_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            KontoZaPrikaz = PrikazKonta_dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.Close();
        }



        private void PrikazKonta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (KontoZaPrikaz == string.Empty)
            {
                MessageBox.Show("Molim odaberite konto");
                e.Cancel = true;

            }
        }
    }
}
