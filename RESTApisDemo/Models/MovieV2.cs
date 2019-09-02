using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTApisDemo.Models
{
    public class MovieV2
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public string Type { get; set; }
    }
}
