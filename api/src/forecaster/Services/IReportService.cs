using System.Collections.Generic;
using Data.Sql.Entities;

namespace Forecaster.Services
{
    public interface IReportService
    {
        public IEnumerable<Report> GetReportsForDate(string startDate, string endDate);
    }
}
