namespace Welic.Dominio.ViewModels
{
    public class MessageSendModel
    {
        public string UserFrom { get; set; }

        public string UserTo { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public int? ListingID { get; set; }
    }
}
