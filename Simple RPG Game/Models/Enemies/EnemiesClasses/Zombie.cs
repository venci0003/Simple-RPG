namespace Console_RPG.Models.Enemies.EnemiesClasses
{

    using Console_RPG.Models.Enemy;
    public class Zombie : EnemyEntity
    {
        public const int HEALTH_INCREMENT = 15;

        public const int DAMAGE_INCREMENT = 20;
        public Zombie() : base(HEALTH_INCREMENT, DAMAGE_INCREMENT)
        {
        }
    }
}
