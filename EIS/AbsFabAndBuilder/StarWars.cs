using System;
using System.Collections.Generic;
using System.Text;

namespace AbsFabAndBuilder
{
    public class StarWars : IAbstractEAFabric
    {
        public Setting CreateSetting()
        {
            return new SpaceWarSetting();
        }

        public Weapon CreateWeapon()
        {
            return new SpaceWarWeapon();
        }
    }
}
