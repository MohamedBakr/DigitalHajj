using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalHajj.Models
{
    public class AirportStatusResult
    {
        public int airport_id;
        public long total;

        public int air { get; set; }
        public string airport_title { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
    }
}
