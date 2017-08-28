using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmStation.Domain.Abstract;
using FilmStation.Domain.Entities;
using FilmStation.WebUI.Models;

namespace FilmStation.WebUI.Controllers
{
    public class NavController : Controller
    {

        private IFilmRepository repository;
        public NavController(IFilmRepository FilmRepo)
        {
            repository = FilmRepo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectCategory = category;
            IEnumerable<Category> Categories = repository.Categorys.Distinct().AsEnumerable();
            return PartialView(Categories);
        }
    }
}