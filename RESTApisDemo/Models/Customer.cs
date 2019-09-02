using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTApisDemo.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required,StringLength(20)]
        public string Name { get; set; }
        [RegularExpression(@"^\w + ([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",ErrorMessage ="Email Format is Not Valid")]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
