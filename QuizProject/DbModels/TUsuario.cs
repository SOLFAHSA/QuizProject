using System;
using System.Collections.Generic;

namespace Data.DbModels
{
    public partial class TUsuario
    {
        public TUsuario()
        {
            TCuestionario = new HashSet<TCuestionario>();
            TCuestionarioRegistro = new HashSet<TCuestionarioRegistro>();
        }

        public int Id { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual TTipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<TCuestionario> TCuestionario { get; set; }
        public virtual ICollection<TCuestionarioRegistro> TCuestionarioRegistro { get; set; }
    }
}
