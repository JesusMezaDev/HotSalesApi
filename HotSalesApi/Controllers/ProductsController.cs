using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MediatR;

using HotSalesCore.Features.Products.Queries;
using HotSalesCore.Features.Pagination.Models;

namespace HotSalesApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Product_Id:int}")]
        public async Task<ContentResult> GetByTerm(int Product_Id)
        {
            var query = new GetProductByIdQueryRequest();
            query.Product_Id = Product_Id;
            var data = await _mediator.Send(query);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }

        //[HttpGet, Route("{Search_Term}")]
        [HttpGet]
        public async Task<ContentResult> GetByTerm([FromQuery] SearchProductQueryRequest searchProductQueryRequest)
        {
            //var query = new SearchProductQueryRequest();
            //query.Search_Term = searchProductQueryRequest.Search_Term;
            //query.Page = searchProductQueryRequest.Page;
            //query.RecordsByPage = searchProductQueryRequest.RecordsByPage;
            var data = await _mediator.Send(searchProductQueryRequest);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }

        [HttpPost]
        public async Task<ContentResult> Save([FromBody] SaveProductQueryRequest saveProductQueryRequest)
        {
            var data = await _mediator.Send(saveProductQueryRequest);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }

        [HttpPatch]
        public async Task<ContentResult> Update([FromBody] UpdateProductQueryRequest updateProductQueryRequest)
        {
            var data = await _mediator.Send(updateProductQueryRequest);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }

        [HttpDelete("{Product_Id:int}")]
        public async Task<ContentResult> Delete(int Product_Id)
        {
            var query = new DeleteProductQueryRequest();
            query.Product_Id = Product_Id;
            var data = await _mediator.Send(query);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }
    }
}
