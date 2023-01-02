namespace Console_RPG.Models.Enemies.Interfaces
{
using Console_RPG.Models.Interfaces;

    public interface IEnemy : IBasicAbility
    {
        int Health { get; }

        int Damage { get; }
     
    }
}
