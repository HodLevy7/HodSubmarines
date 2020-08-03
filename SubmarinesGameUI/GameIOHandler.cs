using SubmarinesGameBL;
using System.Collections.Generic;

namespace SubmarinesGameUI
{
    public abstract class GameIOHandler
    {
        private GameSettings SettingsOfGame { get; set; }
        private GameManagement GameLogic { get; set; }
        public abstract void Write(string content);
        public abstract void WriteLine(string content);
        public abstract string ReadLine();

        public string ReadUnemptyString()
        {
            string content = ReadLine();
            if (string.IsNullOrEmpty(content))
            {
                Write("You didn't enter a valid content. Please Try again");
                content = ReadUnemptyString();
            }
            return content;
        }

        public int ReadInteger()
        {
            int content;

            if (!int.TryParse(ReadLine(), out content))
            {
                WriteLine("You haven't enter an integer. Please Try Again");
                content = ReadInteger();
            }

            return content;
        }

        public void StartGame()
        {
            SettingsOfGame = GameSettingsInitializer.InitialSettings(this);
            GetPlayersDetails();
        }

        public void GetPlayersDetails()
        {
            string firstPlayer, secondPlayer;

            WriteLine("First player, please enter your name:");
            firstPlayer = ReadUnemptyString();
            WriteLine("Second player, please enter your name:");
            secondPlayer = ReadUnemptyString();
            List<Player> Players = SettingsOfGame.CreatePlayersToGame(firstPlayer, secondPlayer);
            GameLogic = new GameManagement(Players[0], Players[1]);
        }
    }
}
