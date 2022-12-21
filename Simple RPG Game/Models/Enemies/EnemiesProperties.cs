using Console_RPG.Models.Enemies;
using Console_RPG.Models.Players.Interfaces;

namespace Console_RPG.Models.Enemy
{
    public abstract class EnemiesProperties : IEnemy
    {
        private int health;

        public EnemiesProperties(int enemyHealth, int enemyDamage)
        {
            Health = enemyHealth;
            Damage = enemyDamage;
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

        public void EnemyDealDamage(IPlayer enemy, IPlayer player)
        {
            player.TakeDamage(enemy);
        }

        public void EnemyTakeDamage(IPlayer player)
        {
            health -= player.Damage;
        }
    }
}
