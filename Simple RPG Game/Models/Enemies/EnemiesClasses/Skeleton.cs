using Console_RPG.Models.Enemy;

namespace Console_RPG.Models.Enemies.EnemiesClasses
{
    public class Skeleton : EnemyEntity
    {
        public const int HEALTH_INCREMENT = 10;

        public const int DAMAGE_INCREMENT = 30;
        public Skeleton() : base(HEALTH_INCREMENT, DAMAGE_INCREMENT)
        {
        }
    }
}
