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

        [TestMethod]
        public void GetServerNameTest()
        {
            try
            {
                XmlUtility.XmlRequestUtility xmlRequestUtility = new XmlUtility.XmlRequestUtility(_elementsString);
                string serverNameToTest = "sdisssql01";
                string serverNameTested = "";

                serverNameTested = xmlRequestUtility.ServerName;
                Assert.AreEqual(serverNameToTest, serverNameTested);

            }
            catch (Exception e)
            {
                Assert.AreEqual("ERROR 1 - Invalid Server Name", e.Message);
            }


        }

        [TestMethod]
        public void GetCatalogNameTest()
        {
            try
            {
                XmlUtility.XmlRequestUtility xmlRequestUtility = new XmlUtility.XmlRequestUtility(_elementsString);
                string catalogNameToTest = "MyUiEmployer";
                string catalogNameTested = "";

                catalogNameTested = xmlRequestUtility.CatalogName;
                Assert.AreEqual(catalogNameToTest, catalogNameTested);
            }
            catch (Exception e)
            {
                Assert.AreEqual("ERROR 2 - Invalid Catalog Name", e.Message);
            }

        }

        [TestMethod]
        public void GetUserNameTest()
        {
            try
            {
                XmlUtility.XmlRequestUtility xmlRequestUtility = new XmlUtility.XmlRequestUtility(_elementsString);
                string userNameToTest = "MyUiEmployerUser";
                string userNameTested = "";

                userNameTested = xmlRequestUtility.UserName;
                Assert.AreEqual(userNameToTest, userNameTested);
            }
            catch (Exception e)
            {
                Assert.AreEqual("ERROR 3 - Invalid User Name", e.Message);
            }
        }

        [TestMethod]
        public void GetPasswordTest()
        {
            try
            {
                XmlUtility.XmlRequestUtility xmlRequestUtility = new XmlUtility.XmlRequestUtility(_elementsString);
                string passwordToTest = "MyUiEmployerUser";
                string passwordTested = "";

                passwordTested = xmlRequestUtility.Password;
                Assert.AreEqual(passwordToTest, passwordTested);
            }
            catch (Exception e)
            {
                Assert.AreEqual("ERROR 4 - Invalid Password", e.Message);
            }
        }

        [TestMethod]
        public void GetServerTypeTest()
        {
            try
            {
                XmlUtility.XmlRequestUtility xmlRequestUtility = new XmlUtility.XmlRequestUtility(_elementsString);
                string serverTypeToTest = "SQL Server";
                string serverTypeTested = "";

                serverTypeTested = xmlRequestUtility.ServerType;
                Assert.AreEqual(serverTypeToTest, serverTypeTested);
            }
            catch (Exception e)
            {
                Assert.AreEqual("ERROR 5 - Invalid Server Type", e.Message);
            }
        }
    }
}
