using Microsoft.AspNetCore.Mvc;

using MediatR;
using Newtonsoft.Json;

using HotSalesCore.Features.Asentamientos.Queries;

namespace HotSalesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsentamientoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AsentamientoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("{CP}")]
        public async Task<ContentResult> Get(String CP)
        {
            var query = new GetAsentamientosQueryRequest();
            query.CP = CP;
            var data = await _mediator.Send(query);
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }
    }
}
