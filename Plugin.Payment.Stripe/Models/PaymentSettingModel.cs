using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Plugin.Payment.Models
{
    public class PaymentSettingModel
    {
        public string StripeClientID { get; set; }

        public string StripeApiKey { get; set; }

        public string StripePublishableKey { get; set; }        

        public Setting Setting { get; set; }
    }
}