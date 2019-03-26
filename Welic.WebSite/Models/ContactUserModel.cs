namespace WebApi.Models
{
    public class ContactUserModel
    {
        public string UserID { get; set; }

        public int ListingID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }
    }
}