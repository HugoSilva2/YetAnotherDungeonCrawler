using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class Controller
    {
        private Player player;
        private List<Room> rooms;
        private int currentRoomId;
        private bool gameRunning = false;

        public void Start(IView view)
        {
            view.Intro();

            player = new Player("John Warrior", 100, 30, view);
            rooms = new List<Room>
            {
                new Room(-4, new Enemy("Skeleton", 35, 20, view), new List<Item> { new Item("Health Potion") }),
                new Room(-3, new Enemy("Skeleton", 35, 20, view), new List<Item> { new Item("Health Potion") }),
                new Room(-2, new Enemy("Goblin", 20, 10, view), new List<Item> { new Item("Health Potion") }),
                new Room(-1, new Enemy("Goblin", 20, 10, view), new List<Item> { new Item("Useless Junk") }),
                new Room(0, new Enemy("Goblin", 20, 10, view), new List<Item> { new Item("Health Potion") }),
                new Room(1, new Enemy("Skeleton", 35, 20, view), new List<Item> { new Item("Useless Junk") }),
                new Room(2, new Enemy("Skeleton", 35, 20, view), new List<Item> { new Item("Health Potion") }),
                new Room(3, new Enemy("Slime", 120, 15, view), new List<Item> { new Item("Even More Useless Junk") }),
                new Room(4, new Enemy("Bob The Necromancer", 200, 40, view), new List<Item> { new Item("Artifact") })
            };

            gameRunning = true;
            while (gameRunning)
            {
                Room currentRoom = rooms.Find(r => r.Id == currentRoomId);
                view.DisplayRoomInfo(currentRoom);
                view.ListActions();
                string action = view.GetPlayerInput().ToLower();

                switch (action)
                {
                    case "move right":
                        if (currentRoom.Enemy == null)
                        {
                            currentRoomId += 1;
                            if (!rooms.Exists(r => r.Id == currentRoomId))
                            {
                                currentRoomId -= 1;
                                view.NoMove();
                            }
                            else
                            {
                                view.Move(player.Name, currentRoomId);
                            }
                        }
                        else
                        {
                            view.MoveWhileEnemy();
                        }
                        break;

                    case "use potion":
                        player.UseHealthPotion();
                        break;

                    case "move left":
                        if (currentRoom.Enemy == null)
                        {
                            currentRoomId -= 1;
                            if (!rooms.Exists(r => r.Id == currentRoomId))
                            {
                                currentRoomId += 1;
                                view.NoMove();
                            }
                            else
                            {
                                view.Move(player.Name, currentRoomId);
                            }
                        }
                        else
                        {
                            view.MoveWhileEnemy();
                        }
                        break;

                    case "attack":
                        if (currentRoom.Enemy != null)
                        {
                            player.Attack(currentRoom.Enemy);
                            if (currentRoom.Enemy.Health <= 0)
                            {
                                view.EnemyDead(currentRoom.Enemy.Name);
                                currentRoom.Enemy = null;
                            }
                            else
                            {
                                currentRoom.Enemy.Attack(player);
                                if (player.Health <= 0)
                                {
                                    view.SkillIssue();
                                    gameRunning = false;
                                }
                            }
                        }
                        else
                        {
                            view.NoEnemies();
                        }
                        break;

                    case "pickup":
                        if (currentRoom.Enemy == null)
                        {
                            if (currentRoom.Items.Count > 0)
                            {
                                var item = currentRoom.Items[0];
                                if (player.PickupItem(item))
                                {
                                    currentRoom.Items.RemoveAt(0);
                                }
                            }
                            else
                            {
                                view.NoItem();
                            }
                        }
                        else
                        {
                            view.NoPickUP();
                        }
                        break;


                    case "quit":
                        gameRunning = false;
                        break;

                    default:
                        view.InvalidAction();
                        break;
                }
            }

            view.TheEnd(player.Health > 0 && player.Inventory.Exists(item => item.Name == "Artifact"));
        }
    }
}
