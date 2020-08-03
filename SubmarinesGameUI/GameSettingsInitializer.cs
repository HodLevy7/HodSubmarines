using SubmarinesGameBL;

namespace SubmarinesGameUI
{
    public static class GameSettingsInitializer
    {
        private static GameSettings Settings { get; set; }
        public static GameSettings InitialSettings(GameIOHandler iOHandler)
        {
            Settings = new GameSettings();
            bool isBoardValid = false;

            iOHandler.WriteLine("Welcome to Submarines Game!");
            iOHandler.WriteLine("Whould you like to change the standard settings for the game? Click 1 for YES, 2 for NO"); //change that...
            if (GetYesOrNoAnswer(iOHandler) == 1)
            {
                do
                {
                    iOHandler.WriteLine("Please enter Board's Height:");
                    Settings.BoardHeight = iOHandler.ReadInteger();
                    iOHandler.WriteLine("Please enter Board's Width:");
                    Settings.BoardWidth = iOHandler.ReadInteger();
                    isBoardValid = CheckIfBoardSizeValid(Settings.BoardHeight, Settings.BoardWidth);
                    if (!isBoardValid)
                    {
                        iOHandler.WriteLine("Invalid board size. Please try again.");
                    }
                }
                while (!isBoardValid);
                iOHandler.WriteLine("Accept option to locate submarine diagonaly? Click 1 for YES, 2 for NO");
                if (GetYesOrNoAnswer(iOHandler) == 1)
                {
                    Settings.IsWithDiagonal = true;
                }
                iOHandler.WriteLine("Would you like to play VS computer? Click 1 for YES, 2 for NO");
                if (GetYesOrNoAnswer(iOHandler) == 1)
                {
                    Settings.IsGameVSComputer = true;

                    iOHandler.WriteLine("Would you like to make this game Harder? Click 1 for YES, 2 for NO");
                    if (GetYesOrNoAnswer(iOHandler) == 1)
                    {
                        Settings.LevelOfGame = GameLevel.ADVANCED;
                    }
                }
            }

            return Settings;
        }

        private static bool CheckIfBoardSizeValid(int height, int width)
        {
            return height >= ConfigIssues.LongestSubmarine && width >= ConfigIssues.LongestSubmarine;
        }

        private static int GetYesOrNoAnswer(GameIOHandler iOHandler)
        {
            int number = iOHandler.ReadInteger();
            if (number != 1 && number != 2) //maybe an enum??
            {
                iOHandler.WriteLine("You have entered invalid number. Please try again.");
                GetYesOrNoAnswer(iOHandler);
            }
            return number;
        }
    }
}
