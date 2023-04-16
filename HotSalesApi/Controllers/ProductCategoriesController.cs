using Microsoft.AspNetCore.Mvc;
using MediatR;
using Newtonsoft.Json;
using HotSalesCore.Features.ProductCategories.Queries;

namespace HotSalesApi.Controllers
{
    [Route("api/product-categories")]
    [ApiController]
    public class ProductCategoriesController: ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{ProductCategory_Id:int}")]
        public async Task<ContentResult> GetByTerm(int ProductCategory_Id)
        {
            var query = new GetProductCategoryByIdQueryRequest();
            query.ProductCategory_Id = ProductCategory_Id;
            var data = await _mediator.Send(query);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }

        [HttpGet, Route("{Search_Term}")]
        public async Task<ContentResult> GetByTerm(string Search_Term)
        {
            var query = new SearchProductCategoryQueryRequest();
            query.SearchTerm = Search_Term;
            var data = await _mediator.Send(query);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }

        [HttpPost]
        public async Task<ContentResult> Save([FromBody] SaveProductCategoryQueryRequest saveProductCategoryQueryRequest)
        {
            var data = await _mediator.Send(saveProductCategoryQueryRequest);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }

        [HttpPatch]
        public async Task<ContentResult> Update([FromBody] UpdateProductcategoryQueryRequest updateProductcategoryQueryRequest)
        {
            var data = await _mediator.Send(updateProductcategoryQueryRequest);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }

        [HttpDelete("{ProductCategory_Id:int}")]
        public async Task<ContentResult> Delete(int ProductCategory_Id)
        {
            var query = new DeleteProductCategoryQueryRequest();
            query.ProductCategory_Id = ProductCategory_Id;
            var data = await _mediator.Send(query);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }
    }
}
