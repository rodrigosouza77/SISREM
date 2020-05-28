using prmToolkit.NotificationPattern;
using SisRem.Domain.Arguments.Log.Aplicacao.Request;
using SisRem.Domain.Entities;
using SisRem.Domain.Entities.Log;
using SisRem.Domain.Interfaces.Repositories;
using SisRem.Domain.Interfaces.Services;
using System;

namespace SisRem.Domain.Services
{
    public class LogAplicacaoService : Notifiable, LogAplicacaoIService
    {

        private readonly LogAplicacaoIRepository _repositoryLogAplicacao;
        private readonly UsuarioIRepository _repositoryUsuario;
        public LogAplicacaoService()
        {

        }
        public LogAplicacaoService(LogAplicacaoIRepository repositoryLogAplicacao, UsuarioIRepository repositoryUsuario)
        {
            _repositoryLogAplicacao = repositoryLogAplicacao;
            _repositoryUsuario = repositoryUsuario;
        }

        public void Criar(AdicionarRequest request)
        {

            Usuario usuario = _repositoryUsuario.ObterPor(x => x.Email.Endereco == request.UsuarioLogado);
            LogAplicacao logAplicacao = new LogAplicacao { DsEvento = request.Messagem
                                                         , ValorEvento = request.Valor
                                                         , IdTabela = request.IdTabela
                                                         , DtEvento = DateTime.Now
                                                         , UsuarioEvento = usuario };

            _repositoryLogAplicacao.Adicionar(logAplicacao);

        }


    }
}
