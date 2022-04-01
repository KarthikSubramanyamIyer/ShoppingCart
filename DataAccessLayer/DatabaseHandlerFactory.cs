using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace DataAccessLayer
{

    public class DatabaseHandlerFactory
    {
        private ConnectionStringSettings connectionStringSettings;

        public DatabaseHandlerFactory(string connectionStringName)
        {
            connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
        }

        public IDataAccessHandler CreateDatabase()
        {
            IDataAccessHandler database = null;

            switch (connectionStringSettings.ProviderName.ToLower())
            {
                case "system.data.sqlclient":
                    database = new SqlDataAccess(connectionStringSettings.ConnectionString);
                    break;

                default:
                    break;
            }

            return database;
        }

        public string GetProviderName()
        {
            return connectionStringSettings.ProviderName;
        }
    }

}
