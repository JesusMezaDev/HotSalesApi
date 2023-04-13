﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MediatR;

using HotSalesCore.Features.Products.Queries;

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

        [HttpGet, Route("{Search_Term}")]
        public async Task<ContentResult> GetByTerm(string Search_Term)
        {
            var query = new SearchProductQueryRequest();
            query.SearchTerm = Search_Term;
            var data = await _mediator.Send(query);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }

        [HttpPost]
        public async Task<ContentResult> Save([FromBody] SaveProductQueryRequest saveProductQueryRequest)
        {
            var data = await _mediator.Send(saveProductQueryRequest);
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