using static System.Console;

namespace playSokoban
{
    public class sokoban
    {
        const int Rows = 10;
        const int Cols = 20;
        static char[,] _grid = new char[Rows, Cols];
        
        static int _spots;
        static int _spotsLeft;

        const char BoxChar = '#';
        const char SpotChar = 'X';
        const char PlayerChar = 'O';
        const char WallChar = 'W';
        const char VoidChar = ' ';



        public static void MainSokobanRun()
        {
            Clear();
            while (Run()) 
            { }
            WriteLine("\nT♦ Thank you for playing ☺");
        }

        public static bool Run()
        {
            var player = (X: 1, Y: 1);
            

            _grid = new char[Rows, Cols];
            _spots = 5;
            _spotsLeft = 0;

            // Populate grid
            for (var x = 0; x < Cols; x++)
            {
                for (var y = 0; y < Rows; y++)
                {
                    if (x == 0 || x == Cols - 1 || y == 0 || y == Rows - 1)
                    {
                        _grid[y, x] = WallChar;                       
                        continue;
                    }
                    _grid[y, x] = VoidChar;                   
                }
            }

            // Place boxes and coins
            var rnd = new Random();
            var boxesPosition = Enumerable.Range(0, 1).Select(_ => (X: rnd.Next(2, Cols - 2), Y: rnd.Next(2, Rows - 2))).ToArray();            
            foreach (var box in boxesPosition) { _grid[box.Y, box.X] = BoxChar; }
            var spotsLocation = Enumerable.Range(0, 5).Select(_ => (X: rnd.Next(1, Cols - 1), Y: rnd.Next(1, Rows - 1))).ToArray();
            foreach (var spot in  spotsLocation) { _grid[spot.Y, spot.X] = SpotChar; }


            // Place the player
            _grid[player.Y, player.X] = PlayerChar;


            while (true)
            {
                Clear();
                WriteLine($"\n♦  {_spots} spots left ♦");

                // Update the grid
                for (var i = 0; i < _grid.GetLength(0); i++)
                {
                    for (var j = 0; j < _grid.GetLength(1); j++)
                    {
                        Write(_grid[i, j]);                       
                    }
                    Write("\n");

                }


                // Check winning condition
                if (_spotsLeft == spotsLocation.Length)
                {
                    Console.WriteLine("\nYOU WIN!\nPRESS R TO RESTART OR ESC TO QUIT.");
                    while (true)
                    {
                        var key = Console.ReadKey();
                        if (key.Key == ConsoleKey.R) return true;
                        if (key.Key == ConsoleKey.Escape) return false;
                    }
                }

                

                WriteLine("Use Arrow keys to move around\nPress R to restart map\nPress Esc to exit");
                WriteLine("\n*** Map Info\n* O -> Player\n* # -> Box\n* X -> Box storage");

                var input = ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.Escape: return false;
                    case ConsoleKey.UpArrow: Move(0, -1, ref player); break;
                    case ConsoleKey.DownArrow: Move(0, 1, ref player); break;
                    case ConsoleKey.LeftArrow: Move(-1, 0, ref player); break;
                    case ConsoleKey.RightArrow: Move(1, 0, ref player); break;
                    case ConsoleKey.R: return true;
                }
            }
        }


        private static void Move(int x, int y, ref (int X, int Y) player)
        {
            var to = new { X = player.X + x, Y = player.Y + y };
            var nextTo = new { X = player.X + x + x, Y = player.Y + y + y };

            if (to.X <= 0 || to.Y <= 0 || to.X >= Cols - 1 || to.Y >= Rows - 1) return;

            if (_grid[to.Y, to.X] == BoxChar)
            {
                if (nextTo.X <= 0 || nextTo.Y <= 0 || nextTo.X >= Cols - 1 || nextTo.Y >= Rows - 1 || _grid[nextTo.Y, nextTo.X] == BoxChar) 
                    return;

                if (_grid[nextTo.Y, nextTo.X] == SpotChar)
                {
                    // Box is pushed onto a spot, making it immovable
                    _grid[to.Y, to.X] = SpotChar;
                    _grid[nextTo.Y, nextTo.X] = BoxChar;
                    _grid[to.Y, to.X] = BoxChar;
                    _grid[to.Y, to.X] = VoidChar;
                    _spotsLeft++;
                    _spots--;
                    return;
                }


                _grid[to.Y, to.X] = VoidChar;
                _grid[nextTo.Y, nextTo.X] = BoxChar;
            }

            if (_grid[to.Y, to.X] == SpotChar)
                return;
            

            _grid[player.Y, player.X] = VoidChar;
            _grid[to.Y, to.X] = PlayerChar;

            player.X = to.X;
            player.Y = to.Y;
        }


    }

}
