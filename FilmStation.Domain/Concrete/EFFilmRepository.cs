using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmStation.Domain.Abstract;
using FilmStation.Domain.Entities;
 
namespace FilmStation.Domain.Concrete
{
    public class EFFilmRepository : IFilmRepository
    {
        private EFFilmContext context = new EFFilmContext();

        public IQueryable<Film> Films
        {
            get
            {
                return context.Films;
            }
        }

        public IQueryable<Category> Categorys
        {
            get
            {
                return context.Categorys;
            }
        }
    }
}
