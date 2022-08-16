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

            //List of enemies the player will encounter
            List<string> enemies = new List<string>() { "Zombie", "Skeleton", "Human" };

            //List of randomized words
            List<string> randomWords = new List<string>() { "awoken", "reanimated", "spawned", "resurrected", "reborn", "called upon the gods", "rejuvenated", "created", "revived" };

            //Dictionary for the player stats (name, health, damage, backpack capacity)
            Dictionary<string, PlayerStatus> playerStatus = new Dictionary<string, PlayerStatus>();

            Console.WriteLine("Console RPG\n\nStart\n\nVersion 1.0");
            string menuChoice = Console.ReadLine().ToLower();
            if (menuChoice == "start")
            {
                Console.Clear();
                //Class selection
                Console.WriteLine("Choose player class:\nHuman\nZombie\nSkeleton\n");
                playerClass = Console.ReadLine().ToLower();
                Console.Clear();

                //Name selection
                //TODO make random recommendations for a name
                Console.WriteLine("Pick a name:");
                playerName = Console.ReadLine();
                Console.Clear();
                //Each class can have different stats and different abilities
                //TODO
                if (playerClass == "human")
                {
                    playerHealth = 3;
                    playerDamage = 1;
                    backpackCapacity = 5;
                    playerGold = 0;
                    PlayerStatus currentPlayerStatus = new PlayerStatus(playerName, playerHealth, playerDamage, backpackCapacity,playerGold);
                    playerStatus[playerName] = currentPlayerStatus;
                    string randomWord = string.Empty;
                    randomWord = randomWordsEncounter(randomWords);
                    Console.WriteLine($"{playerName} the {playerClass} has been {randomWord}");
                    //TODO make random sentences when a character has been created
                }
                else if (playerClass == "zombie")
                {
                    playerHealth = 2;
                    playerDamage = 2;
                    backpackCapacity = 3;
                    playerGold = 0;
                    PlayerStatus currentPlayerStatus = new PlayerStatus(playerName, playerHealth, playerDamage, backpackCapacity,playerGold);
                    playerStatus[playerName] = currentPlayerStatus;
                    string randomWord = string.Empty;
                    randomWord = randomWordsEncounter(randomWords);
                    Console.WriteLine($"{playerName} the {playerClass} has been {randomWord}");
                }
                else if (playerClass == "skeleton")
                {
                    playerHealth = 1;
                    playerDamage = 3;
                    backpackCapacity = 2;
                    playerGold = 0;
                    PlayerStatus currentPlayerStatus = new PlayerStatus(playerName, playerHealth, playerDamage, backpackCapacity,playerGold);
                    playerStatus[playerName] = currentPlayerStatus;
                    string randomWord = string.Empty;
                    randomWord = randomWordsEncounter(randomWords);
                    Console.WriteLine($"{playerName} the {playerClass} has been {randomWord}");
                }
            }
            Console.Clear();
            Console.WriteLine($"Your jorney begins!\nGood luck out there {playerName}...");
            Thread.Sleep(2000);
            Console.Clear();
            while (playerHealth > 0)
            {
                bool enemyFound = false;
                enemyFound = chanceToEncounterEnemy(enemyFound);

                if (enemyFound)
                {
                    string enemyType = string.Empty;
                    enemyType = randomEnemyEncounter(enemies);
                    if (enemyType == "Zombie")
                    {
                        //TODO
                        string type = "zombie";
                        int health = 1;
                        int damage = 1;
                        EnemiesProperties enemy = new EnemiesProperties(type, health, damage);
                        Console.WriteLine($"You are being attacked!\nAttacker:{enemyType}\nEnemy health: {enemy.EnemyHealth}\nEnemy damage: {enemy.EnemyDamage}");
                        while (true)
                        {
                            playerStatus[playerName].Health -= enemy.EnemyDamage;
                            Console.WriteLine("Choose an action:\nAttack\nBlock /Not implemented yet");
                            string[] command = Console.ReadLine().Split(' ');
                            if (enemy.EnemyHealth <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine($"You killed the {enemy.EnemyName}");
                                randomGoldReward(playerGold);
                                break;
                            }
                            if (playerStatus[playerName].Health <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine($"You died\nPlayer stats:\nGold Collected: {playerGold}");
                                return;
                            }
                            if (command[0] == "Attack")
                            {
                                enemy.EnemyHealth -= playerStatus[playerName].Damage;
                            }
                        }
                    }
                    else if (enemyType == "Skeleton")
                    {
                        string type = "skeleton";
                        int health = 1;
                        int damage = 1;
                        EnemiesProperties enemy = new EnemiesProperties(type, health, damage);
                        Console.WriteLine($"You are being attacked!\nAttacker:{enemyType}\nEnemy health: {enemy.EnemyHealth}\nEnemy damage: {enemy.EnemyDamage}");
                        while (true)
                        {
                            playerStatus[playerName].Health -= enemy.EnemyDamage;
                            Console.WriteLine("Choose an action:\nAttack\nBlock /Not implemented yet");
                            string[] command = Console.ReadLine().Split(' ');
                            if (enemy.EnemyHealth <= 0)
                            {
                                Console.WriteLine($"You died\nPlayer stats:\nGold Collected: {playerGold}");
                                randomGoldReward(playerGold);
                                break;
                            }
                            if (playerStatus[playerName].Health <= 0)
                            {
                                Console.WriteLine($"You died\nPlayer stats:\nGold Collected: {playerGold}");
                                return;
                            }
                            if (command[0] == "Attack")
                            {
                                enemy.EnemyHealth -= playerStatus[playerName].Damage;
                            }
                        }
                    }
                    else if (enemyType == "Human")
                    {
                        string type = "human";
                        int health = 1;
                        int damage = 1;
                        EnemiesProperties enemy = new EnemiesProperties(type, health, damage);
                        Console.WriteLine($"You are being attacked!\nAttacker:{enemyType}\nEnemy health: {enemy.EnemyHealth}\nEnemy damage: {enemy.EnemyDamage}");
                        while (true)
                        {
                            playerStatus[playerName].Health -= enemy.EnemyDamage;
                            Console.WriteLine("Choose an action:\nAttack\nBlock /Not implemented yet");
                            string[] command = Console.ReadLine().Split(' ');
                            if (enemy.EnemyHealth <= 0)
                            {
                                Console.WriteLine($"You killed the {enemy.EnemyName}");
                                randomGoldReward(playerGold);
                                break;
                            }
                            if (playerStatus[playerName].Health <= 0)
                            {
                                Console.WriteLine($"You died\nPlayer stats:\nGold Collected: {playerGold}");
                                return;
                            }
                            if (command[0] == "Attack")
                            {
                                enemy.EnemyHealth -= playerStatus[playerName].Damage;
                            }
                        }
                    }
                    Thread.Sleep(1000);
                }
                else
                {
                    continue;
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
        static string randomEnemyEncounter(List<string> enemies)
        {
            //Random pick for enemy type 
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
        static string randomWordsEncounter(List<string> randomWords)
        {
            //Random words for sentences 
            string wordType = string.Empty;
            Random randomWord = new Random();

            int randomWordEncounter = randomWord.Next(0, 8);
            if (randomWordEncounter == 0)
            {
                wordType = randomWords[0];
            }
            else if (randomWordEncounter == 1)
            {
                wordType = randomWords[1];
            }
            else if (randomWordEncounter == 2)
            {
                wordType = randomWords[2];
            }
            else if (randomWordEncounter == 3)
            {
                wordType = randomWords[3];
            }
            else if (randomWordEncounter == 4)
            {
                wordType = randomWords[4];
            }
            else if (randomWordEncounter == 5)
            {
                wordType = randomWords[5];
            }
            else if (randomWordEncounter == 6)
            {
                wordType = randomWords[6];
            }
            else if (randomWordEncounter == 7)
            {
                wordType = randomWords[7];
            }
            else if (randomWordEncounter == 8)
            {
                wordType = randomWords[8];
            }
            else if (randomWordEncounter == 9)
            {
                wordType = randomWords[9];
            }

            return wordType;
        }
        static bool chanceToEncounterEnemy(bool Encounter)
        {
            //Random chance to encounter an enemy
            Random rndEncounter = new Random();

            int randomChanceToEncounter = rndEncounter.Next(0, 2);
            if (randomChanceToEncounter == 0 || randomChanceToEncounter == 2)
            {
                return Encounter = true;
            }
            else
            {
                return Encounter = false;
            }
        }
    }
    class PlayerStatus
    {
        public PlayerStatus(string playerName, int health, int damage, int capacity, int gold)
        {
            this.PlayerName = playerName;
            this.Health = health;
            this.Damage = damage;
            this.Backpack = new List<Weapon>(capacity);
            this.Capacity = capacity;
            this.Gold = gold;
        }

        public string PlayerName { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public List<Weapon> Backpack { get; set; }
        public int Capacity { get; set; }
        public int Gold { get; set; }
    }
    class Weapon
    {
        public string WeaponName { get; set; }
        public int Damage { get; set; }
    }
    class EnemiesProperties
    {
        public EnemiesProperties(string enemyName, int enemyHealth, int enemyDamage)
        {
            this.EnemyName = enemyName;
            this.EnemyHealth = enemyHealth;
            this.EnemyDamage = enemyDamage;
        }

        public string EnemyName { get; set; }
        public int EnemyHealth { get; set; }
        public int EnemyDamage { get; set; }
    }
}
