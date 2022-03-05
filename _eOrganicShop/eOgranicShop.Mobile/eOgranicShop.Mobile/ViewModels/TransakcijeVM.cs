using eOgranicShop.Mobile.Helpers;
using eOrganicShop.Model;
using eOrganicShop.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eOgranicShop.Mobile.ViewModels
{

    public class TransakcijeVM : BaseViewModel
    {
        private readonly APIService transakcijeService = new APIService("Transakcije");
        private readonly APIService korisnikService = new APIService("Korisnici");
        private readonly APIService proizvodiService = new APIService("Proizvodi");
        private readonly APIService narudzbaService = new APIService("Narudzba");

        public ObservableCollection<Transakcije> TransactionList { get; set; } = new ObservableCollection<Transakcije>();

        public ICommand InitCommand { get; set; }

        public TransakcijeVM()
        {
            InitCommand = new Command(async () => await Init());
        }


        private string _brojNarudzbe;
        public string BrojNarudzbe
        {
            get { return _brojNarudzbe; }
            set
            {
                SetProperty(ref _brojNarudzbe, value);

            }
        }



        DateTime? _from = DateTime.Now;
        public DateTime From
        {
            get { return (DateTime)_from; }
            set
            {
                SetProperty(ref _from, value);
                if (value != null)
                    InitCommand.Execute(null);
            }
        }

        DateTime? _to = DateTime.Now;
        public DateTime To
        {
            get { return (DateTime)_to; }
            set
            {
                SetProperty(ref _to, value);
                if (value != null)
                    InitCommand.Execute(null);
            }
        }

        public async Task Init()
        {
            var KorisnikID = SignIn.Korisnik.KorisnikID;
            var req = new TransakcijeSearchRequest
            {
                KorisnikID = KorisnikID,
                From = _from,
                To = _to
            };
            if (TransactionList.Count() > 0)
            {
                TransactionList.Clear();
            }
            var list = await transakcijeService.Get<List<Transakcije>>(req);
            var user = await korisnikService.GetById<Korisnici>(KorisnikID);

            if (list.Count() != 0)
            {
                foreach (var x in list)
                {
                    var narudzba = await narudzbaService.GetById<Narudzba>(x.NarudzbaID);
                    BrojNarudzbe = narudzba.BrojNarudzbe;
                    TransactionList.Add(x);

                }
            }
        }
    }
    }

