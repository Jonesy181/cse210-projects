class SimpleGoal : BaseGoal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool status, string goalType) 
    : base (name, description, points, status, goalType)
    {
        _isComplete = status;
    }

    public SimpleGoal() : base("SimpleGoal")
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }
        
        _isComplete = true;
        return StatusComplete();
    }
}