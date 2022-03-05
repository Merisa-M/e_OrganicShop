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
    public partial class ProizvodEdit : UserControl
    {
        private readonly APIService proizvodService = new APIService("Proizvodi");
        private readonly APIService vrsteService = new APIService("VrsteProizvoda");

        private Model.Korisnici _korisnik;
        private static int _proizvodID;
        public ProizvodEdit(Model.Korisnici korisnik, int proizvodID)
        {
            _korisnik = korisnik;
            _proizvodID = proizvodID;
            InitializeComponent();
        }
        private async void ProizvodEdit_Load(object sender, EventArgs e)
        {
            var proizvod = await proizvodService.GetById<Model.Proizvodi>(_proizvodID);
            var vrsta = await vrsteService.GetById<Model.VrsteProizvoda>(proizvod.VrstaProizvodaID);
            txtNazivProizvoda.Text = proizvod.NazivProizvoda;
            txtVrsta.Text = vrsta.Naziv;
            txtCijena.Text = proizvod.Cijena.ToString();
            txtOpis.Text = proizvod.Opis;
            txtSifra.Text = proizvod.Sifra;

            if (proizvod.Slika.Length > 3)
            {
                pbSlikaProizvoda.Image = ImageHelper.ByteArrayToSystemDrawing(proizvod.Slika);
                pbSlikaProizvoda.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            var proizvod = await proizvodService.GetById<Model.Proizvodi>(_proizvodID);
            var vrsta = await vrsteService.GetById<Model.VrsteProizvoda>(proizvod.VrstaProizvodaID);
            if (ValidateChildren())
            {

                var request = new ProizvodiUpsertRequest
                {
                    NazivProizvoda = txtNazivProizvoda.Text,
                    Sifra = txtSifra.Text,
                    Cijena = float.Parse(txtCijena.Text),
                    KorisnikID = proizvod.KorisnikID,
                    Opis = txtOpis.Text,
                    Slika = pbSlikaProizvoda.Image != null ? ImageHelper.SystemDrawingToByteArray(pbSlikaProizvoda.Image) : null,
                    VrstaProizvodaID = vrsta.VrsteProizvodaID,
                };
                await proizvodService.Update<Model.Proizvodi>(_proizvodID, request);
                MessageBox.Show("Proizvod uspješno editovan.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PanelHelper.SwapPanels(this.Parent, this, new ProizvodiList(_korisnik, proizvod));
            }
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            var proizvod = await proizvodService.GetById<Model.Proizvodi>(_proizvodID);
            PanelHelper.SwapPanels(this.Parent, this, new ProizvodiList(_korisnik, proizvod));
        }

        private void btnUcitajSliku_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.jpeg;*.gif;)|*.jpg;*.jpeg;*.gif;"
            };
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                pbSlikaProizvoda.SizeMode = PictureBoxSizeMode.StretchImage;
                pbSlikaProizvoda.Image = new Bitmap(openfd.FileName);
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
        bool DoesItContainComma(char c)
        {
            if (c != ',')
            {
                return true;
            }
            return false;
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if ((c < '0' || c > '9') && DoesItContainComma(c))
                    return false;
            }

            return true;

        }

        private void txtCijena_TextChanged(object sender, EventArgs e)
        {
          
        } 
    
       
        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            string cijena = txtCijena.Text.ToString();
            if (string.IsNullOrWhiteSpace(txtCijena.Text) || txtCijena.Text.Length < 1)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCijena, "Price field can't be empty!");
            }
            else
            {
                errorProvider1.SetError(txtCijena, null);
                if (IsDigitsOnly(cijena) == false)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtCijena, "You must use decimal numbers with comma or integer numbers!");
                }
                else
                {
                    errorProvider1.SetError(txtCijena, null);
                }
            }
        }

        private void txtOpis_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOpis.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtOpis, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtOpis, null);
            }
        }
    }
}
