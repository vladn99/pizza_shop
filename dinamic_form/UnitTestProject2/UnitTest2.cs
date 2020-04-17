using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string[]> checklist = new List<string[]>();//
            checklist.Add(new string[] { "piza1", "120", "423", "23", "10000000" });
            checklist.Add(new string[] { "piza2", "200", "630", "30", "0" });
            checklist.Add(new string[] { "piza3", "150", "740", "40", "0" });
            int og_rez = 1200000000, rez;
            dinamic_form.Form1 untest = new dinamic_form.Form1();
            untest.checklist = checklist;
            rez = untest.summ();
            Assert.AreEqual(rez, og_rez);
        }
    }
}
