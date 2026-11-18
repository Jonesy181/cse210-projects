using System;

class Program
{
    static void Main(string[] args)
    {
        //BaseGoal myBaseGoal = new BaseGoal();
        //Console.WriteLine(myBaseGoal.GetConsoleString());

        SimpleGoal mySimpleGoal = new SimpleGoal();
        Console.WriteLine(mySimpleGoal.GetConsoleString());
        mySimpleGoal.RecordEvent();
        Console.WriteLine(mySimpleGoal.GetConsoleString());
    }
}