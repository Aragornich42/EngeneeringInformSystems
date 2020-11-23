using System;
using System.Collections.Generic;
using System.Text;

namespace AbsFabAndBuilder
{
    public class TypicalEAGameBuilder : IEAGameBuilder
    {
        private Game _game = new Game();

        public void SetColor()
        {
            _game.Color = "Пофиг, главное - ДЕНЬГИ!";
        }

        public void SetComposer()
        {
            _game.Composer = "Главное, чтобы эпично, ради ДЕНЕГ!";
        }

        public void SetGenre(IAbstractEAFabric concrete)
        {
            _game.Setting = null;
            _game.Weapon = null;
        }

        public Game GetGame()
        {
            return _game;
        }
    }
}
