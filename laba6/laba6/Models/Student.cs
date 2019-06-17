using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba6.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
