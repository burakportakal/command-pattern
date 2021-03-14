using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Event
{
    public class DeleteEventResponse : ICommandResult
    {
        public bool isSuccess { get; set; }
    }
}
