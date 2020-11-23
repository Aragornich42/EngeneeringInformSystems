using System;
using System.Collections.Generic;
using System.Text;

namespace AbsFabAndBuilder
{
    public class FIFABuilder : IEAGameBuilder
    {
        private Game _game = new Game();

        public void SetColor()
        {
            _game.Color = "Вырвиглазный стиль";
        }

        public void SetComposer()
        {
            _game.Composer = "Какие-то рандомы";
        }

        public void SetGenre(IAbstractEAFabric concrete)
        {
            _game.Setting = concrete.CreateSetting();
            _game.Weapon = concrete.CreateWeapon();
        }

        public Game GetGame()
        {
            return _game;
        }
    }
}
