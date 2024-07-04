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
    public class NEstado
    {
        DBConnection _DBContext = new DBConnection();
        public List<Estados> Consultar()
        {
            List<Estados> lista = _DBContext.Estados.ToList();
            return lista;
        }
        public Estados Consultar(int id)
        {
            Estados estados = _DBContext.Estados.Find(id);
            return estados;
        }
        public void Agregar(Estados estados)
        {
            _DBContext.Estados.Add(estados);
            _DBContext.SaveChanges();
        }
        public void Actualizar(Estados estados)
        {
            _DBContext.Entry(estados).State = EntityState.Modified;
            _DBContext.SaveChanges();
        }
        public void Eliminar(int id)
        {
            var oEstado = _DBContext.Estados.Find(id);
            if(oEstado != null)
            {
                _DBContext.Estados.Remove(oEstado);
                _DBContext.SaveChanges();
            }
        }
    }
}
