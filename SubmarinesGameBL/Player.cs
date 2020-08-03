using System.Collections.Generic;
using System.Linq;

namespace SubmarinesGameBL
{
    public class Player
    {
        public delegate void MyDel();
        public event MyDel HasLostEvent;
        private string Name { get; set; }
        private int Score { get; set; }
        private GameBoard SelfBoard { get; set; }
        private List<Submarine> Submarines { get; set; }
        public bool HisTurn { get; set; }
        private bool HasLost { get; set; }

        public Player(string name, GameBoard board)
        {
            Name = name;
            Score = 0;
            SelfBoard = board;
            Submarines = new List<Submarine>();


        }

        public bool IsMoveValid(Coordinate chosenSquare)
        {
            return SelfBoard.CanSquareBeSelected(chosenSquare);
        }

        public void MakeMove(Coordinate chosenSquare)
        {
            SelfBoard.SelectSquare(chosenSquare);
            Square chosen = SelfBoard.GetSquareByIndex(chosenSquare);

            if (chosen.Status == SquareStatus.HITTED_BOAT)
            {
                Submarines[chosen.Id].HitBoat();
            }

            if (Submarines.All(s => s.IsDestroyed))
            {
                HasLostEvent?.Invoke();
            }
        }

        public void AddSubmarine(Coordinate initialCoordinate, Coordinate finalCoordinate, int length)
        {
            Submarines.Add(new Submarine(length, Submarines.Count));
            SelfBoard.LocateSubmarine(initialCoordinate, finalCoordinate, length, Submarines[Submarines.Count - 1].Id);

            Submarines[Submarines.Count - 1].DestructionEvent += DestroyFrameOfSubmarine; //register the event
        }

        public string GetPlayersDetails()
        {
            if (!HasLost)
            {
                return $"{Name} won with {Score} points!";
            }

            return $"{Name} lost with {Score} points.";
        }

        private void DestroyFrameOfSubmarine(int submarineId)
        {
            SelfBoard.GetCoordinateOfSquaresById(submarineId)
                .ForEach(c => SelfBoard.GetValidFrameOfSquareByIndex(c).ForEach(s => s.HitSquare()));
        }

    }
}
