class Goals
{
    private List<BaseGoal> _goals;
    private int _score;

    public Goals()
    {
        _goals = new List<BaseGoal>();
        _score = 0;
    }

    public void DisplayScore()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        Console.WriteLine("Your goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_goals[i].GetConsoleString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type would you like to create? ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal());
                break;

            case "2":
                _goals.Add(new EternalGoal());
                break;

            case "3":
                _goals.Add(new ChecklistGoal());
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        Console.WriteLine("Goal created.");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording an event.");
            return;
        }

        DisplayGoals();
        Console.Write("Which goal did you accomplish? ");

        if (!int.TryParse(Console.ReadLine(), out int choice)
            || choice < 1
            || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        BaseGoal selectedGoal = _goals[choice - 1];

        int earnedPoints = selectedGoal.RecordEvent();
        _score += earnedPoints;

        Console.WriteLine($"You earned {earnedPoints} points!");
        DisplayScore();
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save to: ");
        string filename = Console.ReadLine();

        try
        {
            List<string> lines = new List<string>();
            lines.Add(_score.ToString());

            foreach (BaseGoal goal in _goals)
            {
                lines.Add(goal.GetSaveData());
            }

            File.WriteAllLines(filename, lines);
            Console.WriteLine("Goals saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to save goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load: ");
        string filename = Console.ReadLine();

        try
        {
            string[] lines = File.ReadAllLines(filename);
            int loadedScore = int.Parse(lines[0]);
            List<BaseGoal> loadedGoals = new List<BaseGoal>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');

                string goalType = parts[0];
                string name = Uri.UnescapeDataString(parts[1]);
                string description = Uri.UnescapeDataString(parts[2]);
                int points = int.Parse(parts[3]);
                bool status = bool.Parse(parts[4]);

                switch (goalType)
                {
                    case "SimpleGoal":
                        loadedGoals.Add(new SimpleGoal(
                            name, description, points, status, goalType));
                        break;

                    case "EternalGoal":
                        loadedGoals.Add(new EternalGoal(
                            name, description, points));
                        break;

                    case "ChecklistGoal":
                        int completionCount = int.Parse(parts[5]);
                        int targetCount = int.Parse(parts[6]);
                        int bonusPoints = int.Parse(parts[7]);

                        loadedGoals.Add(new ChecklistGoal(
                            name, description, points,
                            targetCount, bonusPoints, completionCount));
                        break;

                    default:
                        throw new FormatException("Unknown goal type.");
                }
            }

            _score = loadedScore;
            _goals = loadedGoals;

            Console.WriteLine("Goals loaded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to load goals: {ex.Message}");
        }
    }
}