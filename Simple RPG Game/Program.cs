using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {

            //player stats
            //string playerName = Console.ReadLine();
            string playerName = string.Empty;
            string playerClass = string.Empty;
            int playerHealth = 0;
            int playerDamage = 0;
            int playerGold = 0;
            int backpackCapacity = 0;
            List<string> enemies = new List<string>() { "Zombie", "Skeleton", "Human" };

            Dictionary<string, PlayerStatus> playerStatus = new Dictionary<string, PlayerStatus>();

            Console.WriteLine("Console RPG\n\nStart\n\nVersion 1.0");
            string menuChoice = Console.ReadLine().ToLower();
            if (menuChoice == "start")
            {
                Console.Clear();
                Console.WriteLine("Choose player class:\nHuman\nZombie\nSkeleton\n");
                playerClass = Console.ReadLine().ToLower();
                playerName = Console.ReadLine();
                //Each class can have different stats and different abilities
                //TODO
                if (playerClass == "human")
                {
                    playerHealth = 3;
                    playerDamage = 1;
                    backpackCapacity = 5;  
                    PlayerStatus currentPlayerStatus = new PlayerStatus(playerName, playerHealth, playerDamage,backpackCapacity);
                    playerStatus[playerName] = currentPlayerStatus;
                }
                else if (playerClass == "zombie")
                {
                    playerHealth = 2;
                    playerDamage = 2;
                    backpackCapacity = 3;
                    PlayerStatus currentPlayerStatus = new PlayerStatus(playerName, playerHealth, playerDamage, backpackCapacity);
                    currentPlayerStatus =
                    playerStatus[playerName] = currentPlayerStatus;

                }
                else if (playerClass == "skeleton")
                {
                    playerHealth = 1;
                    playerDamage = 3;
                    backpackCapacity = 2;
                    PlayerStatus currentPlayerStatus = new PlayerStatus(playerName, playerHealth, playerDamage, backpackCapacity);
                    playerStatus[playerName] = currentPlayerStatus;
                }
            }
            while (playerHealth > 0)
            {
                string enemyType = string.Empty;
                enemyType = randomEnemyEncounter(enemies);
                if (enemyType == "Zombie")
                {
                    //TODO
                }
            }
        }

        static void randomGoldReward(int playerGold)
        {
            //Random gold reward after each enemy encounter
            Random rndGold = new Random();

            int randomGold = rndGold.Next(10, 20);
            playerGold += randomGold;
            Console.WriteLine($"{randomGold}+ Gold!");
            Console.WriteLine($"You have {playerGold} gold!");
        }
        static string randomEnemyEncounter(List<string>enemies)
        {
            //Random enemy encounter for each room the player 
            string enemyType = string.Empty;
            Random randomEnemy = new Random();

            int randomEnemyEncounter = randomEnemy.Next(0, 3);
            if (randomEnemyEncounter == 0)
            {
                enemyType = enemies[0];
            }
            else if (randomEnemyEncounter == 1)
            {
                enemyType = enemies[1];
            }
            else if (randomEnemyEncounter == 2)
            {
                enemyType = enemies[2];
            }
            return enemyType;
        }
    }
    class PlayerStatus
    {
        public PlayerStatus(string playerName, int health, int damage, int capacity) //List<Weapon> backpack needs to be added to class
        {
            this.PlayerName = playerName;
            this.Health = health;
            this.Damage = damage;
            this.Backpack = new List<Weapon>(capacity);
            this.Capacity = capacity;
        }

        public string PlayerName { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public List<Weapon> Backpack { get; set; }
        public int Capacity { get; set; }
    }
    class Weapon
    {
        public string WeaponName { get; set; }
        public int Damage { get; set; }
    }
}
