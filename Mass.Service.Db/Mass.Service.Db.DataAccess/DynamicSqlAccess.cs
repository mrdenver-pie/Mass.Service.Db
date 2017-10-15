using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mass.Service.Db.Utilities.DatabaseUtility;
using Mass.Service.Db.Utilities.XmlUtility;

namespace Mass.Service.Db.DataAccess
{
    public class DynamicSqlAccess
    {
        private DatabaseConnectionInfo _requestConnection;
        public DynamicSqlAccess(string xmlRequest)
        {
            XmlRequestUtility request = new XmlRequestUtility(xmlRequest);
            _requestConnection = new DatabaseConnectionInfo()
            {
                ServerName = request.ServerName,
                CatalogName = request.CatalogName,
                Password = request.Password,
                ServerType = request.ServerType,
                UserName = request.UserName
            };
        }

        public string ExecuteSql(DatabaseConnectionInfo connectionInfo)
        {
            using (var context = new DataAccess(CreateConnStr(_requestConnection)))
            {
                return "";
            }
        }

        private string CreateConnStr(DatabaseConnectionInfo requestConnection)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = requestConnection.ServerName, // server address
                InitialCatalog = requestConnection.CatalogName, // database name
                IntegratedSecurity = false, // server auth(false)/win auth(true)
                MultipleActiveResultSets = false, // activate/deactivate MARS
                PersistSecurityInfo = true, // hide login credentials
                UserID = requestConnection.UserName, // user name
                Password = requestConnection.Password // password
            };
            return builder.ConnectionString;
        }
    }
}
