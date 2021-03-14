using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Event
{
    public class GetEventsResponse: ICommandResult
    {
        public List<Event> Events { get; set; }
    }
}
