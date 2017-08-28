using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmStation.Domain.Entities;
using FilmStation.WebUI.Models;
using FilmStation.Domain.Abstract;

namespace FilmStation.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IFilmRepository repository;

        int PageSize = 20;

        public AdminController(IFilmRepository repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //生成列表
        public ActionResult List(string category, int page = 1)
        {
            Category current = new Category();
            if (category != null)
            {
                current = repository.Categorys.Where(p => p.EnCateName == category).Distinct().FirstOrDefault();
            }
            ClassifyFilmViewModel viewmodel = new ClassifyFilmViewModel()
            {
                ClassifyInfo = new ClassifyInfo()
                {
                    Category = category == null ? null : category,
                    Language = null,
                    Year = null,
                    Area = null,
                    Rate = null,
                },
                Films = repository.Films
                .Where(p => category == null || p.Style.Contains(current.ChCateName))
                .OrderBy(p => p.Id)
                .Skip((PageSize * (page - 1)))
                .Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Films
                        .Where(p => category == null || p.Style.Contains(current.ChCateName))
                        .Count()
                },
                CurrentCategory = category

            };
            return View(viewmodel);
        }

        public ActionResult FilterForm()
        {
            ClassifyNav nav = new ClassifyNav()
            {
                Category = repository.Categorys.Distinct().AsEnumerable(),
                Language = null,
                Area = null,
                Rate = null,
                Year = null,
            };
            return PartialView(nav);
        }

        ////创建
        //public ActionResult Create()
        //{
        //    return View()
        //}

        ////编辑
        //public ActionResult Edit()
        //{
        //    return View();
        //}

        ////post提交
        //[HttpPost]
        //public ActionResult Edit() 
        //{
        //    return View();
        //}

        ////删除
        //public ActionResult Delete()
        //{
        //    return View();
        //}
    }
}