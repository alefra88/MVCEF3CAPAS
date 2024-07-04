using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;
using System.Data.Entity;

namespace Business
{
    public class NEstatus
    {
        DBConnection _DBContext = new DBConnection();
        
        public List<EstatusAlumnos> Consultar()
        {
            return _DBContext.EstatusAlumnos.ToList();
            
        }
        public EstatusAlumnos Consultar(int id)
        {
            return _DBContext.EstatusAlumnos.Find(id);
        }
        public void Agregar(EstatusAlumnos estatusAlumnos)
        {
            _DBContext.EstatusAlumnos.Add(estatusAlumnos);
        }
        public void Actualizar(EstatusAlumnos estatusAlumnos)
        {
            _DBContext.Entry(estatusAlumnos).State = EntityState.Modified;
            _DBContext.SaveChanges();
        }
        public void Eliminar(int id)
        {
            var estatusAlumnos = _DBContext.EstatusAlumnos.Find(id);
            if(estatusAlumnos != null)
            {
                _DBContext.EstatusAlumnos.Remove(estatusAlumnos);
                _DBContext.SaveChanges();
            }
        }
    }
}
