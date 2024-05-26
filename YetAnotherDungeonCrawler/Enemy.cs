using System;
namespace YetAnotherDungeonCrawler
{
    public class Enemy : Character
    {
        public Enemy(string name, int maxHealth, int attackPower, IView view)
            : base(maxHealth, attackPower, view)
        {
            Name = name;
            MaxHealth = maxHealth;
            AttackPower = attackPower;
            _view = view;
        }
    }
    
}
