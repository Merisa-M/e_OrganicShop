using Acr.UserDialogs;
using eOgranicShop.Mobile.Helpers;
using eOgranicShop.Mobile.Models;
using eOrganicShop.Model;
using eOrganicShop.Model.Request;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eOgranicShop.Mobile.ViewModels
{
    public class KupiProizvodVM : BaseViewModel
    {
        private readonly APIService kupovineService = new APIService("Kupovine");
        private readonly APIService transakcijeService = new APIService("Transakcije");
        private readonly APIService stavkeService = new APIService("NarudzbaStavke");
        private readonly APIService narudzbaService = new APIService("Narudzba");


        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        public KupiProizvodVM()
        {
            SubmitCommand = new Command(async () => await Kupovina());
        }
        
        //public KupiProizvodVM(INavigation nav)
        //{
        //    this.Navigation = nav;
        //    SubmitCommand = new Command(async () => await Kupovina());
        //}

        private readonly INavigation Navigation;
        public Proizvodi Proizvod { get; set; }

        private string StripeTestApiKey = "pk_test_51ITsWFJhqfSL3GBcw3lQq0WwQqPGbri16hs24aIootbfGr4U2bHqzpNCc5oexs9hOf7wxVusWxr70YDc06xvlDdL00CejvATXy";

        private CreditCard _creditCardModel;
        private TokenService Tokenservice;
        private Token stripeToken;
        private bool _isCarcValid;
        private bool _isTransectionSuccess;
        private string _expMonth;
        private string _expYear;
        private string _title;
        private string _number;
        private string _cvc;

        Korisnici korisnik = SignIn.Korisnik;
        public string Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
        }
        public string Cvc
        {
            get { return _cvc; }
            set { SetProperty(ref _cvc, value); }
        }
        public string ExpMonth
        {
            get { return _expMonth; }
            set { SetProperty(ref _expMonth, value); }
        }
        public bool IsCarcValid
        {
            get { return _isCarcValid; }
            set { SetProperty(ref _isCarcValid, value); }
        }
        public bool IsTransectionSuccess
        {
            get { return _isTransectionSuccess; }
            set { SetProperty(ref _isTransectionSuccess, value); }
        }
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public string ExpYear
        {
            get { return _expYear; }
            set { SetProperty(ref _expYear, value); }
        }
        public CreditCard CreditCardModel
        {
            get { return _creditCardModel; }
            set { SetProperty(ref _creditCardModel, value); }
        }

        float _iznos = 0;
        public float Iznos
        {
            get { return _iznos; }
            set { SetProperty(ref _iznos, value); }
        }

        int _narudzbaID = 0;
        public int NarudzbaID
        {
            get { return _narudzbaID; }
            set { SetProperty(ref _narudzbaID, value); }
        }

        public ICommand SubmitCommand { get; set; }
        private async Task<string> CreateTokenAsync()
        {
            try
            {
                StripeConfiguration.ApiKey = StripeTestApiKey;

                var Tokenoptions = new TokenCreateOptions()
                {
                    Card = new TokenCardOptions()
                    {
                        Number = CreditCardModel.Number,
                        ExpYear = CreditCardModel.ExpYear,
                        ExpMonth = CreditCardModel.ExpMonth,
                        Cvc = CreditCardModel.Cvc,
                        Name = korisnik.Ime + " " + korisnik.Prezime,
                        AddressLine1 = "Adresa bb",
                        AddressLine2 = "11",
                        AddressCity = "Mostar",
                        AddressZip = "88000",
                        AddressState = "Mostar1",
                        AddressCountry = "Bosna i Hercegovina",
                        Currency = "usd",
                    }
                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(Tokenoptions);
                return stripeToken.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> MakePaymentAsync(string token)
        {
            var narudzba = await narudzbaService.GetById<Narudzba>(NarudzbaID);

            try
            {
                StripeConfiguration.ApiKey = "sk_test_51ITsWFJhqfSL3GBcXqWrUGofCVqfLCVWlzB12obhiSRf50cr6HkFhs8pFMKw19AXwPqy1MxTmWpTHffMZLCYFQGI00dP6lZAJl";

                var options = new ChargeCreateOptions();

                options.Amount = Convert.ToInt64(Iznos) * 100;
                options.Currency = "usd";
                options.Description = narudzba.BrojNarudzbe;
                options.Source = stripeToken.Id;
                options.StatementDescriptor = "Custom descriptor";
                options.Capture = true;
                options.ReceiptEmail = korisnik.Email.ToString();
                var service = new ChargeService();
                Charge charge = service.Create(options);
                UserDialogs.Instance.Alert("Uspješna kupovina!");
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(narudzba.BrojNarudzbe + " (CreateCharge)" + ex.Message);
                throw ex;
            }
        }
        public async Task Kupovina()
        {
            var kupovine = await kupovineService.Get<List<Kupovine>>(null);
            var narudzba = await narudzbaService.GetById<Narudzba>(NarudzbaID);
            bool have = false;
            foreach (var x in kupovine)
                if (x.KorisnikID == korisnik.KorisnikID && NarudzbaID == x.NarudzbaID)
                    have = true;

            if (have == true)
            {
                await App.Current.MainPage.DisplayAlert("Information", "Proizvod je već kupljen!", "OK");
            }
            else
            {
                if (ExpMonth == null || ExpMonth == "" || ExpYear == null || ExpYear == "" || Number == null || Number == "" || Cvc == null || Cvc == "")
                {
                    UserDialogs.Instance.Alert("Morate popuniti sva polja", "Payment failed", "OK");
                    return;
                }
                if (ExpMonth != null || ExpMonth != "" || ExpYear != null || ExpYear != "" || Number != null || Number != "" || Cvc != null || Cvc != "")
                {
                    if (!IsDigitsOnly(ExpMonth) || !IsDigitsOnly(ExpMonth) || !IsDigitsOnly(Number) || !IsDigitsOnly(Cvc))
                    {
                        UserDialogs.Instance.Alert("Ne možete koristiti slova", "Greška prilikom kupovine", "OK");
                        return;
                    }
                }
                CreditCardModel = new CreditCard();
                CreditCardModel.ExpMonth = Convert.ToInt64(ExpMonth);
                CreditCardModel.ExpYear = Convert.ToInt64(ExpYear);
                CreditCardModel.Number = Number;
                CreditCardModel.Cvc = Cvc;
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                CancellationToken token = tokenSource.Token;
                try
                {
                    UserDialogs.Instance.ShowLoading("Učitavanje ...");
                    await Task.Run(async () =>
                    {
                        var Token = CreateTokenAsync();
                        Console.Write(narudzba.BrojNarudzbe + "Token :" + Token);
                        if (Token.ToString() != null)
                        {
                            IsTransectionSuccess = await MakePaymentAsync(Token.Result);
                        }
                        else
                        {
                            UserDialogs.Instance.Alert("Neispravni podaci o kartici", null, "OK");
                        }
                    });
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.Alert(ex.Message, null, "OK");
                    //Console.Write(Proizvod.NazivProizvoda + ex.Message);
                }
                finally
                {
                    if (IsTransectionSuccess)
                    {
                    
                        var kupovina = new KupovineUpsertRequest()
                        {
                            DatumKupovine = DateTime.Now,
                            NarudzbaID = NarudzbaID,
                            KorisnikID = korisnik.KorisnikID,
                            Cijena = Iznos,
                            KorisnickoIme = korisnik.KorisnickoIme,
                            NazivProizovda = narudzba.BrojNarudzbe,
                            StripeId = stripeToken.Id
                        };

                        var transakcija = new TransakcijeUpsertRequest
                        {
                            KorisnikID = korisnik.KorisnikID,
                            Cijena = Iznos,
                            DatumTranskacije = DateTime.Now,
                            NazivProizvoda = narudzba.BrojNarudzbe,
                            KorisnickoIme = korisnik.KorisnickoIme,
                            NarudzbaID = NarudzbaID,
                        };
                        await kupovineService.Insert<Kupovine>(kupovina);
                        await transakcijeService.Insert<Transakcije>(transakcija);
                        Console.Write(narudzba.BrojNarudzbe + "Kupovina uspješno završena");

                        UserDialogs.Instance.HideLoading();

                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        Console.Write(Proizvod.NazivProizvoda + "Greška ");
                    }
                }
            }
        }
    }
}
