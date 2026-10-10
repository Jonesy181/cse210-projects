class JournalEntry
{
    public string _date;

    public string _prompt;

    public string _response;


    public void DisplayEntry()
    {
        Console.Write($"{_date}, ");
        Console.WriteLine($"{_prompt}, ");
        Console.WriteLine($"{_response}, ");
    }

    public void CreateJournalEntry()
    {
        DateTime theCurrentTime = DateTime.Now;
        _date = theCurrentTime.ToShortDateString();
        List<string> prompts = new List<string>()
        {
            "How was your day?",
            "What was the best part of your day?",
            "What is something you learned today?",
            "What are you grateful for today?",
            "What is something you could improve tomorrow?",
            "What are your goals for the day? Did you complete them?",
            "Did you meet anyone interesting today?",
            "What did you do to help someone today?",
            "What cool fact did you learn today?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Count);

        _prompt = prompts[index];

        Console.Write($"{_prompt}");
        _response = Console.ReadLine();
        
    }
}