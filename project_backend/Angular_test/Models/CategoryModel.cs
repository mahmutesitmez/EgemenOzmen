﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Angular_test.Models
{
    public class CategoryModel
    {
        public string Title { get; set; }
        [DisplayName("Başlık"), Required(ErrorMessage = "{0} boş geçilmez!"), 
            MaxLength(200, ErrorMessage = " En fazla {1} karakter")]
        public string Description { get; set; }
        [DisplayName("Açıklama"), Required(ErrorMessage = "{0} Boş geçilmez"), 
            MinLength(1, ErrorMessage = " En fazla {1} karakter")]
        


        public int Id { get; set; }
        //[Range(10, 100, ErrorMessage = "En az {1} ile {2} arası rakam girilmelidir.")]
        //public int Hit { get; set; }

        //public string Password { get; set; }

        //[Compare("Password", ErrorMessage = "Password tekrarı password ile aynı değil")]
        //public string RePassword { get; set; }
    }
}
