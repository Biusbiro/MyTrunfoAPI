using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrunfoAPI.Model
{
    public class PropertyValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Decimal DecimalValue { get; set; }
        public int IntValue { get; set; }
        public Card Card { get; set; }
        public Category Category { get; set; }
    }
}
