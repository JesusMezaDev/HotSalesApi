using Microsoft.AspNetCore.Mvc;

using MediatR;
using Newtonsoft.Json;

using HotSalesCore.Features.Settlements.Queries;

namespace HotSalesApi.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class SettlementsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SettlementsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ContentResult> GetAll()
        {
            var query = new GetAllSettlementsQueryRequest();
            var data = await _mediator.Send(query);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }

        [HttpGet, Route("{PC}")]
        public async Task<ContentResult> GetByCP(String PC)
        {
            var query = new GetSettlementsByPCQueryRequest();
            query.PC = PC;
            var data = await _mediator.Send(query);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }
    }
}
