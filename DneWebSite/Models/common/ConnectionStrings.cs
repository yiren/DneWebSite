using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DneWebSite.Models.common
{
    class ConnectionStrings
    {
        private static string dbInstance = "";
        private static string user = "";
        private static string passowrd = "";
        //For Entity Framework Model or Database設定使用，因為要設定ORM metadata
        public static string BulltinConnectionString(string name)
        {
            var conStr = new EntityConnectionStringBuilder();
            
            conStr.Provider = "System.Data.SqlClient";
            conStr.ProviderConnectionString = baseConnectionString(name);
            //conStr.Metadata = "";
            
            return conStr.ConnectionString;
        }

        //Entity Framework Code-First Connection String
        public static string baseConnectionString(string name)
        {

            var sqlBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = dbInstance,
                InitialCatalog = name,
                PersistSecurityInfo = true,
                MultipleActiveResultSets = true,
                UserID = user,
                Password = password
            };
            
            return sqlBuilder.ToString();
        }
    }
}
