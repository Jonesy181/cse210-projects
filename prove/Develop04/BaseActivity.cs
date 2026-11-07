class BaseActivity
{
    private string _name;
    private string _description;
    private int _duration;
    private DateTime _endTime;

    public BaseActivity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    protected int GetRemainingSeconds()
    {
        return Math.Max(0, (int)Math.Ceiling((_endTime - DateTime.Now).TotalSeconds));
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity!");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        ObtainDuration();
        DisplaySpinnerMessage("Get ready...", 3);
        Console.WriteLine();
    }

    public void DisplayEnding()
    {
        DisplaySpinnerMessage("Well done!", 3);
        DisplaySpinnerMessage($"You have completed {_duration} seconds of the {_name} Activity.", 5);
        Console.WriteLine();
    }

    public void RunCountDownMessage(string message, int seconds)
    {
        Console.CursorVisible = false;
        for(int i=seconds; i>=1; i--)
        {
            Console.Clear();
            Console.Write($"{message} - {i}");
            Thread.Sleep(1000);
        }
        Console.CursorVisible = true;
    }

    public void DisplaySpinnerMessage(string message, int seconds)
    {
        Console.CursorVisible = false;
        Console.Clear();
        Console.Write($"{message} ");
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("+");
            Thread.Sleep(200);
            Console.Write("\b");
            Console.Write("-");
            Thread.Sleep(200);
            Console.Write("\b");
        }
        Console.CursorVisible = true;
    }

    public void StartTime()
    {
        _endTime = DateTime.Now.AddSeconds(_duration);
    }

    public bool HasTimerExpired()
    {
        return DateTime.Now >= _endTime;
    }

    public void ObtainDuration()
    {
        Console.Write("How long, in seconds, would you like your session? ");

        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a positive whole number: ");
        }
    }

    public string GetPromptString(List<FlaggedString> prompts)
    {
        List<FlaggedString> unusedPrompts = new List<FlaggedString>();

        foreach (FlaggedString prompt in prompts)
        {
            if (!prompt.GetHasBeenUsed())
            {
                unusedPrompts.Add(prompt);
            }
        }

        if (unusedPrompts.Count == 0)
        {
            return "";
        }

        Random random = new Random();
        int index = random.Next(unusedPrompts.Count);

        FlaggedString selectedPrompt = unusedPrompts[index];
        selectedPrompt.SetHasBeenUsed();

        return selectedPrompt.GetPrompt();
    }
}