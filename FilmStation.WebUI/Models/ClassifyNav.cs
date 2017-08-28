using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmStation.WebUI.Models;
using FilmStation.Domain.Entities;

namespace FilmStation.WebUI.Models
{
    public class ClassifyNav
    {
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<string> Year { get; set; }
        public IEnumerable<string> Area { get; set; }
        public IEnumerable<string> Language { get; set; }
        public IEnumerable<string> Rate { get; set; }
    }
}