using HotSalesCore.Features.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotSalesApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
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
            query.SearchTerm = Search_Term;
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
    }
}
