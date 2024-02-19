using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Domain.Interfaces
{
    public interface IGameProcess
    {
        public void MakeMove(char move);
        public (int, int) CheckHeroPosition();
        public bool CheckWin();
        public bool CheckMovePosition(char move, int x, int y);
        public void SwitchMove(char move, int x, int y);
        public void ShowPlayer();
    }
}
