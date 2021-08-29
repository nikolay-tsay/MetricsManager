using MetricsManager.DAL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/networkmetrics")]
    public class NetworkMetricsController : Controller
    {
        private readonly INetworkMetricService _service;

        public NetworkMetricsController(INetworkMetricService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Route("read")]
        public IActionResult GetAllMetrics()
        {
            return Ok(_service.GetAll());
        }
    }
}