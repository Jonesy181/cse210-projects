using System;

class Program
{
    static void Main(string[] args)
    {
        Goals goals = new Goals();
        Menu menu = new Menu(goals);

        menu.Run();
    }

}