namespace Console_RPG.Models.Interfaces
{
    public interface IPlayer : IInventory, IExperience
    {
        string Name { get; }

        string PlayerClass { get; }

        int Health { get; }

        int Damage { get; }

        int Gold { get; }
    }
}
