using System;
using System.Collections.Generic;
using System.Text;

namespace AbsFabAndBuilder
{
    public static class BuilderHub
    {
        public static Game CreateGame(IEAGameBuilder builder, IAbstractEAFabric fabric)
        {
            builder.SetColor();
            builder.SetComposer();
            builder.SetGenre(fabric);
            return builder.GetGame();
        }
    }
}
