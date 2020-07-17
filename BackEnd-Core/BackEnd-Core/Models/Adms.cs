using System;
using System.Collections.Generic;

namespace BackEnd_Core.Models
{
    public partial class Adms
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SenhaOld { get; set; }
        public string SenhaNew { get; set; }
    }
}
