﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GR.Web.Models
{
    public class BookViewModel
    {
        [Display(Name = "Book Name")]
        public string BookName
        {
            get;
            set;
        }
        public string ISBN
        {
            get;
            set;
        }
        public string Publisher
        {
            get;
            set;
        }
    }
}
