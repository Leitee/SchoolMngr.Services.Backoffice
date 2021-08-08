
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codeit.NetStdLibrary.Base.Application;
using Codeit.NetStdLibrary.Base.BusinessLogic;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fitnner.Trainers.Catalog.Controllers
{
    public class ProductsController : ApiBaseController
    {
        private readonly IProductSVC _productSVC;
        public ProductsController(ILoggerFactory loggerFactory, IProductSVC productSVC) : base(loggerFactory)
        {
            _productSVC = productSVC;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await _productSVC.GetAllAsync(cancellationToken);
            return response.ToHttpResponse();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{pId}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid pId)
        {
            var response = await _productSVC.GetByIdAsync(pId);
            return response.ToHttpResponse();
        }

        // POST api/<ProductsController>
        [HttpPost]
        [ProducesResponseType(typeof(BLSingleResponse<ProductDTO>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] ProductDTO pProduct)
        {
            var response = await _productSVC.CreateAsync(pProduct);
            return response.ToHttpResponse();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{pId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid pId)
        {
            var resul = await _productSVC.GetByIdAsync(pId);
            if (resul == null)
                return NotFound();

            var response = await _productSVC.DeleteAsync(resul.Payload);
            return response.ToHttpResponse();
        }

        // PATCH: api/<ProductsController>
        [HttpPatch("{pId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Patch([FromBody] ProductDTO pProduct, Guid pId)
        {
            if (pProduct.Id != pId)
                return NotFound();

            var response = await _productSVC.UpdateAsync(pProduct);
            return response.ToHttpResponse();
        }

        // GET api/<ProductsController>/Fitner/5
        [HttpGet("Fitner/{fId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(Guid fId)
        {
            var response = await _productSVC.GetAllAsync(fId);
            return response.ToHttpResponse();
        }
    }
}
