using eOrganicShop.Model.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eOrganicShop.WinUI.Main
{
    public partial class frmLogin : Form
    {
        private readonly APIService korisnikService = new APIService("Korisnici");
        public frmLogin()
        {
            InitializeComponent();
        }
        private void LoadPanel(Model.Korisnici korisnik)
        {
           
            var admin = korisnik.KorisnikUloge.Select(i => i.Uloge.Naziv).FirstOrDefault();
            if (admin == "Admin")
            {
                var form = new frmAdmin(korisnik);
                form.Show();
            }
            else
            {
                MessageBox.Show("Nije ispravan unos!");
                frmLogin frm = new frmLogin();
                frm.Show();
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            APIService.Username = txtKorisnickoIme.Text;
            APIService.Password = txtLozinka.Text;

            var request = new UserAuthenticationRequest()
            {
                Username = APIService.Username,
                Password = APIService.Password
            };

            var user = await korisnikService.Authenticate(request);

            if (user != null)
            {
                LoadPanel(user);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username Or Password!");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
