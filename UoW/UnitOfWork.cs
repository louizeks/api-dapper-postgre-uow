using ExemploDapperPostgreUow.Repositorios;
using ExemploDapperPostgreUow.Repositorios.Interfaces;
using ExemploDapperPostgreUow.UoW.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploDapperPostgreUow.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private IConfiguration _configuracoes;
        private NpgsqlConnection _conexao;
        private NpgsqlTransaction _transacao;
        private ICervejaRepositorio _cervejaRepositorio;
        private bool _disposed;

        public UnitOfWork(IConfiguration configuracoes)
        {
            _configuracoes = configuracoes;
            _conexao = new NpgsqlConnection(
                _configuracoes.GetConnectionString("BaseCerveja"));

            _conexao.Open();
            _transacao = _conexao.BeginTransaction();
            
        }

        public ICervejaRepositorio CervejaRepositorio
        {
            get { return _cervejaRepositorio ??( _cervejaRepositorio = new CervejaRepositorio(_transacao)); }
        }

        public void Commit()
        {
            try
            {
                _transacao.Commit();
            }
            catch
            {
                _transacao.Rollback();
                throw;
            }
            finally
            {
                _transacao.Dispose();
                _transacao = _conexao.BeginTransaction();
                resetarRepositorios();
            }
        }

        private void resetarRepositorios()
        {
            _cervejaRepositorio = null;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transacao != null)
                    {
                        _transacao.Dispose();
                        _transacao = null;
                    }
                    if (_conexao != null)
                    {
                        _conexao.Dispose();
                        _conexao = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
