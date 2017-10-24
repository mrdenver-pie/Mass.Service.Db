using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mass.Service.Db.DataAccess;
using Mass.Service.Db.Utilities.XmlUtility;
using NUnit.Framework;

namespace Mass.Service.Db.NUnit
{
    [TestFixture()]
    public class DataAccessTests
    {
        private string _elementsString = "";

        [SetUp]
        public void Init()
        {
            _elementsString = "<pollingRequestData>";
            _elementsString += "      <connectionData>";
            _elementsString += "          <serverName>tcp:win2016sqlserver.database.windows.net,1433</serverName>";
            _elementsString += "          <catalogName>WideWorldImporters</catalogName>";
            _elementsString += "          <userName>mrdenver</userName>";
            _elementsString += "          <password>SqlserverSucks12</password>";
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
            _elementsString += "         <redCriterian>customer='Burt'</redCriterian>";
            _elementsString += "          <yellowCriterian>customer='BobbyJoe'</yellowCriterian>";
            _elementsString += "          <greenCriterian>customer='Happy Gilmore'</greenCriterian>";
            _elementsString += "      </responseCriterian>";
            _elementsString += " </pollingRequestData>";

        }

        [Test]
        public void TestSQLConnect()
        {
            DynamicSqlAccess dynamicSqlAccess = new DynamicSqlAccess(_elementsString);

            var rtn = dynamicSqlAccess.ExecuteSql();
        }

    }
}
