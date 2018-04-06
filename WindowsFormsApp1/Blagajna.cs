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
        public Blagajna()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("hr-HR");
            Datum_dtp.Value = DateTime.Today;
            Datum_dtp.Format = DateTimePickerFormat.Custom;
            Datum_dtp.CustomFormat = "dd.MM.yyyy";
        }

        private void Iznos_tb_TextChanged(object sender, EventArgs e)
        {
            Iznos_tb.Text = string.Format("{0:#,##0.00}", double.Parse(Iznos_tb.Text));
        }

        private void Blagajna_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nova_apl17DataSet.komitent' table. You can move, or remove it, as needed.
            this.komitentTableAdapter.Fill(this.nova_apl17DataSet.komitent);

        }

        private void komitentBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
