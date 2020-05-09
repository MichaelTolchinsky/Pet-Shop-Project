using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public Animal Animal{ get; set; }

        public string CommentMessage { get; set; }
    }
}
