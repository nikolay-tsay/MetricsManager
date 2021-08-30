using MetricsManager.DAL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/cpumetrics")]
    public class CpuMetricsController : Controller
    {
        private readonly ICpuMetricService _service;
        private readonly ILogger<CpuMetricsController> _logger;
        
        public CpuMetricsController(ICpuMetricService service, ILogger<CpuMetricsController> logger)
        {
            _service = service;
            _logger = logger;
        }
        
        [HttpGet]
        [Route("read")]
        public IActionResult GetAllMetrics()
        {
            _logger.LogInformation("GetAll method called from CpuMetricsController");
            return Ok(_service.GetAll());
        }
    }
}