
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codeit.NetStdLibrary.Base.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fitnner.Trainers.Catalog.Controllers
{
    public class AgendasController : ApiBaseController
    {
        private readonly IAgendaSVC _agendaSVC;
        public AgendasController(ILoggerFactory loggerFactory, IAgendaSVC agendaSVC) : base(loggerFactory)
        {
            _agendaSVC = agendaSVC;
        }

        // GET: api/<AgendasController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await _agendaSVC.GetAllAsync(cancellationToken);
            return response.ToHttpResponse();
        }

        // GET api/<AgendasController>/5
        [HttpGet("{id}", Name = "GetAgenda")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _agendaSVC.GetByIdAsync(id);
            return response.ToHttpResponse();
        }

        // POST api/<AgendasController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Post([FromBody] AgendaDTO pAgenda)
        {
            var response = await _agendaSVC.CreateAsync(pAgenda);
            return response.ToHttpResponse();
        }

        // DELETE api/<AgendasController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var resul = await _agendaSVC.GetByIdAsync(id);
            if (resul == null)
            {
                return NotFound();
            }

            var response = await _agendaSVC.DeleteAsync(resul.Payload);
            return response.ToHttpResponse();
        }

        // PATCH: api/<AgendasController>
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Patch([FromBody] AgendaDTO pAgenda)
        {
            var response = await _agendaSVC.UpdateAsync(pAgenda);
            return response.ToHttpResponse();
        }
    }
}
