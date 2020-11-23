using System;
using System.Collections.Generic;
using System.Text;

namespace AbsFabAndBuilder
{
    public abstract class Weapon
    {
        public bool IsSteelArms { get; set; }
        public bool IsFirearms { get; set; }
        public string Name { get; set; }
    }
}
