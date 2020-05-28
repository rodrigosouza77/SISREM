using SisRem.Domain.Entities.Base;

namespace SisRem.Domain.Entities.Log
{
    public class LogAplicacaoCampo : EntityBase
    {

        public int IDLogAplicacao { get; set; }
        public string Campo { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorNovo { get; set; }
        public string Justificativa { get; set; }
        public virtual LogAplicacao LogAplicacao { get; set; }


    }
}
