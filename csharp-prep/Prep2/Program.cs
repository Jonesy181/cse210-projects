using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Letter Grade");

        Console.WriteLine("Enter your score: ");
        string input = Console.ReadLine();
        int percentage = int.Parse(input);

        if (percentage >= 90)
        {
            Console.WriteLine("You got an A!");
            Console.WriteLine("You passed the course! Great job!");
        }
        else if (percentage >= 80)
        {
            Console.WriteLine("You got a B!");
            Console.WriteLine("You passed the course! Great job!");
        }
        else if (percentage >= 70)
        {
            Console.WriteLine("You got a C!");
            Console.WriteLine("You passed the course! Great job!");
        }
        else if (percentage >= 60)
        {
            Console.WriteLine("You got a D.");
            Console.WriteLine("You need to study more. Don't give up!");
        }
        else if (percentage < 60)
        {
            Console.WriteLine("You got an F.");
            Console.WriteLine("You need to study more. Don't give up!");
        }
        else 
        {
            Console.WriteLine("Please enter a valid score.");
        }
    }
}