using Data.Sql.Entities;

namespace Forecaster.Services
{
    public interface IProjectService
    {
        public object GetProjectsForDate(string monthDate);
        bool UpdateProject(Project project);
    }
}
