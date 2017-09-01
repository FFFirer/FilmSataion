using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmStation.Domain.Entities;

namespace FilmStation.Domain.Abstract
{
    public interface IFilmRepository
    {
        IQueryable<Film> Films { get; }
        void SaveFilm(Film film);
        void DeleteFilm(Film film);

        IQueryable<Category> Categorys { get; }
        void SaveCategory(Category category);
        void DeleteCategory(Category category);

        IQueryable<RateCollection> RateCollections { get; }
        void SaveRate(RateCollection rate);
        void DeleteRate(RateCollection rate);

        IQueryable<YearCollection> YearCollections { get; }
        void SaveYear(YearCollection year);
        void DeleteYear(YearCollection year);

        IQueryable<AreaCollection> AreaCollections { get; }
        void SaveArea(AreaCollection area);
        void DeleteArea(AreaCollection area);

        IQueryable<LanguageCollection> LanguageCollections { get; }
        void SaveLanguage(LanguageCollection language);
        void DeleteLanguage(LanguageCollection language);
    }
}
