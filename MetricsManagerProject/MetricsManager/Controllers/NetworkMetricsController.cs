using MetricsManager.DAL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/networkmetrics")]
    public class NetworkMetricsController : Controller
    {
        private readonly INetworkMetricService _service;
        private readonly ILogger<NetworkMetricsController> _logger;
        public NetworkMetricsController(INetworkMetricService service, ILogger<NetworkMetricsController> logger)
        {
            _service = service;
            _logger = logger;
        }
        
        [HttpGet]
        [Route("read")]
        public IActionResult GetAllMetrics()
        {
            _logger.LogInformation("GetAll method called from NetworkMetricsController");
            return Ok(_service.GetAll());
        }
    }
}