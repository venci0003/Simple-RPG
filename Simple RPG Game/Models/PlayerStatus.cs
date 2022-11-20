using Console_RPG.Models;
using Console_RPG.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Console_RPG
{
    public class PlayerStatus : IPlayer
    {
        private string playerName;

        private string playerClass;

        private int health;

        private int damage;

        private int capacity;

        private int gold;

        private int experience;

        private int level;

        private List<Weapon> backpack;

        public PlayerStatus(string playerName, int health, int damage, int backpackMaxCapacity, int gold, int experience, int level)
        {
            this.Name = playerName;

            this.Health = health;

            this.Damage = damage;

            this.Backpack = new List<Weapon>(capacity);

            this.BackpackCapacity = backpackMaxCapacity;

            this.Gold = gold;

            this.Experience = experience;

            this.Level = level;
        }



        public List<Weapon> Backpack { get; set; }

        public string Name
        {
            get
            {
                return playerName;
            }
            private set
            {
                if (value.Length <= 3 || value.Length > 12)
                {
                    throw new Exception($"{this.GetType().Name} must be between 4 or 12 characters long!");
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"{this.GetType().Name} cannot be empty!");
                }
                playerName = value;
            }
        }

        public string PlayerClass
        {
            get
            {
                return playerClass;
            }
            private set
            {
                playerClass = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value <= 0)
                {
                    //throw new Exception($"{this.GetType().Name} cannot be 0 or a negative number!");
                }

                health = value;
            }
        }

        public int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception($"{this.GetType().Name} cannot be 0 or a negative number!");
                }
                damage = value;
            }
        }

        public int Gold
        {
            get
            {
                return gold;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception($"{this.GetType().Name} cannot be 0 or a negative number!");
                }

                gold = value;
            }
        }

        public int BackpackCapacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;
            }
        }

        public int Experience
        {
            get
            {
                return experience;
            }
            set
            {
                experience = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }
    }
}
