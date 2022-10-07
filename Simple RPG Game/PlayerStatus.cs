using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    public class PlayerStatus
    {
        private string playerName;

        private int health;

        private int damage;

        private int capacity;

        private int backpackMaxCapacity;

        private int gold;

        private int experience;

        private int level;

        public PlayerStatus(string playerName, int health, int damage, int capacity, int backpackMaxCapacity, int gold, int experience, int level)
        {
            this.PlayerName = playerName;

            this.Health = health;

            this.Damage = damage;

            this.Backpack = new List<Weapon>(capacity);

            this.Capacity = capacity;

            this.BackpackMaxCapacity = backpackMaxCapacity;

            this.Gold = gold;

            this.Experience = experience;

            this.Level = level;
        }

        public string PlayerName
        {
            get { return this.playerName; }

            set { this.playerName = value; }
        }
        public int Health
        {
            get { return this.health; }

            set { this.health = value; }
        }
        public int Damage
        {
            get { return this.damage; }

            set { this.damage = value; }
        }

        public List<Weapon> Backpack { get; set; }
        public int Capacity
        {
            get { return this.capacity; }

            set { this.capacity = value; }
        }
        public int BackpackMaxCapacity
        {
            get { return this.backpackMaxCapacity; }

            set { this.backpackMaxCapacity = value; }
        }
        public int Gold
        {
            get { return this.gold; }

            set { this.gold = value; }
        }
        public int Experience
        {
            get { return this.experience; }

            set { this.experience = value; }
        }
        public int Level
        {
            get { return this.level; }

            set { this.level = value; }
        }
    }
}
