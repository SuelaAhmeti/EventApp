using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Models;

public class FileRepository : IRepository<Event>
{
    private string filePath = "events.csv";
    private List<Event> events = new List<Event>();

    public List<Event> GetAll()
    {
        return events;
    }

    public Event GetById(int id)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return events.FirstOrDefault(e => e.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
    }

    public void Add(Event entity)
    {
        events.Add(entity);
    }

    public void Save()
    {
        File.WriteAllLines(filePath,
            events.Select(e => $"{e.Id},{e.Title},{e.Date},{e.Price}"));
    }
}
