namespace Console_RPG.Models.Enemies.EnemiesClasses
{
    using Console_RPG.Models.Enemy;
    public class Mercenary : EnemyEntity
    {
        public const int HEALTH_INCREMENT = 25;

        public const int DAMAGE_INCREMENT = 15;
        public Mercenary() : base(HEALTH_INCREMENT, DAMAGE_INCREMENT)
        {
        }
    }
}
