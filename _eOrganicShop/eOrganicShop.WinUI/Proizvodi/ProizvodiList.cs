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

namespace eOrganicShop.WinUI.Proizvodi
{
    public partial class ProizvodiList : UserControl
    {
        private APIService proizvodiService = new APIService("Proizvodi");
        private APIService vrsteproizvodiService = new APIService("VrsteProizvoda");
        private APIService korisniciService = new APIService("Korisnici");

        private static Model.Korisnici _korisnik;
        public static Model.Proizvodi _proizvod;

        public ProizvodiList( Model.Korisnici korisnici, Model.Proizvodi proizvodi)
        {
            _korisnik = korisnici;
            _proizvod = proizvodi;
            SignIn.Korisnik = _korisnik;
            InitializeComponent();
        }

        private async void ProizvodiList_Load(object sender, EventArgs e)
        {
           await LoadData();
        }
        private async Task LoadList(ProizvodiSearchRequest request)
        {
            var result = await proizvodiService.Get<List<Model.Proizvodi>>(request);
            dgvProizvodi.AutoGenerateColumns = false;
            dgvProizvodi.ReadOnly = true;
            dgvProizvodi.DataSource = result;
        }
        private async Task LoadData()
        {
            var result = await proizvodiService.Get<List<Model.Proizvodi>>(null);
            var subcategories = await vrsteproizvodiService.Get<List<Model.VrsteProizvoda>>(null);

            dgvProizvodi.AutoGenerateColumns = false;
            dgvProizvodi.ReadOnly = true;
            dgvProizvodi.DataSource = result;
        }
        private void dgvProizvodi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new ProizvodAdd(_korisnik, _proizvod));

        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            if (dgvProizvodi.CurrentRow != null)
            {
                int ID = Convert.ToInt32(dgvProizvodi.CurrentRow.Cells["ProizvodID"].Value);
                PanelHelper.SwapPanels(this.Parent, this, new ProizvodEdit(_korisnik, ID));
            }
        }

        private async void btnPretragaProizvoda_Click(object sender, EventArgs e)
        {
            var search = txtPretragaProizvoda.Text;
            if (search.StartsWith("Enter"))
            {
                search = "";
            }
            var request = new ProizvodiSearchRequest()
            {
                NazivProizvoda = search
            };
            await LoadList(request);
        }

        private void txtPretragaProizvoda_Enter(object sender, EventArgs e)
        {
            txtPretragaProizvoda.Clear();
            txtPretragaProizvoda.ForeColor = Color.Black;
        }

        private void txtPretragaProizvoda_Leave(object sender, EventArgs e)
        {
            if (txtPretragaProizvoda.Text == "")
            {
                txtPretragaProizvoda.Text = "naziv proizvoda";
                txtPretragaProizvoda.ForeColor = Color.Silver;
            }
        }

        private async void btnUkloni_Click(object sender, EventArgs e)
        {
            if (dgvProizvodi.CurrentRow != null)
            {
                var result = false;
                int ID = Convert.ToInt32(dgvProizvodi.CurrentRow.Cells["ProizvodID"].Value);
                if (MessageBox.Show("Da li ste sigurni?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    result = await proizvodiService.Delete<dynamic>(ID);
                }
                if (result == true)
                {
                    MessageBox.Show("Uspješno obrisano", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PanelHelper.SwapPanels(this.Parent, this, new ProizvodiList(_korisnik, _proizvod));
            }
        }
    }
}
