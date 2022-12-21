using Console_RPG.Models.Players.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Models.Enemies
{
    public interface IEnemy
    {
        int Health { get; }

        int Damage { get; }
        public void EnemyDealDamage(IPlayer firstPlayer, IPlayer enemy);

        public void EnemyTakeDamage(IPlayer player);
    }
}
