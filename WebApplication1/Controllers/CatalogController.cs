using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Reposotories;

namespace WebApplication1.Controllers
{
    public class CatalogController : Controller
    {
        private IRepository repository;
        public CatalogController(IRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult CatalogPage(int id = 1)
        {
            return View(repository.GetAnimals().Where(anm => anm.CategoryId == id));
        }

        public IActionResult DetailPage(int id)
        {
            var animal = repository.GetAnimals().First(an => an.AnimalId == id);
            DetailViewModel model = new DetailViewModel();
            model.Animal = animal;
            model.AnimalCategory = repository.GetAnimalCategoty(animal.CategoryId);
            model.AnimalComments = animal.Comments;
            return View(model);
        }

        [HttpPost]
        public IActionResult DetailPage(int Animal, string CommentMessage)
        {
            var animal = repository.GetAnimals().First(an => an.AnimalId == Animal);
            animal.Comments.Add(new Comment() { CommentMessage = CommentMessage });
            repository.SaveComment();
            return RedirectToAction("CatalogPage");
        }
    }
}