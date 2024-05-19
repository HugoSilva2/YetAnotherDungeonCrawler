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
        void TheEnd();
        void DisplayRoomInfo(Room room);
        string GetPlayerInput(); // Adicionado
    }
}
