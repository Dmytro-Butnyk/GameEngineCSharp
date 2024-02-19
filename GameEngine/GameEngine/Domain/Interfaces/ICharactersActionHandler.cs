using GameEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
