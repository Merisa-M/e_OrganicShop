using eOrganicShop.Model.Request;
using eOrganicShop.WinUI.Helper;
using eOrganicShop.WinUI.Main;
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

namespace eOrganicShop.WinUI.Korisnici
{
    public partial class RacunEdit : UserControl
    {
        private readonly APIService korisnikService = new APIService("Korisnici");
        private readonly APIService ulogaService = new APIService("Uloge");

        private readonly int _ID;

        public RacunEdit(int ID)
        {
            _ID = ID;

            InitializeComponent();
        }

        private async void RacunEdit_Load(object sender, EventArgs e)
        {
            var korisnik = await korisnikService.GetById<Model.Korisnici>(_ID);


            txtIme.Text = korisnik.Ime;
            txtPrezime.Text = korisnik.Prezime;
            txtEmail.Text = korisnik.Email;
            txtTelefon.Text = korisnik.Telefon;
            txtKorisnickoIme.Text = korisnik.KorisnickoIme;

            var uloge = await ulogaService.Get<List<Model.Uloge>>(null);
            clbUloge.DataSource = uloge;
            clbUloge.ValueMember = "UlogaID";
            clbUloge.DisplayMember = "Naziv";
            clbUloge.SelectionMode = SelectionMode.None;

            if (korisnik.Image.Length > 3)
            {
                pbSlika.Image = ImageHelper.ByteArrayToSystemDrawing(korisnik.Image);
                pbSlika.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            var rolesList = clbUloge.Items.Cast<Model.Uloge>().Select(i => i.UlogaID).ToList();
            foreach (var userRole in korisnik.KorisnikUloge)
            {
                for (int i = 0; i < clbUloge.Items.Count; i++)
                {
                    if (rolesList[i] == userRole.UlogeID)
                    {
                        clbUloge.SetItemChecked(i, true);
                    }
                }
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            var user = await korisnikService.GetById<Model.Korisnici>(_ID);
            if (ValidateChildren())
            {
                var roleList = clbUloge.CheckedItems.Cast<Model.Uloge>().Select(x => x.UlogaID).ToList();
                var request = new KorisnikUpsertRequest
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    KorisnickoIme = txtKorisnickoIme.Text,
                    Email = txtEmail.Text,
                    Telefon = txtTelefon.Text,
                    Image = pbSlika.Image != null ? ImageHelper.SystemDrawingToByteArray(pbSlika.Image) : null,
                    Uloge = roleList

                };

                await korisnikService.Update<Model.Korisnici>(_ID, request);
                MessageBox.Show("Uspjesno editovano!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PanelHelper.SwapPanels(this.Parent, this, new Home());
            }
        }

        private void pbSlika_Click(object sender, EventArgs e)
        {

        }

        private void btnUcitajSliku_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.jpeg;*.gif;)|*.jpg;*.jpeg;*.gif;"
            };
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                pbSlika.SizeMode = PictureBoxSizeMode.StretchImage;
                pbSlika.Image = new Bitmap(openfd.FileName);
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new Home());

        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtIme, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtIme, null);
            }
        }

        private void btnLozinka_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new Lozinka(_ID));
        }
    }
}