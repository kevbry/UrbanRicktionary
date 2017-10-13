using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApp.Models
{
    public class Rickism
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }
        public string Usage { get; set; }

        public DateTime Created { get; set; }
    }
}
