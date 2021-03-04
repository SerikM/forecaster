using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Forecaster.Services;

namespace Forecaster.Controllers
{
    [Route("v1/[controller]")]
    public class ReportController : ControllerBase
    {
        private const string ErrorMessage = "failed to process request";
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        /// <summary>
        /// updates a project
        /// </summary>
        /// <param name="startMo"></param>
        /// <param name="endMo"></param>
        /// <returns></returns>
        [HttpGet("{startMo}/{endMo}")]
        public IActionResult Get(string startMo, string endMo)
        {
            var reports = _reportService.GetReportsForDate(startMo, endMo);
            if (reports == null) return BadRequest(ErrorMessage);
            return Ok(JsonConvert.SerializeObject(reports));
        }
    }
}