using System.Collections.Generic;
using System.Data.SqlClient;
using NLog.Internal;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using Org.BouncyCastle.Asn1.Cms;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace UseFul.Uteis
{
    public class ConnectionStringUtil
    {
        private const string ProviderName = @"System.Data.SqlClient";       

        private static ConnectionStringUtil _instance;

        public static ConnectionStringUtil Instance => _instance ?? (_instance = new ConnectionStringUtil());
        //private const string MetaData =
        //        "res://*/ACSolutions.SGC.Persistence.Model.csdl|res://*/ACSolutions.SGC.Persistence.Model.ssdl|res://*/ACSolutions.SGC.Persistence.Model.msl"
        //    ;

        public string Name { get; set; }
        public string ServerName { get; set; }
        public string DataBaseName { get; set; }

        //public string ConnectionString => MountEntityConnectionString(Name);

        public static void SetInstance(ConnectionStringUtil connectionStringUtil)
        {
            _instance = connectionStringUtil;
        }

        //public static string MountEntityConnectionString(string connectionString)
        //{
        //    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    EntityConnectionStringBuilder entityBuilder =
        //        new EntityConnectionStringBuilder
        //        {
        //            Provider = ProviderName,
        //            ProviderConnectionString =
        //                CryptographyUtil.DecryptSecureString(config.ConnectionStrings
        //                    .ConnectionStrings[connectionString].ConnectionString),
        //            Metadata = MetaData
        //        };
        //    return entityBuilder.ToString();
        //}

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