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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eOrganicShop.WinUI.Korisnici
{
    public partial class KorisnikAdd : UserControl
    {

        private readonly APIService korisnikService = new APIService("Korisnici");
        private readonly APIService ulogaService = new APIService("Uloge");
        string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";

        public KorisnikAdd()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new KorisniciList());
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    var ulogeList = clbUloge.CheckedItems.Cast<Model.Uloge>().Select(i => i.UlogaID).ToList();

                    var request = new KorisnikUpsertRequest
                    {
                        Ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        KorisnickoIme = txtKorisnickoIme.Text,
                        Email = txtEmail.Text,
                        Telefon = txtTelefon.Text,
                        Password = txtLozinka.Text,
                        PasswordConfirmation = txtLozinkaPotvrdi.Text,
                        Image = pbSlika.Image != null ? ImageHelper.SystemDrawingToByteArray(pbSlika.Image) : null,
                        Uloge = ulogeList
                    };

                      await korisnikService.Insert<Model.Korisnici>(request);

                    MessageBox.Show("User added Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PanelHelper.SwapPanels(this.Parent, this, new KorisniciList());
                }
                catch
                {
                    MessageBox.Show("You don't have permission to do that!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtKorisnickoIme_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbSlika_Click(object sender, EventArgs e)
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

        private async void KorisnikAdd_Load(object sender, EventArgs e)
        {
            var ulogeList = await ulogaService.Get<List<Model.Uloge>>(null);
            clbUloge.DataSource = ulogeList;
            clbUloge.ValueMember = "UlogaID";
            clbUloge.DisplayMember = "Naziv";
        }

        private void clbUloge_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
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

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPrezime, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtPrezime, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
                bool isEmailValid = Regex.IsMatch(txtEmail.Text, emailPattern);
                if (isEmailValid == false)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtEmail, "Email nije u ispravnom formatu!");
                }
            }
        }
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            string telefon = txtTelefon.Text.ToString();
            if (string.IsNullOrWhiteSpace(txtTelefon.Text) || txtTelefon.Text.Length < 9 || txtTelefon.Text.Length > 9)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTelefon, "Mora sadržavati najvise 9 brojeva!");
            }
            else
            {
                errorProvider1.SetError(txtTelefon, null);
                if (IsDigitsOnly(telefon) == false)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtTelefon, "Ne možete koristiti slova!");
                }
                else
                {
                    errorProvider1.SetError(txtTelefon, null);
                }
            }
        }

        private void txtKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text) || txtKorisnickoIme.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtKorisnickoIme, "Najmanje 3 slova");
            }
            else
            {
                errorProvider1.SetError(txtKorisnickoIme, null);
            }
        }

        private void txtLozinka_Validating(object sender, CancelEventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            if (string.IsNullOrWhiteSpace(txtLozinka.Text))
            {
                errorProvider1.SetError(txtLozinka, Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                if (hasNumber.IsMatch(txtLozinka.Text) && hasUpperChar.IsMatch(txtLozinka.Text) && hasMinimum8Chars.IsMatch(txtLozinka.Text))
                {
                    errorProvider1.SetError(txtLozinka, null);
                }
                else
                {
                    errorProvider1.SetError(txtLozinka, "Lozinka treba da sadrzi velika i mala slova, brojeve i najmanje 8 karaktera!");
                    e.Cancel = true;

                }
            }
        }

        private void txtLozinkaPotvrdi_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLozinkaPotvrdi.Text))
            {
                errorProvider1.SetError(txtLozinkaPotvrdi, Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                if (txtLozinka.Text == txtLozinkaPotvrdi.Text)
                {
                    errorProvider1.SetError(txtLozinkaPotvrdi, null);
                }
                else
                {
                    errorProvider1.SetError(txtLozinkaPotvrdi, "Lozinke se ne podudaraju!");
                    e.Cancel = true;
                }
            }
        }

        private void btnSlika_Click(object sender, EventArgs e)
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
    }
}
