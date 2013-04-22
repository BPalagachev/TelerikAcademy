using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Task 6 - Implement MeteoridBall
    public class MeteoriteBall : Ball
    {
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> newTrailList = new List<GameObject>();
            newTrailList.Add(new TrailObject(this.TopLeft, 4));
            return newTrailList;
        }
    }
}
