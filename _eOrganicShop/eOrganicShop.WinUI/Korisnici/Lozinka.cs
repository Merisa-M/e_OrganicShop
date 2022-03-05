using eOrganicShop.Model.Request;
using eOrganicShop.WinUI.Helper;
using eOrganicShop.WinUI.Main;
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
    public partial class Lozinka : UserControl
    {
        private readonly APIService korisnikService = new APIService("Korisnici");
        private readonly int _ID;
        public Lozinka(int ID)
        {
            _ID = ID;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            try
            {
                var korisnik = await korisnikService.GetById<Model.Korisnici>(_ID);
                KorisnikUpsertRequest request = null;
                if (txtLozinkaStara.Text == APIService.Password)
                {
                    request = new KorisnikUpsertRequest
                    {
                        Ime = korisnik.Ime,
                        Prezime = korisnik.Prezime,
                        KorisnickoIme = korisnik.KorisnickoIme,
                        Email = korisnik.Email,
                        Telefon = korisnik.Telefon,
                        Image = korisnik.Image,
                        Password = txtNovaLozinka.Text,
                        PasswordConfirmation = txtPotvrdiLozinku.Text
                    };
                }
                else
                {
                    MessageBox.Show("Lozinka nije ispravna!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtNovaLozinka.Text != txtPotvrdiLozinku.Text)
                {
                    MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await korisnikService.Update<Model.Korisnici>(_ID, request);

                MessageBox.Show("Uspjesno ste promijenili lozinku.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var form = new frmLogin();
                form.Show();
                ParentForm.Close();
            }
            catch
            {
                MessageBox.Show("Ups, something went wrong!");
            }
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new KorisnikEdit(_ID));

        }
    }
}
