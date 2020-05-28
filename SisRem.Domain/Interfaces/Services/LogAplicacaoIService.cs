
using SisRem.Domain.Interfaces.Services.Base;
using SisRem.Domain.Arguments.Log.Aplicacao.Request;

namespace SisRem.Domain.Interfaces.Services
{
    public interface LogAplicacaoIService : IServiceBase
    {
        void Criar(AdicionarRequest request);

    }
}
