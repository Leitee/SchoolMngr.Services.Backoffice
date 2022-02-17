namespace SchoolMngr.Services.Backoffice.Controllers
{
    using Codeit.Enterprise.Base.Abstractions.BusinessLogic;
    using Codeit.Enterprise.Base.Application;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using SchoolMngr.Services.Backoffice.BL.Abstractions;
    using SchoolMngr.Services.Backoffice.BL.Dtos;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class SubjectsController : ApiBaseController
    {
        private readonly ISubjectSvc _subjectSvc;
        public SubjectsController(ILoggerFactory loggerFactory, ISubjectSvc subjectSvc) : base(loggerFactory)
        {
            _subjectSvc = subjectSvc;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        [AllowAnonymous]
        [ProducesDefaultResponseType(typeof(IBLListResponse<SubjectDto>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await _subjectSvc.GetAllAsync(cancellationToken);
            return response.ToHttpResponse();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{pId}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid pId)
        {
            var response = await _subjectSvc.GetByIdAsync(pId);
            return response.ToHttpResponse();
        }

        // POST api/<ProductsController>
        [HttpPost]
        [ProducesResponseType(typeof(IBLSingleResponse<SubjectDto>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] SubjectDto pProduct)
        {
            var response = await _subjectSvc.CreateAsync(pProduct);
            return response.ToHttpResponse();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{pId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid pId)
        {
            var resul = await _subjectSvc.GetByIdAsync(pId);
            if (resul == null)
                return NotFound();

            var response = await _subjectSvc.DeleteAsync(resul.Payload);
            return response.ToHttpResponse();
        }

        // PATCH: api/<ProductsController>
        [HttpPatch("{pId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Patch([FromBody] SubjectDto pProduct, Guid pId)
        {
            if (pProduct.Id != pId)
                return NotFound();

            var response = await _subjectSvc.UpdateAsync(pProduct);
            return response.ToHttpResponse();
        }

        // GET api/<ProductsController>/Fitner/5
        [HttpGet("Fitner/{fId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(Guid fId)
        {
            var response = await _subjectSvc.GetAllAsync();
            return response.ToHttpResponse();
        }
    }
}
