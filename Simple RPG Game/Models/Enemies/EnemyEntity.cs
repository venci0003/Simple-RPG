using Console_RPG.Models.Enemies.Interfaces;
using Console_RPG.Models.Players.Interfaces;

namespace Console_RPG.Models.Enemy
{
    public abstract class EnemyEntity : IEnemy
    {
        private int health;

        public EnemyEntity(int enemyHealth, int enemyDamage)
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
