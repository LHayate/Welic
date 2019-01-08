using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UseFul.ClientApi.Entidades;
using UseFul.Uteis;

namespace UseFul.ClientApi
{
    public sealed class ClienteApi
    {
        private static volatile ClienteApi _instance;
        private static readonly object SyncRoot = new object();

        private ClienteApi()
        {
        }

        public static ClienteApi Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new ClienteApi();
                        }
                    }
                }
                return _instance;
            }
        }

        public HttpClient ClienteHttp { get; private set; }

        public void DefinirClienteApi(HttpClient cliente)
        {
            ClienteHttp = cliente;
        }

        public HttpResponseMessage RequisicaoGet(string url)
        {
            HttpResponseMessage response =
                ClienteHttp.GetAsync(url).Result;

            ObterResposta(response);

            return response;
        }

        public async Task<HttpResponseMessage> RequisicaoGetAsync(string url)
        {
            HttpResponseMessage response =
                await
                    ClienteHttp.GetAsync(url);

            ObterResposta(response);

            return response;
        }

        public HttpResponseMessage RequisicaoPost(string url, object conteudo)
        {
            HttpResponseMessage response =
                ClienteHttp.PostAsJsonAsync(url, conteudo)
                    .Result;

            return response;
        }

        public async Task<HttpResponseMessage> RequisicaoPostAsync(string url, object conteudo)
        {
            HttpResponseMessage response =
                await
                    ClienteHttp.PostAsJsonAsync(url, conteudo);

            return response;
        }

        public void ObterResposta(HttpResponseMessage response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                ProcessarStatusCode(response);
            }
        }

        public T ObterResposta<T>(HttpResponseMessage response)
        {
            ObterResposta(response);
            string jsonString = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public async Task<T> ObterRespostaAsync<T>(HttpResponseMessage response)
        {
            await ProcessarStatusCodeAsync(response);
            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        private async Task ProcessarStatusCodeAsync(HttpResponseMessage response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                string jsonString = await response.Content.ReadAsStringAsync();

                NotificacoesDominio notificacao =
                    JsonConvert.DeserializeObject<NotificacoesDominio>(jsonString);

                StringBuilder mensagem = new StringBuilder();
                if (notificacao.Errors != null)
                {
                    foreach (NotificacaoDominio notificacaoDominio in notificacao.Errors)
                    {
                        mensagem.AppendLine($"- {notificacaoDominio.Valor}");
                    }
                    throw CustomErro.Erro(mensagem.ToString());
                }
                MensagemApi mensagemApi =
                    JsonConvert.DeserializeObject<MensagemApi>(jsonString);

                AppLogging.Log(mensagemApi.StackTrace, LogType.Error);

                throw CustomErro.Erro(mensagemApi.ExceptionMessage);
            }
            response.EnsureSuccessStatusCode();
        }

        private void ProcessarStatusCode(HttpResponseMessage response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                string jsonString = response.Content.ReadAsStringAsync().Result;

                NotificacoesDominio notificacao =
                    JsonConvert.DeserializeObject<NotificacoesDominio>(jsonString);

                StringBuilder mensagem = new StringBuilder();
                if (notificacao.Errors != null)
                {
                    foreach (NotificacaoDominio notificacaoDominio in notificacao.Errors)
                    {
                        mensagem.AppendLine($"- {notificacaoDominio.Valor}");
                    }

                    throw CustomErro.Erro(mensagem.ToString());
                }

                if (notificacao.Errors == null)
                {
                    AppLogging.Log(notificacao.Error_description, LogType.Error);
                    throw CustomErro.Erro(notificacao.Error_description);
                }

                MensagemApi mensagemApi =
                    JsonConvert.DeserializeObject<MensagemApi>(jsonString);

                AppLogging.Log(mensagemApi.StackTrace, LogType.Error);

                throw CustomErro.Erro(mensagemApi.ExceptionMessage);
            }
            response.EnsureSuccessStatusCode();
        }

        public HttpResponseMessage RequisicaoPost(string url)
        {
            HttpResponseMessage response =
                ClienteHttp.PostAsync(url,null)
                    .Result;

            return response;
        }
    }
}