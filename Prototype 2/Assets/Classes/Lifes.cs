namespace Assets.Classes
{
    internal class Lifes
    {
        private short Life { get; set; } = 3;

        public void AddLive()
        {
            Life++;
        }

        public void MinusLive()
        {
            Life--;
        }

        public short GetLives()
        {
            return Life;
        }
    }
}
