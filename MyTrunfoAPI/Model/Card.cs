using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTrunfoAPI.Model
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Code { get; set; }
        public String Title { get; set; }
        public String Subtitle { get; set; }
        public String Icon { get; set; }
        public String Image { get; set; }
        public List<Property> Properties { get; set; }
    }
}
