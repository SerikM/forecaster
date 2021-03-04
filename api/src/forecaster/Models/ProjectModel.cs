using Data.Sql.Enums;
using Data.Sql.Interfaces;
using Newtonsoft.Json;
using System;

namespace Data.Sql.Entities
{
    [JsonObject("project")]
    public class ProjectModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("status")]
        public StatusType Status { get; set; }
        [JsonProperty("clientName")]
        public string ClientName { get; set; }
        [JsonProperty("jobNo")]
        public string JobNo { get; set; }
        [JsonProperty("revenue")]
        public double Revenue { get; set; }
        [JsonProperty("monthDate")]
        public DateTime MonthDate { get; set; }
    }
}