using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd_Core.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        SaContext _context;

        public AdminController(SaContext context)
        {
            _context = context;
        }
        // GET: api/<AdminController>
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var admin = from adm in _context.Adms
                        select new { adm.Nome, adm.SenhaOld };

            return admin;
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminController>
        [HttpPost]
        public dynamic Post([FromBody] Adms value)
        {
            
            var login = _context.Adms.FirstOrDefault(x => x.Nome == value.Nome && x.SenhaOld == value.SenhaOld);

            if (login == null)
            {
                return "Wrong Login!";
            }
            else
            {
                return true;
            }
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public dynamic Put(int id, [FromBody] Adms value)
        {
            Adms alterar = _context.Adms.Find(id);
            

            var verifyAccount = _context.Adms.FirstOrDefault(x => x.Nome == value.Nome && x.SenhaOld == value.SenhaOld);

            if (verifyAccount != null)
            {
                alterar.SenhaOld = value.SenhaNew;
                _context.SaveChanges();
                return "Salvo";
            }
            return "senhas incorretas!";
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
