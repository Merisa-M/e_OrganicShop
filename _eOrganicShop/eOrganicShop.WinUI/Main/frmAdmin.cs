using eOrganicShop.WinUI.Helper;
using eOrganicShop.WinUI.Korisnici;
using eOrganicShop.WinUI.Proizvodi;
using eOrganicShop.WinUI.Transakcije;
using eOrganicShop.WinUI.VrsteProizvoda;
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
    public partial class frmAdmin : Form
    {
        private static Model.Korisnici _korisnik;
        private static Model.Proizvodi _proizvod;

        public frmAdmin(Model.Korisnici korisnik)
        {
            _korisnik = korisnik;
            SignIn.Korisnik = _korisnik;
            InitializeComponent();
        }

        private void Home_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHome_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            PanelHelper.AddPanel(ContentPanel, new Home());

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(ContentPanel);
            PanelHelper.AddPanel(ContentPanel, new KorisniciList());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(ContentPanel);
            PanelHelper.AddPanel(ContentPanel, new VrsteProizvodaList());
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            PanelHelper.AddPanel(ContentPanel, new Home());

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            PanelHelper.AddPanel(ContentPanel, new ProizvodiList(_korisnik, _proizvod));

        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            PanelHelper.AddPanel(ContentPanel, new TransakcijeList());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PanelHelper.AddPanel(ContentPanel, new RacunEdit(_korisnik.KorisnikID));

        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            var form = new frmLogin();
            form.Show();
            Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
