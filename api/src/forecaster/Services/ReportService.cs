using System.Collections.Generic;
using Data.Sql.Interfaces;
using Data.Sql.Entities;
using System;

namespace Forecaster.Services
{
    public class ReportService : IReportService
    {
        private readonly IBaseRepository<Report> _reportRepo;

        public ReportService(IBaseRepository<Report> reportRepo)
        {
            _reportRepo = reportRepo;
        }

        /// <summary>
        /// retrieves reports
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Report> GetReportsForDate(string startDate, string endDate)
        {
            throw new NotImplementedException();
        }
    }
}








