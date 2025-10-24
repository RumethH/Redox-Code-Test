using System;

public class  Event
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime DateTime { get; set; }

    public override string ToString()
    {
        return $"{Name} at {Location} on {DateTime}";
    }

}