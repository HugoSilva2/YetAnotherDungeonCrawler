namespace YetAnotherDungeonCrawler
{
    public class Player : Character
    {
        public Player(string name, int maxHealth, int AttackPower)
        {
            Name = name;
            MaxHealth = maxHealth;
            maxHealth = maxHealth;
            AttackPower = attackPower;
            Inventory = new List<InventoryItem>();

        }
    }

}