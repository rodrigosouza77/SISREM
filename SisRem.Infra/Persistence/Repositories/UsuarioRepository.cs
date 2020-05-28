using System;
using SisRem.Domain.Entities;
using SisRem.Domain.Interfaces.Repositories;
using SisRem.Infra.Persistence.Repositories.Base;

namespace SisRem.Infra.Persistence.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario, int>, UsuarioIRepository
    {
        protected readonly SisRemContext _context;

        public UsuarioRepository(SisRemContext context) : base(context)
        {
            _context = context;
        }
    }
}
