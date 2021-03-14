using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCommandHandlers;
using ApiCommands;
using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebApi.Controllers
{
    public class BaseApiController : ControllerBase
    {
        private IComponentContext _icoContext;
        public BaseApiController(IComponentContext icocontext)
        {
            _icoContext = icocontext;
        }
        protected async Task<ActionResult> Go(ICommand command)
        {
            var handler = GetCommandHandler(command);
            var response = await handler.Execute(command);
            return Ok(response);
        }
        private ICommandHandler GetCommandHandler(ICommand command)
        {
            return _icoContext.ResolveNamed<ICommandHandler>(command.GetType().FullName);
        }
    }
}