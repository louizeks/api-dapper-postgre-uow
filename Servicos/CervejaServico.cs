using ExemploDapperPostgreUow.Entidades;
using ExemploDapperPostgreUow.Servicos.Interfaces;
using ExemploDapperPostgreUow.UoW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploDapperPostgreUow.Servicos
{
    public class CervejaServico : ICervejaServico
    {
        readonly IUnitOfWork _unitOfWork;

        public CervejaServico(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Cerveja Alterar(Cerveja cerveja)
        {
            var retorno = _unitOfWork.CervejaRepositorio.Alterar(cerveja);
            _unitOfWork.Commit();
            return cerveja;
        }

        public void Excluir(int idCerveja)
        {
            _unitOfWork.CervejaRepositorio.Excluir(idCerveja);
            _unitOfWork.Commit();
        }

        public Cerveja Incluir(Cerveja cerveja)
        {
             cerveja = _unitOfWork.CervejaRepositorio.Incluir(cerveja);
            _unitOfWork.Commit();

            return cerveja;
        }

        public Cerveja ListarPorId(int idCerveja)
        {
            return _unitOfWork.CervejaRepositorio.ListarPorId(idCerveja);
        }

        public IEnumerable<Cerveja> ListarTodas()
        {
            return _unitOfWork.CervejaRepositorio.ListarTodas();
        }
    }
}
