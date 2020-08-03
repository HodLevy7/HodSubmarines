namespace SubmarinesGameUI
{
    class Program
    {
        static void Main(string[] args)
        {
            GameIOHandler iOHandler = ConsoleHandler.GetInstance();
            iOHandler.StartGame();
        }
    }
}
