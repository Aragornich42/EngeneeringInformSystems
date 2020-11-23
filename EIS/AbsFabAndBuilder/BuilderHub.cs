using System;
using System.Collections.Generic;
using System.Text;

namespace AbsFabAndBuilder
{
    public class BuilderHub
    {
        public Game CreateGame(IEAGameBuilder builder, IAbstractEAFabric fabric)
        {
            builder.SetColor();
            builder.SetComposer();
            builder.SetGenre(fabric);
            return builder.GetGame();
        }
    }
}
