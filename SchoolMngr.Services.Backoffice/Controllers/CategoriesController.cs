
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codeit.NetStdLibrary.Base.Abstractions.BusinessLogic;
using Codeit.NetStdLibrary.Base.Application;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Fitnner.Trainers.Catalog.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriesController : ApiBaseController
    {
        private readonly ICategorySVC _categorySVC;

        public CategoriesController(ILoggerFactory loggerFactory, ICategorySVC categorySVC)
            : base(loggerFactory)
        {
            _categorySVC = categorySVC;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        [AllowAnonymous]
        [ProducesDefaultResponseType(typeof(IBLListResponse<CategoryDTO>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await _categorySVC.GetAllWithRelationshipAsync(includeFather: true, includeChildren: false, cancellationToken);
            return response.ToHttpResponse();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType(typeof(IBLSingleResponse<CategoryDTO>))]
        public async Task<IActionResult> Get(Guid pId)
        {
            var response = await _categorySVC.GetByIdAsync(pId);
            return response.ToHttpResponse();
        }

        // POST api/<CategoriesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(IBLSingleResponse<int>))]
        public async Task<IActionResult> Post([FromBody] CategoryDTO pCategory)
        {
            var response = await _categorySVC.CreateAsync(pCategory);
            return response.ToHttpResponse();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType(typeof(IBLSingleResponse<bool>))]
        public async Task<IActionResult> Delete(Guid pId)
        {
            var resul = await _categorySVC.GetByIdAsync(pId);
            if (resul == null)
            {
                return NotFound();
            }

            var response = await _categorySVC.DeleteAsync(resul.Payload);
            return response.ToHttpResponse();
        }

        // PATCH: api/<CategoriesController>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType(typeof(IBLSingleResponse<bool>))]
        public async Task<IActionResult> Patch([FromBody] CategoryDTO pCategory, Guid pId)
        {
            if (pCategory.Id != pId)
                return NotFound();

            var response = await _categorySVC.UpdateAsync(pCategory);
            return response.ToHttpResponse();
        }
    }
}
