using MetricsManager.DAL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/diskmetrics")]
    public class PhysicalDiskMetricsController : Controller
    {
        private readonly IDiskMetricService _service;
        private readonly ILogger _logger;

        public PhysicalDiskMetricsController(IDiskMetricService service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }
        
        [HttpGet]
        [Route("read")]
        public IActionResult GetAllMetrics()
        {
            _logger.Information("GetAll method called from DiskMetricsController");
            return Ok(_service.GetAll());
        }
    }
}