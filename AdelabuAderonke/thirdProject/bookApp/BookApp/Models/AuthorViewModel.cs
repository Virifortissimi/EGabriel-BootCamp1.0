﻿using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class AuthorViewModel
    {
        public long Id {  
            get;  
            set;  
        }  
        [Display(Name = "First Name")]  
        public string FirstName {  
            get;  
            set;  
        }  
        [Display(Name = "Last Name")]  
        public string LastName {  
            get;  
            set;  
        }  
        public string Email {  
            get;  
            set;  
        }
        public string MobileNo
        {
            get;
            set;
        }
        [Display(Name = "Book Name")]  
        public string BookName {  
            get;  
            set;  
        }  
        public string ISBN {  
            get;  
            set;  
        }  
        public string Publisher {  
            get;  
            set;  
        }  
    }
}
