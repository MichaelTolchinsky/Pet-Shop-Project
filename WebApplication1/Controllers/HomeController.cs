using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        public HomeController(IRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult Index()
        {
            return View(repository.GetAnimals().OrderByDescending(a => a.Comments.Count).Take(2));
        }

    }
}
