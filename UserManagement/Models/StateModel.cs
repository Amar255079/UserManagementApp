using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Models
{
    public class StateModel
    {
        public bool Selected { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public int CountryID { get; set; }
    }
}