using MetricsManager.DAL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/memorymetrics")]
    public class MemoryMetricsController : Controller
    {
        private readonly IMemoryMetricService _service;

        public MemoryMetricsController(IMemoryMetricService service)
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