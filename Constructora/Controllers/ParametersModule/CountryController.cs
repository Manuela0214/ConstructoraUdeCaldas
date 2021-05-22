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
    public class CountryController : BaseController
    {
        private CountryImpController capaNegocio = new CountryImpController();
        private CountryImpController capaNegocioCountry = new CountryImpController();

        // GET: Country
        public ActionResult Index(string filter = "")
        {
            CountryModelMapper mapper = new CountryModelMapper();
            IEnumerable<CountryModel> roleList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());
            return View(roleList);
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            CountryModel cityModel = new CountryModel();
            IEnumerable<CountryDTO> dtoList = capaNegocioCountry.RecordList(string.Empty);
            CountryModelMapper mapper = new CountryModelMapper();
            //cityModel.CountryList = mapper.MapperT1T2(dtoList);
            return View(cityModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,CountryId")] CountryModel model)
        {
            if (ModelState.IsValid)
            {
                CountryModelMapper mapper = new CountryModelMapper();
                CountryDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            CountryModel cityModel = new CountryModel();
            IEnumerable<CountryDTO> dtoList = capaNegocioCountry.RecordList(string.Empty);
            CountryModelMapper mapperCountry = new CountryModelMapper();
            CountryModelMapper mapper = new CountryModelMapper();
            CountryModel model = mapper.MapperT1T2(dto);

            cityModel.Code = model.Code;
            cityModel.Name = model.Name;
            //cityModel.CountryList = mapperCountry.MapperT1T2(dtoList);
            return View(cityModel);
        }

        // POST: Country/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,CountryId,Removed")] CountryModel model)
        {
            if (ModelState.IsValid)
            {
                CountryModelMapper mapper = new CountryModelMapper();
                CountryDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            CountryModelMapper mapper = new CountryModelMapper();
            CountryModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Code,Name,Country,Removed")] CountryModel model)
        {
            CountryModelMapper mapper = new CountryModelMapper();
            CountryDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);


        }


        private ActionResult ProcessResponse(int response, CountryModel model)
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
