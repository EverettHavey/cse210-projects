public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            System.Console.WriteLine($"Congratulations! You earned {_points} points for completing '{_shortName}'.");
        }
        else
        {
            System.Console.WriteLine($"'{_shortName}' is already complete.");
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName}|{_description}|{_points}|{_isComplete}";
    }
}