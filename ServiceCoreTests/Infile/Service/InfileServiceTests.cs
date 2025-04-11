using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceCore.Infile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static ServiceCore.Infile.Service.InfileService;

namespace ServiceCore.Infile.Service.Tests
{
    [TestClass()]
    public class InfileServiceTests
    {
        InfileService infileService = new InfileService();
        string url = "https://fe-webservice-test.infile.com.do/republica_dominicana/auth/login";
        string username = "infile-ws-test";
        string password = "5285D1A3";
        string key = "SK6FEAA903461486B5FDC2C3CA1824FD";
        RequestToken requestToken = new RequestToken
        {
            rnc = "131098207",
            llave = "252D4EF516194E7BA2F210FBAA5DD479"
        };

        [TestMethod()]
        public void GetTokenTest()
        {                       
            var response = infileService.GetToken(url, username, password, key, requestToken);
            var isValidToken = (response.Contains("Error")) ? false : true;
            Assert.IsTrue(isValidToken);
        }

        [TestMethod()]
        public void GetTokenFailTest()
        {
            // only to test the fail case
            string password = "5285D1A3ssssssssssssss";
            
            var response = infileService.GetToken(url, username, password, key, requestToken);
            var isValidToken = (response.Contains("Error")) ? false : true;

            Assert.IsFalse(isValidToken);
        }
    }
}