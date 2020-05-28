using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using SisRem.Domain.Arguments.Usuario;
using SisRem.Domain.Entities;
using SisRem.Domain.Interfaces.Repositories;
using SisRem.Domain.Interfaces.Services;
using SisRem.Domain.Resources;
using SisRem.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using SisRem.Domain.Arguments.Base;
using SisRem.Domain.Arguments.Usuario.Response;
using SisRem.Domain.Arguments.Usuario.Request;
using SisRem.Domain.Extensions;


namespace SisRem.Domain.Services
{
    public class UsuarioService : Notifiable, UsuarioIService
    {
        private readonly UsuarioIRepository _repositoryUsuario;
        public UsuarioService()
        {

        }
        public UsuarioService(UsuarioIRepository repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public AdicionarResponse Adicionar(AdicionarRequest request)
        {
            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);
            var usuarioLogado = new Email(request.UsuarioLogado);

            Usuario usuario = new Usuario(nome, email, request.Senha);

            AddNotifications(nome, email, usuarioLogado);

            if (!Extension.VerificarPropriedadesNaoNulasOuVazias(request))
            {
                AddNotification("Campos Vazios", Message.CAMPOS_VAZIOS);
            }

            if (_repositoryUsuario.Existe(x=>x.Email.Endereco == request.Email))
            {
                AddNotification("E-mail", Message.JA_EXISTE_UM_X0_CHAMADO_X1.ToFormat("e-mail", request.Email));
            }

            if (this.IsInvalid())
            {
                return null;
            }

            usuario = _repositoryUsuario.Adicionar(usuario);
            usuario.Id = _repositoryUsuario.Listar().ToList().Select(Usuario => (UsuarioResponse)usuario).ToList().Select(x => x.Id).Count() + 1;

            return (AdicionarResponse)usuario;
        }

        public AlterarResponse Alterar(AlterarRequest request)
        {
            if (request == null)
            {
                AddNotification("AlterarUsuarioRequest", Message.X0_E_OBRIGATORIO.ToFormat("AlterarUsuarioRequest"));
            }

            Usuario Usuario = _repositoryUsuario.ObterPorId(request.Id);

            if (Usuario == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            //var email = new Email(request.Email);
            
            Usuario.AlterarUsuario(nome, Usuario.Status);

            AddNotifications(Usuario);

            if (IsInvalid())
            {
                return null;
            }

            _repositoryUsuario.Editar(Usuario);

            return (AlterarResponse)Usuario;
        }

        public AutenticarResponse Autenticar(AutenticarRequest request)
        {
            if (request == null)
            {
                AddNotification("AutenticarUsuarioRequest", Message.X0_E_OBRIGATORIO.ToFormat("AutenticarUsuarioRequest"));
            }

            var email = new Email(request.Email);
            var Usuario = new Usuario(email, request.Senha);

            AddNotifications(Usuario, email);

            if (Usuario.IsInvalid())
            {
                return null;
            }

            Usuario = _repositoryUsuario.ObterPor(x => x.Email.Endereco == Usuario.Email.Endereco && x.Senha == Usuario.Senha);

            return (AutenticarResponse)Usuario;
        }

        public IEnumerable<UsuarioResponse> Listar()
        {
            return _repositoryUsuario.Listar().ToList().Select(Usuario => (UsuarioResponse)Usuario).ToList();
        }


        public ResponseBase Excluir(int id)
        {
            Usuario Usuario = _repositoryUsuario.ObterPorId(id);

            if (Usuario == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryUsuario.Remover(Usuario);

            return new ResponseBase();
        }
    }
}
