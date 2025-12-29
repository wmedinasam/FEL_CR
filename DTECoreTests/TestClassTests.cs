using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        [TestMethod()]
        public void testtestCreditNote()
        {
            testClass.testCreditNote();
        }

        [TestMethod]
        public void Emisor_Xml_Tags_Order_Is_Respected()
        {
            testClass.Emisor_Xml_Tags_Order_Is_Respected();
        }

        [TestMethod]
        public void MontoPago_ShouldTruncateToTwoDecimalsWithoutRounding()
        {

            testClass.MontoPago_ShouldTruncateToTwoDecimalsWithoutRounding();

        }
    }
}