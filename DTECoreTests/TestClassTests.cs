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
        [TestMethod()]
        public void testTest()
        {
            TestClass testClass = new TestClass();
            testClass.test();
        }
    }
}