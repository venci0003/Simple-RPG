using Console_RPG.Models.Enemies.Interfaces;
using Console_RPG.Models.Players.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Models.Interfaces
{
    public interface IBasicAbility
    {
        public void DealDamage(IPlayer firstPlayer, IEnemy enemy);

        public void TakeDamage(IPlayer player);
    }
}
