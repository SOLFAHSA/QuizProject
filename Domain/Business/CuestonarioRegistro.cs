using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Business
{
    public class CuestonarioRegistro
    {
        public int Id { get; set; }
        public int IdCuestionario { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal? Puntaje { get; set; }

    }
}
