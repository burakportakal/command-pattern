using ApiModels;
using ApiModels.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCommands.Event
{
    public class GetEventsCommand : Command<NoDataRequest, GetEventsResponse>, ICommand
    {

    }
}
