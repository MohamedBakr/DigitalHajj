using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalHajj.Models
{
    [Table("HallType")]
    public class Hall
    {
        public int halltype_id { get; set; }
        public string halltype_name { get; set; }
    }
}
