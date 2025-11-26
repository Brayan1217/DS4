using Laboratorio19.Models.WS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Laboratorio19.Controllers
{
    public class AccessController : ApiController
    {


        [HttpGet]
        public Reply HelloWorld()
        {
            Reply oR = new Reply();
            oR.result = 1;
            oR.message = "Mi Hello World en API";

            return oR;
        }
    }
}
