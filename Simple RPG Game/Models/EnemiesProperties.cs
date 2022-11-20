using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    public class EnemiesProperties
    {
        private int enemyHealth;

        private int enemyDamage;

        public EnemiesProperties(int enemyHealth, int enemyDamage)
        {

            this.EnemyHealth = enemyHealth;
            this.EnemyDamage = enemyDamage;
        }


        public int EnemyHealth
        {
            get { return this.enemyHealth; }

            set { this.enemyHealth = value; }
        }
        public int EnemyDamage
        {
            get { return this.enemyDamage; }

            set { this.enemyDamage = value; }
        }

        public void EnemyStatus(string enemyType, ref int health, ref int damage, ref EnemiesProperties enemy, ref EnemiesProperties zombie, ref EnemiesProperties skeleton, ref EnemiesProperties human)
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
    }
}
