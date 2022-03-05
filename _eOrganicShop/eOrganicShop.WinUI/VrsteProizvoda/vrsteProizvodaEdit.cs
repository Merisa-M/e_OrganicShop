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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eOrganicShop.WinUI.VrsteProizvoda
{
    public partial class vrsteProizvodaEdit : UserControl
    {
        private APIService vrsteProizvodaService = new APIService("VrsteProizvoda");
        private readonly int _ID;
        public vrsteProizvodaEdit(int ID)
        {
            _ID = ID;
            InitializeComponent();
        }

        private async void vrsteProizvodaEdit_Load(object sender, EventArgs e)
        {
            var vrste = await vrsteProizvodaService.GetById<Model.VrsteProizvoda>(_ID);
            txtNazivProizvoda.Text = vrste.Naziv;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new VrsteProizvodaList());
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            var korisnik = await vrsteProizvodaService.GetById<Model.VrsteProizvoda>(_ID);
            if (ValidateChildren())
            {

                var request = new VProizvodaUpsertRequest
                {
                    Naziv = txtNazivProizvoda.Text

                };

                await vrsteProizvodaService.Update<Model.VrsteProizvoda>(_ID, request);
                MessageBox.Show("Uspješo editovano.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PanelHelper.SwapPanels(this.Parent, this, new VrsteProizvodaList());
            }
        }
       
        private void txtNazivProizvoda_TextChanged(object sender, EventArgs e)
        {

        }

        private void vrsteProizvodaEdit_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazivProizvoda.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNazivProizvoda, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtNazivProizvoda, null);
            }
        }
    }
}
