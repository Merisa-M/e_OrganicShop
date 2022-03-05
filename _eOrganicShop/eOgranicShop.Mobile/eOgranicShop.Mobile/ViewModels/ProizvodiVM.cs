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
    public class ProizvodiVM:BaseViewModel
    {
        private readonly APIService korisnikService = new APIService("Korisnici");
        public ICommand LikeCommand { get; set; }

        private bool _isLiked;
        public bool IsLiked
        {
            get { return _isLiked; }
            set
            {
                _isLiked = value;
                OnPropertyChanged(nameof(IsLikedImage));
            }
        }
        public string IsLikedImage
        {
            get => IsLiked ? "heart.png" : "heart-empty.png";
        }



        private Proizvodi _proizvod;
        public Proizvodi Proizvod
        {
            get { return _proizvod; }
            set { SetProperty(ref _proizvod, value); }
        }

        public ProizvodiVM()
        {

        }
        public ProizvodiVM(Proizvodi proizvod)
        {
            Proizvod = proizvod;
            if (LikeHelper.FavProizvodi != null)
                IsLiked = LikeHelper.FavProizvodi.Find(i => i.ProizvodID == Proizvod.ProizvodID) != null;

            LikeCommand = new Command(async () => await ToggleLike());
        }

        private async Task ToggleLike()
        {
            try
            {
                if (IsLiked)
                {
                    await korisnikService.DeleteLikedProizvod(SignIn.Korisnik.KorisnikID, Proizvod.ProizvodID);
                    IsLiked = false;
                    LikeHelper.Remove(Proizvod);
                }
                else
                {
                    await korisnikService.InsertLikedProizvodi(SignIn.Korisnik.KorisnikID, Proizvod.ProizvodID);
                    IsLiked = true;
                    LikeHelper.FavProizvodi.Add(Proizvod);
                }
            }
            catch
            {

            }
        }
    }
}