using Data.DbModels;
using Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class OpcionRepository : IOpcionRepository
    {

        #region Fiels
        private readonly DB_Context db;

        public OpcionRepository()
        {
            db = new DB_Context();
        }
        public bool Delete(int id)
        {
            try
            {
                var data = db.TOpcion.Find(id);
                db.TOpcion.Remove(data);
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
                var data = db.TOpcion.Find(id);
                return data != null ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<Opcion> GetAll()
        {
            try
            {
                var data = db.TOpcion.Select(o => new TOpcion()
                {
                    IdPregunta = o.IdPregunta,
                    Texto = o.Texto,
                    Valor = o.Valor,
                    EsRespuestaDefecto = o.EsRespuestaDefecto,
                    OrdenRespuesta = o.OrdenRespuesta,
                    Etiqueta = o.Etiqueta
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Opcion GetbyId(int id)
        {
            try
            {
                var data = db.TOpcion.Find(id);
                return data != null ? ConvertToDBDDomain(data) : null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool save(Opcion o)
        {
            try
            {
                var dbtable = ConvertToDBTable(o);
                db.TOpcion.Add(dbtable);
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

        public bool Update(Opcion o)
        {
            try
            {
                var data = db.TOpcion.Find(o.Id);
                if (data != null)
                {

                    db.TOpcion.Update(ConvertToDBTable(o));
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

        public TOpcion ConvertToDBTable(Opcion o)
        {
            return new TOpcion
            {
                IdPregunta = o.IdPregunta,
                Texto = o.Texto,
                Valor = o.Valor,
                EsRespuestaDefecto = o.EsRespuestaDefecto,
                OrdenRespuesta = o.OrdenRespuesta,
                Etiqueta = o.Etiqueta

            };
        }
        public Opcion ConvertToDBDDomain(TOpcion o)
        {
            return new Opcion
            {
                IdPregunta = o.IdPregunta,
                Texto = o.Texto,
                Valor = o.Valor,
                EsRespuestaDefecto = o.EsRespuestaDefecto,
                OrdenRespuesta = o.OrdenRespuesta,
                Etiqueta = o.Etiqueta
            };

        }
    }
}