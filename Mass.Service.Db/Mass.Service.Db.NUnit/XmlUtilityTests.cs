using NUnit.Framework;
using System;
using Mass.Service.Db.Utilities;
using Mass.Service.Db.Utilities.XmlUtility;

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
            _elementsString += "          <sqlStatement></sqlStatement>";
            _elementsString += "          <sqlParameters>";
            _elementsString += "              <sqlParameter>" +
                                               "<Name>ABC</Name>" +
                                               "<Value>1200</Value>" +
                                               "</sqlParameter>";
            _elementsString += "              <sqlParameter>" +
                                               "<Name>XYZ</Name>" +
                                               "<Value>Mississippi</Value>" +
                                               "</sqlParameter>";
            _elementsString += "              <sqlParameter>" +
                               "                <Name>mammals</Name>" +
                               "                <Value>elephant</Value>" +
                               "                </sqlParameter>";
            _elementsString += "              <sqlParameter>" +
                               "                <Name>customer</Name>" +
                               "                <Value>Harold</Value>" +
                               "                </sqlParameter>";          
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
                XmlRequestUtility xmlRequestUtility = new XmlRequestUtility(_elementsString);
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
        
        [Test()]
        public void GetCatalogNameTest()
        {
            try
            {
                XmlRequestUtility xmlRequestUtility = new XmlRequestUtility(_elementsString);
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
        
        [Test()]
        public void GetUserNameTest()
        {
            try
            {
                XmlRequestUtility xmlRequestUtility = new XmlRequestUtility(_elementsString);
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
        
        [Test()]
        public void GetPasswordTest()
        {
            try
            {
                XmlRequestUtility xmlRequestUtility = new XmlRequestUtility(_elementsString);
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
        
        [Test()]
        public void GetServerTypeTest()
        {
            try
            {
                XmlRequestUtility xmlRequestUtility = new XmlRequestUtility(_elementsString);
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

        [Test]
        public void GetSqlParameters()
        {
            try
            {
                XmlRequestUtility xmlRequestUtility = new XmlRequestUtility(_elementsString);
                var parameterList = xmlRequestUtility.SqlParameters;
                
                Assert.AreEqual(4, parameterList.Count);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
