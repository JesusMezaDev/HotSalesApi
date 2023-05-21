using HotSalesCore.Features.Customers.Queries;
using HotSalesCore.Features.Pagination.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace HotSalesApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController: ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("{Search_Term}")]
        public async Task<ContentResult> GetByTerm(string Search_Term)
        {
            var query = new SearchCustomerQueryRequest();
            var pagination = GetPagination();
            query.SearchTerm = Search_Term;
            query.Page = pagination.Page;
            query.RecordsByPage = pagination.RecordsByPage;
            var data = await _mediator.Send(query);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }

        [HttpGet, Route("customer/{Customer_Id}")]
        public async Task<ContentResult> GetById(int Customer_Id)
        {
            var query = new GetCustomerByIdQueryRequest();
            query.Customer_Id = Customer_Id;
            var data = await _mediator.Send(query);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }

        [HttpPost]
        public async Task<ContentResult> Save([FromBody]SaveCustomerQueryRequest saveCustomerQueryRequest)
        {
            var data = await _mediator.Send(saveCustomerQueryRequest);
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
