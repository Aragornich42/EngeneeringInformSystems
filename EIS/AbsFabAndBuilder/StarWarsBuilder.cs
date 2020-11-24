using System;
using System.Collections.Generic;
using System.Text;

namespace AbsFabAndBuilder
{
    public class StarWarsBuilder : IEAGameBuilder
    {
        private Game _game = new Game();
        public void SetColor()
        {
            _game.Color = "Темно-тревожный";
        }

        public void SetComposer()
        {
            _game.Composer = "Горди Хааб и Стивен Бартон";
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
