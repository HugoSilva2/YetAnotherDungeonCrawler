using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public interface IView
    {
        void Intro();
        void Move(string name, int id);
        void Attack(string name1, string name2, int damage);
        void Heal(string name, int heal);
        void RoomDescription();
        void PickUpItem(string name, Item item);
        void UI(int health, int maxhealth, int attackpower);
        void Inventory();
        void TheEnd(bool victory);
        void DisplayRoomInfo(Room room);
        string GetPlayerInput();
        void ListActions(); 
        void NoItem();
        void NoMove();
        void MoveWhileEnemy();
        void EnemyDead(string name);
        void NoEnemies();
        void InvalidAction();
        void NoPickUP();
        public void SkillIssue();
        public void Attack2(string thisName, string otherName, int attackpower);
        public void ShowHP(string name, int hp);
        public void Die(string Name);
        public void Respawn(string Name);
    }
}
