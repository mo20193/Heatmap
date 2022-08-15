using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//xxxxxxx  00 01 02 03 04 05 06
//xxxxxxx  10 11 12 13 14 15 16
//xxxxxxx  20 21 22 23 24 25 26
//xxx7xxx  30 31 32 33 34 35 36  33(O)
//xxxxxxx  40 41 42 43 44 45 46
//xxxxxxx  50 51 52 53 54 55 56
//xxxxxxx  60 61 62 63 64 65 66


//1 2 3
//4 o 5
//6 7 8 


namespace Heatmap
{
    internal class Program
    {
        public static int[,] _fields = new int[7, 7];
        public static Coordinates coordinates = new Coordinates(3,3);
        public static Coordinates tempCoordinates = coordinates;
        public static Random _random = new Random(); 

        private static int run = 0;

        static void Main(string[] args)
        {
            InitializeArray();

            do
            {


                for (int i = 0; i < 3; i++)
                {
                    var tempNumber = GetRandomNumber();
                    DetermineEndPoint(tempCoordinates, tempNumber);
                    Console.WriteLine("tempNumber: " + tempNumber);
                    Console.WriteLine(tempCoordinates.X + " " + tempCoordinates.Y);
                }

                _fields[tempCoordinates.X, tempCoordinates.Y]++;


                tempCoordinates = coordinates; //um auf ursprung zurückztusetzen, sonst out of range

                Console.Clear();
                //10
                // 5
                run++;

            }while(run < 200);

            ShowField();         

            Console.ReadKey();
        }

        private static int GetMaxNumberinField()
        {
            var max = _fields[0, 0];
            
            for (var i = 0; i < 7; i++)
            {
                for (var j = 0; j < 7; j++)
                {
                    var item = _fields[i, j];

                    if(item > max)
                    {
                        max = item;
                    }
                    
                }
            }

            return max;
        }

        private static void DetermineEndPoint(Coordinates c, int number)
        {
            var x = tempCoordinates.X;
            var y = tempCoordinates.Y;

            switch (number)
            {
                case 1:
                    x--;
                    y--;
                    tempCoordinates = new Coordinates(x,y);
                    break;

                case 2:
                    x--;
                    tempCoordinates = new Coordinates(x, y);
                    break;

                case 3:
                    x--;
                    y++;
                    tempCoordinates = new Coordinates(x, y);
                    break;

                case 4:
                    y--;
                    tempCoordinates = new Coordinates(x, y);
                    break;

                case 5:
                    y++;
                    tempCoordinates = new Coordinates(x, y);
                    break;

                case 6:
                    x++;
                    y--;
                    tempCoordinates = new Coordinates(x, y);
                    break;
                case 7:
                    x++;
                    tempCoordinates = new Coordinates(x, y);
                    break;

                case 8:
                    x++;
                    y++;
                    tempCoordinates = new Coordinates(x, y);
                    break;
            }

        }

        private static int GetRandomNumber()
        {
            var currentNumber = _random.Next(1, 9);

            return currentNumber;
        }

        public static void InitializeArray()
        {
            // x ---> | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
            _fields[0, 0] = 0;
            _fields[0, 1] = 0;
            _fields[0, 2] = 0;
            _fields[0, 3] = 0;
            _fields[0, 4] = 0;
            _fields[0, 5] = 0;
            _fields[0, 6] = 0;

            // row 1 --->
            _fields[1, 0] = 0;
            _fields[1, 1] = 0;
            _fields[1, 2] = 0;
            _fields[1, 3] = 0;
            _fields[1, 4] = 0;
            _fields[1, 5] = 0;
            _fields[1, 6] = 0;

            // row 2 --->
            _fields[2, 0] = 0;
            _fields[2, 1] = 0;
            _fields[2, 2] = 0;
            _fields[2, 3] = 0;
            _fields[2, 4] = 0;
            _fields[2, 5] = 0;
            _fields[2, 6] = 0;

            //row 3
            _fields[3, 0] = 0;
            _fields[3, 1] = 0;
            _fields[3, 2] = 0;
            _fields[3, 3] = 0;
            _fields[3, 4] = 0;
            _fields[3, 5] = 0;
            _fields[3, 6] = 0;

            //row 4
            _fields[4, 0] = 0;
            _fields[4, 1] = 0;
            _fields[4, 2] = 0;
            _fields[4, 3] = 0;
            _fields[4, 4] = 0;
            _fields[4, 5] = 0;
            _fields[4, 6] = 0;

            //row 5
            _fields[5, 0] = 0;
            _fields[5, 1] = 0;
            _fields[5, 2] = 0;
            _fields[5, 3] = 0;
            _fields[5, 4] = 0;
            _fields[5, 5] = 0;
            _fields[5, 6] = 0;

            //row 6
            _fields[6, 0] = 0;
            _fields[6, 1] = 0;
            _fields[6, 2] = 0;
            _fields[6, 3] = 0;
            _fields[6, 4] = 0;
            _fields[6, 5] = 0;
            _fields[6, 6] = 0;
        }

        private static void ShowField()
        {
            Console.WriteLine();
            for (int i = 0; i < 7; i++)
            {
               

                for (int j = 0; j < 7; j++)
                {
                    if (_fields[i, j] > 9)
                    {
                        Console.Write("    ");
                    }
                    else
                    {
                        Console.Write("     ");
                    }
                    var f = GetMaxNumberinField();

                    if (_fields[i, j] == f)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("   " + _fields[i, j] + "   ");
                    }else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("   " + _fields[i, j] + "   ");
                    }
                    Console.ForegroundColor = ConsoleColor.White;

                    
                }
                //Console.Write("  |");
                Console.WriteLine();
            }
        }
    }
}
