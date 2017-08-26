using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mass.Service.Db.Utilities.Test
{
    [TestClass]
    public class XmlUtilityTest
    {
        private string _elementsString = "";

        [TestInitialize]
        public void InitTest()
        {
            _elementsString = "<pollingRequestData>";
            _elementsString += "      <connectionData>";
            _elementsString += "          <serverName>sdisssql01</serverName>";
            _elementsString += "          <catalogName>";
            _elementsString += "          </catalogName>";
            _elementsString += "          <userName>";
            _elementsString += "          </userName>";
            _elementsString += "          <password>";
            _elementsString += "          </password>";
            _elementsString += "          <serverType>";
            _elementsString += "          </serverType>";
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

        [TestMethod]
        public void GetServerNameTest()
        {
            XmlUtility xmlUtility = new XmlUtility(_elementsString);
            string serverNameToTest = "sdisssql01";
            string serverNameTested = "";

            serverNameTested = xmlUtility.ServerName;
            Assert.AreEqual(serverNameToTest, serverNameTested);

        }
    }
}
