
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class MyRepository : IRepository
    {
        private MyDbContext context;
        public MyRepository(MyDbContext _context)
        {
            context = _context;
        }

        public void SaveComment()
        {
            context.SaveChanges();
        }

        public void DeleteAnimal(int id)
        {
            var animalInDb = context.Animals.SingleOrDefault(a => a.AnimalId == id);
            context.Animals.Remove(animalInDb);
            context.SaveChanges();
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return context.Animals.Include(anm => anm.Comments);
        }

        public Animal GetAnimalById(int id)
        {
            return GetAnimals().Where(an => an.AnimalId == id) as Animal;
        }

        public string GetAnimalCategoty(int id)
        {
            return (context.Categories.First(cat => cat.Id == id) as Category).Name;
        }

        public void InsertAnimal(Animal animal)
        {
            animal.ImgUrl = "/images/Animals/" + animal.ImgUrl;
            context.Animals.Add(animal);
            context.SaveChanges();
        }

        public void UpdateAnimal(int id, Animal animal)
        {
            var animalInDb = context.Animals.SingleOrDefault(a => a.AnimalId == id);
            animalInDb.Name = animal.Name;
            animalInDb.Age = animal.Age;
            animalInDb.ImgUrl = "/images/Animals/" + animal.ImgUrl;
            animalInDb.Description = animal.Description;
            animalInDb.CategoryId = animal.CategoryId;
            context.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.Categories;
        }
    }
}
