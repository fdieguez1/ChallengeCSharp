using Entidades.Ejercicio5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Ejercicio5
{
    [TestClass]
    public class Ejercicio5_Test
    {
        [TestMethod]
        public void FilterAndSortEnemiesBelow15Hp_Test()
        {
            List<Ship> ships = new()
            {
                new Ship() { army = new List<Enemy>() { new Enemy(20, "testNameA"), new Enemy(5, "testNameB"), new Enemy(10, "TestNameC") } }, 
                new Ship() { army = new List<Enemy>() { new Enemy(55,"TestNameD"), new Enemy(15,"TestNameE"), new Enemy(90, "TestNameF") } },
                new Ship() { army = new List<Enemy>() { new Enemy(11,"TestNameG"), new Enemy(6,"TestNameJ"), new Enemy(100,"TestNameK") } },
            };
            List<string> names = ships.FilterAndSortEnemiesBelow15Hp().ToList();
            var nonBelow15HpList = ships.SelectMany(x => x.army).Where(x => x.HP >= 15).Select(x => x.name).ToList();
            Assert.IsNotNull(names, "names returned null");
            Assert.IsTrue(names.Count == 4, "resulting names list count was diferent as expected");
            Assert.IsFalse(nonBelow15HpList.Any(x => names.Contains(x)), "There's at least one name conflicting, existing in lists with more or equals than 15 hp and the list with less than 15");
        }
    }
}
