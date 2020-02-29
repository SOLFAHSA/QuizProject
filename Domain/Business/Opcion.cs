using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Business
{
   public class Opcion
    {
        public int Id { get; set; }
        public int IdPregunta { get; set; }
        public string Texto { get; set; }
        public decimal Valor { get; set; }
        public bool EsRespuestaDefecto { get; set; }
        public int OrdenRespuesta { get; set; }
        public string Etiqueta { get; set; }
    }
}
