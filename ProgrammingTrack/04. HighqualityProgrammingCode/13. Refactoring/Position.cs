namespace GameFifteen
{
    internal struct Position
    {
        public int XCoord { get; set; }

        public int YCoord { get; set; }

        public void Update(Direction direction)
        {
            this.XCoord += direction.XSpeed;
            this.YCoord += direction.YSpeed;
        }
    }
}
