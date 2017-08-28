using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FilmStation.Domain.Entities
{   
    [Table("Categorys")]
    public class Category
    {
        public int Id { get; set; }
        public string ChCateName { get; set; }
        public string EnCateName { get; set; }
    }
}
