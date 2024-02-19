using GameEngine.Domain.Models.Environment;
using GameEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Domain.Interfaces
{
    public interface IBackMapBuilder
    {
        public abstract void BuildMap(int width, int height, int numEnemies, int numCoins);
    }
}
