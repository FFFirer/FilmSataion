using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FilmStation.Domain.Entities
{
    public class LanguageCollection
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "please enter something")]
        [StringLength(50, ErrorMessage = "please enter string shorter than 50")]
        public string Language { get; set; }

        public int Amount { get; set; }
        public bool IsShow { get; set; }
    }
}
