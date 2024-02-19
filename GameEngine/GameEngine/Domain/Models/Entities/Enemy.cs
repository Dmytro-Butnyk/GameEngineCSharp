using GameEngine.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Domain.Models
{
    public class Enemy : Character, IHostileActionHandler
    {
        private int _lvl;
        public Enemy():base(10, 5)
        {
            _lvl = 1;
        }
        public Enemy(int lvl):base(lvl * 5, lvl * 3)
        {
            _lvl = lvl;
        }
        public bool Action(ref MainHero mainHero)
        {
            while (this.Health > 0 && mainHero.Health > 0)
            {
                mainHero.Health -= Damage;
                if (mainHero.Health <= 0)
                    return false;

                Health -= mainHero.Damage;
            }
            return Health <= 0;
        }
        public override string ToString()
        {
            return $"Enemy:\n" + base.ToString() +
                $"|Level: {_lvl}|";
        }
    }
}
