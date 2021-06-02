using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoyeriaE.Controllers
{
    public class ProvedoresController : Controller
    {
        public ActionResult Index()
        {
            JoyeriaEntities contexto = new JoyeriaEntities();
            List<Models.ProvedorModel> lista = (from e in contexto.Proveedores

                                               select new Models.ProvedorModel
                                               {
                                                   IdProveedor = e.IdProveedor,
                                                   IdItem = e.Iditem,
                                                   Nombre = e.Nombre,
                                                   Email = e.Email,
                                                   Telefono = e.Telefono

                                               }).ToList();

            return View(lista);

        }


        // GET: Proveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedores/Create
        [HttpPost]
        public ActionResult Create(Models.ProvedorModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    JoyeriaEntities contexto = new JoyeriaEntities();
                    Proveedores proveedores = new Proveedores
                    {
                        IdProveedor = model.IdProveedor,
                        Iditem = model.IdItem,
                        Nombre = model.Nombre,
                        Email = model.Email,
                        Telefono = model.Telefono
                    };
                    contexto.Proveedores.Add(proveedores);
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

        // GET: Proveedores/Edit/5
        public ActionResult Edit(int id)
        {

            JoyeriaEntities contexto = new JoyeriaEntities();

            Models.ProvedorModel proveedores = (from e in contexto.Proveedores
                                            where e.IdProveedor == id
                                            select new Models.ProvedorModel
                                            {

                                                IdProveedor = e.IdProveedor,
                                                IdItem = e.Iditem,
                                                Nombre = e.Nombre,
                                                Email = e.Email,
                                                Telefono = e.Telefono


                                            }).FirstOrDefault();


            return View(proveedores);

        }

        // POST: Proveedores/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.ProvedorModel model)
        {
            if (ModelState.IsValid)
            {
                JoyeriaEntities contexto = new JoyeriaEntities();
                Proveedores Proveedores = (from a in contexto.Proveedores
                                     where a.IdProveedor == model.IdProveedor
                                     select a).FirstOrDefault();
                Proveedores.IdProveedor = model.IdProveedor;
                Proveedores.Iditem = model.IdItem;
                Proveedores.Nombre = model.Nombre;
                Proveedores.Email = model.Email;
                Proveedores.Telefono = model.Telefono;
                contexto.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(model);
        }

        // GET: Proveedores/Delete/5
        public ActionResult Delete(int id)
        {

            JoyeriaEntities contexto = new JoyeriaEntities();

            Models.ProvedorModel proveedores = (from e in contexto.Proveedores
                                            where e.IdProveedor == id
                                            select new Models.ProvedorModel
                                            {
                                                IdProveedor = e.IdProveedor,
                                                IdItem = e.Iditem,
                                                Nombre = e.Nombre,
                                                Email = e.Email,
                                                Telefono = e.Telefono

                                            }).FirstOrDefault();


            return View(proveedores);
        }

        // POST: Proveedores/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            JoyeriaEntities contexto = new JoyeriaEntities();
            try
            {
                Proveedores proveedores = (from a in contexto.Proveedores
                                     where a.IdProveedor == id
                                     select a).FirstOrDefault();
                contexto.Proveedores.Remove(proveedores);
                contexto.SaveChanges();

            }
            catch (Exception)
            {


            }
            return RedirectToAction("Index");
        }
    }
}
