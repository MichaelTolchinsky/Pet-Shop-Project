using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Reposotories;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        private IRepository repository;
        public AdminController(IRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult AdminPage(int id = 1)
        {
            return View(repository.GetAnimals().Where(anm => anm.CategoryId == id));
        }

        public IActionResult DeleteAnimal(int id)
        {
            repository.DeleteAnimal(id);
            return RedirectToAction("AdminPage");
        }

        [HttpGet]
        public IActionResult EditAnimal(int id)
        {
            var currentAnimal = repository.GetAnimals().First(an=> an.AnimalId == id);
            return View(currentAnimal);
        }

        [HttpPost]
        public IActionResult EditAnimal(int id,Animal animal)
        {
                repository.UpdateAnimal(id,animal);
                return RedirectToAction("AdminPage");
        }

        [HttpGet]
        public IActionResult AddAnimal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
            if (ModelState.IsValid)
            { 
                repository.InsertAnimal(animal);
                return RedirectToAction("AdminPage");
            }
            else
            {
                return View("AddAnimal");
            }
            
        }
    }
}