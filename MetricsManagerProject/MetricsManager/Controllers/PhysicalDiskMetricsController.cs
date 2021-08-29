using MetricsManager.DAL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/diskmetrics")]
    public class PhysicalDiskMetricsController : Controller
    {
        private readonly IDiskMetricService _service;

        public PhysicalDiskMetricsController(IDiskMetricService service)
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