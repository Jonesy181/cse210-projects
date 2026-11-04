using System;

class Program
{
    static void Main(string[] args)
    {
        BaseActivity activity = new BaseActivity();
        activity.RunCountDownMessage("Get Ready", 5);
        activity.DisplaySpinnerMessage("Well Done", 10);

        DateTime endTime = DateTime.Now.AddSeconds(15);
        
        while (DateTime.Now < endTime)
        {
            activity.RunCountDownMessage("Breath in . . .", 4);
            activity.RunCountDownMessage("Breath out . . .", 6);
        }
    }
}