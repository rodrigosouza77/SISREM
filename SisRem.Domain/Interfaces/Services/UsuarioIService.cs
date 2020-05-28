using System;
using System.Collections.Generic;
using SisRem.Domain.Arguments.Base;
using SisRem.Domain.Arguments.Usuario;
using SisRem.Domain.Interfaces.Services.Base;
using SisRem.Domain.Arguments.Usuario.Request;
using SisRem.Domain.Arguments.Usuario.Response;

namespace SisRem.Domain.Interfaces.Services
{
    public interface UsuarioIService : IServiceBase
    {
        AutenticarResponse Autenticar(AutenticarRequest request);

        AdicionarResponse Adicionar(AdicionarRequest request);

        AlterarResponse Alterar(AlterarRequest request);

        IEnumerable<UsuarioResponse> Listar();

        ResponseBase Excluir(int id);
    }
}
