namespace Console_RPG.Models.Players.Interfaces
{
    public interface IPlayer : IInventory, IExperience
    {
        string Name { get; }

        int Health { get; }

        int Damage { get; }

        int Gold { get; }

        public void DealDamage(IPlayer firstPlayer, IPlayer enemy);

        public void TakeDamage(IPlayer player);
    }
}
