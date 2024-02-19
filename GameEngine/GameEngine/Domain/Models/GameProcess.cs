using GameEngine.Domain.Interfaces;
using GameEngine.Domain.Models.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;
using static System.Console;

namespace GameEngine.Domain.Models
{
    public class GameProcess : IGameProcess
    {
        private GameMap _gameMap = new();
        private VisualMap _visualMap = new();
        public EventHandler TriggerEvent;
        // constructors
        #region 
        public GameProcess(GameMap gameMap)
        {
            _gameMap = gameMap;
            _visualMap = new(_gameMap);
        }
        public GameProcess()
        {
            _visualMap = new();
            _gameMap = new();
        }
        #endregion

        // properties
        #region
        public GameMap GameMap
        {
            get { return _gameMap; }
            set
            {
                if (value == null) throw new Exception("Null gameMap");
                _gameMap = value;
            }
        }
        public VisualMap VisualMap
        {
            get { return _visualMap; }
            set
            {
                if (value == null) throw new Exception("Null visualMap");
                _visualMap = value;
            }
        }
        #endregion

        // interface methods
        #region
        public void MakeMove(char move)
        {
            int heroRow, heroCol;
            (heroRow, heroCol) = CheckHeroPosition();
            if (CheckMovePosition(move, heroRow, heroCol))
            {
                SwitchMove(move, heroRow, heroCol);
            }
            _visualMap = new(_gameMap);
        }
        public (int, int) CheckHeroPosition()
        {
            for (int i = 0; i < _gameMap.BackMap.Count; i++)
            {
                for (int j = 0; j < _gameMap.BackMap[i].Count; j++)
                {
                    if (_gameMap.BackMap[i][j] is MainHero)
                    {
                        return (i, j);
                    }
                }
            }
            return (0, 0);
        }
        public bool CheckMovePosition(char move, int x, int y)
        {
            switch (move)
            {
                case 'w':
                    return x - 1 >= 0;
                case 'a':
                    return y - 1 >= 0;
                case 's':
                    return x + 1 <= _gameMap.BackMap.Count - 1;
                case 'd':
                    return y + 1 <= _gameMap.BackMap[0].Count - 1;
                default:
                    WriteLine("Entered wrong direction!");
                    return false;
            }
        }
        public async void SwitchMove(char move, int x, int y)
        {
            int newX = x, newY = y;

            switch (move)
            {
                case 'w':
                    newX--;
                    break;
                case 'a':
                    newY--;
                    break;
                case 's':
                    newX++;
                    break;
                case 'd':
                    newY++;
                    break;
                default:
                    return;
            }

            var hero = _gameMap.BackMap[x][y] as MainHero;
            var cell = _gameMap.BackMap[newX][newY];

            if (cell is Enemy enemy)
            {
                    TriggerEvent?.Invoke($"Battle with {enemy}");
                    Thread.Sleep(2000);
                if (enemy.Action(ref hero))
                {
                    _gameMap.BackMap[x][y] = hero;
                    _gameMap.BackMap[newX][newY] = new Ground(Enums.GroundType.ground);
                }
                else
                {
                    WriteLine("Health < 0. Game over");
                    ReadKey();
                    Exit(0);
                }
            }
            else if (cell is Coin coin)
            {
                coin.Action(ref hero);
                _gameMap.BackMap[x][y] = hero;
                _gameMap.BackMap[newX][newY] = new Ground(Enums.GroundType.ground);
                TriggerEvent?.Invoke($"Up {coin}");
                Thread.Sleep(1000);
            }

            (_gameMap.BackMap[x][y], _gameMap.BackMap[newX][newY]) =
                (_gameMap.BackMap[newX][newY], _gameMap.BackMap[x][y]);
        }


        public bool CheckWin()
        {
            foreach(var it in _gameMap.BackMap)
            {
                foreach(var cell in it)
                {
                    if (cell is Enemy)
                        return false;
                }
            }
            return true;
        }
        public void ShowPlayer()
        {
            int x, y;
            (x, y) = CheckHeroPosition();
            var hero = _gameMap.BackMap[x][y] as MainHero;
            WriteLine(hero);
        }
        #endregion
    }

    public delegate void EventHandler(string Message);
}
