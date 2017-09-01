using NUnit.Framework;
using System;
using Mass.Service.Db.Utilities;

namespace Mass.Service.Db.NUnit
{
    [TestFixture()]
    public class Test
    {
        private string _elementsString = "";

        public void Init()
        {
            _elementsString = "<pollingRequestData>";
            _elementsString += "      <connectionData>";
            _elementsString += "          <serverName></serverName>";
            _elementsString += "          <catalogName>MyUiEmployer</catalogName>";
            _elementsString += "          <userName>MyUiEmployerUser</userName>";
            _elementsString += "          <password>MyUiEmployerUser</password>";
            _elementsString += "          <serverType>SQL Server</serverType>";
            _elementsString += "      </connectionData>";
            _elementsString += "      <sqlRequest>";
            _elementsString += "          <sqlStatement>";
            _elementsString += "          </sqlStatement>";
            _elementsString += "          <sqlParameters>";
            _elementsString += "              <sqlParameter>";
            _elementsString += "                  <name>";
            _elementsString += "                  </name>";
            _elementsString += "                  <value>";
            _elementsString += "                  </value>";
            _elementsString += "              </sqlParameter>";
            _elementsString += "          </sqlParameters>";
            _elementsString += "      </sqlRequest>";
            _elementsString += "      <responseCriterian>";
            _elementsString += "         <redCriterian>";
            _elementsString += "         </redCriterian>";
            _elementsString += "          <yellowCriterian>";
            _elementsString += "         </yellowCriterian>";
            _elementsString += "          <greenCriterian>";
            _elementsString += "          </greenCriterian>";
            _elementsString += "      </responseCriterian>";
            _elementsString += " </pollingRequestData>";
            
        }

        [Test()]
        public void GetServerNameTest()
        {
            try
            {
                XmlUtility xmlUtility = new XmlUtility(_elementsString);
                string serverNameToTest = "sdisssql01";
                string serverNameTested = "";

                serverNameTested = xmlUtility.ServerName;
                Assert.AreEqual(serverNameToTest, serverNameTested);

            }
            catch (Exception e)
            {
                Assert.AreEqual("ERROR 1 - Invalid Server Name", e.Message);
            }
        }

    }
}
