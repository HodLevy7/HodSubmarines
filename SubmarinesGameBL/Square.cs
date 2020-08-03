using System;

namespace SubmarinesGameBL
{
    public class Square
    {
        public delegate void MyDel();
        public event MyDel OnBoatHit;
        public SquareStatus Status { get; private set; }
        public bool IsAvailableForInput { get; set; }
        public bool IsHitted { get; private set; }

        public int Id { get; set; }
        public Square()
        {
            Status = SquareStatus.EMPTY;

            IsAvailableForInput = true;
            IsHitted = false;
        }

        public void SetSquareAsBoat(int id)
        {
            IsAvailableForInput = false;
            Status = SquareStatus.BOAT;
            Id = id;
        }

        public void HitSquare()
        {
            try
            {
                Status += 1;
                IsHitted = true;
                if (Status == SquareStatus.HITTED_BOAT)
                {
                    OnBoatHit?.Invoke();
                }
            }
            catch (Exception)
            {
            }
        }

        public override string ToString()
        {
            switch (Status)
            {
                case SquareStatus.EMPTY:
                    return " O ";
                case SquareStatus.MISS:
                    return " M ";
                case SquareStatus.BOAT:
                    return " ^ ";
                case SquareStatus.HITTED_BOAT:
                    return " X ";
            }

            return "Something went wrong. ";
        }
    }
}
