class FlaggedString
{
    private string _prompt;
    private bool _HasBeenUsed;

    public FlaggedString(string prompt, bool hasBeenUsed)
    {
        _prompt = prompt;
        _HasBeenUsed = hasBeenUsed;
    }

    public string GetPrompt()
    {
        return _prompt;
    }

    public void SetHasBeenUsed()
    {
        _HasBeenUsed = true;
    }

    public bool GetHasBeenUsed()
    {
        return _HasBeenUsed;
    }
}