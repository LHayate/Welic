using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Token;
using Welic.App.Models.Usuario;
using Welic.App.Services.ServicesViewModels;


namespace Welic.App.Services.API
{
    public class WebApi : IAuthenticate
    {
        private static volatile Lazy<WebApi> _lazy = new Lazy<WebApi>(() => new WebApi());        

        public static WebApi Current
        {
            get
            {
                if (_lazy == null)
                {
                    lock (SyncRoot)
                    {
                        if (_lazy == null)
                        {
                            new Lazy<WebApi>(() => new WebApi());
                        }
                    }
                }
                return _lazy.Value;
            }
        }

        private static readonly object SyncRoot = new object();       

        //private readonly HttpClient _HttpClient;
        public HttpClient _HttpClient { get; private set; }


        public WebApi()
        {
            
            _HttpClient = new HttpClient
            {
                //BaseAddress = new Uri("http://localhost:16954/")
                //BaseAddress = new Uri("http://192.168.0.10:3000/api/")
                BaseAddress = new Uri("http://192.168.0.10/api/")
            };
            _HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var token = new UserToken();
            token = token.LoadAsync();
            if(token!= null)
                _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);
           
        }

        public async Task<bool> AuthenticateAsync(UserDto usuario)
        {
            try
            {
                if (_HttpClient.DefaultRequestHeaders.Authorization == null)
                {
                    var _args = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username", usuario.UserName),
                        new KeyValuePair<string, string>("password", Criptografia.Criptografia.Decriptar(usuario.Password)),
                    };
                    
                    using (var _response = await _HttpClient.PostAsync("token", new FormUrlEncodedContent(_args)))
                    {
                        if (!_response.IsSuccessStatusCode)
                            return false;

                        var result = await _response.Content.ReadAsStringAsync();

                        var tokenResult = JsonConvert.DeserializeObject<UserToken>(result);

                        tokenResult.RegisterToken(tokenResult);

                        this._HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenResult.TokenType, tokenResult.AccessToken);
                    }                  
                }
                return true;
            }
            catch (System.Exception ex)
            {
                return false;

            }
        }

        internal async Task<T> GetAsync<T>(string requestUri)
        {
            try
            {           
                using (var response = await _HttpClient.GetAsync(requestUri))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == HttpStatusCode.Unauthorized)
                            throw new InvalidOperationException("Acesso negado, você precisa estar autenticado para realizar essa requisição.");

                        throw new System.Exception("Algo de errado não deu certo.");
                    }
                    var _result = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(_result);
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Erro ao tentar buscar dados");
            }
        }    

        internal async Task<bool> PostAsync<T>(string uri, T obj)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                using (var _response = await _HttpClient.PostAsync(uri, content))
                {
                    if (!_response.IsSuccessStatusCode)
                        throw new InvalidOperationException("Verifique os dados informados ou sua conexão com a internet");
                    return true;
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            

        }

        internal async Task<bool> PutAsync<T>(int id, T t, string uri)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync($"{uri}{id}", httpContent);

            return result.IsSuccessStatusCode;
        }

        internal async Task<bool> DeleteAsync<T>(int id, string uri)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync($"{uri}{id}");

            return response.IsSuccessStatusCode;
        }             
    }
}
