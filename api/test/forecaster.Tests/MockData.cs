using Data.Sql.Entities;
using System;

namespace Forecaster.Tests
{
    public static class MockData
    {
        internal static object GetProjectResponse()
        {
            return new { projectModels = new ProjectModel(), total = 45.00};
        }
    }
}
