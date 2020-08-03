using System;

namespace SubmarinesGameUI
{
    public class ConsoleHandler : GameIOHandler
    {
        private static ConsoleHandler Instance = new ConsoleHandler();
        private ConsoleHandler() : base()
        {

        }
        public static ConsoleHandler GetInstance()
        {
            return Instance;
        }
        public override string ReadLine()
        {
            return Console.ReadLine();
        }

        public override void Write(string content)
        {
            Console.Write(content);
        }

        public override void WriteLine(string content)
        {
            Console.WriteLine(content);
        }
    }
}
