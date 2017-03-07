using ClassLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace TubitetWebAPI.Controllers
{
    public class FacultyController : ApiController
    {
      
        [HttpPost]
         public int SaveNewFaculty(Faculty faculty)
        {
            return faculty.save();
        }

        public string getAllFaculties()
        {
            return JsonConvert.SerializeObject(new Faculty().getFaculties(""));
        }

    }
}
