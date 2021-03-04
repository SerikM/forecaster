using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Forecaster.Services;
using Data.Sql.Entities;

namespace Forecaster.Controllers
{
    [Route("v1/[controller]")]
    public class DefaultController : ControllerBase
    {
        private const string ErrorMessage = "failed to process request";
        private readonly IProjectService _projectService;
        private readonly IReportService _reportService;


        public DefaultController(IProjectService projectService, IReportService reportService)
        {
            _projectService = projectService;
            _reportService = reportService;
        }

        /// <summary>
        /// returns a collection of projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public  IActionResult Projects(string date)
        {
           var projects =  _projectService.GetProjectsForDate(date);
           if (projects == null) return BadRequest(ErrorMessage);
           return Ok(JsonConvert.SerializeObject(projects));
        }

        /// <summary>
        /// updates a project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        public  IActionResult Projects([FromBody]Project project)
        {
            if(project == null) return BadRequest(ErrorMessage);
            if (!_projectService.UpdateProject(project)) return BadRequest(ErrorMessage);
            return Ok();
        }

        /// <summary>
        /// returns reports
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Reports(string startMo, string endMo)
        {
            var reports = _reportService.GetReportsForDate(startMo, endMo);
            if (reports == null) return BadRequest(ErrorMessage);
            return Ok(JsonConvert.SerializeObject(reports));
        }
    }
}