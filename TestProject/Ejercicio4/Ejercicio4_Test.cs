using Entidades.Ejercicio4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.Ejercicio4
{
    [TestClass]
    public class Ejercicio4_Test
    {
        [TestMethod]
        public void TestEvents() 
        {
            EventExample.Instance.InvokeMyEvent();
            string message = EventExample.Instance.ShowMyString();
            System.Diagnostics.Trace.WriteLine(message);
            Assert.IsTrue(message.Length > 0);
        }
    }
}
