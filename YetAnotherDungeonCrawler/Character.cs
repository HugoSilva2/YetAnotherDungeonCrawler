namespace YetAnotherDungeonCrawler
{
    public class Character
    {
        protected bool canMove = false;
        protected string Name { get; set; }
        protected int Health { get; set; }
        protected int MaxHealth { get; set; }
        protected int AttackPower { get; set; }
        protected List<Item> Inventory { get; set; }

        protected Character(string name, int maxHealth, int attackPower)
        {
            Name = name;
            Health = maxHealth;
            MaxHealth = maxHealth;
            AttackPower = attackPower;
            Inventory = new List<Item>();
        }

        public void Attack(Enemy enemy)
        {
            Console.WriteLine($"{Name} attacked {enemy.Name} for {AttackPower} damage.");
            enemy.Health -= AttackPower;
            if (enemy.Health <= 0)
            {
                Console.WriteLine($"{enemy.Name} was slain.");
                enemy.Health = 0;
            }
            else
            {
                Console.WriteLine($"{enemy.Name} has {enemy.Health} health remaining.");
            }
        }

        public void Move(string direction)
        {
            Console.WriteLine($"{Name} moves in {direction}.");
        }

        public void PickupItem(Item item)
        {
            Inventory.Add(item);
            Console.WriteLine($"{Name} picked up {item.Name}.");
        }

        public void Die()
        {
            Console.WriteLine($"{Name} has suffered a very tragic and painful death.");
        }
    }
}
