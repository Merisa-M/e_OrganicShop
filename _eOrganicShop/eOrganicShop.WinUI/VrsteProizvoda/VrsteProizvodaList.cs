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

namespace eOrganicShop.WinUI.VrsteProizvoda
{
    public partial class VrsteProizvodaList : UserControl
    {
        private readonly APIService vrsteProizvodaService = new APIService("VrsteProizvoda");

        public VrsteProizvodaList()
        {
            InitializeComponent();
        }
        private async Task LoadList()
        {
            var result = await vrsteProizvodaService.Get<List<Model.VrsteProizvoda>>(null);


            dgvVrsteProizvoda.AutoGenerateColumns = false;
            dgvVrsteProizvoda.ReadOnly = true;
            dgvVrsteProizvoda.DataSource = result;

        }
        private async void VrsteProizvodaList_Load(object sender, EventArgs e)
        {
            await LoadList();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new vrsteProizvodaAdd());
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            if (dgvVrsteProizvoda.CurrentRow != null)
            {
                int ID = Convert.ToInt32(dgvVrsteProizvoda.CurrentRow.Cells["VrsteProizvodaID"].Value);
                PanelHelper.SwapPanels(this.Parent, this, new vrsteProizvodaEdit(ID));
            }
        }

        private void dgvVrsteProizvoda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnUkloni_Click(object sender, EventArgs e)
        {
            if (dgvVrsteProizvoda.CurrentRow != null)
            {
                bool result = false;
                int ID = Convert.ToInt32(dgvVrsteProizvoda.CurrentRow.Cells["VrsteProizvodaID"].Value);

                if (MessageBox.Show("DA li ste sigurni?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    result = await vrsteProizvodaService.Delete<dynamic>(ID);
                }
                if (result == true)
                {
                    MessageBox.Show("Obrisano.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PanelHelper.SwapPanels(this.Parent, this, new VrsteProizvodaList());
            }
        }
    }
}
