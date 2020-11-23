using System;
using System.Collections.Generic;
using System.Text;

namespace AbsFabAndBuilder
{
    public interface IEAGameBuilder
    {
        Game GetGame();

        void SetColor();

        void SetComposer();

        void SetGenre(IAbstractEAFabric concrete);
    }
}
