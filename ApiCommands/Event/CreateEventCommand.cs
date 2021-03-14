using ApiData;
using ApiModels.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCommands.Event
{
    public class CreateEventCommand : Command<EventCreateRequest,EventCreateResponse>, ICommand
    {

    }
}
