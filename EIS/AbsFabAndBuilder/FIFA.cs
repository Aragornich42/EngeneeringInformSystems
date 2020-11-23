using System;
using System.Collections.Generic;
using System.Text;

namespace AbsFabAndBuilder
{
    public class FIFA : IAbstractEAFabric
    {
        public Setting CreateSetting()
        {
            return new FootballSetting();
        }

        public Weapon CreateWeapon()
        {
            return null;
        }
    }
}
