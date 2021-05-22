using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Constructora.Helpers;
using Constructora.Mapper.ParametersModule;
using Constructora.Models.ParametersModule;
using ConstructoraController.DTO.ParametersModule;
using ConstructoraController.Implementation.ParametersModule;

namespace Constructora.Controllers.ParametersModule
{
    public class PropertyController : BaseController
    {
        private PropertyImpController capaNegocio = new PropertyImpController();
        private CountryImpController capaNegocioCountry = new CountryImpController();

        // GET: Property
        public ActionResult Index(string filter = "")
        {
            PropertyModelMapper mapper = new PropertyModelMapper();
            IEnumerable<PropertyModel> roleList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());
            return View(roleList);
        }

        // GET: Property/Create
        public ActionResult Create()
        {
            PropertyModel cityModel = new PropertyModel();
            IEnumerable<CountryDTO> dtoList = capaNegocioCountry.RecordList(string.Empty);
            CountryModelMapper mapper = new CountryModelMapper();
            //cityModel.CountryList = mapper.MapperT1T2(dtoList);
            return View(cityModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,CountryId")] PropertyModel model)
        {
            if (ModelState.IsValid)
            {
                PropertyModelMapper mapper = new PropertyModelMapper();
                PropertyDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Property/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            PropertyModel cityModel = new PropertyModel();
            IEnumerable<CountryDTO> dtoList = capaNegocioCountry.RecordList(string.Empty);
            CountryModelMapper mapperCountry = new CountryModelMapper();
            PropertyModelMapper mapper = new PropertyModelMapper();
            PropertyModel model = mapper.MapperT1T2(dto);

            cityModel.Code = model.Code;
            cityModel.Name = model.Name;
            //cityModel.CountryList = mapperCountry.MapperT1T2(dtoList);
            return View(cityModel);
        }

        // POST: Property/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,CountryId,Removed")] PropertyModel model)
        {
            if (ModelState.IsValid)
            {
                PropertyModelMapper mapper = new PropertyModelMapper();
                PropertyDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Property/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            PropertyModelMapper mapper = new PropertyModelMapper();
            PropertyModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: Property/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Code,Name,Country,Removed")] PropertyModel model)
        {
            PropertyModelMapper mapper = new PropertyModelMapper();
            PropertyDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);


        }


        private ActionResult ProcessResponse(int response, PropertyModel model)
        {
            switch (response)
            {
                case 1:
                    return RedirectToAction("Index");
                case 2:
                    ViewBag.Message = Messages.ExceptionMessage;
                    return View(model);
                case 3:
                    ViewBag.Message = Messages.alreadyExistMessage + model.Name;
                    return View(model);
            }
            return RedirectToAction("Index");
        }

    }
}
