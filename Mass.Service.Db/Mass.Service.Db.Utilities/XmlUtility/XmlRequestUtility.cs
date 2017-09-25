using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Mass.Service.Db.Utilities.XmlUtility
{

//"<pollingRequestData>";
//"      <connectionData>";
//"          <serverName>sdisssql01</serverName>";
//"          <catalogName></catalogName>";
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

    public class XmlRequestUtility
    {
        private XElement _elements;

        public XmlRequestUtility(string xmlRequest)
        {
            _elements = XElement.Parse(xmlRequest);
        }

        public string ServerName
        {
            get
            {
                bool passValidation = true;
                var serverName = GetConnectionData("serverName");

                if (serverName.Count() > 1)
                {
                    passValidation = false;
                }

                if (String.IsNullOrEmpty(serverName.FirstOrDefault()))
                {
                    passValidation = false;
                }

                var match = MatchAlphaNumericCharacters(serverName.FirstOrDefault());
                if (!match.Success)
                {
                    passValidation = false;
                }

                if (!passValidation)
                {
                    Exception ex = new Exception("ERROR 1 - Invalid Server Name");
                    throw ex;
                }

                return serverName.FirstOrDefault();
            }
        }

        public string CatalogName
        {
            get
            {
                bool passValidation = true;
                var catalogName = GetConnectionData("catalogName");

                if (catalogName.Count() > 1)
                {
                    passValidation = false;
                }

                if (String.IsNullOrEmpty(catalogName.FirstOrDefault()))
                {
                    passValidation = false;
                }

                var match = MatchAlphaNumericCharacters(catalogName.FirstOrDefault());
                if (!match.Success)
                {
                    passValidation = false;
                }

                if (!passValidation)
                {
                    Exception ex = new Exception("ERROR 2 - Invalid Catalog Name");
                    throw ex;
                }
                return catalogName.FirstOrDefault();
            }
        }

        public string UserName
        {
            get
            {
                bool passValidation = true;
                var userName = GetConnectionData("userName");

                if (userName.Count() > 1)
                {
                    passValidation = false;
                }

                if (String.IsNullOrEmpty(userName.FirstOrDefault()))
                {
                    passValidation = false;
                }

                var match = MatchAlphaNumericCharacters(userName.FirstOrDefault());
                if (!match.Success)
                {
                    passValidation = false;
                }

                if (!passValidation)
                {
                    Exception ex = new Exception("ERROR 3 - Invalid User Name");
                    throw ex;
                }

                return userName.FirstOrDefault();
            }
        }

        public string Password
        {
            get
            {
                bool passValidation = true;
                var password = GetConnectionData("password");

                if (password.Count() > 1)
                {
                    passValidation = false;
                }

                if (String.IsNullOrEmpty(password.FirstOrDefault()))
                {
                    passValidation = false;
                }

                if (!passValidation)
                {
                    Exception ex = new Exception("ERROR 4 - Invalid Password");
                    throw ex;
                }

                return password.FirstOrDefault();
            }
        }

        public string ServerType
        {
            get
            {
                bool passValidation = true;
                var serverType = GetConnectionData("serverType");

                if (serverType.Count() > 1)
                {
                    passValidation = false;
                }

                if (String.IsNullOrEmpty(serverType.FirstOrDefault()))
                {
                    passValidation = false;
                }

                var match = MatchAlphaNumericCharacters("severType");
                if (!match.Success)
                {
                    passValidation = false;
                }

                if (!passValidation)
                {
                    Exception ex = new Exception("ERROR 5 - Invalid Server Type");
                    throw ex;
                }

                return serverType.FirstOrDefault();
            }
        }

        public string SqlStatement {
            get
            {
                bool passValidation = true;
                var sqlStatement = GetSqlRequest("sqlStatement");

                if (sqlStatement.Count() > 1)
                {
                    passValidation = false;
                }

                if (String.IsNullOrEmpty(sqlStatement.FirstOrDefault()))
                {
                    passValidation = false;
                }

                if (!passValidation)
                {
                    Exception ex = new Exception("ERROR 6 - Invalid SQL Statement");
                }

                return sqlStatement.FirstOrDefault();
            } 
        }

        public List<SqlParmeterInfo> SqlParameters
        {
            get
            {
                bool passValidation = false;
                List<SqlParmeterInfo> sqlParameters = GetSqlRequestParameters("sqlParameters");

                return sqlParameters;
            }
        }

        private List<SqlParmeterInfo> GetSqlRequestParameters(string sqlparameters)
        {
            XElement xElement;
            
            var elements = from element in _elements.Descendants("sqlParameters")
                select element;
            
            
            List<SqlParmeterInfo> rtnList = new List<SqlParmeterInfo>();
            foreach (var element in elements)
            {
                SqlParmeterInfo sqlParmInfo = new SqlParmeterInfo();
                
                xElement = element.Element("sqlParameter");
                if (xElement != null)
                {
                    var parmName = xElement.Element("Name");
                    if (!String.IsNullOrEmpty(parmName.Value))
                    {
                        sqlParmInfo.ParameterName = parmName.Value;
                    }
                    else
                    {
                         Exception ex = new Exception("ERROR 7 - Parameter Name can not be null");
                    }
                    var parmValue = xElement.Element("Value");
                    if (!String.IsNullOrEmpty(parmValue.Value))
                    {
                        sqlParmInfo.ParameterValue = parmValue.Value;
                    }
                    else
                    {
                        Exception ex = new Exception("ERROR 8 - Parameter Value can not be null");
                    }
                }
                rtnList.Add(sqlParmInfo);
            }
            return rtnList;
        }


        public string RedCriteria { get; }
        public string YellowCriteria { get; }
        public string GreenCriteria { get; }

        private static Match MatchAlphaNumericCharacters(string value)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9]*$");
            Match match = regex.Match(value);
            return match;
        }
        
        private List<string> GetConnectionData(string value)
        {
            return GetElementData("connectionData", value);
        }

        private List<string> GetSqlRequest(string value)
        {
            return GetElementData("sqlRequest", value);
        }
        
        private List<string> GetElementData(string elementKey, string value)
        {
            var elements = from element in _elements.Descendants(elementKey)
                select element;

            List<string> rtnList = new List<string>();
            foreach (var element in elements)
            {
                var xElement = element.Element(value);
                if (xElement != null)
                {
                    rtnList.Add(xElement.Value);
                }
            }
            return rtnList.ToList<string>();
        }
    }
}
