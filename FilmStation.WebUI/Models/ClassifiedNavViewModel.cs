using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmStation.Domain.Entities;

namespace FilmStation.WebUI.Models
{
    public class ClassifiedNavViewModel
    {
        public ClassifyInfo ClassifyInfo { get; set; }
        public IEnumerable<YearCollection> Years { get; set; }
        public IEnumerable<AreaCollection> Areas { get; set; }
        public IEnumerable<LanguageCollection> Languages { get; set; }
    }
}