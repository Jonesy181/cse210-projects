class EternalGoal : BaseGoal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points, false, "EternalGoal")
    {
    }

    public EternalGoal() : base("EternalGoal")
    {
    }

    public override int RecordEvent()
    {
        return GetPoints();
    }
}