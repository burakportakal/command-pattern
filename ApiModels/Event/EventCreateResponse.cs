using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Event
{
    public class EventCreateResponse : ICommandResult
    {
        public bool IsSuccess { get; set; }
        public Event Event { get; set; }
    }
}
