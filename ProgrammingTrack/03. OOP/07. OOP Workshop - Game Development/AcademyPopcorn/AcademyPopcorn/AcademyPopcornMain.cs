using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                // task 10 - Test Exploding blocks
                //Block currBlock = new Block(new MatrixCoords(startRow, i));
                Block currBlock = new ExplodingBlock(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            // Task 7 - Test the MeteoridBall
            // Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));
            // Ball theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            // Task 9 - tesk the Unstappable Ball            
            UnstoppableBall theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));


            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            // task 1 - Add Indestructable Blocks at side walls and the ceiling
            // Walls
            // Right wall is there but its not displayed! 
            for (int i = 0; i < WorldRows; i++)
            {
                //IndestructibleBlock leftWall = new IndestructibleBlock(new MatrixCoords(i,0));
                //IndestructibleBlock rightWall = new IndestructibleBlock(new MatrixCoords(i, WorldCols));
                
                
                // Task 9 - Test the unpassableBlocks
                UnpassableBlock leftWall = new UnpassableBlock(new MatrixCoords(i, 0));
                UnpassableBlock rightWall = new UnpassableBlock(new MatrixCoords(i, WorldCols));
                engine.AddObject(leftWall);
                engine.AddObject(rightWall);
            }
            // Ceiling
            for (int i = 0; i < WorldCols; i++)
            {
                //IndestructibleBlock ceiling = new IndestructibleBlock(new MatrixCoords(0, i));

                // Task 9 - Test the unpassableBlocks
                UnpassableBlock ceiling = new UnpassableBlock(new MatrixCoords(0, i));
                engine.AddObject(ceiling);
            }

            // Task 5 - Test TrailObjectClass
            TrailObject trail = new TrailObject ( new MatrixCoords(WorldCols / 2, WorldRows / 2) , 30);
            engine.AddObject(trail);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, 100);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
