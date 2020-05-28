using prmToolkit.NotificationPattern;
using SisRem.Domain.Interfaces.Repositories;
using SisRem.Domain.Interfaces.Services;
using SisRem.Domain.Arguments.Log.Campos.Request;

namespace SisRem.Domain.Services
{
    public class LogAplicacaoCampoService : Notifiable, LogAplicacaoCampoIService
    {

        private readonly LogAplicacaoCampoIRepository _repositoryLogAplicacaoCampo;
        private readonly UsuarioIRepository _repositoryUsuario;
        public LogAplicacaoCampoService()
        {

        }
        public LogAplicacaoCampoService(LogAplicacaoCampoIRepository repositoryLogAplicacaoCampo, UsuarioIRepository repositoryUsuario)
        {
            _repositoryLogAplicacaoCampo = repositoryLogAplicacaoCampo;
            _repositoryUsuario = repositoryUsuario;
        }

        public void Criar(AdicionarRequest request)
        {

            //Usuario usuario = _repositoryUsuario.ObterPor(x => x.Email.Endereco == request.UsuarioLogado);
            //LogAplicacao logAplicacao = new LogAplicacao
            //{
            //    DsEvento = request.Messagem
            //                                             ,
            //    ValorEvento = request.Valor
            //                                             ,
            //    IdTabela = request.IdTabela
            //                                             ,
            //    DtEvento = DateTime.Now
            //                                             ,
            //    UsuarioEvento = usuario
            //};

            //_repositoryLogAplicacao.Adicionar(logAplicacao);

        }


    }
}
