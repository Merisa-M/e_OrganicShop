using eOrganicShop.Model.Request;
using eOrganicShop.WinUI.Helper;
using eOrganicShop.WinUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eOrganicShop.WinUI.Proizvodi
{
    public partial class ProizvodAdd : UserControl
    {
        private APIService proizvodiService = new APIService("Proizvodi");
        private APIService vrsteproizvodiService = new APIService("VrsteProizvoda");
        private APIService korisniciService = new APIService("Korisnici");

        private static Model.Korisnici _korisnik;
        public static Model.Proizvodi _proizvod;
        public ProizvodAdd(Model.Korisnici korisnici, Model.Proizvodi proizvodi)
        {

            _korisnik = korisnici;
            _proizvod = proizvodi;
            InitializeComponent();
        }

        private async void ProizvodAdd_Load(object sender, EventArgs e)
        {
            var vrsta = await vrsteproizvodiService.Get<List<Model.VrsteProizvoda>>(null);
            vrsta.Insert(0, new Model.VrsteProizvoda());
            cbVrste.DataSource = vrsta;
            cbVrste.ValueMember = "VrsteProizvodaID";
            cbVrste.DisplayMember = "Naziv";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {

                var vrste = Convert.ToInt32(cbVrste.SelectedValue);

                var request = new ProizvodiUpsertRequest
                {
                    NazivProizvoda = txtNazivProizvoda.Text,
                    Cijena = Convert.ToInt32(txtCijena.Text),
                    Sifra = txtSifra.Text,
                    KorisnikID = _korisnik.KorisnikID,
                    Slika = pbSlikaProizvoda.Image != null ? ImageHelper.SystemDrawingToByteArray(pbSlikaProizvoda.Image) : null,
                    VrstaProizvodaID = vrste,
                };
                await proizvodiService.Insert<Model.Proizvodi>(request);
                MessageBox.Show("Proizvod dodan", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PanelHelper.SwapPanels(this.Parent, this, new ProizvodiList(_korisnik, _proizvod));
            }
        }

        private void txtNazivProizvoda_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazivProizvoda.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNazivProizvoda, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtNazivProizvoda, null);
            }
        }

        private void txtSifra_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSifra.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSifra, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtSifra, null);
            }
        }

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCijena.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCijena, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtCijena, null);
            }
        }

        private void cbVrste_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbVrste.Text))
            {
                MessageBox.Show("Odaberite vrstu");
            }

            else
            {

                errorProvider1.SetError(cbVrste, null);

            }
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new ProizvodiList(_korisnik, _proizvod));
        }
    }
}
