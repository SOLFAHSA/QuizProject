using System;
using System.Collections.Generic;

namespace Data.DbModels
{
    public partial class TOpcion
    {
        public int Id { get; set; }
        public int IdPregunta { get; set; }
        public string Texto { get; set; }
        public decimal Valor { get; set; }
        public bool EsRespuestaDefecto { get; set; }
        public int OrdenRespuesta { get; set; }
        public string Etiqueta { get; set; }

        public virtual TPregunta IdPreguntaNavigation { get; set; }
    }
}
