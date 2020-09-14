using Cadres.Service.Dto;
using Cadres.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Cadres.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FrameController : ControllerBase
    {
        private IFrameService FrameService { get; set; }

        public FrameController(IFrameService frameService)
        {
            FrameService = frameService;
        }

        [HttpGet]
        public ActionResult<FrameGetPriceOutputDataContract> Get(decimal width, decimal large, long idRod)
        {
            var dataContract = new FrameGetPriceInputDataContract { Width = width, Large = large, IdRod = idRod };
            return Ok(FrameService.GetPriceFrameOutputDataContract(dataContract));
        }
    }
}