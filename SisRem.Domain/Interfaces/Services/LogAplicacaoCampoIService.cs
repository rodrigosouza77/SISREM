
using SisRem.Domain.Arguments.Log.Campos.Request;
using SisRem.Domain.Interfaces.Services.Base;

namespace SisRem.Domain.Interfaces.Services
{
    public interface LogAplicacaoCampoIService : IServiceBase
    {
        void Criar(AdicionarRequest request);

    }
}
