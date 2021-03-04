using Data.Sql.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Data.Sql.Entities
{
    public class Report : IEntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
