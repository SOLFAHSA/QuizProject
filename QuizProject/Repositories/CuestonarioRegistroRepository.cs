using Data.DbModels;
using Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class CuestonarioRegistroRepository : ICuestonarioRegistroRepository
    {

        #region Fiels
        private readonly DB_Context db;

        public CuestonarioRegistroRepository()
        {
            db = new DB_Context();
        }
        public bool Delete(int id)
        {
            try
            {
                var data = db.TCuestionarioRegistro.Find(id);
                db.TCuestionarioRegistro.Remove(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Exist(int id)
        {
            try
            {
                var data = db.TCuestionarioRegistro.Find(id);
                return data != null ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<CuestonarioRegistro> GetAll()
        {
            try
            {
                var data = db.TCuestionarioRegistro.Select(x => new TCuestionarioRegistro()
                {
                    IdCuestionario = x.IdCuestionario,
                    IdUsuario = x.IdUsuario,
                    FechaInicio = x.FechaInicio,
                    FechaFin = x.FechaFin,
                    Puntaje = x.Puntaje
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public CuestonarioRegistro GetbyId(int id)
        {
            try
            {
                var data = db.TCuestionarioRegistro.Find(id);
                return data != null ? ConvertToDBDDomain(data) : null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool save(CuestonarioRegistro c)
        {
            try
            {
                var dbtable = ConvertToDBTable(c);
                db.TCuestionarioRegistro.Add(dbtable);
                db.SaveChanges();

                int i = dbtable.Id;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(CuestonarioRegistro c)
        {
            try
            {
                var data = db.TCuestionarioRegistro.Find(c.Id);
                if (data != null)
                {

                    db.TCuestionarioRegistro.Update(ConvertToDBTable(c));
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion Other Methos

        public TCuestionarioRegistro ConvertToDBTable(CuestonarioRegistro c)
        {
            return new TCuestionarioRegistro
            {
                IdCuestionario = c.IdCuestionario,
                IdUsuario = c.IdUsuario,
                FechaInicio = c.FechaInicio,
                FechaFin = c.FechaFin,
                Puntaje = c.Puntaje
            };
        }
        public CuestonarioRegistro ConvertToDBDDomain(TCuestionarioRegistro c)
        {
            return new CuestonarioRegistro
            {
                IdCuestionario = c.IdCuestionario,
                IdUsuario = c.IdUsuario,
                FechaInicio = c.FechaInicio,
                FechaFin = c.FechaFin,
                Puntaje = c.Puntaje
            };
        }
    }
}