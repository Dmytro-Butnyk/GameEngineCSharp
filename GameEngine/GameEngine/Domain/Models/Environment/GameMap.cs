using GameEngine.Domain.Interfaces;

namespace GameEngine.Domain.Models.Environment
{
    public class GameMap : IBackMapBuilder
    {
        private List<List<dynamic>> _backMap;

        public GameMap()
        {
            _backMap = new List<List<dynamic>>();
        }
        public GameMap(List<List<dynamic>> backMap)
        {
            _backMap = backMap;
        }
        public List<List<dynamic>> BackMap
        {
            get { return _backMap; }
        }

        public void BuildMap(int width, int height, int numEnemies, int numCoins)
        {
            _backMap = new List<List<dynamic>>();

            Random random = new Random();

            // Initialize the map with null
            for (int i = 0; i < width; i++)
            {
                _backMap.Add(new List<dynamic>());
                for (int j = 0; j < height; j++)
                {
                    _backMap[i].Add(null);
                }
            }

            // Add the main hero
            PlaceRandomly(new MainHero(10, 1, 10, 5));

            // Add enemies
            for (int i = 0; i < numEnemies; i++)
            {
                PlaceRandomly(new Enemy(random.Next(1, 7)));
            }

            // Add coins
            for (int i = 0; i < numCoins; i++)
            {
                PlaceRandomly(new Coin(random.Next(1, 10)));
            }

            // Fill the rest with ground
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (_backMap[i][j] == null)
                    {
                        _backMap[i][j] = new Ground(Enums.GroundType.ground);
                    }
                }
            }

            void PlaceRandomly(dynamic gameObject)
            {
                int x, y;
                do
                {
                    x = random.Next(width);
                    y = random.Next(height);
                }
                while (_backMap[x][y] != null);

                _backMap[x][y] = gameObject;
            }
        }
    }
}
