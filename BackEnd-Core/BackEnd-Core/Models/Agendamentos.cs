using System;
using System.Collections.Generic;

namespace BackEnd_Core.Models
{
    public partial class Agendamentos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
    }
}
