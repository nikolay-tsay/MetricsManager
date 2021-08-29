using MetricsManager.DAL.Repositories.Interfaces;
using MetricsManager.DAL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/cpumetrics")]
    public class CpuMetricsController : Controller
    {
        private ICpuMetricService _service;

        public CpuMetricsController(ICpuMetricService service)
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