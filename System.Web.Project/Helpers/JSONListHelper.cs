using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Project.Models;

namespace System.Web.Project.Helpers
{
    public static class JSONListHelper
    {
        public static string GetEventListJSONString(List<Models.Event> events)
        {
            var eventlist = new List<Event>();
            foreach (var model in events)
            {
                var myevent = new Event()
                {
                    id = model.Id,
                    start = model.StartTime,
                    end = model.EndTime,
                    resourceId = model.Location.Id,
                    description = model.Description,
                    title = model.Name
                };
                eventlist.Add(myevent);
            }
            return Text.Json.JsonSerializer.Serialize(eventlist);
        }

        public static string GetResourceListJSONString(List<Models.Location> locations)
        {
            var resourcelist = new List<Resource>();

            foreach (var loc in locations)
            {
                var resource = new Resource()
                {
                    id = loc.Id,
                    title = loc.Name
                };
                resourcelist.Add(resource);
            }
            return Text.Json.JsonSerializer.Serialize(resourcelist);
        }

        internal static object? GetResourceListJSONString(List<Department> departments)
        {
            var resourcelist = new List<Resource>();
            foreach (var dep in departments)
            {
                var resource = new Resource()
                {
                    id = dep.Id,
                    title = dep.Name
                };
                resourcelist.Add(resource);
            }
            return Text.Json.JsonSerializer.Serialize(resourcelist);
        }
    }

    public class Event
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int resourceId { get; set; }
        public string description { get; set; }
    }

    public class Resource
    {
        public int id { get; set; }
        public string title { get; set; }

    }
}
