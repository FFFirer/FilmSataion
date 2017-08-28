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
        IQueryable<Category> Categorys { get; }
    }
}
