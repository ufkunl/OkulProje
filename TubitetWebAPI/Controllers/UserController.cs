using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace TubitetWebAPI.Controllers
{
    public class UserController : ApiController
    {


        public int saveNewUser(User user)
        {

            int eklenenuser = user.save();

            return eklenenuser;

        }





    }
}
