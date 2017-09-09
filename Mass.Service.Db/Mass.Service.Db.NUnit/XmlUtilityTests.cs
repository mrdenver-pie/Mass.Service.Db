using NUnit.Framework;
using System;
using Mass.Service.Db.Utilities;

namespace Mass.Service.Db.NUnit
{
    [TestFixture()]
    public class XmlUtilityTests
    {
        private string _elementsString = "";

        [SetUp]
        public void Init()
        {
            _elementsString = "<pollingRequestData>";
            _elementsString += "      <connectionData>";
            _elementsString += "          <serverName>sdisssql01</serverName>";
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
        
        [Test()]
        public void GetCatalogNameTest()
        {
            try
            {
                XmlUtility xmlUtility = new XmlUtility(_elementsString);
                string catalogNameToTest = "MyUiEmployer";
                string catalogNameTested = "";

                catalogNameTested = xmlUtility.CatalogName;
                Assert.AreEqual(catalogNameToTest, catalogNameTested);
            }
            catch (Exception e)
            {
                Assert.AreEqual("ERROR 2 - Invalid Catalog Name", e.Message);
            }

        }
        
        [Test()]
        public void GetUserNameTest()
        {
            try
            {
                XmlUtility xmlUtility = new XmlUtility(_elementsString);
                string userNameToTest = "MyUiEmployerUser";
                string userNameTested = "";

                userNameTested = xmlUtility.UserName;
                Assert.AreEqual(userNameToTest, userNameTested);
            }
            catch (Exception e)
            {
                Assert.AreEqual("ERROR 3 - Invalid User Name", e.Message);
            }
        }
        
        [Test()]
        public void GetPasswordTest()
        {
            try
            {
                XmlUtility xmlUtility = new XmlUtility(_elementsString);
                string passwordToTest = "MyUiEmployerUser";
                string passwordTested = "";

                passwordTested = xmlUtility.Password;
                Assert.AreEqual(passwordToTest, passwordTested);
            }
            catch (Exception e)
            {
                Assert.AreEqual("ERROR 4 - Invalid Password", e.Message);
            }
        }   
        
        [Test()]
        public void GetServerTypeTest()
        {
            try
            {
                XmlUtility xmlUtility = new XmlUtility(_elementsString);
                string serverTypeToTest = "SQL Server";
                string serverTypeTested = "";

                serverTypeTested = xmlUtility.ServerType;
                Assert.AreEqual(serverTypeToTest, serverTypeTested);
            }
            catch (Exception e)
            {
                Assert.AreEqual("ERROR 5 - Invalid Server Type", e.Message);
            }
        }        
    }
}
