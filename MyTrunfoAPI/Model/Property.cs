using MyTrunfoAPI.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTrunfoAPI.Model
{
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasurement { get; set; }
        public EComparativeType ComparativeType { get; set; }
    }
}
