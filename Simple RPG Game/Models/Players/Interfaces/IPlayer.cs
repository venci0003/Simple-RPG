using Console_RPG.Models.Enemies.Interfaces;
using Console_RPG.Models.Interfaces;

namespace Console_RPG.Models.Players.Interfaces
{
    public interface IPlayer : IInventory, IExperience, IBasicAbility
    {
        string Name { get; }

        int Health { get; }

        int Damage { get; }

        int Gold { get; }
    }
}
