﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;
using System.Data.Entity;
using Business.ServRefWCFAlumno;

namespace Business
{
    public class NAlumno
    {
        DBConnection _DBContext = new DBConnection();
        WCFAlumnoClient _oWCFAlumnoClient = new WCFAlumnoClient();
        public List<Alumnos> Consultar()
        {
            return _DBContext.Alumnos.ToList();

        }

        public Alumnos Consultar(int id)
        {
            return _DBContext.Alumnos.Find(id);
        }
        public void Agregar(Alumnos alumno)
        {
            _DBContext.Alumnos.Add(alumno);
            _DBContext.SaveChanges();
        }
        public void Actualizar(Alumnos alumnos)
        {
            _DBContext.Entry(alumnos).State = EntityState.Modified;
            _DBContext.SaveChanges();
        }
        public void Eliminar(int id)
        {
            var oAlumno = _DBContext.Alumnos.Find(id);
            if (oAlumno != null)
            {
                _DBContext.Alumnos.Remove(oAlumno);
                _DBContext.SaveChanges();
            }
        }
        public AportacionesIMSS CalcularIMSS(int id)
        {
            AportacionesIMSS oAportacionesIMSS = _oWCFAlumnoClient.CalcularIMSS(id);
            return oAportacionesIMSS;
        }

        public ItemTablaISR CalcularISR(int id)
        {

            ItemTablaISR oItemTablaISR = _oWCFAlumnoClient.CalcularISR(id);
            return oItemTablaISR;
        }
    }
}