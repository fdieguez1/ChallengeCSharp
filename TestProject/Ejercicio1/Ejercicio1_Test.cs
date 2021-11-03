using Entidades;
using Entidades.Ejercicio1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject.Ejercicio1
{
    [TestClass]
    public class Ejercicio1_Test
    {
        [TestMethod]
        public void Test_HardcodeTestClassList()
        {
            List<TestClass> resultingList;
            List<TestClass> expectedList = new()
            {
                new TestClass() { IsActive = true, Name = "TestName List A", Number = 5 },
                new TestClass() { IsActive = true, Name = "TestName List B", Number = 6 },
                new TestClass() { IsActive = false, Name = "TestName List C", Number = 7 },
                new TestClass() { IsActive = false, Name = "TestName List D", Number = 2 },
                new TestClass() { IsActive = true, Name = "TestName List E", Number = 3 },
            };
            resultingList = Entidades.Ejercicio1.Ejercicio.HardcodeTestClassList();

            Assert.IsNotNull(resultingList, "resulting list was null");
            Assert.IsTrue(resultingList.Count == expectedList.Count, "Hardcode method returned a diferent count of items than expected");
            Assert.AreNotSame(resultingList, expectedList, "Both objects refer to the same object");
            Assert.IsTrue(resultingList.GetType() == typeof(List<TestClass>), "not expected resulting type");
            for (int i = 0; i < resultingList.Count; i++)
            {
                Assert.IsTrue(resultingList[i].Id == expectedList[i].Id, $"Id not matching for index{i}");
                Assert.IsTrue(resultingList[i].Number == expectedList[i].Number, $"Number not matching for index{i}");
                Assert.IsTrue(resultingList[i].Name == expectedList[i].Name, $"Name not matching for index{i}");
                Assert.IsTrue(resultingList[i].IsActive == expectedList[i].IsActive, $"IsActive not matching for index{i}");
            }
        }
        [TestMethod]
        public void Test_HardcodeTestClassStack()
        {
            Stack<TestClass> resultingStack;
            Stack<TestClass> expectedStack = new();

            expectedStack.Push(new TestClass() { IsActive = true, Name = "TestName List A", Number = 5 });
            expectedStack.Push(new TestClass() { IsActive = true, Name = "TestName List B", Number = 6 });
            expectedStack.Push(new TestClass() { IsActive = false, Name = "TestName List C", Number = 7 });
            expectedStack.Push(new TestClass() { IsActive = false, Name = "TestName List D", Number = 2 });
            expectedStack.Push(new TestClass() { IsActive = true, Name = "TestName List E", Number = 3 });

            resultingStack = Entidades.Ejercicio1.Ejercicio.HardcodeTestClassStack();


            Assert.IsNotNull(resultingStack, "resulting stack was null");
            Assert.IsTrue(resultingStack.Count == expectedStack.Count, "Hardcode method returned a diferent count of items than expected");
            Assert.AreNotSame(resultingStack, expectedStack, "Both objects refer to the same objecct");
            Assert.IsTrue(resultingStack.GetType() == typeof(Stack<TestClass>), "not expected resulting type");
            for (int i = 0; i < resultingStack.Count; i++)
            {
                Assert.IsTrue(resultingStack.Pop().Id == expectedStack.Pop().Id, $"Id not matching for index{i}");
                Assert.IsTrue(resultingStack.Pop().Number == expectedStack.Pop().Number, $"Number not matching for index{i}");
                Assert.IsTrue(resultingStack.Pop().Name == expectedStack.Pop().Name, $"Name not matching for index{i}");
                Assert.IsTrue(resultingStack.Pop().IsActive == expectedStack.Pop().IsActive, $"IsActive not matching for index{i}");
            }
        }

        [TestMethod]
        public void Test_HardcodeIntQueue()
        {
            Queue<int> expectedQueue = new ();
            for (int i = 0; i < 5; i++)
            {
                expectedQueue.Enqueue(Ejercicio.Rnd.Next(0, 101));
            }
            Queue<int> resultingQueue;
            resultingQueue = Entidades.Ejercicio1.Ejercicio.HardcodeIntQueue();
            Assert.IsTrue(expectedQueue.Count == resultingQueue.Count, "Hardcode method returned a diferent count of items than expected");
            Assert.IsNotNull(resultingQueue, "resulting queue was null");
            Assert.IsTrue(resultingQueue.GetType() == typeof(Queue<int>), "not expected resulting type");
        }
        [TestMethod]
        public void Test_HardcodeStringStack()
        {
            Stack<string> expectedStack = new();
            for (int i = 0; i < 5; i++)
            {
                expectedStack.Push("TestString" + i);
            }
            Stack<string> resultingStack;
            resultingStack = Entidades.Ejercicio1.Ejercicio.HardcodeStringStack();
            Assert.IsTrue(expectedStack.Count == resultingStack.Count, "Hardcode method returned a diferent count of items than expected");
            Assert.IsNotNull(resultingStack, "resulting stack was null");
            Assert.IsTrue(resultingStack.GetType() == typeof(Stack<string>), "not expected resulting type");
        }
        [TestMethod]
        public void Test_FilterCollection_IntArray()
        {
            int[] intArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] result = intArray.FilterCollection(x => x < 4).Value.MyToArray();
            foreach (int number in result)
            {
                Assert.IsTrue(number < 4, "The filter method returned invalid values");
            }
        }
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void NullCollectionThrowsNullArgumentException()
        {
            int[] intArray = null;
            var result = intArray.FilterCollection(x => x < 4).Value;
            Assert.IsNull(result, "Filter result was not null, exception expected");
        }
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void NullPredicateThrowsNullArgumentException()
        {
            int[] intArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Func<int, bool> evaluate = null;
            var result = intArray.FilterCollection(evaluate).Value;
            Assert.IsNull(result, "Filter result was not null, exception expected");
        }
        [TestMethod]
        public void Test_FilterCollection_StringList()
        {
            List<string> stringList = new() { "string one", "string two", "string three", "string four", "string five" };
            List<string> result = new (stringList.FilterCollection(x => x.Contains("o")).Value);
            Assert.IsNotNull(result, "Filter result was null");
            foreach (string str in result)
            {
                Assert.IsTrue(str.Contains("o"));
            }
        }
        [TestMethod]
        public void Test_FilterCollection_StackObject()
        {
            Stack<TestClass> stringList = Entidades.Ejercicio1.Ejercicio.HardcodeTestClassStack();
            Stack<TestClass> result = new (stringList.FilterCollection(x => x.Number > 3).Value);
            Assert.IsNotNull(result, "Filter result was null");
            foreach (TestClass instance in result)
            {
                Assert.IsTrue(instance.Number > 3);
            }
        }
        [TestMethod]
        public void Test_FilterCollection_intQueue()
        {
            Queue<int> intQueue = Entidades.Ejercicio1.Ejercicio.HardcodeIntQueue();
            Queue<int> result = new (intQueue.FilterCollection(x => x > 50).Value);
            Assert.IsNotNull(result, "Filter result was null");
            foreach (int number in result)
            {
                Assert.IsTrue(number > 50);
            }
        }


    }
}
