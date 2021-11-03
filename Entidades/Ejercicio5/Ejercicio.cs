using System.Collections.Generic;
using System.Linq;

namespace Entidades.Ejercicio5
{
    public static class Ejercicio
    {
        public static IEnumerable<string> FilterAndSortEnemiesBelow15Hp(this IEnumerable<Ship> shipCollection)
        {
            return shipCollection.SelectMany(s => s.army).Where(x => x.HP < 15).OrderBy(x => x.HP).Select(x => x.name);
        }
    }
}
