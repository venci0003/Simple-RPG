using Console_RPG.Models.Weapons;
using System;
using System.Collections.Generic;
using Console_RPG.Models.Players.Interfaces;
using Console_RPG.Models.Enemies.Interfaces;

namespace Console_RPG.Models.Player
{
    public abstract class PlayerEntity : IPlayer
    {
        private string playerName;

        private int health;

        private int capacity;

        private List<Weapon> backpack;

        protected PlayerEntity(string playerName, int health, int damage, int backpackCapacity, int gold, int experience, int level)
        {
            Name = playerName;

            Health = health;

            Damage = damage;

            backpack = new List<Weapon>(capacity);

            BackpackCapacity = 0;

            Gold = 0;

            Experience = 0;

            Level = 1;
        }


        public IReadOnlyCollection<Weapon> Backpack => backpack;

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
                    throw new Exception($"{GetType().Name} must be between 4 or 12 characters long!");
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"{GetType().Name} cannot be empty!");
                }

                playerName = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }
            private set
            {
                if (value <= 0)
                {
                    health = 0;
                }

                health = value;
            }
        }

        public int Damage { get; private set; }

        public int Gold { get; private set; }

        public int BackpackCapacity { get; private set; }

        public int Experience { get; private set; }

        public int Level { get; private set; }

        public void DealDamage(IPlayer player, IEnemy enemy)
        {
            enemy.TakeDamage(player);
        }

        public void TakeDamage(IPlayer player)
        {
            health -= player.Damage;
        }
    }
}
