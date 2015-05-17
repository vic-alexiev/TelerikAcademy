using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitWars.Warriors
{
    public class Turtle : Warrior
    {
        public Turtle(int index)
            : base(1, 3, index, 'T')
        {
        }
    }
}
