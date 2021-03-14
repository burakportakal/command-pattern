using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApiCommands;
using ApiModels;

namespace ApiCommandHandlers
{
    public abstract class CommandHandler<TCommand, TResult> : ICommandHandler 
        where TCommand: ICommand
        where TResult : ICommandResult
    {
        protected abstract Task<TResult> ProcessCommand(TCommand command);
        protected abstract Task<TCommand> OnBeforeProcessCommand(TCommand command);
        protected abstract Task<ICommandResult> OnAfterProcessCommand(ICommandResult result);
        public virtual async Task<ICommandResult> Execute(ICommand command)
        {
            command = await BeforeExecute(command);
            var result  = await ProcessCommand((TCommand)command);
            return await AfterExecute(result);
        }
        public virtual async Task<TCommand> BeforeExecute(ICommand command)
        {
            return await OnBeforeProcessCommand((TCommand)command);
        }
        public virtual async Task<ICommandResult> AfterExecute(ICommandResult result)
        {
            return await OnAfterProcessCommand(result);
        }
    }
}
