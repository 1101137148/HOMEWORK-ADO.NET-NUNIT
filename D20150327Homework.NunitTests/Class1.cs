using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace D20150327Homework.NunitTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void CalAge()
        {
            Age.Calculate cal = new Age.Calculate();
            
            DateTime inputBirthday = Convert.ToDateTime("2015/03/29");
            int expect = 0;

            Assert.AreEqual(expect, cal.getAge(inputBirthday));
        }
    }
}
