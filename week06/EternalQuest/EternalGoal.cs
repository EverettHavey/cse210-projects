public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {

    }

    // override void value
    public override void RecordEvent()
    {
        System.Console.WriteLine($"Event recorded for '{_shortName}'. You earned {_points} points.");
    }

    // override bool value
    public override bool IsComplete()
    {
        return false;
    }

    // override string
    public override string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description}) - Points per event: {_points}";
    }
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName}|{_description}|{_points}";
    }
}