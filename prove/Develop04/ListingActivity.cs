class ListingActivity : BaseActivity
{
    private List<FlaggedString> _prompts;

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things " +
            "in your life by having you list as many things as you " +
            "can in a certain area.")
    {
        _prompts = new List<FlaggedString>
        {
            new FlaggedString("Who are people that you appreciate?", false),
            new FlaggedString("What are personal strengths of yours?", false),
            new FlaggedString("Who are people that you have helped this week?", false),
            new FlaggedString("When have you felt the Holy Ghost this month?", false),
            new FlaggedString("Who are some of your personal heroes?", false)
        };
    }

    public void Run()
    {
        StartActivity();

        string prompt = GetPromptString(_prompts);

        if (prompt == "")
        {
            for (int i = 0; i < _prompts.Count; i++)
            {
                _prompts[i] = new FlaggedString(
                    _prompts[i].GetPrompt(), false);
            }

            prompt = GetPromptString(_prompts);
        }

        RunCountDownMessage(
            $"List as many responses as you can:\n\n{prompt}\n\nBegin in",
            5);

        Console.Clear();
        Console.WriteLine(prompt);
        Console.WriteLine("Enter one item per line. Press Enter after each item.");
        Console.WriteLine();

        StartTime();
        int count = ReadItems();

        DisplaySpinnerMessage(
            $"Time is up! You listed {count} items.", 3);

        DisplayEnding();
    }

    public int ReadItems()
    {
         int count = 0;

    while (!HasTimerExpired())
    {
        Console.Write("> ");
        string item = Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(item))
        {
            count++;
        }
    }

    return count;
    }
}