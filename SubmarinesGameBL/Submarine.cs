namespace SubmarinesGameBL
{
    public class Submarine
    {
        public delegate void MyDel(int submarineId);

        public event MyDel DestructionEvent;
        private int Length { get; set; }
        private int Hits { get; set; }
        public int Id { get; private set; }
        public bool IsDestroyed { get; private set; }

        public Submarine(int length, int id)
        {
            if (length != 0)
            {
                Length = length;
            }

            Id = id;
            Hits = 0;
        }

        public void HitBoat()
        {
            Hits++;

            if (Hits == Length)
            {
                IsDestroyed = true;
                DestructionEvent?.Invoke(Id);
            }
        }
    }
}
