using System.Collections.Generic;

namespace UseFul.ClientApi.Entidades
{
    public class NotificacoesDominio
    {
        public List<NotificacaoDominio> Errors { get; set; }
        public string Error { get; set; }
        public string Error_description { get; set; }
    }
}