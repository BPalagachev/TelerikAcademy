using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class EngineInherited : Engine
    {
        // Task 4 - inherit Engine
        public EngineInherited(IRenderer renderer, IUserInterface keyboard, int aSleepTime)
            : base(renderer, keyboard, aSleepTime)
        {
        }

        // Create method ShootPlayerRacket
        public void ShootPlayerRacker()
        {
            throw new NotImplementedException();
        }
    }
}
