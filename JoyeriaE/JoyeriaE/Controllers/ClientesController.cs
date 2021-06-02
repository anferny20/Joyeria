using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoyeriaE.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            JoyeriaEntities contexto = new JoyeriaEntities();
            List<Models.ClienteModel> lista = (from e in contexto.Clientes
                                            
                                               select new Models.ClienteModel
                                               {
                                                   IdCliente = e.IdCliente,
                                                   Nombre = e.Nombre,
                                                   Monto = e.Monto,
                                                   Email = e.Email,
                                                   Telefono = e.Telefono

                                               }).ToList();

            return View(lista);
           
        }


        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(Models.ClienteModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    JoyeriaEntities contexto = new JoyeriaEntities();
                    Clientes clientes = new Clientes
                    {
                        IdCliente = model.IdCliente,
                        Nombre = model.Nombre,
                        Monto = model.Monto,
                        Email = model.Email,
                        Telefono = model.Telefono
                    };
                    contexto.Clientes.Add(clientes);
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

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {

            JoyeriaEntities contexto = new JoyeriaEntities();

            Models.ClienteModel clientes = (from e in contexto.Clientes
                                            where e.IdCliente == id
                                            select new Models.ClienteModel
                                            {

                                                IdCliente = e.IdCliente,
                                                Nombre = e.Nombre,
                                                Monto = e.Monto,
                                                Email = e.Email,
                                                Telefono = e.Telefono


                                            }).FirstOrDefault();

           
            return View(clientes);
        
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit( Models.ClienteModel model)
        {
            if (ModelState.IsValid)
            {
                JoyeriaEntities contexto = new JoyeriaEntities();
                Clientes Clientes = (from a in contexto.Clientes
                                    where a.IdCliente == model.IdCliente
                                    select a).FirstOrDefault();
                Clientes.IdCliente = model.IdCliente;
                Clientes.Nombre = model.Nombre;
                Clientes.Monto = model.Monto;
                Clientes.Email = model.Email;
                Clientes.Telefono = model.Telefono;               
                contexto.SaveChanges();
                return RedirectToAction("Index");

            }
            
            return View(model);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {

            JoyeriaEntities contexto = new JoyeriaEntities();

            Models.ClienteModel clientes = (from e in contexto.Clientes
                                            where e.IdCliente == id
                                            select new Models.ClienteModel
                                            {
                                                IdCliente = e.IdCliente,
                                                Nombre = e.Nombre,
                                                Monto = e.Monto,
                                                Email = e.Email,
                                                Telefono = e.Telefono

                                            }).FirstOrDefault();

            
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            JoyeriaEntities contexto = new JoyeriaEntities();
            try
            {
                Clientes clientes = (from a in contexto.Clientes
                                    where a.IdCliente == id
                                    select a).FirstOrDefault();
                contexto.Clientes.Remove(clientes);
                contexto.SaveChanges();

            }
            catch (Exception)
            {


            }
            return RedirectToAction("Index");
        }
    }
}
