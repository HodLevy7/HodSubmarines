namespace SubmarinesGameBL
{
    public class GameManagement
    {
        public Player FirstPlayer { get; set; }
        public Player SecondPlayer { get; set; }

        public GameManagement(Player first, Player second)
        {
            FirstPlayer = first;
            SecondPlayer = second;

            FirstPlayer.HisTurn = true;
        }
    }
}
