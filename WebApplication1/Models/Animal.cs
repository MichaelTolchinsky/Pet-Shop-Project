using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter age.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter a url.")]
        public string ImgUrl { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
