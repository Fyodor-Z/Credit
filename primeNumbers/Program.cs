using System;

namespace primeNumbers
{
    class Program
    {
        static void Main(string[] args)


        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to The Sieve of Eratosthenes v 0.1 - animated Prime Numbers Search Engine");
            Console.ResetColor();
            Console.WriteLine("-------------------------------------------------------------------------------- ");

            bool result = false;

            uint N = 0;

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

            for (int i = 1; i <= N; i++)
            {

                Console.Write($"{i,4}|");

                if (i % 10 == 0) //new line every 10 numbers
                {

                    drawLine(5);
                }
            }

        }
        static void drawLine(int lngth)
        {
            for (int i = 0; i <= lngth; i++)
            {

                Console.Write('-');
                if (Console.CursorLeft < Console.BufferWidth)
                {
                    Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                }
                else
                {
                    break;
                }
                Console.WriteLine();

            }


        }
    }
}
