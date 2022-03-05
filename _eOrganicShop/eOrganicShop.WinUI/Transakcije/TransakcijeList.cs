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

namespace eOrganicShop.WinUI.Transakcije
{
    public partial class TransakcijeList : UserControl
    {
        private APIService transakcijaService = new APIService("Transakcije");
        private APIService korisnikService = new APIService("Korisnici");
        private APIService narudzbeService = new APIService("Narudzba");
        public TransakcijeList()
        {
            InitializeComponent();
        }

        private async void TransakcijeList_Load(object sender, EventArgs e)
        {
           await LoadList();
        }
        private async Task LoadList(TransakcijeSearchRequest request)
        {
            var result = await transakcijaService.Get<List<Model.Transakcije>>(request);
            dgvTransakcije.AutoGenerateColumns = false;
            dgvTransakcije.ReadOnly = true;
            dgvTransakcije.DataSource = result;
        }
        private async Task LoadList()
        {
            var result = await transakcijaService.Get<List<Model.Transakcije>>(null);
            var korisnici = await korisnikService.Get<List<Model.Korisnici>>(null);
            var narudzbe = await narudzbeService.Get<List<Model.Narudzba>>(null);

            korisnici.Insert(0, new Model.Korisnici { KorisnickoIme = "Svi korisnici" });
            cbKorisnici.DataSource = korisnici;
            cbKorisnici.DisplayMember = "KorisnickoIme";
            cbKorisnici.ValueMember = "KorisnikID";

            narudzbe.Insert(0, new Model.Narudzba {BrojNarudzbe="Sve narudzbe" });
            cbNarudzba.DataSource = narudzbe;
            cbNarudzba.DisplayMember = "BrojNarudzbe";
            cbNarudzba.ValueMember = "NarudzbaID";



            dgvTransakcije.AutoGenerateColumns = false;
            dgvTransakcije.ReadOnly = true;
            dgvTransakcije.DataSource = result;
        }

        private async void cbKorisnici_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.Korisnici korisnik;
            korisnik = cbKorisnici.SelectedItem as Model.Korisnici;
            var korisnikID = korisnik.KorisnikID;
            if (korisnik.KorisnickoIme == "Svi korisnici")
            {
                await LoadList(null);
            }
            else
            {
                var request = new TransakcijeSearchRequest()
                {
                    KorisnikID = korisnikID
                };
                await LoadList(request);
            }
        }

      

        private async void btnUkloni_Click(object sender, EventArgs e)
        {
            if (dgvTransakcije.CurrentRow != null)
            {
                var result = false;
                int ID = Convert.ToInt32(dgvTransakcije.CurrentRow.Cells["TransakcijaID"].Value);
                if (MessageBox.Show("Da li ste sigurni?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    result = await transakcijaService.Delete<dynamic>(ID);
                }
                if (result == true)
                {
                    MessageBox.Show("Uspjesno obrisano", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PanelHelper.SwapPanels(this.Parent, this, new TransakcijeList());
            }
        }

        private async void cbProizvodi_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            Model.Narudzba narudzba;
            narudzba = cbNarudzba.SelectedItem as Model.Narudzba;
            var narudzbaID = narudzba.NarudzbaID;
            if (narudzba.BrojNarudzbe == "Sve narudzbe")
            {
                await LoadList(null);
            }
            else
            {
                var request = new TransakcijeSearchRequest()
                {
                    NarudzbaID = narudzbaID
                };
                await LoadList(request);
            }

        }

        private void dgvTransakcije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
