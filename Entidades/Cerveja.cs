using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploDapperPostgreUow.Entidades
{
    public class Cerveja
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cervejaria { get; set; }
        public string Estilo { get; set; }
        public decimal ABV { get; set; }
        public string CopoIdeal { get; set; }
    }
}
