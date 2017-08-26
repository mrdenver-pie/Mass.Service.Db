using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mass.Service.Db.Utilities
{
    public class XmlUtility
    {
        private XElement elements { get;  set; }

        public string ServerName
        {
            get
            {
                
            };
        }

        public string CatalogName { get; }
        public string UserName { get; }
        public string Password { get; }
        public string ServerType { get; }

        public string SqlStatement { get; }
        public Dictionary<string, string> SqlParameters { get; }


        public string RedCriteria { get; }
        public string YellowCriteria { get; }
        public string GreenCriteria { get; }


    }
}
