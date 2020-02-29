using Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    interface ICuestonarioRegistroRepository
    {
        public bool save(CuestonarioRegistro c);

        public CuestonarioRegistro GetbyId(int id);

        public bool Delete(int id);

        public bool Update(CuestonarioRegistro c);

        public IEnumerable<CuestonarioRegistro> GetAll();

        public bool Exist(int id);
    }
}
