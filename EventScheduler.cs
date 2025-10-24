using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

public class EventScheduler
{
    private List<Event> events = new List<Event>();
    private const string FilePath = "events.json";

    public void ScheduleEvent(Event newEvent)
    {
        if (events.Any(e => e.DateTime == newEvent.DateTime))
        {
            Console.WriteLine("Error: Another event is already scheduled at this time.");
            return;
        }

        events.Add(newEvent);
        SaveEvents();
        Console.WriteLine("Event scheduled successfully!");
    }

    public void CancelEvent(string eventName)
    {
        var ev = events.FirstOrDefault(e => e.Name.Equals(eventName, StringComparison.OrdinalIgnoreCase));

        if (ev != null)
        {
            events.Remove(ev);
            SaveEvents();
            Console.WriteLine($"Event '{eventName}' cancelled.");
        }
        else
        {
            Console.WriteLine("Event not found.");
        }
    }

    public List<Event> GetUpcomingEvents()
    {
        return events.Where(e => e.DateTime >= DateTime.Now)
        .OrderBy(e => e.DateTime)
        .ToList();
    }

    public void SaveEvents()
    {
        var json = JsonSerializer.Serialize(events, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }
    
    public void LoadEvents()
    {
        if (File.Exists(FilePath))
        {
            var json = File.ReadAllText(FilePath);
            events = JsonSerializer.Deserialize<List<Event>>(json) ?? new List<Event>();
        }
    }
}