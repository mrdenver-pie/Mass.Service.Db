using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mass.Service.Db.Utilities.DatabaseUtility;
using Mass.Service.Db.Utilities.XmlUtility;

using Dapper;

namespace Mass.Service.Db.DataAccess
{
    public class DynamicSqlAccess
    {
        private DatabaseConnectionInfo _requestConnection;
        public static Func<DbConnection> ConnectionFactory = null;

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
            
            ConnectionFactory = () => new SqlConnection(CreateConnStr(_requestConnection));
        }

        public string ExecuteSql()
        {
            try
            {
                using (var connection = ConnectionFactory())
                {
                    connection.Open();

                    string query = "select CityName, count(cityname) as countOfCities ";
                    query += "from application.cities ";
                    query += "group by cityname ";
                    query += "having count(cityname) > 10 and CityName = 'Middletown'";

                    var invoices = connection.Query(query).ToList();

                    return "";
                }
            }
            catch (SqlException sqlEx)
            {
                Exception ex = new Exception(sqlEx.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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

        public static IEnumerable<dynamic> DynamicListFromSql(DbContext db, string Sql, Dictionary<string, object> Params)
        {
            using (var cmd = db.Database.Connection.CreateCommand())
            {
                cmd.CommandText = Sql;
                if (cmd.Connection.State != ConnectionState.Open) { cmd.Connection.Open(); }

                foreach (KeyValuePair<string, object> p in Params)
                {
                    DbParameter dbParameter = cmd.CreateParameter();
                    dbParameter.ParameterName = p.Key;
                    dbParameter.Value = p.Value;
                    cmd.Parameters.Add(dbParameter);
                }

                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var row = new ExpandoObject() as IDictionary<string, object>;
                        for (var fieldCount = 0; fieldCount < dataReader.FieldCount; fieldCount++)
                        {
                            row.Add(dataReader.GetName(fieldCount), dataReader[fieldCount]);
                        }
                        yield return row;
                    }
                }
            }
        }
    }
}
