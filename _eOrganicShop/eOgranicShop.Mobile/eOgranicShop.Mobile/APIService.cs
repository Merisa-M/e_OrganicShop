using eOrganicShop.Model;
using eOrganicShop.Model.Request;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eOgranicShop.Mobile
{
    public class APIService
    {
        private string _resource;
        public static Korisnici PrijavljeniKorisnik { get; set; }

        public static string Username { get; set; }
        public static string Password { get; set; }
        private readonly string ApiURL = "http://localhost:44318/api";

        public APIService(string resource)
        {
            _resource = resource;
        }

        public async System.Threading.Tasks.Task<eOrganicShop.Model.Korisnici> Authenticate(UserAuthenticationRequest request)
        {
            try
            {
                var url = $"{ApiURL}/Korisnici/Authenticate";

                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<Korisnici>();
            }
            catch (FlurlHttpException)
            {
                return default;
            }
        }
        public async Task<eOrganicShop.Model.Korisnici> Login(KorisnikUpsertRequest request)
        {
            try
            {
                var url = $"{ApiURL}/Korisnici/Login";
                return await url.PostJsonAsync(request).ReceiveJson<eOrganicShop.Model.Korisnici>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<T> Get<T>(object search)
        {
            var url = $"{ApiURL}/{_resource}";

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();

            }
            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        //public async Task<T> GetAll<T>(object searchRequest = null)
        //{
        //    var query = "";
        //    if (searchRequest != null)
        //    {
        //        query = await searchRequest?.ToQueryString();
        //    }

        //    var list = await $"{endpoint}{_resource}?{query}"
        //       .WithBasicAuth(Username, Password).GetJsonAsync<T>();

        //    return list;
        //}

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{ApiURL}/{_resource}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            try
            {

                var url = $"{ApiURL}/{_resource}";

                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
        public async Task<T> Update<T>(int ID, object request)
        {
            try
            {
                var url = $"{ApiURL}/{_resource}/{ID}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }

        public async Task<Narudzba> GetByBrojNarudzbe(string brNarudzbe)
        {
            //http://localhost:44318/api/Narudzba/GetByBrojNarudzbe?naziv=N006"
            var url = $"{ApiURL}/Narudzba/GetByBrojNarudzbe?naziv={brNarudzbe}";


            return await url.WithBasicAuth(Username, Password).GetJsonAsync<Narudzba>();
        }

        public async Task<bool> Delete<T>(int id)
        {
            try
            {
                var url = $"{ApiURL}/{_resource}/{id}";


                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<bool>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }

        public async Task<bool> Remove(int ID, string actionName = null)
        {
            var url = $"{ApiURL}/{_resource}";

            if (actionName != null)
                url += "/" + actionName;

            url += "/" + ID;

            return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<bool>();
        }

        public async Task<List<eOrganicShop.Model.Proizvodi>> GetRecommendedProizvodi(int ID)
        {
            try
            {
                var url = $"{ApiURL}/{_resource}/GetRecommendedProizvodi?KorisnikID={ID}";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<List<eOrganicShop.Model.Proizvodi>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<List<eOrganicShop.Model.Kupovine>> GetKupljeneProizvode(int ID)
        {
            try
            {
                var url = $"{ApiURL}/Korisnici/{ID}/GetKupljeneProizvode";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<List<eOrganicShop.Model.Kupovine>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<List<Proizvodi>> GetLikedProizvodi(int ID, ProizvodiSearchRequest search)
        {
            try
            {
                var url = $"{ApiURL}/Korisnici/{ID}/LikedProizvodi";

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<List<Proizvodi>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<Proizvodi> InsertLikedProizvodi(int ID, int ProizvodID)
        {
            try
            {                
                var url = $"{ApiURL}/Korisnici/{ID}/LikedProizvodi/{ProizvodID}";

                return await url.WithBasicAuth(Username, Password).PostJsonAsync(null).ReceiveJson<Proizvodi>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<float> GetProsjekRating<T>(int ID)
        {
            try
            {
                var url = $"{ApiURL}/{_resource}/{ID}/GetProsjek";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<float>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<Proizvodi> DeleteLikedProizvod(int ID, int ProizvodID)
        {
            try
            {
                var url = $"{ApiURL}/Korisnici/{ID}/LikedProizvodi/{ProizvodID}";
                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<Proizvodi>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }

        public async Task<List<Proizvodi>> GetPreporuceneProizvode(int KorisnikID)
        {
            try
            {
                var url = $"{ApiURL}/{_resource}/GetPreporuceneProizvode?KorisnikID={KorisnikID}";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<List<Proizvodi>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
    }
}
