using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Data.Entity;

namespace FilmStation.Domain.Entities
{
    [Table("filmdetail")]
    public class Film
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string PostId { get; set; }
        public string Name { get; set; }
        public string Direct { get; set; }
        public string ScreenWriter { get; set; }
        public string MainPerformer { get; set; }
        public string Style { get; set; }
        public string OfficalWebSite { get; set; }
        public string Location { get; set; }
        public string Language { get; set; }
        public string PublishTime { get; set; }
        public string TimeLength { get; set; }
        public string OtherName { get; set; }
        public string IMDblink { get; set; }
        public string ImageName { get; set; }
    }
}
