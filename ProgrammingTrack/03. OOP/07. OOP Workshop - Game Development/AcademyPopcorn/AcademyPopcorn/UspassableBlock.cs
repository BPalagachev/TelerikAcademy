using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class UnpassableBlock : IndestructibleBlock
    {
        public new const string CollisionGroupString = "unpassable";
         public const char Symbol = '+';

         public UnpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = IndestructibleBlock.Symbol;
        }

         public override string GetCollisionGroupString()
         {
             return "unpassable";
         }
    }
}
