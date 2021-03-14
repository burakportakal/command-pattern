using ApiCommands.Event;
using ApiData;
using ApiData.Infastructure;
using ApiData.Repositories;
using ApiModels;
using ApiModels.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCommandHandlers.Event
{
    public class GetEventsCommandHandler : CommandHandler<GetEventsCommand, GetEventsResponse>
    {
        private IEventRepository eventRepository;
        private IUnitOfWork unitOfWork;

        public GetEventsCommandHandler(IEventRepository eventRepository,IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.eventRepository = eventRepository;
        }

        protected override Task<GetEventsCommand> OnBeforeProcessCommand(GetEventsCommand command)
        {
            return Task.FromResult(command);
        }

        protected override Task<GetEventsResponse> ProcessCommand(GetEventsCommand command)
        {
            var response = new GetEventsResponse();
            response.Events = eventRepository.GetAll().ToList();
            return Task.FromResult(response);
        }

        protected override Task<ICommandResult> OnAfterProcessCommand(ICommandResult result)
        {
            return Task.FromResult(result);
        }

    }
}
