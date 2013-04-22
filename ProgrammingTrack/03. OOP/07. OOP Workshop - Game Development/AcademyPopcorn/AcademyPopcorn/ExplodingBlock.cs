using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // task 10 - Exploding blocks
    public class ExplodingBlock : Block
    {
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {

        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<Shrapnel> listOfShrapnels = new List<Shrapnel>();

            if( this.IsDestroyed == true)
            {
            listOfShrapnels.Add(new Shrapnel(this.TopLeft, new MatrixCoords(0, 1)));
            listOfShrapnels.Add(new Shrapnel(this.TopLeft, new MatrixCoords(0, -1)));
            listOfShrapnels.Add(new Shrapnel(this.TopLeft, new MatrixCoords(1, 0)));
            listOfShrapnels.Add(new Shrapnel(this.TopLeft, new MatrixCoords(-1, 0)));

            
            }
            return listOfShrapnels;

        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.ProduceObjects();
            this.IsDestroyed = true;
        }
    }
}
