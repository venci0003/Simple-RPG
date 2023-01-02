using Console_RPG.Models.Enemy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Models.Enemies.EnemiesClasses
{
    public class Slime : EnemyEntity
    {
        public const int HEALTH_INCREMENT = 5;

        public const int DAMAGE_INCREMENT = 10;
        public Slime() : base(HEALTH_INCREMENT, DAMAGE_INCREMENT)
        {
        }
    }
}
