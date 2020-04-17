﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string[]> checklist = new List<string[]>();//
            checklist.Add(new string[] { "piza1", "120", "423", "23", "1" });
            checklist.Add(new string[] { "piza2", "200", "630", "30", "1" });
            checklist.Add(new string[] { "piza3", "150", "740", "40", "0" });
            int og_rez = 320, rez;
            dinamic_form.Form1 untest = new dinamic_form.Form1();
            untest.checklist = checklist;
            rez = untest.summ();
            Assert.AreEqual(rez, og_rez);
        }
    }
}
