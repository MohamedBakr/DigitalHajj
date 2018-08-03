using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalHajj.Models
{
    [Table("Airport")]
    public class Airport
    {
        [Key]
        public int airport_id { get; set; }
        public string airport_title { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
    }
}
