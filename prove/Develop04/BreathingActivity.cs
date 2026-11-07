class BreathingActivity : BaseActivity
{
    public BreathingActivity() : base("Breathing", "This Activity will help you relax by walking you through " + 
    "breathing in and out slowly. Clear your mind and focus " + 
    "on your breathing.")
    {
        
    }

    public void Run()
    {
        StartActivity();
        StartTime();

        while (!HasTimerExpired())
        {
            int breathInSeconds = Math.Min(4, GetRemainingSeconds());
            RunCountDownMessage("Breathe in...", breathInSeconds);

            if (HasTimerExpired())
            {
                break;
            }

            int breathOutSeconds = Math.Min(6, GetRemainingSeconds());
            RunCountDownMessage("Breathe out...", breathOutSeconds);
        }

        DisplayEnding();
    }
}