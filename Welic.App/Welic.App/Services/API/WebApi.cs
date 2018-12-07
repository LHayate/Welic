using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        public HttpResponseMessage Resposta;
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
                //BaseAddress = new Uri("http://192.168.0.10:3000/api/")
                //BaseAddress = new Uri("http://192.168.1.3:3000/api/")
                //BaseAddress = new Uri("http://192.168.0.10/api/")
                BaseAddress = new Uri("https://welic.app/api/")
            };
            _HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            VerificaToken();                       
        }

        private async void VerificaToken()
        {
            var token = new UserToken();
            token = token.LoadAsync();
            try
            {
                if (token != null)
                    _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);
                else
                {
                    var user = (new UserDto()).LoadAsync();
                    if (user != null)
                        await AuthenticateAsync(user);
                }
            }
            catch (System.Exception)
            {
                return;
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
                        new KeyValuePair<string, string>("username", usuario.NickName),
                        new KeyValuePair<string, string>("password", usuario.Password),
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
                            throw new InvalidOperationException(
                                "Acesso negado, você precisa estar autenticado para realizar essa requisição.");

                        if (response.StatusCode == HttpStatusCode.NotImplemented)
                            throw new InvalidOperationException(
                                "Acesso negado, Processo não Implementado.");


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

        internal async Task<ObservableCollection<T>> GetListAsync<T>(string requestUri)
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

                    using (var responseStrean = await response.Content.ReadAsStreamAsync().ConfigureAwait(true))
                    {
                        return JsonConvert.DeserializeObject<ObservableCollection<T>>(await new StreamReader(responseStrean).ReadToEndAsync().ConfigureAwait(true));
                    }
                    //var _result = await response.Content.ReadAsStringAsync().ContinueWith(true);

                    //return JsonConvert.DeserializeObject<ObservableCollection<T>>(_result);
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Erro ao tentar buscar dados");
            }
        }

        internal async Task<T> PostAsync<T>(string uri, T obj)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                using (var _response = await _HttpClient.PostAsync(uri, content))
                {
                    if (!_response.IsSuccessStatusCode)
                    {
                        if(_response.StatusCode == HttpStatusCode.Conflict)
                            throw new InvalidOperationException("Dados Duplicados");
                        if(_response.StatusCode == HttpStatusCode.Unauthorized)
                            throw new InvalidOperationException("Não Autorizado");

                        throw new InvalidOperationException("Erro ao Gravar Informações");
                    }
                        
                    var result =  await _response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(result);
                }              
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }            
        }
     
        internal async Task<bool> PutAsync<T>(T t, string uri)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync($"{uri}", httpContent);

            return result.IsSuccessStatusCode;
        }

        internal async Task<bool> DeleteAsync(string uri)
        {
            try
            {
                
                HttpContent content = new StringContent("application/json");
                using (var _response = await _HttpClient.PostAsync(uri,content))
                {
                    if (!_response.IsSuccessStatusCode)
                    {
                        if (_response.StatusCode == HttpStatusCode.Conflict)
                            throw new InvalidOperationException("Dados Duplicados");
                        if (_response.StatusCode == HttpStatusCode.Unauthorized)
                            throw new InvalidOperationException("Não Autorizado");

                        throw new InvalidOperationException(_response.RequestMessage.ToString());
                    }

                    return true;
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw ;
            }
            
        }

        internal async Task<string> UploadAsync(MultipartFormDataContent path)
        {
            try
            {                
                using (var _response = await _HttpClient.PostAsync("uploads/files", path))
                {
                    if (!_response.IsSuccessStatusCode)
                        throw new InvalidOperationException("Verifique os dados informados ou sua conexão com a internet");

                    return await _response.Content.ReadAsStringAsync();
                    
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
       
    }
}
