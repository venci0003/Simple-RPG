using Console_RPG.Models.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Models.Players.PlayerClasses
{
    public class Skeleton : PlayerEntity
    {
        public const int HEALTH_INCREMENT = 25;

        public const int DAMAGE_INCREMENT = 50;

        public const int BACKPACK_CAPACITY_INCREMENT = 2;

        public const int GOLD_INCREMENT = 100;

        public Skeleton(string playerName, int experience, int level) : base(playerName, HEALTH_INCREMENT, DAMAGE_INCREMENT, BACKPACK_CAPACITY_INCREMENT, GOLD_INCREMENT, experience, level)
        {
        }
    }
}
