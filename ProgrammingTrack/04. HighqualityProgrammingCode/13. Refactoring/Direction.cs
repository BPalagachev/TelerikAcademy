namespace GameFifteen
{
    using System;

    internal struct Direction
    {
        private DirectionType directionType;

        public DirectionType DirectionType
        {
            get
            {
                return this.directionType;
            }

            set
            {
                switch (value)
                {
                    case DirectionType.ButtomRight:
                        this.XSpeed = 1;
                        this.YSpeed = 1;
                        break;
                    case DirectionType.Right:
                        this.XSpeed = 1;
                        this.YSpeed = 0;
                        break;
                    case DirectionType.TopRight:
                        this.XSpeed = 1;
                        this.YSpeed = -1;
                        break;
                    case DirectionType.Top:
                        this.XSpeed = 0;
                        this.YSpeed = -1;
                        break;
                    case DirectionType.TopLeft:
                        this.XSpeed = -1;
                        this.YSpeed = -1;
                        break;
                    case DirectionType.Left:
                        this.XSpeed = -1;
                        this.YSpeed = 0;
                        break;
                    case DirectionType.ButtomLeft:
                        this.XSpeed = -1;
                        this.YSpeed = 1;
                        break;
                    case DirectionType.Buttom:
                        this.XSpeed = 0;
                        this.YSpeed = 1;
                        break;
                    default:
                        throw new ArgumentException("Invalid direction type: " + value);
                }

                this.directionType = value;
            }
        }

        public int XSpeed { get; private set; }

        public int YSpeed { get; private set; }
    }
}
