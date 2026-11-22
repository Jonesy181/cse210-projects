class Menu
{
    private Goals _goals;

    public Menu(Goals goals)
    {
        _goals = goals;
    }

    public void Run()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            _goals.DisplayScore();
            DisplayOptions();

            int choice = GetChoice();

            switch (choice)
            {
                case 1:
                    _goals.CreateGoal();
                    break;

                case 2:
                    _goals.DisplayGoals();
                    break;

                case 3:
                    _goals.SaveGoals();
                    break;

                case 4:
                    _goals.LoadGoals();
                    break;

                case 5:
                    _goals.RecordEvent();
                    break;

                case 6:
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Please choose a number from 1 to 6.");
                    break;
            }
        }
    }

    private void DisplayOptions()
    {
        Console.WriteLine();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
        Console.Write("Select a choice: ");
    }

    private int GetChoice()
    {
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            return choice;
        }

        return -1;
    }
}