using System;
using System.Collections.Generic;
using System.Text;

namespace AbsFabAndBuilder
{
    public class SpaceWarWeapon : Weapon
    {
        public SpaceWarWeapon()
        {
            IsFirearms = false;
            IsSteelArms = true;
            Name = "Световой меч";
        }
    }
}
