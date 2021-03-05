using Data.Sql.Interfaces;
using Data.Sql.Entities;
using System;
using System.Linq;

namespace Forecaster.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IBaseRepository<Project> _projectRepo;

        public ProjectService(IBaseRepository<Project> projectRepo)
        {
            _projectRepo = projectRepo;
        }

        /// <summary>
        /// retrieves projects
        /// </summary>
        /// <returns></returns>
        public object GetProjectsForDate(string month)
        {
            DateTime monthDate;
            bool success = DateTime.TryParse(month, out monthDate);
            if (!success) return null;


            var projects = _projectRepo.Get(p => p.Months.Any(d => d.Date == monthDate))
                ?.Select(m => new ProjectModel
                {
                    ClientName = m.ClientName,
                    Id = m.Id,
                    JobNo = m.JobNo,
                    MonthDate = m.Months.FirstOrDefault(d => d.Date == monthDate).Date,
                    Revenue = m.Months.FirstOrDefault(d => d.Date == monthDate).Revenue,
                    Name = m.Name,
                    Status = m.Status
                });
            var total = projects.ToList().Sum(d => d.Revenue);
            return new { total, projects };
        }

        /// <summary>
        /// updates a project or saves it
        /// </summary>
        /// <returns></returns>
        public bool UpdateProject(Project project)
        {
            var entity = _projectRepo.GetSingle(project.Id);
            if (entity == null)
            {
                _projectRepo.Add(new Project
                {
                    ClientName = project.ClientName,
                    JobNo = project.JobNo,
                    Months = project.Months,
                    Name = project.Name,
                    Status = project.Status
                });
            }
            else
            {
                entity.ClientName = project.ClientName;
                entity.JobNo = project.JobNo;
                entity.Status = project.Status;


                _projectRepo.Edit(entity);
            }
            return _projectRepo.Commit();
        }
    }
}






