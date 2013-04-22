using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Task 11
    public class Gift : MovingObject
    {
        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { 'p' } }, new MatrixCoords(1, 0))
        {
        }
    }
}
