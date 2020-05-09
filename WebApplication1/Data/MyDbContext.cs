using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
        {
        }

        public DbSet<Category> Categories{ get; set; }

        public DbSet<Animal> Animals{ get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new {Id = 1,Name = "Mamal"},
                new {Id = 2,Name = "Reptile"},
                new {Id = 3,Name = "Aquatic"}
            );

            modelBuilder.Entity<Animal>().HasData(
                new {AnimalId = 1,Name = "Eastern grey kangaroo",Age = 10,ImgUrl="/images/Animals/kangaroo.jpg",Description = "The eastern grey kangaroo (Macropus giganteus) is a marsupial found in eastern third of Australia, with a population of several million. It is also known as the great grey kangaroo and the forester kangaroo. Although a big eastern grey male typically masses around 66 kg (weight 145 lb.) and stands almost 2 m (6.6 ft.) tall, the scientific name, Macropus giganteus (gigantic large-foot), is misleading: the red kangaroo of the semi-arid inland is larger, weighing up to 90 kg.",CategoryId = 1},
                new {AnimalId = 2,Name = "Stellagama stellio",Age = 13,ImgUrl="/images/Animals/stellagama.jpg",Description = "Lizards are a widespread group of squamate reptiles, with over 6,000 species,ranging across all continents except Antarctica, as well as most oceanic island chains. The group is paraphyletic as it excludes the snakes and Amphisbaenia; some lizards are more closely related to these two excluded groups than they are to other lizards. Lizards range in size from chameleons and geckos a few centimeters long to the 3 meter long Komodo dragon.",CategoryId = 2},
                new {AnimalId = 3,Name = "King penguin",Age = 15,ImgUrl="/images/Animals/penguin.jpg",Description = "The king penguin (Aptenodytes patagonicus) is the second largest species of penguin, smaller, but somewhat similar in appearance to the emperor penguin. There are two subspecies: A. p. patagonicus and A. p. halli; patagonicus is found in the South Atlantic and halli in the South Indian Ocean (at the Kerguelen Islands, Crozet Island, Prince Edward Islands and Heard Island and McDonald Islands) and at Macquarie Island.",CategoryId = 3}
                );


            modelBuilder.Entity<Comment>().HasData(
                new { Id  = 1, AnimalId = 1, CommentMessage = "good animal" },
                new { Id  = 2, AnimalId = 1, CommentMessage = "decent animal" },
                new { Id  = 3, AnimalId = 1, CommentMessage = "not bad animal" },
                new { Id = 4, AnimalId = 2, CommentMessage = "nice animal" },
                new { Id = 5, AnimalId = 2, CommentMessage = "good lizard" },
                new { Id = 6, AnimalId = 3, CommentMessage = "pinguins are okay animal" }
                );

            modelBuilder.Entity<Animal>().HasMany(c => c.Comments).WithOne(an => an.Animal).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
