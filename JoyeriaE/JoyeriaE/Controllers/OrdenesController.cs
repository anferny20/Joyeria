using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JoyeriaE;
using JoyeriaE.Models;
using QRCoder;

namespace JoyeriaE.Controllers
{
    public class OrdenesController : Controller
    {
         JoyeriaEntities1 contexto = new JoyeriaEntities1();

        // GET: Ordenes
        public ActionResult Index()
        {
            List<Models.OrdenModel> lista = (from e in contexto.Ordenes
                                               join b in contexto.Items on e.IdItem equals b.IdItem
                                               join c in contexto.Clientes on e.IdCliente equals c.IdCliente
                                               join d in contexto.Empleados on e.IdEmpleado equals d.IdEmpleado
                                                select new Models.OrdenModel

                                                {   IdOrden =e.IdOrden,
                                                    IdCliente = e.IdCliente,
                                                    NombreC = c.Nombre,
                                                    IdItem = e.IdItem,
                                                    NombreI = b.Nombre,
                                                    IdEmpleado = e.IdEmpleado,
                                                    NombreE = d.Nombre,
                                                    FechaCreacion = e.FechaCreacion,
                                                    FechaFinalizacion = e.FechaFinalizacion
                                                    
                                                    
                                                }).ToList();

            return View(lista);
        }

      
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenModel ordenesModel = contexto.OrdenesModels.Find(id);
            if (ordenesModel == null)
            {
                return HttpNotFound();
            }
            return View(ordenesModel);
        }

       
        public ActionResult Create()
        {
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FieldAccessException d)
        {
            if (ModelState.IsValid)
            {
                contexto.OrdenesModels.Add(ordenesModel);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ordenesModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenModel ordenesModel = contexto.OrdenesModels.Find(id);
            if (ordenesModel == null)
            {
                return HttpNotFound();
            }
            return View(ordenesModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            if (ModelState.IsValid)
            {
                contexto.Entry(ordenesModel).State = EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ordenesModel);
        }

     
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenModel ordenesModel = contexto.OrdenesModels.Find(id);
            if (ordenesModel == null)
            {
                return HttpNotFound();
            }
            return View(ordenesModel);
        }

  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenModel ordenesModel = contexto.OrdenesModels.Find(id);
            contexto.OrdenesModels.Remove(ordenesModel);
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                contexto.Dispose();
            }
            base.Dispose(disposing);
        }


        public static List<Models.VehiculoModel> LlenarDrp()
        {
            BodyShopFlowEntities contexto = new BodyShopFlowEntities();

            List<Models.VehiculoModel> lista = (from e in contexto.vehiculo

                                                select new Models.VehiculoModel
                                                {
                                                    idVehiculo = e.idVehiculo,
                                                    Placa = e.placa
                                                }).ToList();


            return lista;
        }


        public ActionResult CerrarOrden(int id)
        {
            BodyShopFlowEntities contexto = new BodyShopFlowEntities();
            orden ordens = (from a in contexto.orden
                            where a.idOrden == id
                            select a).FirstOrDefault();
            string user = Session["Iduser"].ToString();
            ordens.usuarioCierre = user;
            ordens.fechaCierre = DateTime.Now;

            contexto.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult QR(int id)
        {
            BodyShopFlowEntities contexto = new BodyShopFlowEntities();

            Models.OrdenModel ordens = (from e in contexto.orden
                                        where e.idOrden == id
                                        select new Models.OrdenModel
                                        {
                                            idOrden = e.idOrden,
                                            referenciaInterna = e.referenciaInterna,
                                            fechaRegistro = e.fechaRegistro,
                                            adicional1 = e.adicional1,
                                            adicional2 = e.adicional2,
                                            md5orden = e.md5Orden,
                                            usuarioCierre = e.usuarioCierre,
                                            fechaCierre = e.fechaCierre,
                                            idVehiculo = e.idVehiculo,
                                            activo = e.activo


                                        }).FirstOrDefault();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(ordens.md5orden,
            QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return View(BitmapToBytes(qrCodeImage));

        }

        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

    }
}

