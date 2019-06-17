using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba6.Models
{
    public class PriceBody
    {
        public int id { get; set; }
        public string value { get; set; }
    }

    public class UpdateModel
    {
        public int ClassTypeId { get; set; }
        public string ClassLead  { get; set; }
    }
}
