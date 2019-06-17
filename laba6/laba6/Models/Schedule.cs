using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba6.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
