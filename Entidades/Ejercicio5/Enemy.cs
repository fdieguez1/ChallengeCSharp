using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ejercicio5
{
    public class Enemy
    {
        public string name;
        public int HP;

        public Enemy(int HP, string name)
        {
            this.name = name;
            this.HP = HP;
        }
    }
}
