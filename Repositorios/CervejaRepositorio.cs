using Dapper;
using ExemploDapperPostgreUow.Entidades;
using ExemploDapperPostgreUow.Repositorios.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExemploDapperPostgreUow.Repositorios
{
    public class CervejaRepositorio : RepositorioBase, ICervejaRepositorio
    {
        public CervejaRepositorio(NpgsqlTransaction transacao)
            : base(transacao)
        { }

        public Cerveja Alterar(Cerveja cerveja)
        {
            var sql = @"Update cervejas set ABV= @abv, Cervejaria=@cervejaria, CopoIdeal = @copoIdeal, Estilo=@estilo, Nome=@nome";
            if (Conexao.Execute(sql, cerveja) <= 0)
            {
                throw new Exception("Não foi possível alterar a Cerveja.");
            }

            return cerveja;
        }

        public void Excluir(int idCerveja)
        {
            Conexao.Execute(@"delete from cervejas where id = @id", new { id = idCerveja });
        }

        public Cerveja Incluir(Cerveja cerveja)
        {
            var sql = @"INSERT INTO cervejas(ABV, Cervejaria, CopoIdeal, Estilo, Nome) VALUES (@abv, @cervejaria, @copoIdeal, @estilo, @nome) RETURNING id";
            cerveja.Id  = Conexao.ExecuteScalar<int>(sql, cerveja);
          
            return cerveja;
        }

        public Cerveja ListarPorId(int idCerveja)
        {
            return Conexao.Query<Cerveja>(@"select * from cervejas where id = @id",
                new { id = idCerveja }).FirstOrDefault();
        }

        public IEnumerable<Cerveja> ListarTodas()
        {
            return Conexao.Query<Cerveja>(@"select * from cervejas");           
        }
    }
}
