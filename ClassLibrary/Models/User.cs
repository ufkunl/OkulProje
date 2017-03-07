using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.Models
{
    class User
    {

        public int ID { get; set; }
        public Faculty Faculty { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Boolean IsDeleted { get; set; }


    }
}
