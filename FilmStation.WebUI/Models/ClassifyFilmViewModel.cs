using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmStation.WebUI.Models;
using FilmStation.Domain.Entities;

namespace FilmStation.WebUI.Models
{
    public class ClassifyFilmViewModel
    {
        public ClassifyInfo ClassifyInfo { get; set; }
        public IEnumerable<Film> Films { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}