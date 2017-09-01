using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmStation.Domain.Entities;
using FilmStation.WebUI.Models;
using FilmStation.Domain.Abstract;
using System.Text.RegularExpressions;

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

        //Film
        //生成列表
        public ActionResult List(string name, string category, string language, string area, string year, int page = 1)
        {

            Category current = new Category();
            if ( !string.IsNullOrEmpty(category) )
            {
                current = repository.Categorys.Where(p => p.EnCateName == category).Distinct().FirstOrDefault();
            }
            ClassifyFilmViewModel viewmodel = new ClassifyFilmViewModel()
            {
                ClassifyInfo = new ClassifyInfo()
                {
                    Category = category,
                    Language = language,
                    Year = year,
                    Area = area,
                    Name = name,
                    Rate = null,
                },
                Films = repository.Films
                .Where(p => (string.IsNullOrEmpty(name) || p.Name.Contains(name)) && (string.IsNullOrEmpty(category)||p.Style.Contains(current.ChCateName)) && (string.IsNullOrEmpty(area) || p.Location.Contains(area)) && (string.IsNullOrEmpty(language) || p.Language.Contains(language)) && (string.IsNullOrEmpty(year) || p.PublishTime.Contains(year)) )
                .OrderBy(p => p.Id)
                .Skip((PageSize * (page - 1)))
                .Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Films.Where(p => (string.IsNullOrEmpty(name) || p.Name.Contains(name)) && (string.IsNullOrEmpty(category) || p.Style.Contains(current.ChCateName)) && (string.IsNullOrEmpty(area) || p.Location.Contains(area)) && (string.IsNullOrEmpty(language) || p.Language.Contains(language)) && (string.IsNullOrEmpty(year) || p.PublishTime.Contains(year))).Count()
                },
                CurrentCategory = category,

            };
            return View(viewmodel);
        }

        public ActionResult Create()
        {
            return View("Edit", new Film());
        }

        public ActionResult Edit(int filmId)
        {
            Film film = repository.Films.FirstOrDefault(p => p.Id == filmId);
            return View(film);
        }

        [HttpPost]
        public ActionResult Edit(Film film)
        {
            if(ModelState.IsValid)
            {
                repository.SaveFilm(film);
                return RedirectToAction("List");
            }
            else
            {
                return View(film);
            }
        }

        public ActionResult Delete(int filmId)
        {
            Film film = repository.Films.Where(p => p.Id == filmId).FirstOrDefault();
            if(film != null)
            {
                repository.DeleteFilm(film);
            }
            return RedirectToAction("List");
        }

        public ActionResult FilterForm()
        {
            ClassifyNav nav = new ClassifyNav()
            {
                Category = repository.Categorys.Distinct().AsEnumerable(),
                Language = repository.LanguageCollections.Select(x => x.Language).Distinct().AsEnumerable(),
                Area = repository.AreaCollections.Select( x => x.Area).Distinct().AsEnumerable(),
                Rate = repository.RateCollections.Select( x => x.Rate).Distinct().AsEnumerable(),
                Year = repository.YearCollections.Select( x => x.Year).Distinct().AsEnumerable(),
            };
            return PartialView(nav);
        }

        //List
        //Create
        //Edit
        //[httpPost]Edit
        //Delete
        
        //Category
        public ActionResult CateList()
        {
            IEnumerable<Category> CategoryList = repository.Categorys.Distinct().OrderBy(p => p.Id).AsEnumerable();
            return View(CategoryList);
        }
        public ActionResult CateCreate()
        {
            return View("CateEdit", new Category());
        }
        public ActionResult CateEdit(int id)
        {
            Category cate = repository.Categorys.Where(p => p.Id == id).FirstOrDefault();
            return View(cate);
        }
        [HttpPost]
        public ActionResult CateEdit(Category catecollection)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCategory(catecollection);
                return RedirectToAction("CateList");
            }
            else
            {
                return View(catecollection);
            }
        }
        public ActionResult CateDelete(int id)
        {
            Category cate = repository.Categorys.Where(p => p.Id == id).FirstOrDefault();
            if (cate != null)
            {
                repository.DeleteCategory(cate);
            }
            return RedirectToAction("CateList");
        }

        //Year
        public ActionResult YearList()
        {
            IEnumerable<YearCollection> YearList = repository.YearCollections.Distinct().OrderBy(p => p.Id).AsEnumerable();
            return View(YearList);
        }
        public ActionResult YearCreate()
        {
            return View("YearEdit", new YearCollection());
        }
        public ActionResult YearEdit( int id)
        {
            YearCollection year = repository.YearCollections.Where(p => p.Id == id).FirstOrDefault();
            return View(year);
        }
        [HttpPost]
        public ActionResult YearEdit(YearCollection yearcollection)
        {
            if(ModelState.IsValid)
            {
                repository.SaveYear(yearcollection);
                return RedirectToAction("YearList");
            }
            else
            {
                return View(yearcollection);
            }
        }
        public ActionResult YearDelete(int id)
        {
            YearCollection year = repository.YearCollections.Where(p => p.Id == id).FirstOrDefault();
            if(year != null)
            {
                repository.DeleteYear(year);
            }
            return RedirectToAction("YearList");
        }

        //Rate
        public ActionResult RateList()
        {
            IEnumerable<RateCollection> RateList = repository.RateCollections.Distinct().OrderBy(p => p.Id).AsEnumerable();
            return View(RateList);
        }
        public ActionResult RateCreate()
        {
            return View("RateEdit", new RateCollection());
        }
        public ActionResult RateEdit(int id)
        {
            RateCollection rate = repository.RateCollections.Where(p => p.Id == id).FirstOrDefault();
            return View(rate);
        }
        [HttpPost]
        public ActionResult RateEdit(RateCollection ratecollection)
        {
            if(ModelState.IsValid)
            {
                repository.SaveRate(ratecollection);
                return RedirectToAction("RateList");
            }
            else
            {
                return View(ratecollection);
            }
        }
        public ActionResult RateDelete(int id)
        {
            RateCollection rate = repository.RateCollections.Where(p => p.Id == id).FirstOrDefault();
            if(rate != null)
            {
                repository.DeleteRate(rate);
            }
            return RedirectToAction("RateList");
        }

        //Area
        public ActionResult AreaList()
        {
            IEnumerable<AreaCollection> AreaList = repository.AreaCollections.Distinct().OrderBy(p => p.Id).AsEnumerable();
            return View(AreaList);
        }
        public ActionResult AreaCreate()
        {
            return View("AreaEdit", new AreaCollection());
        }
        public ActionResult AreaEdit(int id)
        {
            AreaCollection area = repository.AreaCollections.Where(p => p.Id == id).FirstOrDefault();
            return View(area);
        }
        [HttpPost]
        public ActionResult AreaEdit(AreaCollection areacollection)
        {
            if(ModelState.IsValid)
            {
                repository.SaveArea(areacollection);
                return RedirectToAction("AreaList");
            }
            else
            {
                return View(areacollection);
            }
        }
        public ActionResult AreaDelete(int id)
        {
            AreaCollection area = repository.AreaCollections.Where(p => p.Id == id).FirstOrDefault();
            if(area != null)
            {
                repository.DeleteArea(area);
            }
            return RedirectToAction("AreaList");
        }

        //Language
        public ActionResult LanguageList()
        {
            IEnumerable<LanguageCollection> LanguageList = repository.LanguageCollections.Distinct().OrderBy(p => p.Id).AsEnumerable();
            return View(LanguageList);
        }
        public ActionResult LanguageCreate()
        {
            return View("LanguageEdit", new LanguageCollection());
        }
        public ActionResult LanguageEdit(int id)
        {
            LanguageCollection language = repository.LanguageCollections.Where(p => p.Id == id).FirstOrDefault();
            return View(language);
        }
        [HttpPost]
        public ActionResult LanguageEdit(LanguageCollection language)
        {
            if(ModelState.IsValid)
            {
                repository.SaveLanguage(language);
                return RedirectToAction("LanguageList");
            }
            else
            {
                return View(language);
            }
        }
        public ActionResult LanguageDelete(int id)
        {
            LanguageCollection language = repository.LanguageCollections.Where(p => p.Id == id).FirstOrDefault();
            if(language != null)
            {
                repository.DeleteLanguage(language);
            }
            return RedirectToAction("LanguageList");
        }

        //clean Area Year Category Language from film
        public ActionResult GetYear()
        {
            
            return View(GetYearDistinct());
        }

        [HttpPost]
        public ActionResult GetYear(List<YearCollection> years)
        {
            if(ModelState.IsValid)
            {
                foreach (YearCollection y in years)
                {
                    if(y.IsShow == true)
                    {
                        repository.SaveYear(y);
                    }
                    else
                    {
                        continue;
                    }
                }
                return RedirectToAction("YearList");
            }
            else
            {
                return View(years.AsEnumerable());
            }
        }

        public ActionResult GetCate()
        {
            return View(GetCateDistinct());
        }

        [HttpPost]
        public ActionResult GetCate(List<Category> categories)
        {
            if(ModelState.IsValid)
            {
                foreach(Category cate in categories)
                {
                    if(cate.IsShow == true)
                    {
                        repository.SaveCategory(cate);
                    }
                    else
                    {
                        continue;
                    }
                }
                return RedirectToAction("CateList");
            }
            else
            {
                return View(categories.AsEnumerable());
            }
        }

        public ActionResult GetArea()
        {
            return View(GetAreaDistinct());
        }

        [HttpPost]
        public ActionResult GetArea(List<AreaCollection> areas)
        {
            if (ModelState.IsValid)
            {
                foreach (AreaCollection area in areas)
                {
                    if(area.IsShow == true)
                    {
                        repository.SaveArea(area);
                    }
                    else
                    {
                        continue;
                    }
                }
                return RedirectToAction("AreaList");
            }
            else
            {
                return View(areas.AsEnumerable());
            }
        }

        public ActionResult GetLanguage()
        {
            return View(GetLanguageDistinct());
        }

        [HttpPost]
        public ActionResult GetLanguage(List<LanguageCollection> languages)
        {
            if(ModelState.IsValid)
            {
                foreach(LanguageCollection lang in languages)
                {
                    if(lang.IsShow == true)
                    {
                        repository.SaveLanguage(lang);
                    }
                    else
                    {
                        continue;
                    }
                }
                return RedirectToAction("LanguageList");
            }
            else
            {
                return View(languages.AsEnumerable());
            }
        }

        public IEnumerable<YearCollection> GetYearDistinct()
        {
            List<string> Years = new List<string>();
            List<string> PublishTime = repository.Films.Select(x => x.PublishTime).ToList();
            foreach (string year in PublishTime)
            {
                if (year != "null")
                {
                    string[] spilt = year.Split('/');
                    foreach (string i in spilt)
                    {
                        string x = i.Trim();
                        if (Regex.IsMatch(x, @"^\d\d\d\d"))
                        {
                            x = x.Substring(0, 4);
                            Years.Add(x);
                        }
                        else
                        {
                            continue;
                        }
                    }

                }
                else
                {
                    continue;
                }
            }
            IEnumerable<string> res = Years.OrderBy(p => p).Distinct();
            List<YearCollection> YearList = new List<YearCollection>();
            foreach (string r in res)
            {
                YearCollection cate = new YearCollection()
                {
                    Year = r,
                    Amount = repository.Films.Where(p => p.PublishTime.Contains(r)).Count(),
                };
                YearList.Add(cate);
            }

            return YearList.AsEnumerable();
        }

        public IEnumerable<Category> GetCateDistinct()
        {
            List<string> Category = new List<string>();
            List<string> catelist = repository.Films.Select(p => p.Style).ToList();
            foreach (string eachcate in catelist)
            {
                if (eachcate != "null")
                {
                    string[] cates = eachcate.Split('/');
                    foreach (string cate in cates)
                    {
                        Category.Add(cate.Trim());
                    }
                }
                else
                {
                    continue;
                }
            }

            IEnumerable<string> res = Category.OrderBy(p => p).Distinct();
            List<Category> CateList = new List<Category>();
            foreach(string r in res)
            {
                Category cate = new Category()
                {
                    ChCateName = r,
                    Amount = repository.Films.Where(p => p.Style.Contains(r)).Count(),
                };
                CateList.Add(cate);
            }
            return CateList.AsEnumerable();
        }

        public IEnumerable<AreaCollection> GetAreaDistinct()
        {
            List<string> Area = new List<string>();
            List<string> arealist = repository.Films.Select(p => p.Location).ToList();
            foreach (string eacharea in arealist)
            {
                if (eacharea != "null")
                {
                    string[] areas = eacharea.Split('/');
                    foreach (string area in areas)
                    {
                        Area.Add(area.Trim());
                    }
                }
                else
                {
                    continue;
                }
            }
            IEnumerable<string> res = Area.OrderBy(p => p).Distinct();
            List<AreaCollection> AreaList = new List<AreaCollection>();
            foreach(string r in res)
            {
                AreaCollection area = new AreaCollection()
                {
                    Area = r,
                    Amount = repository.Films.Where(p => p.Location.Contains(r)).Count()
                };
                AreaList.Add(area);
            }
            return AreaList.AsEnumerable();
        }

        public IEnumerable<LanguageCollection> GetLanguageDistinct()
        {
            List<string> languages = new List<string>();
            List<string> languageList = repository.Films.Select(p => p.Language).ToList();
            foreach (string lan in languageList)
            {
                if (lan != "null")
                {
                    string[] spls = lan.Split('/');
                    foreach (string spl in spls)
                    {
                        languages.Add(spl.Trim());
                    }
                }
            }
            IEnumerable<string> res = languages.OrderBy(p => p).Distinct();
            List<LanguageCollection> LangList = new List<LanguageCollection>();
            foreach(string r in res)
            {
                LanguageCollection lang = new LanguageCollection()
                {
                    Language = r,
                    Amount = repository.Films.Where(p => p.Language.Contains(r)).Count()
                };
                LangList.Add(lang);
            }
            return LangList.AsEnumerable();
        }

        public string IsNull(string keyword)
        {
            if(keyword == null || keyword == "0" || keyword == "")
            {
                return null;
            }
            else
            {
                return keyword;
            }
        }

        public bool IsEqualNull(string keyword)
        {
            if(keyword == null || keyword == "0" || keyword == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}