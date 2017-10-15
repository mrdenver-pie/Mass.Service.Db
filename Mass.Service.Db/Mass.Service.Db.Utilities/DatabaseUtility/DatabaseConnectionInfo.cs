using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mass.Service.Db.Utilities.DatabaseUtility
{
    public class DatabaseConnectionInfo
    {
        public string ServerName { get; set; }
        public string CatalogName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ServerType { get; set; }
    }
}
