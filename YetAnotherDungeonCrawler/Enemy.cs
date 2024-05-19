using System;
namespace YetAnotherDungeonCrawler
{
    public class Enemy : Character
    {
        public Enemy(string name, int maxHealth, int attackPower)
            : base(maxHealth, attackPower)
        {
            Name = name;
        }
    }
}
