using GameEngine.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Domain.Models
{
    public class Coin(int lvlValue): IPeacefulActionHandler
    {
        private int _lvlValue = lvlValue;
        public int LvlValue
        {
            get { return _lvlValue; }
        }
        public void Action(ref MainHero mainHero)
        {
            mainHero.MaxHealth += (int)(_lvlValue * 1.5);
            mainHero.Health = mainHero.MaxHealth;
            mainHero.Damage += _lvlValue * 2;
            mainHero.Level += _lvlValue;
        }
        public override string ToString()
        {
            return $"Coin: LVL: {_lvlValue}"; 
        }
    }
}
