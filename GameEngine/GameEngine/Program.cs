// See https://aka.ms/new-console-template for more information
using GameEngine.Domain.Models;
using GameEngine.Domain.Models.Environment;
using static System.Console;

/*
WriteLine(" ......      ...   ...      ...       ...     ...    ...... \r\n" +
          ".........    ...   ....    ....      .....     ..   ........\r\n" +
          "..      ..         .....  .....     .......     .   ...   ..\r\n" +
          "..      ..   ...   ............    ...   ...         ...    \r\n" +
          "..      ..   ...   ...  ..  ...   ...     ...         ...   \r\n" +
          "..      ..   ...   ...      ...   ...........          ...  \r\n" +
          "..     ..    ...   ...      ...   ...........       ..  ... \r\n" +
          "........     ...   ...      ...   ...     ...       ........\r\n" +
          " ......       .    ...      ...   ...     ...        ...... \r\n" +
          "                          _____   ____                      \r\n" +
          "     _                   / ____| |  __|                     \r\n" +
          "  __| |  _   _   _ __   | |  __  | |__    ___    _ __       \r\n" +
          " / _` | | | | | | '_ \\  | | |_ | |  __|  / _ \\  | '_ \\      \r\n" +
          "| (_| | | |_| | | | | \\ | |__| | | |__  | (_) | | | | \\     \r\n" +
          " \\__,_|  \\__,_| |_| |_|  \\_____| |____|  \\___/  |_| |_|      ");
WriteLine("               PRESS ANY KEY TO START");
ReadKey();
*/
GameStarting();
GameMap gameMap = new(new List<List<dynamic>>());
gameMap.BuildMap(10, 10, 10, 5);

GameProcess game = new GameProcess(gameMap);
game.TriggerEvent = a => WriteLine(a);

while (true)
{
    Clear();
    if (game.CheckWin())
    {
        WriteLine("YOU WIN!!!!!!");
        ReadKey();
        return;
    }
    game.VisualMap.InitiateVisualMap();
    game.ShowPlayer();

    WriteLine("Enter move (w, a, s, d) or press Escape to exit:");

    ConsoleKey key = ReadKey(true).Key;

    if (key == ConsoleKey.Escape)
    {
        break;
    }

    char action = key.ToString().ToLower()[0];

    if ("wasd".Contains(action))
    {
        game.MakeMove(action);
    }
    else
    {
        WriteLine("Wrong move direction.");
    }
}


void GameStarting()
{
    string _dima = " ......      ...   ...      ...       ...     ...    ...... \r\n" +
          ".........    ...   ....    ....      .....     ..   ........\r\n" +
          "..      ..         .....  .....     .......     .   ...   ..\r\n" +
          "..      ..   ...   ............    ...   ...         ...    \r\n" +
          "..      ..   ...   ...  ..  ...   ...     ...         ...   \r\n" +
          "..      ..   ...   ...      ...   ...........          ...  \r\n" +
          "..     ..    ...   ...      ...   ...........       ..  ... \r\n" +
          "........     ...   ...      ...   ...     ...       ........\r\n" +
          " ......       .    ...      ...   ...     ...        ...... \r\n";
    string _dungeon = "                          _____   ____                      \r\n" +
          "     _                   / ____| |  __|                     \r\n" +
          "  __| |  _   _   _ __   | |  __  | |__    ___    _ __       \r\n" +
          " / _` | | | | | | '_ \\  | | |_ | |  __|  / _ \\  | '_ \\      \r\n" +
          "| (_| | | |_| | | | | \\ | |__| | | |__  | (_) | | | | \\     \r\n" +
          " \\__,_|  \\__,_| |_| |_|  \\_____| |____|  \\___/  |_| |_|     ";
    string _pressKey = "               PRESS ANY KEY TO START";

    ForegroundColor = ConsoleColor.Magenta;
    WriteLine(_dima);
    ForegroundColor = ConsoleColor.Red;
    WriteLine(_dungeon);
    ResetColor();
    WriteLine(_pressKey);
    ReadKey();
}
