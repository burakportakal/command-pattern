using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCommandHandlers;
using ApiCommands;
using ApiCommands.Event;
using ApiModels.Event;
using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNetWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : BaseApiController
    {
        private IComponentContext _icoContext;
        public EventsController(IComponentContext icocontext) : base(icocontext)
        {
            _icoContext = icocontext;
        }
        // GET api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            var command = new GetEventsCommand();
            var response = await Go(command);
            return Ok(response);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/events
        [HttpPost]
        public async Task<ActionResult<EventCreateResponse>> Post([FromBody]EventCreateRequest value)
        {
            var command = new CreateEventCommand();
            command.Data = value;
            var response = await Go(command);
            return Ok(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteEventResponse>> DeleteAsync(int id)
        {
            var command = new DeleteEventCommand();
            var request = new DeleteEventRequest() { EventID = id };
            command.Data = request;
            var response = await Go(command);
            return Ok(response);
        }
    }
}
