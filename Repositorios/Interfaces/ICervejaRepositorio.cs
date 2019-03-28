using ExemploDapperPostgreUow.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploDapperPostgreUow.Repositorios.Interfaces
{
    public interface ICervejaRepositorio
    {
        Cerveja Incluir(Cerveja cerveja);

        Cerveja Alterar(Cerveja cerveja);

        void Excluir(int idCerveja);

        IEnumerable<Cerveja> ListarTodas();

        Cerveja ListarPorId(int idCerveja);
    }
}
