using Data.Sql.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Sql.Entities
{
    public class Month : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public double Revenue { get; set; }
    }
}