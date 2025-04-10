using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTECore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTECore.Tests
{
    [TestClass()]
    public class TestClassTests
    {
        TestClass testClass = new TestClass();

        [TestMethod()]
        public void testTestInvoice()
        {            
            testClass.testInvoice();
        }

        [TestMethod()]
        public void testTestFiscalCreditInvoice()
        {
            testClass.testFiscalCreditInvoice();
        }

        [TestMethod()]
        public void testTesttestExportInvoice()
        {
            testClass.testExportInvoice();
        }
    }
}