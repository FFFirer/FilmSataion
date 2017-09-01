using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmStation.Domain.Abstract;
using FilmStation.Domain.Entities;
using System.Data;
using System.Data.Entity;
 
namespace FilmStation.Domain.Concrete
{
    public class EFFilmRepository : IFilmRepository
    {
        private EFFilmContext context = new EFFilmContext();
        //电影
        public IQueryable<Film> Films
        {
            get
            {
                return context.Films;
            }
        }
        public void SaveFilm(Film film)
        {
            if(film.Id == 0)
            {
                context.Films.Add(film);
            }
            else
            {
                context.Entry(film).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public void DeleteFilm(Film film)
        {
            context.Films.Remove(film);
            context.SaveChanges();
        }
        //类别
        public IQueryable<Category> Categorys
        {
            get
            {
                return context.Categorys;
            }
        }
        public void SaveCategory(Category category)
        {
            if(category.Id == 0)
            {
                context.Categorys.Add(category);
            }
            else
            {
                context.Entry(category).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public void DeleteCategory(Category category)
        {
            context.Categorys.Remove(category);
            context.SaveChanges();
        }
        //地区
        public IQueryable<AreaCollection> AreaCollections
        {
            get
            {
                return context.AreaCollections;
            }
        }
        public void SaveArea(AreaCollection area)
        {
            if(area.Id == 0)
            {
                context.AreaCollections.Add(area);
            }
            else
            {
                context.Entry(area).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public void DeleteArea(AreaCollection area)
        {
            context.AreaCollections.Remove(area);
            context.SaveChanges();
        }
        //评分排名
        public IQueryable<RateCollection> RateCollections
        {
            get
            {
                return context.RateCollections;
            }
        }
        public void SaveRate(RateCollection rate)
        {
            if(rate.Id == 0)
            {
                context.RateCollections.Add(rate);
            }
            else
            {
                context.Entry(rate).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public void DeleteRate(RateCollection rate)
        {
            context.RateCollections.Remove(rate);
            context.SaveChanges();
        }
        //年份
        public IQueryable<YearCollection> YearCollections
        {
            get
            {
                return context.YearCollections;
            }
        }
        public void SaveYear(YearCollection year)
        {
            if(year.Id == 0)
            {
                context.YearCollections.Add(year);
            }
            else
            {
                context.Entry(year).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public void DeleteYear(YearCollection year)
        {
            context.YearCollections.Remove(year);
            context.SaveChanges();
        }
        //语言
        public IQueryable<LanguageCollection> LanguageCollections
        {
            get
            {
                return context.LanguageCollections;
            }
        }
        public void SaveLanguage(LanguageCollection language)
        {
            if(language.Id == 0)
            {
                context.LanguageCollections.Add(language);
            }
            else
            {
                context.Entry(language).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public void DeleteLanguage(LanguageCollection language)
        {
            context.LanguageCollections.Remove(language);
            context.SaveChanges();
        }
    }
}
