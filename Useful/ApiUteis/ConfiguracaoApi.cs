using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UseFul.ClientApi.Entidades;
using UseFul.Uteis;

namespace UseFul.ClientApi
{
    public class ConfiguracaoApi
    {
        public string Usuario { get; private set; }
        private string _senha;
        private HttpClient _clienteApi;

        public HttpClient ObterClientApiPadraoNaoAutenticado()
        {
            return _clienteApi;
        }

        private string ObterUrlApi()
        {
            return @"http://localhost:40157/api/";
            //string urlEncript = ConfigurationManager.AppSettings["Api"];
            //return CryptographyUtil.DecryptSecureString(urlEncript);
        }

        public void Configurar()
        {
            string url = ObterUrlApi();

            //Testes com https
      

            _clienteApi = new HttpClient { BaseAddress = new Uri(url) };
            _clienteApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void Autenticar(string usuario, string senha)
        {
            try
            {
                Usuario = usuario;
                _senha = senha;

                var _args = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", Usuario),
                    new KeyValuePair<string, string>("password", _senha),
                };

                MediaTypeFormatterCollection formatters = ConfigurarHttpFormatter();

                HttpResponseMessage tokenResponse =
                    _clienteApi.PostAsync("token", new FormUrlEncodedContent(_args)).Result;
                Token apiToken = tokenResponse.Content.ReadAsAsync<Token>(formatters).Result;

                _clienteApi.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                    apiToken.AccessToken);

                if (tokenResponse.StatusCode != HttpStatusCode.OK)
                {
                    throw CustomErro.Erro("Não possível autenticar o usuário e senha");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw CustomErro.Erro(e.Message); 
            }
            
        }

        private static MediaTypeFormatterCollection ConfigurarHttpFormatter()
        {
            HttpConfiguration config = new HttpConfiguration();
            MediaTypeFormatterCollection formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);
            JsonSerializerSettings jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;

            return formatters;
        }
    }
}