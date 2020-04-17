using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string[]> checklist = new List<string[]>();//
            checklist.Add(new string[] { "piza1", "120", "423", "23", "1" });
            checklist.Add(new string[] { "piza2", "200", "630", "30", "0" });
            checklist.Add(new string[] { "piza3", "150", "740", "40", "a" });
            object og_rez = 120, rez;
            dinamic_form.Form1 untest = new dinamic_form.Form1();
            untest.checklist = checklist;
            rez = untest.summ();
            Assert.AreEqual(rez, og_rez);
        }
    }
}
