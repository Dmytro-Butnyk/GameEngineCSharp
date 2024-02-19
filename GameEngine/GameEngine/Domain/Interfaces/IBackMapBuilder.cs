namespace GameEngine.Domain.Interfaces
{
    public interface IBackMapBuilder
    {
        public abstract void BuildMap(int width, int height, int numEnemies, int numCoins);
    }
}
