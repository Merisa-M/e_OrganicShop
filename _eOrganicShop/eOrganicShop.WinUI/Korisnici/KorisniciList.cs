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
    public partial class KorisniciList : UserControl
    {
        private readonly APIService korinsikService = new APIService("Korisnici");
        public KorisniciList korisnik { get; set; }

        public KorisniciList()
        {
            InitializeComponent();
        }
        private async Task LoadList(KorisnikSearchRequest request)
        {
            var result = await korinsikService.Get<List<Model.Korisnici>>(request);

            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.ReadOnly = true;
            dgvKorisnici.DataSource = result;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            var search = txtKorisnickoImePretraga.Text;
            if (search.StartsWith("Enter"))
            {
                search = "";
            }
            var request = new KorisnikSearchRequest()
            {
                KorisnickoIme = search
            };
            await LoadList(request);
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new KorisnikAdd());
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            if (dgvKorisnici.CurrentRow != null)
            {
                int ID = Convert.ToInt32(dgvKorisnici.CurrentRow.Cells["KorisnikID"].Value);
                PanelHelper.SwapPanels(this.Parent, this, new KorisnikEdit(ID));
            }
        }

        private async void btnUkloni_Click(object sender, EventArgs e)
        {
            if (dgvKorisnici.CurrentRow != null)
            {
                bool result = false;
                int ID = Convert.ToInt32(dgvKorisnici.CurrentRow.Cells["KorisnikID"].Value);

                if (MessageBox.Show("Da li ste sigurni?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (SignIn.Korisnik.KorisnikID == ID)
                    {
                        MessageBox.Show("Ne mozes sebe obrisati", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    result = await korinsikService.Delete<dynamic>(ID);
                }
                if (result == true)
                {
                    MessageBox.Show("Uspješno obrisano", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PanelHelper.SwapPanels(this.Parent, this, new KorisniciList());
            }
        }

        private void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void KorisniciList_Load(object sender, EventArgs e)
        {
            await LoadList();
        }
        private async Task LoadList()
        {
           var result = await korinsikService.Get<List<Model.Korisnici>>(null);

            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.ReadOnly = true;
            dgvKorisnici.DataSource = result;
        }

        private void txtKorisnickoImePretraga_Enter(object sender, EventArgs e)
        {
            txtKorisnickoImePretraga.Clear();
            txtKorisnickoImePretraga.ForeColor = Color.Black;
        }

        private void txtKorisnickoImePretraga_Leave(object sender, EventArgs e)
        {
            if (txtKorisnickoImePretraga.Text == "")
            {
                txtKorisnickoImePretraga.Text = "Unesi korisnicko ime";
                txtKorisnickoImePretraga.ForeColor = Color.Silver;
            }
        }
    }
}
