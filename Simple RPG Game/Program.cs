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
            //TODO add armour
            string playerName = string.Empty;
            string playerClass = string.Empty;
            int playerHealth = 0;
            int playerDamage = 0;
            int playerGold = 0;
            int backpackCapacity = 0;
            int backpackMaxCapacity = 0; 
            int experience = 0;
            int currentLevel = 1;

            int experienceNeededToLevelUp = 100;
            //List of enemies the player will encounter
            List<string> enemies = new List<string>() { "Zombie", "Skeleton", "Human" };
            string enemyType = string.Empty;
            int health = 0;
            int damage = 0;
            EnemiesProperties enemy = new EnemiesProperties(health, damage);
            EnemiesProperties zombie = new EnemiesProperties(health, damage);
            EnemiesProperties skeleton = new EnemiesProperties(health, damage);
            EnemiesProperties human = new EnemiesProperties(health, damage);

            //Weapons stats
            //TODO
            string weaponName = string.Empty;
            int weaponDamage = 0;


            //List of randomized words
            List<string> randomWords = new List<string>() { "awoken", "reanimated", "spawned", "resurrected", "reborn", "called upon the gods", "rejuvenated", "created", "revived" };

            //List of randomized weapon names
            List<string> randomWeaponNames = new List<string>() { "Lightbane", "Soul Reaper", "Stormcaller", "Fusion Katana", "Vindictive Warblade", "Crazed Adamantite Rapier", "Protector's Gold Scimitar", "Cursed Broadsword", "Savage Diamond Quickblade", "Volcanic Doomblade", "Fierce Skeletal Carver", "Bloodlord's Mithril Swiftblade" };

            //Dictionary for the player stats (name, health, damage, backpack capacity)
            Dictionary<string, PlayerStatus> playerStatus = new Dictionary<string, PlayerStatus>();

            Console.WriteLine("Console RPG       Version 1.0\n\nStart\n");
            string menuChoice = Console.ReadLine().ToLower();
            if (menuChoice == "start")
            {
                Console.Clear();
                //Class selection
                Console.WriteLine("Choose player class:\nHuman - 3 health 1 damage 5 backpack slots\nZombie - 2 health 2 damage 3 backpack slots\nSkeleton 1 health 3 damage 2 backpack slots\n");
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
                    playerDamage = 10;
                    backpackCapacity = 5;
                    backpackMaxCapacity = 5;
                    playerGold = 0;
                    PlayerStatus currentPlayerStatus = new PlayerStatus(playerName, playerHealth, playerDamage, backpackCapacity, backpackMaxCapacity, playerGold, experience, currentLevel);
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
                    backpackMaxCapacity = 3;
                    playerGold = 0;
                    PlayerStatus currentPlayerStatus = new PlayerStatus(playerName, playerHealth, playerDamage, backpackCapacity, backpackMaxCapacity, playerGold, experience, currentLevel);
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
                    backpackMaxCapacity = 2;
                    playerGold = 0;
                    PlayerStatus currentPlayerStatus = new PlayerStatus(playerName, playerHealth, playerDamage, backpackCapacity, backpackMaxCapacity, playerGold, experience, currentLevel);
                    playerStatus[playerName] = currentPlayerStatus;
                    string randomWord = string.Empty;
                    randomWord = randomWordsEncounter(randomWords);
                    Console.WriteLine($"{playerName} the {playerClass} has been {randomWord}");
                }
            }
            Thread.Sleep(2000);
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
                    enemyType = string.Empty;
                    enemyType = randomEnemyEncounter(enemies);

                    EnemyStatus(enemyType, ref health, ref damage, ref enemy, ref zombie, ref skeleton, ref human);

                    Console.Clear();
                    Console.WriteLine($"You are being attacked!\n\nAttacker:{enemyType}\nEnemy health: {enemy.EnemyHealth}\nEnemy damage: {enemy.EnemyDamage}\n");
                    while (true)
                    {

                        if (enemy.EnemyHealth <= 0)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"You killed the {enemyType}");
                            Console.ForegroundColor = ConsoleColor.White;
                            randomGoldReward(playerName, playerStatus);
                            randomExperienceReward(playerName, playerStatus);
                            Console.WriteLine($"Experience needed to level up: {playerStatus[playerName].Experience}/{experienceNeededToLevelUp}");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Press any key to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            if (playerStatus[playerName].Experience >= experienceNeededToLevelUp)
                            {
                                experienceNeededToLevelUp = IfGainedLevel(playerName, experienceNeededToLevelUp, playerStatus);
                                break;
                            }
                            break;
                        }
                        if (playerStatus[playerName].Health <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"You died\nPlayer stats:\nGold Collected: {playerStatus[playerName].Gold}");
                            Console.ForegroundColor = ConsoleColor.White;
                            return;
                        }
                        Console.WriteLine("Choose an action:\nAttack\nBlock\n");
                        string[] command = Console.ReadLine().ToLower().Split(' ');
                        if (command[0] == "attack")
                        {
                            int currentEnemyHealth = enemy.EnemyHealth;
                            enemy.EnemyHealth -= playerStatus[playerName].Damage;

                            if (enemy.EnemyHealth <= 0)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"You killed the {enemyType}");
                                Console.ForegroundColor = ConsoleColor.White;
                                randomGoldReward(playerName, playerStatus);
                                randomExperienceReward(playerName, playerStatus);
                                Console.WriteLine($"Experience needed to level up: {playerStatus[playerName].Experience}/{experienceNeededToLevelUp}");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Press any key to continue...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                if (playerStatus[playerName].Experience >= experienceNeededToLevelUp)
                                {
                                    experienceNeededToLevelUp = IfGainedLevel(playerName, experienceNeededToLevelUp, playerStatus);
                                    break;
                                }
                                break;
                            }

                            Console.WriteLine($"You've hit the enemy for {playerStatus[playerName].Damage}\nCurrent enemy health {enemy.EnemyHealth}");
                            playerStatus[playerName].Health -= enemy.EnemyDamage;
                        }
                        if (command[0] == "block")
                        {
                            bool ifBlocked = false;
                            ifBlocked = chanceToBlock(ifBlocked);
                            if (ifBlocked)
                            {
                                Console.Clear();
                                Console.WriteLine("You've blocked succesfully and counter attacked your enemy");
                                int currentEnemyHealth = enemy.EnemyHealth;
                                enemy.EnemyHealth -= playerStatus[playerName].Damage;

                                Console.WriteLine($"You've hit the enemy for {playerStatus[playerName].Damage}\nCurrent enemy health {enemy.EnemyHealth}");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Press any key to continue...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else
                            {
                                Console.Clear();
                                playerStatus[playerName].Health -= enemy.EnemyDamage;
                                Console.WriteLine("Block was unsuccessful");
                                Console.WriteLine($"You got hit\n-{enemy.EnemyDamage}\nCurrent health: {playerStatus[playerName].Health}HP");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Press any key to continue...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                    }
                }
                else
                {
                    bool isChestFound = false;
                    isChestFound = chanceToGetATreasureChest(isChestFound);
                    if (isChestFound)
                    {
                        Console.WriteLine("You've found a treasure chest!");
                        bool weaponOrGold = false;
                        weaponOrGold = randomLoot(weaponOrGold);
                        if (weaponOrGold)
                        {
                            Console.Clear();
                            Console.WriteLine("You've found a weapon!");
                            weaponName = randomWeapon(randomWeaponNames);
                            //Weapon currentWeapon = new Weapon(weaponName,weaponDamage);
                            //Console.WriteLine("Do you want to pick it up?\nYes\nNo");
                            //string pickUpChoice = Console.ReadLine().ToLower();
                            //if (pickUpChoice == "yes")
                            //{
                            //    if (playerStatus[playerName].Capacity != playerStatus[playerName].BackpackMaxCapacity)
                            //    {
                            //        Console.Clear();
                            //        Console.WriteLine("Theres enough space");
                            //        //TODO
                            //    }
                            //}
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Press any key to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You've found some gold!");
                            randomGoldReward(playerName, playerStatus);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Press any key to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                        } 
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You continue down the abyss...");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Press any key to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                    }
                }
            }
        }

        private static int IfGainedLevel(string playerName, int experienceNeededToLevelUp, Dictionary<string, PlayerStatus> playerStatus)
        {
            Console.Clear();
            experienceNeededToLevelUp += 250;
            playerStatus[playerName].Level++;
            Console.WriteLine($"You leveled up!\nYour level now is {playerStatus[playerName].Level}\nPick a power:\nHealth up +1\nDamage up +1");
            string skillPointToSpend = Console.ReadLine().ToLower();
            if (skillPointToSpend == "health" || skillPointToSpend == "health up")
            {
                playerStatus[playerName].Health += 1;
            }
            else if (skillPointToSpend == "damage" || skillPointToSpend == "damage up")
            {
                playerStatus[playerName].Damage++;
            }
            Console.WriteLine($"Your current status\nHealth: {playerStatus[playerName].Health}\nDamage: {playerStatus[playerName].Damage}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            return experienceNeededToLevelUp;
        }
        static void EnemyStatus(string enemyType, ref int health, ref int damage, ref EnemiesProperties enemy, ref EnemiesProperties zombie, ref EnemiesProperties skeleton, ref EnemiesProperties human)
        {
            if (enemyType == "Zombie")
            {
                health = 5;
                damage = 1;
                zombie = new EnemiesProperties(health, damage);
            }
            else if (enemyType == "Skeleton")
            {
                health = 4;
                damage = 5;
                skeleton = new EnemiesProperties(health, damage);
            }
            else if (enemyType == "Human")
            {
                health = 5;
                damage = 2;
                human = new EnemiesProperties(health, damage);
            }
            if (enemyType == "Zombie")
            {
                enemy = zombie;
            }
            else if (enemyType == "Skeleton")
            {
                enemy = skeleton;
            }
            else if (enemyType == "Human")
            {
                enemy = human;
            }
        }
        static void randomGoldReward(string playerName, Dictionary<string, PlayerStatus> playerStatus)
        {
            //Random gold reward after each enemy encounter
            Random rndGold = new Random();

            int randomGold = rndGold.Next(10, 20);
            playerStatus[playerName].Gold += randomGold;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{randomGold}+ Gold!");
            Console.WriteLine($"You have {playerStatus[playerName].Gold} gold!\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void randomExperienceReward(string playerName, Dictionary<string, PlayerStatus> playerStatus)
        {
            //Random gold reward after each enemy encounter
            Random rndEXP = new Random();

            int randomExperience = rndEXP.Next(10, 20);
            playerStatus[playerName].Experience += randomExperience;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{randomExperience}+ EXP!");
            Console.WriteLine($"You have {playerStatus[playerName].Experience} EXP!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static int randomDamageForWeapons(int weaponDamage)
        {
            //Random damage for weapons
            Random rndDMG = new Random();

            int randomDamage = rndDMG.Next(10, 20);
            weaponDamage = randomDamage;
            return weaponDamage;
            
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
        static string randomWeapon(List<string> randomWeaponNames)
        {
            //Random pick for enemy type 
            string weaponName = string.Empty;
            Random randomWeaponName = new Random();

            int randomEnemyEncounter = randomWeaponName.Next(0, 10);
            if (randomEnemyEncounter == 0)
            {
                weaponName = randomWeaponNames[0];
            }
            else if (randomEnemyEncounter == 1)
            {
                weaponName = randomWeaponNames[1];
            }
            else if (randomEnemyEncounter == 2)
            {
                weaponName = randomWeaponNames[2];
            }
            else if (randomEnemyEncounter == 3)
            {
                weaponName = randomWeaponNames[3];
            }
            else if (randomEnemyEncounter == 4)
            {
                weaponName = randomWeaponNames[4];
            }
            else if (randomEnemyEncounter == 5)
            {
                weaponName = randomWeaponNames[5];
            }
            else if (randomEnemyEncounter == 6)
            {
                weaponName = randomWeaponNames[6];
            }
            else if (randomEnemyEncounter == 7)
            {
                weaponName = randomWeaponNames[7];
            }
            else if (randomEnemyEncounter == 8)
            {
                weaponName = randomWeaponNames[8];
            }
            else if (randomEnemyEncounter == 9)
            {
                weaponName = randomWeaponNames[9];
            }
            else if (randomEnemyEncounter == 10)
            {
                weaponName = randomWeaponNames[10];
            }
            return weaponName;
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

            int randomChanceToEncounter = rndEncounter.Next(0, 3);
            if (randomChanceToEncounter == 0 || randomChanceToEncounter == 3)
            {
                return Encounter = true;
            }
            else
            {
                return Encounter = false;
            }
        }
        static bool randomLoot(bool Encounter)
        {
            //Random chance to encounter an enemy
            Random rndLoot = new Random();

            int randomLoot = rndLoot.Next(0, 2);
            if (randomLoot == 0 || randomLoot == 2)
            {
                return Encounter = true;
            }
            else
            {
                return Encounter = false;
            }
        }
        static bool chanceToGetATreasureChest(bool Encounter)
        {
            //Random chance to encounter an enemy
            Random rndChest = new Random();

            int randomChanceToEncounter = rndChest.Next(0, 3);
            if (randomChanceToEncounter == 0 || randomChanceToEncounter == 3)
            {
                return Encounter = true;
            }
            else
            {
                return Encounter = false;
            }
        }
        static bool chanceToBlock(bool BlockChance)
        {
            //Random chance to encounter an enemy
            Random rndBlock = new Random();

            int randomChanceToBlock = rndBlock.Next(0, 2);
            if (randomChanceToBlock == 0 || randomChanceToBlock == 2)
            {
                return BlockChance = true;
            }
            else
            {
                return BlockChance = false;
            }
        }
    }
}
