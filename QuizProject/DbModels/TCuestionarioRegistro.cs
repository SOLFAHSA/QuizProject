using System;
using System.Collections.Generic;

namespace Data.DbModels
{
    public partial class TCuestionarioRegistro
    {
        public TCuestionarioRegistro()
        {
            TRespuesta = new HashSet<TRespuesta>();
        }

        public int Id { get; set; }
        public int IdCuestionario { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal? Puntaje { get; set; }

        public virtual TCuestionario IdCuestionarioNavigation { get; set; }
        public virtual TUsuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<TRespuesta> TRespuesta { get; set; }
    }
}
