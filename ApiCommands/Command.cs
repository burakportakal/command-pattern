using ApiModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCommands
{
    public abstract class Command<TRequest,TResult> where TResult:ICommandResult
    {
        public TRequest Data;
    }
}
