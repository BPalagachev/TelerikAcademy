using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // task 5 
    class TrailObject : GameObject
    {
        public new const string CollisionGroupString = "none";

        protected int lifeTime;

        public TrailObject(MatrixCoords topLeft, int aLifeTime)
            : base(topLeft, new char[,] { { '*' } })
        {
            this.LifeTime = aLifeTime;
        }

        public int LifeTime
        {
            get
            {
                return this.lifeTime;
            }
            protected set
            {
                if (value < 0 )
                {
                    throw new ArgumentOutOfRangeException("LifeTime Value must be positive number!");
                }
                this.lifeTime = value;
            }
        }

        protected virtual void UpdatePosition()
        {
            this.LifeTime--;
            if (this.LifeTime == 0)
            {
                this.IsDestroyed = true;
            }
        }

        public override void Update()
        {
            this.UpdatePosition();
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return false;
        }
    }
}
