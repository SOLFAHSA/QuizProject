using System;
using System.Collections.Generic;

namespace Data.DbModels
{
    public partial class TPregunta
    {
        public TPregunta()
        {
            TOpcion = new HashSet<TOpcion>();
            TRespuesta = new HashSet<TRespuesta>();
        }

        public int Id { get; set; }
        public string Texto { get; set; }
        public int IdTipoPregunta { get; set; }
        public int? Orden { get; set; }
        public string Instrucciones { get; set; }
        public int? IdCuestionario { get; set; }
        public decimal? Peso { get; set; }
        public decimal? RangoMaximo { get; set; }
        public decimal? RangoMinimo { get; set; }

        public virtual TCuestionario IdCuestionarioNavigation { get; set; }
        public virtual ICollection<TOpcion> TOpcion { get; set; }
        public virtual ICollection<TRespuesta> TRespuesta { get; set; }
    }
}
