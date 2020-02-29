using System;
using System.Collections.Generic;

namespace Data.DbModels
{
    public partial class TCuestionario
    {
        public TCuestionario()
        {
            TCuestionarioRegistro = new HashSet<TCuestionarioRegistro>();
            TPregunta = new HashSet<TPregunta>();
        }

        public int Id { get; set; }
        public int IdUsuarioCrea { get; set; }
        public string Nombe { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; }

        public virtual TUsuario IdUsuarioCreaNavigation { get; set; }
        public virtual ICollection<TCuestionarioRegistro> TCuestionarioRegistro { get; set; }
        public virtual ICollection<TPregunta> TPregunta { get; set; }
    }
}
