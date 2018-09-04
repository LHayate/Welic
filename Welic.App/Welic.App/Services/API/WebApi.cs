using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Dtos;

namespace Welic.App.Services.API
{
    public class WebApi : IAuthenticate
    {
        private static Lazy<WebApi> _lazy = new Lazy<WebApi>(() => new WebApi());
        public static WebApi Current { get { return _lazy.Value; } }
        class TokenResult
        {
            public string access_token { get; set; }
            public string token_type { get; set; }

        }
        private readonly HttpClient _HttpClient;
        public WebApi()
        {
            _HttpClient = new HttpClient
            {
                //BaseAddress = new Uri("http://localhost:16954/")
                BaseAddress = new Uri("http://192.168.0.14:3000/")
            };
            _HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        internal async Task<T> GetAsync<T>(string requestUri)
        {
            try
            {           
                using (var _response = await _HttpClient.GetAsync(requestUri))
                {
                    if (!_response.IsSuccessStatusCode)
                    {
                        if (_response.StatusCode == HttpStatusCode.Unauthorized)
                            throw new InvalidOperationException("Acesso negado, você precisa estar autenticado para realizar essa requisição.");

                        throw new Exception("Algo de errado não deu certo.");
                    }
                    var _result = await _response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(_result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar buscar dados");
            }
        }        
        public async Task PostAsync(object obj, string uri)
        {
            string json = JsonConvert.SerializeObject(obj);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (var _response = await _HttpClient.PostAsync(uri, content))
            {
                if (!_response.IsSuccessStatusCode)
                    throw new InvalidOperationException("Verifique os dados informados ou sua conexão com a internet");
            }
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
                        new KeyValuePair<string, string>("password", usuario.Password),
                    };

                    using (var _response = await _HttpClient.PostAsync("token", new FormUrlEncodedContent(_args)))
                    {
                        if (!_response.IsSuccessStatusCode)
                            return false;

                        var _result = await _response.Content.ReadAsStringAsync();

                        var _tokenResult = JsonConvert.DeserializeObject<TokenResult>(_result);

                        this._HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_tokenResult.token_type, _tokenResult.access_token);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
