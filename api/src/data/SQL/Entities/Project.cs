using Data.Sql.Enums;
using Data.Sql.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Sql.Entities
{
    public class Project : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public StatusType Status { get; set; }
        public string ClientName { get; set; }
        public string JobNo { get; set; }
        public ICollection<Month> Months { get; set; }
    }
}