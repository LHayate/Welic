using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace UseFul.Uteis
{
    public class ConnectionStringUtil
    {
        private const string ProviderName = @"System.Data.SqlClient";       

        private static ConnectionStringUtil _instance;

        public static ConnectionStringUtil Instance => _instance ?? (_instance = new ConnectionStringUtil());
        

        public string Name { get; set; }
        public string ServerName { get; set; }
        public string DataBaseName { get; set; }

        //public string ConnectionString => MountEntityConnectionString(Name);

        public static void SetInstance(ConnectionStringUtil connectionStringUtil)
        {
            _instance = connectionStringUtil;
        }
        

        public static List<ConnectionStringUtil> ConnectionList()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int count = config.ConnectionStrings.ConnectionStrings.Count;
            List<ConnectionStringUtil> list = new List<ConnectionStringUtil>();
            for (int i = 0; i < count; i++)
            {
                ConnectionStringSettings csSection = config.ConnectionStrings.ConnectionStrings[i];
                if (csSection.Name != "LocalSqlServer" && csSection.Name != "LocalMySqlServer")
                {
                    SqlConnectionStringBuilder sqlBuilder =
                        new SqlConnectionStringBuilder(
                            CryptographyUtil.DecryptSecureString(csSection.ConnectionString));
                    ConnectionStringUtil cnUtil = new ConnectionStringUtil
                    {
                        Name = config.ConnectionStrings.ConnectionStrings[i].Name,
                        DataBaseName = sqlBuilder.InitialCatalog,
                        ServerName = sqlBuilder.DataSource
                    };
                    list.Add(cnUtil);
                }
            }
            return list;
        }
    }
}