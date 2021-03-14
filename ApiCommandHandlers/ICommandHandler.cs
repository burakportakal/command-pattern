using ApiCommands;
using ApiModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiCommandHandlers
{
    public interface ICommandHandler
    {
        Task<ICommandResult> Execute(ICommand command);
    }
}
