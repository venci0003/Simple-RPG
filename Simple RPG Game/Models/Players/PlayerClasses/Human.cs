using System;
using System.Collections.Generic;
using System.Text;
using Console_RPG.Models.Player;

namespace Console_RPG.Models.Players.PlayerClasses
{
    public class Human : PlayerEntity
    {
        public const int HEALTH_INCREMENT = 100;

        public const int DAMAGE_INCREMENT = 10;

        public const int BACKPACK_CAPACITY_INCREMENT = 5;

        public const int GOLD_INCREMENT = 20;

        public Human(string playerName, int experience, int level) : base(playerName, HEALTH_INCREMENT, DAMAGE_INCREMENT, BACKPACK_CAPACITY_INCREMENT, GOLD_INCREMENT, experience, level)
        {
        }
    }
}
