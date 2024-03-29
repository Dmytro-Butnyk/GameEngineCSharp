﻿namespace GameEngine.Domain.Models
{
    public abstract class Character(int health, int damage)
    {
        public int Health { get; set; } = health;
        public int Damage { get; set; } = damage;

        public override string ToString()
        {
            return $"Health: {Health}|Damage:{Damage}";
        }
    }
}
