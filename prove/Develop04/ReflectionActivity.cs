class ReflectionActivity : BaseActivity
{
    private List<FlaggedString> _prompts;
    private List<FlaggedString> _questions;

    public ReflectionActivity()
        : base(
            "Reflection",
            "This activity will help you reflect on times in your life " +
            "when you have shown strength and resilience. This will help " +
            "you recognize the power you have and how you can use it " +
            "in other aspects of your life.")
    {
        _prompts = new List<FlaggedString>
        {
            new FlaggedString(
                "Think of a time when you stood up for someone else.", false),
            new FlaggedString(
                "Think of a time when you did something really difficult.", false),
            new FlaggedString(
                "Think of a time when you helped someone in need.", false),
            new FlaggedString(
                "Think of a time when you did something truly selfless.", false)
        };

        _questions = CreateQuestions();
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

        Console.Clear();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine(
            "When you have something in mind, press Enter to continue.");

        Console.ReadLine();

        RunCountDownMessage(
            "Reflect on the questions that follow. Beginning in", 5);

        StartTime();

        while (!HasTimerExpired())
        {
            string question = GetPromptString(_questions);

            if (question == "")
            {
                _questions = CreateQuestions();
                question = GetPromptString(_questions);
            }

            int pauseSeconds = Math.Min(10, GetRemainingSeconds());
            DisplaySpinnerMessage(question, pauseSeconds);
        }

        DisplayEnding();
    }

    private List<FlaggedString> CreateQuestions()
    {
        return new List<FlaggedString>
        {
            new FlaggedString("Why was this experience meaningful to you?", false),
            new FlaggedString("Have you ever done anything like this before?", false),
            new FlaggedString("How did you get started?", false),
            new FlaggedString("How did you feel when it was complete?", false),
            new FlaggedString("What made this time different than other times " +
                "when you were not as successful?", false),
            new FlaggedString("What is your favorite thing about this experience?", false),
            new FlaggedString("What could you learn from this experience that " +
                "applies to other situations?", false),
            new FlaggedString("What did you learn about yourself through this experience?",
                false),
            new FlaggedString("How can you keep this experience in mind in the future?",
                false)
        };
    }
}