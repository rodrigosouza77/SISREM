using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SisRem.Api.Controllers.Base;
using SisRem.Domain.Interfaces.Services;
using SisRem.Infra.Transactions;
using SisRem.Domain.Arguments.Usuario.Request;
using SisRem.Domain.Component;
using SisRem.Domain.Arguments.Exception.Request;
using SisRem.Domain.Arguments.Email.Request;

namespace SisRem.Api.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioIService _serviceUsuario;
        private readonly LogAplicacaoIService _serviceLogAplicacao;

        public UsuarioController(IUnitOfWork unitOfWork, UsuarioIService serviceUsuario, LogAplicacaoIService serviceLogAplicacao) : base(unitOfWork)
        {
            _serviceUsuario = serviceUsuario;
            _serviceLogAplicacao = serviceLogAplicacao;
        }

        //[Authorize]
        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(AdicionarRequest request)
        {
            try
            {
                var response = _serviceUsuario.Adicionar(request);
                var responseLog = (SisRem.Domain.Arguments.Log.Aplicacao.Request.AdicionarRequest)request;

                _serviceLogAplicacao.Criar(responseLog);

                return await ResponseAsync(response, _serviceUsuario);
            }
            catch (Exception ex)
            {
                var requestException = (ExceptionRequest)request;

                request = null;

                return await ResponseExceptionAsync(ex, requestException);
            }
            finally 
            {
                if (request != null)
                {
                    var envioEmail = (EmailRequest)request;
                    HelperEnvioEmail.EnviarEmail(envioEmail);
                }
            }
        }

        //[Authorize]
        [Route("Alterar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Alterar(AlterarRequest request)
        {
            try
            {
                var response = _serviceUsuario.Alterar(request);

                var responseLog = (SisRem.Domain.Arguments.Log.Aplicacao.Request.AdicionarRequest)request;

                _serviceLogAplicacao.Criar(responseLog);

                return await ResponseAsync(response, _serviceUsuario);
            }
            catch (Exception ex)
            {
                //log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType).Error(ex);
                ExceptionRequest requestException = new ExceptionRequest();
                return await ResponseExceptionAsync(ex, requestException);
            }
        }

        //[Authorize]
        [Route("Excluir")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Excluir(int id)
        {
            try
            {
                var response = _serviceUsuario.Excluir(id);

                return await ResponseAsync(response, _serviceUsuario);
            }
            catch (Exception ex)
            {
                //log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType).Error(ex);
                ExceptionRequest requestException = new ExceptionRequest();
                return await ResponseExceptionAsync(ex, requestException);
            }
        }

        //[Authorize]
        [Route("Listar")]
        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            try
            {
                var response = _serviceUsuario.Listar();

                return await ResponseAsync(response, _serviceUsuario);
            }
            catch (Exception ex)
            {
                //log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType).Error(ex);
                ExceptionRequest requestException = new ExceptionRequest();
                return await ResponseExceptionAsync(ex, requestException);
            }
        }


    }
}