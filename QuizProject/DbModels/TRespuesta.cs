using System;
using System.Collections.Generic;

namespace Data.DbModels
{
    public partial class TRespuesta
    {
        public int Id { get; set; }
        public int IdCuestionarioRegistro { get; set; }
        public int IdPregunta { get; set; }
        public string Texto { get; set; }
        public decimal? Valor { get; set; }

        public virtual TCuestionarioRegistro IdCuestionarioRegistroNavigation { get; set; }
        public virtual TPregunta IdPreguntaNavigation { get; set; }
    }
}
