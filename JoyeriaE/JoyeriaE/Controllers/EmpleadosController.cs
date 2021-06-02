using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoyeriaE.Controllers
{
    public class EmpleadosController : Controller
    {
        public ActionResult Index()
        {
            JoyeriaEntities contexto = new JoyeriaEntities();
            List<Models.EmpleadoModel> lista = (from e in contexto.Empleados

                                               select new Models.EmpleadoModel
                                               {
                                                   IdEmpleado = e.IdEmpleado,
                                                   Nombre = e.Nombre,                                                 
                                                   Email = e.Email,

                                               }).ToList();

            return View(lista);

        }


        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        public ActionResult Create(Models.EmpleadoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    JoyeriaEntities contexto = new JoyeriaEntities();
                    Empleados empleados = new Empleados
                    {
                        IdEmpleado = model.IdEmpleado,
                        Nombre = model.Nombre,
                        Email = model.Email                     
                    };
                    contexto.Empleados.Add(empleados);
                    contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    return View(model);
                }
            }

            return View(model);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int id)
        {

            JoyeriaEntities contexto = new JoyeriaEntities();

            Models.EmpleadoModel empleados = (from e in contexto.Empleados
                                            where e.IdEmpleado == id
                                            select new Models.EmpleadoModel
                                            {

                                                IdEmpleado = e.IdEmpleado,
                                                Nombre = e.Nombre,
                                                Email = e.Email


                                            }).FirstOrDefault();


            return View(empleados);

        }

        // POST: Empleados/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.EmpleadoModel model)
        {
            if (ModelState.IsValid)
            {
                JoyeriaEntities contexto = new JoyeriaEntities();
                Empleados Empleados = (from a in contexto.Empleados
                                     where a.IdEmpleado == model.IdEmpleado
                                     select a).FirstOrDefault();
                Empleados.IdEmpleado = model.IdEmpleado;
                Empleados.Nombre = model.Nombre;
                Empleados.Email = model.Email;
                contexto.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(model);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int id)
        {

            JoyeriaEntities contexto = new JoyeriaEntities();

            Models.EmpleadoModel empleados = (from e in contexto.Empleados
                                            where e.IdEmpleado == id
                                            select new Models.EmpleadoModel
                                            {
                                                IdEmpleado = e.IdEmpleado,
                                                Nombre = e.Nombre,
                                                Email = e.Email,

                                            }).FirstOrDefault();


            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            JoyeriaEntities contexto = new JoyeriaEntities();
            try
            {
                Empleados empleados = (from a in contexto.Empleados
                                     where a.IdEmpleado == id
                                     select a).FirstOrDefault();
                contexto.Empleados.Remove(empleados);
                contexto.SaveChanges();

            }
            catch (Exception)
            {


            }
            return RedirectToAction("Index");
        }
    }
}
