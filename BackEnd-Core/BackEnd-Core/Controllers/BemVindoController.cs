using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BemVindoController : ControllerBase
    {
        // GET: api/<BemVindoController>
        [HttpGet]
        public string Get()
        {
            return "Bem Vindo";
        }

    }
}
