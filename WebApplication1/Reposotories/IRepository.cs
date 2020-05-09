using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Reposotories
{
    public interface IRepository
    {
        IEnumerable<Animal> GetAnimals();
        Animal GetAnimalById(int id);
        void InsertAnimal(Animal animal);
        void SaveComment();
        void UpdateAnimal(int id,Animal animal);
        void DeleteAnimal(int id);
        string GetAnimalCategoty(int categoryId);
    }
}
