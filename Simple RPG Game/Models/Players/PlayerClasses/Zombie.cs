using Console_RPG.Models.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Models.Players.PlayerClasses
{
    public class Zombie : PlayerEntity
    {
        public const int HEALTH_INCREMENT = 50;

        public const int DAMAGE_INCREMENT = 30;

        public const int BACKPACK_CAPACITY_INCREMENT = 3;

        public const int GOLD_INCREMENT = 10;

        public Zombie(string playerName, int experience, int level) : base(playerName, HEALTH_INCREMENT, DAMAGE_INCREMENT, BACKPACK_CAPACITY_INCREMENT, GOLD_INCREMENT, experience, level)
        {
        }
    }
}
