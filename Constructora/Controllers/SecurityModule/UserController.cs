using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Constructora.Helpers;
using Constructora.Mapper.SecurityModule;
using Constructora.Models.SecurityModule;
using ConstructoraController.DTO.SecurityModule;
using ConstructoraController.Implementation.SecurityModule;

namespace Constructora.Controllers.SecurityModule
{
    public class UserController : Controller
    {
        private UserImplController capaNegocio = new UserImplController();

        // GET: User
        public ActionResult Index(string filter = "")
        {
            UserModelMapper mapper = new UserModelMapper();
            IEnumerable<UserModel> roleList = mapper.MapperT1T2(capaNegocio.RecordList(filter));
            return View(roleList);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Lastname,Document,Cellphone,Email")] UserModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserInSessionId = 1;
                UserModelMapper mapper = new UserModelMapper();
                UserDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                switch (response)
                {
                    case 1:
                        return RedirectToAction("Index");
                    case 2:
                        ViewBag.Message = Messages.ExceptionMessage;
                        return View(model);
                    case 3:
                        ViewBag.Message = Messages.alreadyExistMessage;
                        return View(model);
                }
            }

            return View(model);
        }
        
        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            UserModelMapper mapper = new UserModelMapper();
            UserModel model = mapper.MapperT1T2(dto);
            
            return View(model);
        }

        // POST: User/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Lastname,Document,Cellphone,Email")] UserModel model)
        {
            if (ModelState.IsValid)
            {
                UserModelMapper mapper = new UserModelMapper();
                UserDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                //this.ProcessResponse(response, model);
                switch (response)
                {
                    case 1:
                        return RedirectToAction("Index");
                    case 2:
                        ViewBag.Message = Messages.ExceptionMessage;
                        return View(model);
                    case 3:
                        ViewBag.Message = Messages.alreadyExistMessage;
                        return View(model);
                }

            }
            return View(model);
        }

        /// <summary>
        /// Procesamiento de las respuestas
        /// </summary>
        /// <param name="response">Representa la respuesta</param>
        /// <param name="model">Representa un objeto con informacion del rol</param>
        /// <returns>1: Ok, 2: Excepción, 3:Ya existe</returns>
        private ActionResult ProcessResponse(int response,UserModel model)
        {
            switch (response)
            {
                case 1:
                    return RedirectToAction("Index");
                case 2:
                    ViewBag.Message = Messages.ExceptionMessage;
                    return View(model);
                case 3:
                    ViewBag.Message = Messages.alreadyExistMessage;
                    return View(model);
            }
            return RedirectToAction("Index");
        }

        
        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            UserModelMapper mapper = new UserModelMapper();
            UserModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Name,Removed,Description")] UserModel model)
        {
            UserModelMapper mapper = new UserModelMapper();
            UserDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            switch (response)
            {
                case 1:
                    return RedirectToAction("Index");
                case 2:
                    ViewBag.Message = Messages.ExceptionMessage;
                    return View(model);
                case 3:
                    ViewBag.Message = Messages.alreadyExistMessage;
                    return View(model);
            }
            return RedirectToAction("Index");
        }

    }
}
