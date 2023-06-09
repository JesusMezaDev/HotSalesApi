﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MediatR;

using HotSalesCore.Features.Products.Queries;
using HotSalesCore.Features.Pagination.Models;
using HotSalesCore.Features.Pagination.Queries;
using Microsoft.IdentityModel.Tokens;

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
        public async Task<ContentResult> Get(int Product_Id)
        {
            var query = new GetProductByIdQueryRequest();
            query.Product_Id = Product_Id;
            var data = await _mediator.Send(query);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }

        [HttpGet]
        public async Task<ContentResult> GetAll()
        {
            var query = new GetAllProductsQueryRequest();
            var pagination = GetPagination();
            query.Page = pagination.Page;
            query.RecordsByPage = pagination.RecordsByPage;
            var data = await _mediator.Send(query);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }

        [HttpGet, Route("{term}")]
        public async Task<ContentResult> GetByTerm(string term)
        {
            var query = new SearchProductQueryRequest();
            var pagination = GetPagination();
            query.Search_Term = term;
            query.Page = pagination.Page;
            query.RecordsByPage = pagination.RecordsByPage;
            var data = await _mediator.Send(query);
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

        private PaginationQueryRequest GetPagination()
        {
            var pagination = new PaginationQueryRequest();

            if (HttpContext.Request.Query.Count > 0)
            {    
                if (!HttpContext.Request.Query["page"].IsNullOrEmpty())
                {
                    pagination.Page = Convert.ToInt32(HttpContext.Request.Query["page"]);
                }

                if (!HttpContext.Request.Query["recordsByPage"].IsNullOrEmpty())
                {
                    pagination.RecordsByPage = Convert.ToInt32(HttpContext.Request.Query["recordsByPage"]);
                }
            }

            return pagination;
        }
    }
}
