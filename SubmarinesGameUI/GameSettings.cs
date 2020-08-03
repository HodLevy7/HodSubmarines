using SubmarinesGameBL;
using System.Collections.Generic;

namespace SubmarinesGameUI
{
    public class GameSettings
    {
        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }
        public bool IsWithDiagonal { get; set; }
        public bool IsGameVSComputer { get; set; }
        public GameLevel LevelOfGame { get; set; }

        public GameSettings()
        {
            LevelOfGame = GameLevel.CLASSIC;
            BoardHeight = ConfigIssues.BoardClassicHeight;
            BoardWidth = ConfigIssues.BoardClassicWidth;
            IsWithDiagonal = false;
            IsGameVSComputer = false;
        }


        public List<Player> CreatePlayersToGame(string firstPlayersName, string secondPlayersName)
        {
            return new List<Player>()
            {
                {new Player(firstPlayersName, new GameBoard(BoardHeight, BoardWidth)) },
                {new Player(secondPlayersName, new GameBoard(BoardHeight, BoardWidth)) }
            };
        }
    }
}
