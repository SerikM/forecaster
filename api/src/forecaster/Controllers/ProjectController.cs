using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Forecaster.Services;
using Data.Sql.Entities;

namespace Forecaster.Controllers
{
    [Route("v1/[controller]")]
    public class ProjectController : ControllerBase
    {
        private const string ErrorMessage = "failed to process request";
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        /// returns a collection of projects
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet("{date}")]
        public IActionResult Get(string date)
        {
            var projects = _projectService.GetProjectsForDate(date);
            if (projects == null) return BadRequest(ErrorMessage);
            return Ok(JsonConvert.SerializeObject(projects));
        }

        /// <summary>
        /// updates a project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Update([FromBody] Project project)
        {
            if (project == null) return BadRequest(ErrorMessage);
            if (!_projectService.UpdateProject(project)) return BadRequest(ErrorMessage);
            return Ok();
        }
    }
}