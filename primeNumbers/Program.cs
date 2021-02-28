using System;
using System.Threading;

namespace primeNumbers
{
    class Program
    {

        public struct CursorPos  //cursor position of element on the screen
        {
            public int x;
            public int y;
        }

        public struct NumberData  //number with its potision
        {
            public uint value;
            public CursorPos Position;
        }

        static void Main(string[] args)


        {
            ProgramTitle();


            bool result = false;
            uint N = 0; //limit of numbers to work with


            do  //get N
            {
                Console.WriteLine("Please enter N - the limit of the prime numbers search:");
                Console.Write("N=");
                string input = Console.ReadLine();

                result = uint.TryParse(input, out N);
                result = result && N != 0;

                if (result == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Wrong value entered!");
                    Console.ResetColor();
                }
            }
            while (result == false);

            NumberData[] numbersArray = new NumberData[N + 1];  //numbers and their coordinates on the screen


            TableTitle();

            for (uint i = 1; i <= N; i++)  //numbers output and array initializing 
            {
                numbersArray[i].value = i;
                numbersArray[i].Position.x = Console.CursorLeft;
                numbersArray[i].Position.y = Console.CursorTop;

                Console.Write($"{i,4}|");

                if (i % 10 == 0) //new line every 10 numbers
                {
                    Console.WriteLine("|");
                    DrawLine('-', 50,true);
                }
            }

            NumberSelect(numbersArray[1], ConsoleColor.Black, ConsoleColor.DarkYellow);//mark 1st element

            for (uint i = 2; i <= N; i++) //excluding not prime nunbers 
            {
                if (numbersArray[i].value != 0)

                {
                    NumberSelect(numbersArray[i], ConsoleColor.Black, ConsoleColor.DarkYellow); //select base number

                    for (uint p = 2; (i * p) <= N; p++) //select all products of i
                        if (numbersArray[i * p].value != 0) //if number wasn't deleted earlier
                        {
                            NumberSelect(numbersArray[i * p], ConsoleColor.Yellow, ConsoleColor.Blue);//select product of base number
                            numbersArray[i * p].value = 0;   //assign value to the array member
                            NumberDelete(numbersArray[i * p]);//clean its place
                        }
                }

            }

            //put cursor at the start place of prime numbers area
            Console.CursorLeft = 51;
            Console.CursorTop = numbersArray[1].Position.y;

            for (uint i = 1; i <= N; i++) //output prime numbers to the prime numbers area of the screen
            {

                if (numbersArray[i].value != 0)//all not prime values are assigned to 0
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{i,4}");
                    Console.ResetColor();
                    Console.Write("|");
                    if (Console.CursorLeft >= 101) //new line every 10 numbers
                    {
                        Console.Write("|");
                        Console.CursorLeft = 51;
                        Console.CursorTop += 1;
                        DrawLine('-', 50,false);
                        Console.CursorLeft = 51;
                        Console.CursorTop += 1;
                    }
                }
            }

            ProgramGoodbye(numbersArray[N].Position.y+2);

        }


        static void ProgramTitle()   //startup text
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to The Sieve of Eratosthenes v 0.1 - animated Prime Numbers Search Engine");
            DrawLine('=', 80, true);
            Console.ResetColor();
        }

        static void TableTitle() //markup of the screen
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("---------------Unfiltered numbers----------------|");
            Console.ResetColor();
            DrawLine('=', 48, true);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorTop -= 2;
            Console.CursorLeft = 50;
            Console.WriteLine("|-----------------Prime numbers-------------------");
            Console.ResetColor();
            Console.CursorLeft = 51;
            DrawLine('=', 48, true);

        }

        static void DrawLine(char symbol, int lngth, bool newLine) //insert line of specifed symbols and specified length
        {

            for (int i = 0; i <= lngth; i++)
            {
                Console.Write(symbol);
                if (Console.CursorLeft == (Console.BufferWidth - 1))
                {
                    break;
                }
            }
            if (newLine)
            {
                Console.WriteLine();
            }
            
        }

        static void NumberSelect(NumberData number, ConsoleColor colorBackground, ConsoleColor colorFont)//select number on the screen
        {
            //int currentX = Console.CursorLeft;  //start position of cursor
            //int currentY= Console.CursorTop;

            Console.CursorLeft = number.Position.x;
            Console.CursorTop = number.Position.y;
            Console.BackgroundColor = colorBackground;
            Console.ForegroundColor = colorFont;
            Console.Write($"{number.value,4}");

            Thread.Sleep(100);

            //Console.CursorLeft = number.Position.x; //return Cursor to its start position
            //Console.CursorTop = number.Position.y;
            Console.ResetColor();
        }
        static void NumberDelete(NumberData number)//delete number on the screen
        {


            Console.CursorLeft = number.Position.x;
            Console.CursorTop = number.Position.y;

            Console.Write("    ");

            Thread.Sleep(5);

        }

        static void ProgramGoodbye(int linePos)   //startup text
        {
            //put cursor under the area of numbers
            Console.CursorLeft = 0;
            Console.CursorTop = linePos;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Thank you for using my application.Press any key to exit");

            DrawLine('=', 80, true);
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
