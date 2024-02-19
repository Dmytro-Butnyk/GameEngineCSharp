using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Domain.Models.Environment
{
    public class PlayerCamera(GameMap map, List<List<char>> camera)
    {
        private GameMap _map = map;
        private List<List<char>> _camera = camera;
    }
}
