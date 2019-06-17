using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba6.Models
{
    public class PrepareFuels
    {
        public PrepareFuels() { }
        public PrepareFuels(int id, string classType) {
            Id = id;
            ClassType = classType;
        }
        public int Id { set; get; }
        public string ClassType { get; set; }
    }
}
