using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Rock
{
    private static Random randomGen = new Random();
    private static char[] allowedStone = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';' }; // Possible stone style
    private static ConsoleColor[] stoneColors = { ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Red,
                                                   ConsoleColor.White, ConsoleColor.Magenta, ConsoleColor.Yellow}; // Possible stone colors

    private ConsoleColor stoneColor; // Color for the current stone
    private char rockStyle;   // Symbol for the current stone
    private int xCoord;       // X position of the current stone
    private int yCoord;       // y position of the current stone
    private int length;       // stone length [1-3]
    private int lastYCoord;   // stone position in the previous interation (used for deleting stone in the previous moments)
    private bool disposeOfMe; // Goes to true when the stone fall off the screen


    public int XCoord
    {
        get { return xCoord; }
    }
    public int YCoord
    {
        get { return yCoord; }
    }
    public int Length
    {
        get { return length; }
    }
    public int LastYCoord
    {
        get { return lastYCoord; }
    }
    public bool DisposeOfMe
    {
        get { return disposeOfMe; }
    }

    public Rock()
    {
        this.length = randomGen.Next(1, 4);                 // random stone size;
        xCoord = randomGen.Next(0, Console.WindowWidth);    // random stone initial X position
        if (xCoord > (Console.WindowWidth - 1) - length)    // check if the stone go out of the screen
        {                                                   // if so, put it on the rightmost posible position
            this.xCoord = (Console.WindowWidth - 1) - length;
        }
        this.yCoord = 0;                                    // stones always start from the top;
        this.rockStyle = allowedStone[randomGen.Next(0, allowedStone.Length)]; // random stone style
        lastYCoord = yCoord;
        disposeOfMe = false;                                // false as all stone spawn in the screen
        stoneColor = stoneColors[randomGen.Next(0, stoneColors.Length)]; // random stone color

    }
    public void drawRock()  // use for drawing stone on the screen
    {
        Console.SetCursorPosition(this.xCoord, this.lastYCoord); // set cursor to the stone in the previous moment
        Console.Write(new string(' ', this.length) + "\r");      // and deletes it
        Console.SetCursorPosition(this.xCoord, this.yCoord);     // sets the cursor in the current position
        Console.ForegroundColor = this.stoneColor;               // sets the current stone color
        Console.Write(new String(this.rockStyle, this.length) + "\r");  // display it
        this.lastYCoord = this.yCoord;                           // sets the current position of last (outdated) position  
    }
    public void moveStoneDown() // used for calculating new Y (down) position of the stone
    {
        if (this.yCoord < Console.WindowHeight - 1) // if the position is in the screen range
        {
            this.yCoord++;                          // increment the Y coord 
        }
        else
        {
            this.disposeOfMe = true;                // else - the stone is off the screen so set the "dispose" flag to true
        }
    }
}

class Player
{
    public static uint playerScore; // user score
    public static uint tempScore;   // used for calculating hhow advance is the player in the game
    // if playerScore - tempScore > 250 { game gets harder }
    public static int playerPosition;  // X position of the player;
    public static int playerPreviousPosition; // previous x position of the player - used for deleting dwarf from the screen
    public Player(int playGroundSize)
    {
        // player starts at the middle with 0 points
        playerPosition = playGroundSize / 2;
        playerPreviousPosition = playGroundSize / 2;
        playerScore = 0;
        tempScore = 0;
    }

    public static void movePlayerLeft() // if possile moves the player to the left
    {
        if (playerPosition > 0) // if the player would remain in the screen - move it
        {
            playerPosition--;
        }
    }

    public static void movePlayerRight() // if possible moves the player to the right
    {
        if (playerPosition < Console.BufferWidth - 4)
        {
            playerPosition++; // if the player would remain in the screen - move it
        }
    }

    public static void drawPlayer() // draws the player at his current posistion
    {
        Console.ForegroundColor = ConsoleColor.White; // the player is always white
        Console.SetCursorPosition(playerPreviousPosition, Console.WindowHeight - 1); // set the cursor to previous player position
        Console.Write("   \r");                                                      // delete him from there
        Console.SetCursorPosition(playerPosition, Console.WindowHeight - 1);         // set tge player to his new position
        Console.Write("(0)\r");                                                      // draw a dwarf there
        Player.playerPreviousPosition = playerPosition;                              // mark current position as last e.g. outdated
    }

    public static void Scoring()    // used for scoring
    {
        playerScore += 1;
    }

}
class GameLogic
{
    static Random randomGenerator = new Random();

    static int playingGroundWidth = 50; // how width is the play area

    static int displayTimer = Environment.TickCount; // game speed
    static int dropRate = 150;                       // stones position refresh every dropRate ms e.g. how fast they fall

    static int generateMoreStonePeriod = 1250;        // Defines how often new stones appear (between 500 and 750 ms)
    static int dropTimer = Environment.TickCount;    // used for measuring periods between new stone appearing
    static int dropPeriod = randomGenerator.Next(500, generateMoreStonePeriod); // randomly generated periods between new stone appearing
    //e.g. evert dropPeriod ms a new set of stones is dropped

    static int generateMoreStoneNumber = 6;         // up to how many new stone will appear every time
    static int generateAtLeastStoneNumner = 1;      // atleast how many stones will appear
    static int dropNumber = randomGenerator.Next(generateAtLeastStoneNumner, generateMoreStoneNumber); // the actual number of the stone to drop;
    static float incrementStones = 1f; // used for slowly increment number of stones to fall while scoring

    static LinkedList<Rock> Rocks = new LinkedList<Rock>(); // list of stones

    static void initializeRocks() // spawn between 5 and 15 stone at the initial moment
    {
        for (int i = 0; i < randomGenerator.Next(5, 15); i++)
        {
            Rock tempRock = new Rock();

            if (!Rocks.Contains(tempRock)) // anly add it to the list if it is not there already
            {
                Rocks.AddFirst(tempRock);
            }
            else i--;

        }
    }
    static void initializeScreenSize() // sets windoms Hight and Width as well as background color
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.BufferHeight = Console.WindowHeight;
        Console.WindowWidth = playingGroundWidth;
        Console.BufferWidth = Console.WindowWidth;
        //for (int i = 0; i < Console.WindowWidth; i++)
        //{
        //    for (int j = 0; j < Console.WindowHeight; j++)
        //    {
        //        Console.Write(" ");
        //    }
        //}
    }
    static void DisposeOfStones() // remove stones marked for removal (desposeOfMeflag) from the List Rocks
    {
        LinkedListNode<Rock> node = Rocks.First;
        while (node != null)
        {
            var next = node.Next;
            if (node.Value.DisposeOfMe == true)
            {
                Console.SetCursorPosition(node.Value.XCoord, node.Value.LastYCoord);
                Console.Write(new string(' ', node.Value.Length) + "\r");
                Rocks.Remove(node);
            }
            node = next;
        }
    }
    static void GameModeEasy()
    {
        if (Player.playerScore - Player.tempScore > 250)
        {
            Player.tempScore = Player.playerScore;
            if (generateAtLeastStoneNumner < 10) // dont spawn too many stones
            {
                generateMoreStonePeriod = 1500 - generateAtLeastStoneNumner * 70;
                incrementStones += 0.2f;
                generateAtLeastStoneNumner = (int)(incrementStones);
                generateMoreStoneNumber = generateAtLeastStoneNumner + 7;
            }
        }
    }
    static void Main()
    {
        initializeScreenSize();
        initializeRocks();
        Player p = new Player(playingGroundWidth); // create new player
        Player.drawPlayer(); // display him on the screen

        foreach (Rock stone in Rocks) // display the initial stones
        {
            stone.drawRock();
        }
        while (true)
        {
            // get a key from the user
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    Player.movePlayerLeft();
                    Player.drawPlayer();
                }
                else if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    Player.movePlayerRight();
                    Player.drawPlayer();
                }
            }
            // Time Between new stones e.g. how fast the fall down
            if ((Environment.TickCount - displayTimer) > dropRate)
            {
                foreach (Rock stone in Rocks)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    stone.moveStoneDown();
                    stone.drawRock();
                    displayTimer = Environment.TickCount;
                    Player.Scoring();
                }
            }
            foreach (Rock stone in Rocks) // check for collisions with every stone on the screen
            {
                if (((Player.playerPosition >= stone.XCoord && Player.playerPosition - stone.XCoord < stone.Length)
                    || (stone.XCoord >= Player.playerPosition && stone.XCoord - Player.playerPosition < 3))
                    && stone.YCoord == Console.WindowHeight - 1)
                {                                                   // if the is a collision - game over
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 5);
                    Console.WriteLine("Game Over");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 1 - 5);
                    Console.WriteLine("Your Score is: {0} points. Sweet!\n", Player.playerScore);
                    while (true)
                    {
                    }
                }

            }
            DisposeOfStones();
            // if the time is right add more rocks to fall
            if ((Environment.TickCount - dropTimer) > dropPeriod)
            {
                for (int i = 0; i < dropNumber; i++)
                {
                    Rocks.AddLast(new Rock());
                }
                dropTimer = Environment.TickCount;
                dropPeriod = randomGenerator.Next(500, generateMoreStonePeriod); // set new random period of the falling stones
                dropNumber = randomGenerator.Next(generateAtLeastStoneNumner, generateMoreStoneNumber);
            }
            GameModeEasy();
            Thread.Sleep(20);
        }
    }
}