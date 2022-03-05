using eOgranicShop.Mobile.Helpers;
using eOrganicShop.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eOgranicShop.Mobile.ViewModels
{
    public class UrediProfilVM:BaseViewModel
    {
        Korisnici _korisnik;
        public Korisnici User
        {
            get { return _korisnik; }
            set { SetProperty(ref _korisnik, value); }
        }

        byte[] slika;
        public byte[] Slika
        {
            get { return slika; }
            set { SetProperty(ref slika, value); }
        }

        public ICommand ChangeImage { get; set; }
        public ICommand SacuvajCommand { get; set; }
        public UrediProfilVM()
        {

        }
        public UrediProfilVM(Korisnici user)
        {
            Slika = user.Image;
            ChangeImage = new Command(async () => await OnTapped());
        }
        private async Task OnTapped()
        {
            Slika = await ImageHelper.UploadImage(Slika);
        }
    }
}
