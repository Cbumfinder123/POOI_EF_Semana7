using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagement.Models
{
    public class Employee
    {
        public int employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string departament { get; set; }
        public string extension { get; set; } 
        public string email_address { get; set; }
        public string other_details { get; set; }
    }
}
