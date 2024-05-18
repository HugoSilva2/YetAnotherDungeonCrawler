namespace YetAnotherDungeonCrawler
{
    public class Enemy : Character
    {
        public Enemy(string name, int maxHealth, int AttackPower)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            AttackPower = attackPower;
            Inventory = new List<InventoryItem>();

        }
    }

}