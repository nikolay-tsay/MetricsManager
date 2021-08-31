using MetricsManager.DAL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/memorymetrics")]
    public class MemoryMetricsController : Controller
    {
        private readonly IMemoryMetricService _service;
        private readonly ILogger<MemoryMetricsController> _logger;

        public MemoryMetricsController(IMemoryMetricService service, ILogger<MemoryMetricsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("read")]
        public IActionResult GetAllMetrics()
        {
            _logger.LogInformation("GetAll method called from MemoryMetricsController");
            return Ok(_service.GetAll());
        }
    }
}