using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Domain
{
    public class Grade
    {
        public Course Course { get; set; }
        public string Name { get; set; }
        public decimal Score { get; set; }
        public decimal MaxScore { get; set; }
    }
}
