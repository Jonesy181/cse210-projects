class SimpleGoal : BaseGoal
{
    public SimpleGoal(string name, string description, int points, bool status, string goalType) 
    : base (name, description, points, status, goalType)
    {
        
    }

    public SimpleGoal() : base("SimpleGoal")
    {
        
    }

    public override int RecordEvent()
    {
        return StatusComplete();
    }
}