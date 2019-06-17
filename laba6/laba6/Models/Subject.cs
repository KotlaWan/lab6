using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba6.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Teacher { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}

