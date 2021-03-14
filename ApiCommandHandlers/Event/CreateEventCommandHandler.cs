using ApiCommands.Event;
using ApiData;
using ApiData.Infastructure;
using ApiData.Repositories;
using ApiModels;
using ApiModels.Event;
using ApiValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCommandHandlers.Event
{
    public class CreateEventCommandHandler : CommandHandler<CreateEventCommand, EventCreateResponse>
    {
        private IEventRepository eventRepository;
        private IUnitOfWork unitOfWork;

        public CreateEventCommandHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.eventRepository = eventRepository;
        }

        protected override Task<CreateEventCommand> OnBeforeProcessCommand(CreateEventCommand command)
        {
            var validators = new List<BaseValidator>();
            validators.Add(new RequiredValidator(command.Data.Name,"Name required"));
            validators.Add(new RequiredValidator(command.Data.Date,"Date required"));

            var validator = new Validator();
            var validationResult = validator.Validate(validators);
            if (validator.HasErrors)
            {
                throw new Exception(string.Format("validation errors {0}", validator.GetErrorMessage()));
            }
            return Task.FromResult(command);
        }

        protected override Task<EventCreateResponse> ProcessCommand(CreateEventCommand command)
        {
            var eventEntity = new ApiModels.Event.Event();
            eventEntity.Date = command.Data.Date;
            eventEntity.Name = command.Data.Name;
            eventEntity.Price = command.Data.Price;
            eventEntity.ImageUrl = command.Data.ImageUrl;
            eventEntity.Location = command.Data.Location;
            eventEntity.Sessions = command.Data.Sessions;

            var result = eventRepository.Add(eventEntity);

            var response = new EventCreateResponse();
            var saveResult = unitOfWork.Commit();
            response.IsSuccess = saveResult != 0 ? true : false;
            response.Event = result.Entity;
            return Task.FromResult(response);
        }

        protected override Task<ICommandResult> OnAfterProcessCommand(ICommandResult result)
        {
            return Task.FromResult(result);
        }
    }
}
