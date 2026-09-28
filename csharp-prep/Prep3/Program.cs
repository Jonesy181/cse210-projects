using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("Guess the magic Number! ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber < guess)
            {
                Console.WriteLine("Your guess is too high!");
            }
            else if (magicNumber > guess)
            {
                Console.WriteLine("Your guess is too low!");
            }
            else
            {
                Console.WriteLine("That is correct!");
            }
        }
    }
}