using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba6.Models
{
    public class ClassType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Class> Classes { get; set; }
    }
}
