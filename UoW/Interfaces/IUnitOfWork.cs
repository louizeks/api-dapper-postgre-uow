using ExemploDapperPostgreUow.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploDapperPostgreUow.UoW.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICervejaRepositorio CervejaRepositorio { get; }
        void Commit();
    }
}
