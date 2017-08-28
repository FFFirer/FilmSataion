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

        public ActionResult List(string category, int page = 1)
        {
            Category CurrentCategory = new Category();
            if(category != null)
            {
                CurrentCategory = repository.Categorys.Where(p => p.EnCateName == category).Distinct().FirstOrDefault();
            }
            FilmViewModel viewModel = new FilmViewModel
            {
                Films = repository.Films
                .Where(p => category == null || p.Style.Contains(CurrentCategory.ChCateName))
                .OrderBy(x => x.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    CurrentPage = page,
                    TotalItems = category == null ?
                        repository.Films.Count() :
                        repository.Films.Where(p => p.Style.Contains(CurrentCategory.ChCateName)).Count(),
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

        
    }
}