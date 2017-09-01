using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FilmStation.Domain.Entities
{
    public class YearCollection
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "please enter a year")]
        [RegularExpression(@"\d\d\d\d", ErrorMessage = "please enter a right year")]
        public string Year { get; set; }
        public int Amount { get; set; }
        public bool IsShow { get; set; }
    }
}
