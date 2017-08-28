using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmStation.Domain.Entities;

namespace FilmStation.WebUI.Models
{
    public class FilmViewModel
    {
        public IEnumerable<Film> Films { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}