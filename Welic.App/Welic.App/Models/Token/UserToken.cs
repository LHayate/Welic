using Newtonsoft.Json;
using Welic.App.Services.ServiceViews;

namespace Welic.App.Models.Token
{
    public class UserToken
    {
        [JsonProperty("id_token")]
        public string IdToken { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        private DatabaseManager _dbManager;


        public bool RegisterToken(UserToken userToken)
        {
            _dbManager = new DatabaseManager();            
            _dbManager.database.InsertOrReplace(userToken);
            _dbManager.database.Close();
            return true;
            
        }
        public bool RegisterToken()
        {
            _dbManager = new DatabaseManager();
            _dbManager.database.InsertOrReplace(this);
            _dbManager.database.Close();
            return true;

        }

        public bool RemoveToken()
        {
            _dbManager = new DatabaseManager();
            _dbManager.database.DeleteAll<UserToken>();
            _dbManager.database.Close();
            return true;

        }

        public UserToken LoadAsync()
        {
            _dbManager = new DatabaseManager();
            var token = _dbManager.database.Table<UserToken>()
                .Where(x => x.AccessToken != null);
            return token.FirstOrDefault();
        }
    }   
}
