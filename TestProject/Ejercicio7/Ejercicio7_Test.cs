using Entidades.Ejercicio7;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Ejercicio7
{
    [TestClass]
    public class Ejercicio7_Test
    {
        [TestMethod]

        public void TestIndexer()
        {
            Product.ProductList = new()
            {
                new Product(1, "descTestA", 100),
                new Product(2, "descTestB", 140),
                new Product(3, "descTestC", 70),
            };

            Product expectedProduct = new(1, "descTestA", 100);
            Product resultingProduct = new Product()[1];
            Assert.IsNotNull(resultingProduct);
            Assert.IsTrue(expectedProduct == resultingProduct);
            string message = resultingProduct.ToString();
            System.Diagnostics.Trace.WriteLine(message);
        }
    }
}
