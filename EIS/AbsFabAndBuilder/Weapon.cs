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

        public override string ToString()
        {
            return "холодное оружие: " + IsSteelArms + ", огнестрельное оружие: " + IsFirearms + ", название оружия: " + Name;
        }
    }
}
