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
    public class FilmController : Controller
    {
        public int PageSize = 24;

        private IFilmRepository repository;

        public FilmController(IFilmRepository filmRepo)
        {
             repository = filmRepo;
        }

        public ActionResult List(string category, string year, string area, string language , int page = 1)
        {
            Category CurrentCategory = new Category();
            if(category != null)
            {
                CurrentCategory = repository.Categorys.Where(p => p.EnCateName == category).Distinct().FirstOrDefault();
            }
            FilmViewModel viewModel = new FilmViewModel
            {
                Films = repository.Films
                .Where(p => (category == null || p.Style.Contains(CurrentCategory.ChCateName)) && (string.IsNullOrEmpty(year) || p.PublishTime.Contains(year)) && (string.IsNullOrEmpty(area) || p.Location.Contains(area)) && (string.IsNullOrEmpty(language) || p.Language.Contains(language)) )
                .OrderBy(x => x.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    CurrentPage = page,
                    TotalItems = repository.Films.Where(p => (string.IsNullOrEmpty(category) || p.Style.Contains(CurrentCategory.ChCateName)) && (string.IsNullOrEmpty(year) || p.PublishTime.Contains(year)) && (string.IsNullOrEmpty(area) || p.Location.Contains(area)) && (string.IsNullOrEmpty(language) || p.Language.Contains(language)) ).Count(),
                },
                ClassifyInfo = new ClassifyInfo
                {
                    Name = null,
                    Category = category,
                    Year = year,
                    Area = area,
                    Language = language,
                    Rate = null,
                },
                CurrentCategory = CurrentCategory.EnCateName
            };

            return View(viewModel);
        }

        //public ActionResult List(ClassifyInfo classInfo, int page = 1)
        //{
        //    ClassifyFilmViewModel viewModel = new ClassifyFilmViewModel
        //    {
        //        ClassifyInfo = classInfo,
        //        Films 
        //    }
        //}

        [HttpPost]
        public ActionResult Search(string keyvalue, int page = 1)
        {
            Session["SearchKey"] = keyvalue;
            SearchResultViewModel viewModel = new SearchResultViewModel
            {
                Films = repository.Films
                .Where(p => p.Name.Contains(keyvalue))
                .OrderBy(x => x.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    TotalItems = repository.Films.Where(p => p.Name.Contains(keyvalue)).Count(),
                    ItemsPerPage = PageSize,
                    CurrentPage = page,
                },
                KeyValue = keyvalue
            };
            return View(viewModel);
        }

        public ActionResult SearchResult(int page)
        {
            string keyvalue = (string)Session["SearchKey"];
            if(keyvalue == null)
            {
                return RedirectToAction("List");
            }
            SearchResultViewModel viewModel = new SearchResultViewModel
            {
                Films = repository.Films
                .Where(p => p.Name.Contains(keyvalue))
                .OrderBy(x => x.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    TotalItems = repository.Films.Where(p => p.Name.Contains(keyvalue)).Count(),
                    ItemsPerPage = PageSize,
                    CurrentPage = page,
                },
                KeyValue = keyvalue
            };

            return View("Search", viewModel);
        }

        public ActionResult Detail(int id)
        {
            Film film = repository.Films.Where(p => p.Id == id).FirstOrDefault();
            return View(film);
        }

        public ActionResult ClassifiedNav(ClassifyInfo classInfo)
        {
            ClassifiedNavViewModel viewmodel = new ClassifiedNavViewModel
            {
                ClassifyInfo = classInfo,
                Areas = repository.AreaCollections.Distinct().Where(p => p.IsShow == true).AsEnumerable(),
                Languages = repository.LanguageCollections.Distinct().Where(p => p.IsShow == true).AsEnumerable(),
                Years = repository.YearCollections.Distinct().Where(p => p.IsShow == true).AsEnumerable(),
            };
            return PartialView(viewmodel);
        }
    }
}