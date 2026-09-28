using System;

class Program
{

    static double AddNumbers(double x, int y)
    {
        return x + y;
    }

    static void DisplayGreeting(string name)
    {
        Console.WriteLine($"Welcome {name}, pleased to meet you.");
    }

    static void Main(string[] args)
    { 
        DisplayGreeting("Bob");
        double answer = AddNumbers(12.234, 10);
        Console.WriteLine(answer);

       // for(int i = 0; i < 105; i+=5)
        //{
          //  Console.WriteLine(i);
        //}

        // List<string> myFriends = new List<string> {"Bob", "Betty", "Bill", "Bubba"};
        // myFriends.Add("James");
        // myFriends.Add("Doug");

        // foreach(string name in myFriends)
        // {
        //     Console.WriteLine(name);
        // }  

    }
}
