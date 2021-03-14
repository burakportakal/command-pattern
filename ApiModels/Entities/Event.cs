using System;
using System.Collections.Generic;

namespace ApiModels.Event
{
    public class Event : IEntity
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Location Location { get; set; }
        public string OnlineUrl { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
    public class Location
    {
        public int LocationID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
    public class Session
    {
        public int SessionID { get; set; }
        public string Name { get; set; }
        public string Presenter { get; set; }
        public int Duration { get; set; }
        public string Level { get; set; }
        public string Abstract { get; set; }
    }
}
