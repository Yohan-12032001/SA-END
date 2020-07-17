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
    public class AgendamentoController : ControllerBase
    {
        SaContext _context;

        public AgendamentoController(SaContext context)
        {
            _context = context;
        }
        // GET: api/<AgendamentoController>
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            
            var datas = from agend in _context.Agendamentos
            select new { agend.Id,agend.Cpf, agend.Hora,agend.Telefone, agend.Data.Day,agend.Data.Month,agend.Data.Year, agend.Nome };

            
            Console.WriteLine(datas);
            return datas;
        }

        // GET api/<AgendamentoController>/5
        [HttpGet("{id}")]
        public dynamic Get(string cpf)
        {
            var datas = from agend in _context.Agendamentos
            select new { agend.Id, agend.Cpf, agend.Hora, agend.Telefone, agend.Data.Day, agend.Data.Month, agend.Data.Year, agend.Nome };


            Console.WriteLine(datas);
            return datas;
        }

        // POST api/<AgendamentoController>
        [HttpPost]
        public string Post([FromBody] Agendamentos agend)
        {
            var agendamentos = _context.Agendamentos.ToList();
            bool ExisteAgendamentoDia = agendamentos.Any(x => x.Data == agend.Data);
            var horaMin = new TimeSpan(10, 0, 0);
            var horaMax = new TimeSpan(18, 0, 0);

            var horarioConsulta = TimeSpan.Parse(agend.Hora);
            


            if (horarioConsulta > horaMax || horarioConsulta < horaMin)
            {
                
                return "Horario Informado Invalido";
            }
            //_context.Agendamento2.Sql.Contains(agend.Cpf) || ExisteAgendamentoDia
            if (ExisteAgendamentoDia)
            {

                return "Você Já tem um horario marcado!";
            }

            _context.Agendamentos.Add(agend);
            _context.SaveChanges();
            return "Agendado com Sucesso";
        }

        // PUT api/<AgendamentoController>/5
        [HttpPut("{id}")]
        public dynamic Put(int id, [FromBody] Agendamentos agend)
        {
            Agendamentos alterar = _context.Agendamentos.Find(id);

            var agendamentos = _context.Agendamentos.ToList();
            bool ExisteAgendamentoDia = agendamentos.Any(x => x.Data == agend.Data);
            var horaMin = new TimeSpan(10, 0, 0);
            var horaMax = new TimeSpan(18, 0, 0);

            var horarioConsulta = TimeSpan.Parse(agend.Hora);

            if (horarioConsulta > horaMax || horarioConsulta < horaMin)
            {
                return "Horario invalido";
            }

            if (ExisteAgendamentoDia)
            {
                return "Já existe uma consulta neste horario";
            }

            //_context.Agendamento2.Sql.Contains(agend.Cpf) || ExisteAgendamentoDia
            if (ExisteAgendamentoDia)
            {

                return "Você Já tem um horario marcado!";
            }

            if (agend.Data == null || agend.Cpf == "" || agend.Hora == null || agend.Telefone == "" || agend.Nome == "")
            {
                return "ta errado isso ae";
            }

            alterar.Nome = agend.Nome;
            alterar.Data = agend.Data;
            alterar.Hora = agend.Hora;
            alterar.Telefone = agend.Telefone;
            alterar.Cpf = agend.Cpf;
            _context.SaveChanges();
            return "Reagendado com Sucesso";
        }
    

        // DELETE api/<AgendamentoController>/5
        [HttpDelete("{id}")]
        public dynamic Delete(int id)
        {
            _context.Agendamentos.Remove(_context.Agendamentos.Find(id));
            _context.SaveChanges();
            return "Deletado com Sucesso";
    }
    }
}
