using Cadres.Service.Dto;
using Cadres.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Cadres.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RodController : ControllerBase
    {
        private IRodService RodService { get; set; }
        public RodController(IRodService rodService)
        {
            RodService = rodService;
        }

        [HttpGet]
        public ActionResult<RodOutputDataContract> Get()
        {
            return Ok(RodService.GetRodsAvailable());
        }

        [HttpGet("{id}")]
        public ActionResult<RodOutputDataContract> Get(long id)
        {
            return Ok(RodService.GetByid(id));
        }
    }
}