using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using FilmStation.Domain.Entities;

namespace FilmStation.Domain.Concrete
{
    public class EFFilmContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Category> Categorys { get; set; }
    }
}
