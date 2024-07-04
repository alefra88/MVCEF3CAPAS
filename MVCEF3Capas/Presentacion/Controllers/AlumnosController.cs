using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Business.ServRefWCFAlumno;
using Entities;

namespace Presentacion.Controllers
{
    public class AlumnosController : Controller
    {

        NAlumno _oNAlumno = new NAlumno();
        NEstado _oNEstado = new NEstado();
        Estados _oEstados = new Estados();
        NEstatus _oNEstatus = new NEstatus();
        // GET: Alumnos
        public ActionResult Index()
        {
            List<Alumnos> ListAlumnos = _oNAlumno.Consultar();

            return View(ListAlumnos);
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int id)
        {
            Alumnos oAlumno = _oNAlumno.Consultar(id);
            return View(oAlumno);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            ViewBag.EstadosList = new SelectList(_oNEstado.Consultar(), "id", "nombre");
            ViewBag.EstatusList = new SelectList(_oNEstatus.Consultar(), "id", "nombre");

            return View();
        }

        // POST: Alumnos/Create
        [HttpPost]
        public ActionResult Create(Alumnos alumnos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _oNAlumno.Agregar(alumnos);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.EstadosList = new SelectList(_oNEstado.Consultar(), "id", "nombre");
            ViewBag.EstatusList = new SelectList(_oNEstatus.Consultar(), "id", "nombre");
            Alumnos alumno = _oNAlumno.Consultar(id);
            return View(alumno);
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Alumnos alumnos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _oNAlumno.Actualizar(alumnos);

                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int id)
        {
            Alumnos oAlumno = _oNAlumno.Consultar(id);
            return View(oAlumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Alumnos alumnos)
        {
            try
            {
                _oNAlumno.Eliminar(id);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult _AportacionesIMSS(int id)
        {
            AportacionesIMSS oAportacionesIMSS = _oNAlumno.CalcularIMSS(id);
            return PartialView(oAportacionesIMSS);
        }

        public ActionResult _TablaISR(int id)
        {
            ItemTablaISR oItemTablaISR = _oNAlumno.CalcularISR(id);
            return PartialView(oItemTablaISR);
        }
    }
}
