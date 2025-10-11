using System;

public abstract class Goal
{
    protected string _shortName { get; set; }
    protected string _description { get; set; }
    protected int _points { get; set; }

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();

    public string GetName() => _shortName;
    public int GetPoints() => _points;
}