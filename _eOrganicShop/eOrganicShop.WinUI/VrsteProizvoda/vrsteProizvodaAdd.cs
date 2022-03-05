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
    public partial class vrsteProizvodaAdd : UserControl
    {
        private APIService vrsteProizvodaService = new APIService("VrsteProizvoda");

        public vrsteProizvodaAdd()
        {
            InitializeComponent();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new VrsteProizvodaList());
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    var request = new VProizvodaUpsertRequest
                    {
                        Naziv = txtNazivProizvoda.Text

                    };
                    await vrsteProizvodaService.Insert<Model.VrsteProizvoda>(request);
                    MessageBox.Show("Uspješno ste dodali", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PanelHelper.SwapPanels(this.Parent, this, new VrsteProizvodaList());
                }
                catch
                {
                    MessageBox.Show("You don't have permission to do that!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       
        private void vrsteProizvodaAdd_Load(object sender, EventArgs e)
        {

        }

        private void txtNazivProizvoda_Validating_1(object sender, CancelEventArgs e)
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
