using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class DetailViewModel
    {
        public Animal Animal{ get; set; }
        public IEnumerable<Comment> AnimalComments { get; set; }
        public string AnimalCategory { get; set; }
    }
}
