using System;
using System.Collections.Generic;
using System.Text;

namespace AbsFabAndBuilder
{
    /// <summary>
    /// Ага, ни разу она только не абстрактна, а вполне реальна
    /// </summary>
    public interface IAbstractEAFabric
    {
        Setting CreateSetting();

        Weapon CreateWeapon();
    }
}
