using GameEngine.Domain.Models;

namespace GameEngine.Domain.Interfaces
{
    public interface IPeacefulActionHandler
    {
        public void Action(ref MainHero mainHero);
    }
    public interface IHostileActionHandler
    {
        public bool Action(ref MainHero mainHero);
    }
}
