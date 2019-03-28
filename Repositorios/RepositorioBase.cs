using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploDapperPostgreUow.Repositorios
{
    public abstract class RepositorioBase
    {
        protected NpgsqlTransaction Transacao { get; private set; }
        protected NpgsqlConnection Conexao { get { return Transacao.Connection; } }
       
        public RepositorioBase(NpgsqlTransaction transacao)
        {
            Transacao = transacao;
        }
    }
}
