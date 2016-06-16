using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class LoginViewModel
    {
        const string cardNumberLengthMessage = "The card number is a 16 digit number";
        public LoginViewModel()
        {
        }

        public LoginViewModel(string messages)
        {
            this.Messages = messages;
        }        
        public long CardNumber { get; set; }
        public int Password { get; set; }
        public string Messages { get; set; }
    }
}