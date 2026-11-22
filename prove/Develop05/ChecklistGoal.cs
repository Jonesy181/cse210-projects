class ChecklistGoal : BaseGoal
{
    private int _completionCount;
    private int _targetCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points,
        int targetCount, int bonusPoints, int completionCount = 0)
        : base(name, description, points,
            completionCount >= targetCount, "ChecklistGoal")
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _completionCount = completionCount;
    }

    public ChecklistGoal() : base("ChecklistGoal")
    {
        _completionCount = 0;

        Console.Write("How many times must you complete this goal? ");

        while (!int.TryParse(Console.ReadLine(), out _targetCount)
            || _targetCount <= 0)
        {
            Console.Write("Please enter a number greater than zero: ");
        }

        Console.Write("How many bonus points will completing it earn? ");

        while (!int.TryParse(Console.ReadLine(), out _bonusPoints)
            || _bonusPoints < 0)
        {
            Console.Write("Please enter zero or a positive number: ");
        }
    }

    public override int RecordEvent()
    {
        if (_completionCount >= _targetCount)
        {
            return 0;
        }

        _completionCount++;

        if (_completionCount == _targetCount)
        {
            return StatusComplete() + _bonusPoints;
        }

        return GetPoints();
    }

    public override string GetConsoleString()
    {
        return $"{base.GetConsoleString()} — " +
            $"Completed {_completionCount}/{_targetCount} times";
    }

    public override string GetSaveData()
    {
        return $"{base.GetSaveData()}|" +
            $"{_completionCount}|{_targetCount}|{_bonusPoints}";
    }
}