using System;

namespace primeNumbers
{
    class Program
    {

        public struct cursorPos  //cursor position of element on the screen
        {
            int x;
            int y;
        }

        public struct numberData  //number with its potision
        {
            int value;
            cursorPos Position;
        }

        static void Main(string[] args)


        {
            programTitle();


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

            numberData[] numberS = new numberData[N];  //numbers and their coordinates on the screen

            tableTitle();

            for (int i = 1; i <= N; i++)  //
            {

                Console.Write($"{i,4}|");

                if (i % 10 == 0) //new line every 10 numbers
                {
                    Console.WriteLine("|");
                    drawLine('-', 50);
                }
            }

        }
        

        static void programTitle()   //startup text
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to The Sieve of Eratosthenes v 0.1 - animated Prime Numbers Search Engine");
            drawLine('=', 80);
            Console.ResetColor();
        }

        static void tableTitle() //markup of the screen
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("---------------Unfiltered numbers----------------|");
            Console.ResetColor();
            drawLine('=', 48);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorTop -= 2;
            Console.CursorLeft = 50;
            Console.WriteLine("|---------------Prime numbers----------------");
            Console.ResetColor();
            Console.CursorLeft = 51;
            drawLine('=', 44);


        }

        static void drawLine(char symbol, int lngth) //insert line of specifed symbols and specified length
        {
            
            for (int i = 0; i <= lngth; i++)
            {
                Console.Write(symbol);
                if (Console.CursorLeft == (Console.BufferWidth - 1))
                {
                    break;
                }
            }
            Console.WriteLine();
        }
    }
}
