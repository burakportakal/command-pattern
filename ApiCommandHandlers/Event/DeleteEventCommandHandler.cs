using ApiCommands.Event;
using ApiData.Infastructure;
using ApiData.Repositories;
using ApiModels;
using ApiModels.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiCommandHandlers.Event
{
    public class DeleteEventCommandHandler : CommandHandler<DeleteEventCommand, DeleteEventResponse>
    {
        private IEventRepository eventRepository;
        private IUnitOfWork unitOfWork;

        public DeleteEventCommandHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.eventRepository = eventRepository;
        }

        protected override Task<ICommandResult> OnAfterProcessCommand(ICommandResult result)
        {
            return Task.FromResult(result);
        }

        protected override Task<DeleteEventResponse> ProcessCommand(DeleteEventCommand command)
        {
            var result = eventRepository.Delete(eventRepository.GetById(command.Data.EventID));
            var response = new DeleteEventResponse();
            if (result.State == Microsoft.EntityFrameworkCore.EntityState.Deleted)
            {
                unitOfWork.Commit();
                response.isSuccess = true;
                return Task.FromResult(response);
            }
            response.isSuccess = false;
            return Task.FromResult(response);
        }

        protected override Task<DeleteEventCommand> OnBeforeProcessCommand(DeleteEventCommand command)
        {
            return Task.FromResult(command);
        }

    
    }
}
