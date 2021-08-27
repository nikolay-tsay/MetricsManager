using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/networkmetrics")]
    public class NetworkMetricsController : Controller
    {
        [HttpGet]
        [Route("read")]
        public IActionResult GetAllMetrics()
        {
            return Ok();
        }
    }
}