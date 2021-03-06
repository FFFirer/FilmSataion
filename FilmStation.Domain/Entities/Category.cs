﻿using System;
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

        [Required(ErrorMessage = "please enter something")]
        [StringLength(50, ErrorMessage = "string should shorter than 50")]
        public string ChCateName { get; set; }

        [Required(ErrorMessage = "please enter something")]
        [StringLength(50, ErrorMessage = "string should shorter than 50")]
        public string EnCateName { get; set; }

        public int Amount { get; set; }
        public bool IsShow { get; set; }
    }
}
