using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Domain.Models
{
    public class MainHero : Character
    {
        private int _maxHealth;
        private int _level;
        public MainHero(int maxHealth, int level, int health, int damage) : base(health, damage)
        {
            _maxHealth = maxHealth;
            _level = level;
        }
        public int MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        public override string ToString()
        {
            return $"Main hero:\n" + base.ToString() + $"|Max HP: {_maxHealth}|" +
                $"Level: {_level}";
        }
    }
}
