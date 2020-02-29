using System;
using System.Collections.Generic;

namespace Data.DbModels
{
    public partial class TTipoUsuario
    {
        public TTipoUsuario()
        {
            TUsuario = new HashSet<TUsuario>();
        }

        public int Id { get; set; }
        public string Descriptor { get; set; }

        public virtual ICollection<TUsuario> TUsuario { get; set; }
    }
}
