using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Event
{
    public class EventCreateRequest
    {
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Location Location { get; set; }
        public string OnlineUrl { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}
