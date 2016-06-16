using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Common.Authentication
{
    public class CustomIdentity : System.Security.Principal.IIdentity
    {
        public CustomIdentity(string name)
        {
            this.Name = name;
        }

        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { return !string.IsNullOrEmpty(this.Name); }
        }

        public string Name { get; private set; }
    }
}