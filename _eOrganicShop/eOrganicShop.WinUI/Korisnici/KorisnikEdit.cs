using eOrganicShop.Model.Request;
using eOrganicShop.WinUI.Helper;
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
    public partial class KorisnikEdit : UserControl
    {
        private readonly APIService korisnikService = new APIService("Korisnici");
        private readonly APIService ulogeService = new APIService("Uloge");
        private readonly int _ID;

        public KorisnikEdit(int ID)
        {
            _ID = ID;
            InitializeComponent();
        }
       

        private async void KorisnikEdit_Load(object sender, EventArgs e)
        {
            var korisnik = await korisnikService.GetById<Model.Korisnici>(_ID);

            txtIme.Text = korisnik.Ime;
            txtPrezime.Text = korisnik.Prezime;
            txtKorisnickoIme.Text = korisnik.KorisnickoIme;
            txtEmail.Text = korisnik.Email;
            txtTelefon.Text = korisnik.Telefon;


            if (korisnik.Image.Length > 3)
            {
                pbKorisnik.Image = ImageHelper.ByteArrayToSystemDrawing(korisnik.Image);
                pbKorisnik.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            var roles = await ulogeService.Get<List<Model.Uloge>>(null);
            clbUloge.DataSource = roles;
            clbUloge.ValueMember = "UlogaID";
            clbUloge.DisplayMember = "Naziv";

            var rolesList = clbUloge.Items.Cast<Model.Uloge>().Select(i => i.UlogaID).ToList();
            foreach (var korisnikUloge in korisnik.KorisnikUloge)
            {
                for (int i = 0; i < clbUloge.Items.Count; i++)
                {
                    if (rolesList[i] == korisnikUloge.UlogeID)
                    {
                        clbUloge.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new KorisniciList());
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            var user = await korisnikService.GetById<Model.Uloge>(_ID);
            if (ValidateChildren())
            {
                var ulogeList = clbUloge.CheckedItems.Cast<Model.Uloge>().Select(x => x.UlogaID).ToList();
                List<int> uncheckedUloge = new List<int>();
                for (int i = 0; i < clbUloge.Items.Count; i++)
                {
                    if (!clbUloge.GetItemChecked(i))
                    {
                        int UlogaID = clbUloge.Items.Cast<Model.Uloge>().ToList()[i].UlogaID;
                        uncheckedUloge.Add(UlogaID);
                    }
                }

                var request = new KorisnikUpsertRequest
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    KorisnickoIme = txtKorisnickoIme.Text,
                    Email = txtEmail.Text,
                    Telefon = txtTelefon.Text,
                    Image = pbKorisnik.Image != null ? ImageHelper.SystemDrawingToByteArray(pbKorisnik.Image) : null,
                    Uloge = ulogeList,
                    //UlogeToDelete = uncheckedRoles,
                    
                };

                await korisnikService.Update<Model.Korisnici>(_ID, request);
                MessageBox.Show("User have been updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PanelHelper.SwapPanels(this.Parent, this, new KorisniciList());
            }
        }
    }
}
