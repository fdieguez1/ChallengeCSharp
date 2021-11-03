using Entidades.Ejercicio3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Ejercicio3
{
    [TestClass]

    public class Ejercicio3_Test
    {
        [TestMethod]

        public void TestStructs()
        {
            DateTime date = new (2000, 1, 1);
            //1-1-2000
            DateTime copy = date;
            //1-1-2000

            date = date.AddDays(10);
            //date is now 11-1-2000
            //copy is now 1-1-2000

            int a = 1;
            int b = a;
            a = 2;
            //a is now 2
            //b is now 1

            Coordinate testCoordinate = new(12039423.32, -21034523.32);
            Coordinate secondCoordinate = testCoordinate;
            testCoordinate.x = 15136533.32;

            DBBool customBoolStruct;
            customBoolStruct = DBBool.True;
            DBBool AnotherCustomBoolStruct;
            AnotherCustomBoolStruct = customBoolStruct;
            customBoolStruct = DBBool.Null;
            //customBoolStruct is now DBBool.Null;
            //AnotherCustomBoolStruct is now DBBool.True;

            Assert.AreNotEqual(date, copy);
            Assert.AreNotEqual(a, b);
            Assert.AreNotEqual(testCoordinate, secondCoordinate);
            Assert.IsTrue(secondCoordinate.x < testCoordinate.x);
            Assert.AreEqual(secondCoordinate.y, testCoordinate.y);

            Assert.AreNotEqual(customBoolStruct, AnotherCustomBoolStruct);
            Assert.IsTrue(AnotherCustomBoolStruct.IsTrue);
            Assert.IsTrue(customBoolStruct.IsNull);
        }
    }
}
