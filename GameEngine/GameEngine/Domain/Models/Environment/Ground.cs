using GameEngine.Domain.Enums;

namespace GameEngine.Domain.Models.Environment
{
    public class Ground(GroundType type)
    {
        public GroundType _type = type;
    }
}
