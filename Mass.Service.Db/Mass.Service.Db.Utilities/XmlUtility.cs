using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mass.Service.Db.Utilities
{

//"<pollingRequestData>";
//"      <connectionData>";
//"          <serverName>sdisssql01</serverName>";
//"          <catalogName>";
//"          </catalogName>";
//"          <userName>";
//"          </userName>";
//"          <password>";
//"          </password>";
//"          <serverType>";
//"          </serverType>";
//"      </connectionData>";
//"      <sqlRequest>";
//"          <sqlStatement>";
//"          </sqlStatement>";
//"          <sqlParameters>";
//"              <sqlParameter>";
//"                  <name>";
//"                  </name>";
//"                  <value>";
//"                  </value>";
//"              </sqlParameter>";
//"          </sqlParameters>";
//"      </sqlRequest>";
//"      <responseCriterian>";
//"         <redCriterian>";
//"         </redCriterian>";
//"          <yellowCriterian>";
//"         </yellowCriterian>";
//"          <greenCriterian>";
//"          </greenCriterian>";
//"      </responseCriterian>";
//" </pollingRequestData>";

    public class XmlUtility
    {
        private XElement _elements;

        public XmlUtility(string xmlRequest)
        {
            _elements = XElement.Parse(xmlRequest);
        }

        public string ServerName
        {
            get
            {
                string _serverName = "";

                var elements = from element in _elements.Descendants("connectionData")
                                 select element;

                foreach (var element in elements)
                {
                    var xElement = element.Element("serverName");
                    if (xElement != null) _serverName = xElement.Value;
                }

                return _serverName;
            }
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
