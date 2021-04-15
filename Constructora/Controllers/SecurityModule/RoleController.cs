using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Constructora.Mapper.SecurityModule;
using Constructora.Models.SecurityModule;
using ConstructoraController.DTO.SecurityModule;
using ConstructoraController.Implementation.SecurityModule;

namespace Constructora.Controllers.SecurityModule
{
    public class RoleController : Controller
    {
        private RoleImplController capaNegocio = new RoleImplController();

        // GET: Role
        public ActionResult Index(string filter = "")
        {
            RoleModelMapper mapper = new RoleModelMapper();
            IEnumerable<RoleModel> roleList = mapper.MapperT1T2(capaNegocio.RecordList(filter));
            return View(roleList);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description")] RoleModel model)
        {
            if (ModelState.IsValid)
            {
                RoleModelMapper mapper = new RoleModelMapper();
                RoleDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                switch (response)
                {
                    case 1:
                        return RedirectToAction("Index");
                    case 2:
                        ViewBag.Message = "Ha ocurrido un error ejecunatndo la acción.";
                        return View(model);
                    case 3:
                        ViewBag.Message = "Ya existe un rol con el nombre "+model.Name;
                        return View(model);
                }
            }

            return View(model);
        }
        /*
        // GET: Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEC_ROLE sEC_ROLE = controller.SEC_ROLE.Find(id);
            if (sEC_ROLE == null)
            {
                return HttpNotFound();
            }
            return View(sEC_ROLE);
        }

        // POST: Role/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,REMOVED,DESCRIPTION")] SEC_ROLE sEC_ROLE)
        {
            if (ModelState.IsValid)
            {
                controller.Entry(sEC_ROLE).State = EntityState.Modified;
                controller.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sEC_ROLE);
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEC_ROLE sEC_ROLE = controller.SEC_ROLE.Find(id);
            if (sEC_ROLE == null)
            {
                return HttpNotFound();
            }
            return View(sEC_ROLE);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SEC_ROLE sEC_ROLE = controller.SEC_ROLE.Find(id);
            controller.SEC_ROLE.Remove(sEC_ROLE);
            controller.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                controller.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
