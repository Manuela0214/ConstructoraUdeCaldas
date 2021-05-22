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
    public class CityController : BaseController
    {
        private CityImpController capaNegocio = new CityImpController();
        private CityImpController capaNegocioCity = new CityImpController();

        // GET: City
        public ActionResult Index(string filter = "")
        {
            CityModelMapper mapper = new CityModelMapper();
            IEnumerable<CityModel> roleList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());
            return View(roleList);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            CityModel cityModel = new CityModel();
            IEnumerable<CityDTO> dtoList = capaNegocioCity.RecordList(string.Empty);
            CityModelMapper mapper = new CityModelMapper();
            //cityModel.CityList = mapper.MapperT1T2(dtoList);
            return View(cityModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,CityId")] CityModel model)
        {
            if (ModelState.IsValid)
            {
                CityModelMapper mapper = new CityModelMapper();
                CityDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            CityModel cityModel = new CityModel();
            IEnumerable<CityDTO> dtoList = capaNegocioCity.RecordList(string.Empty);
            CityModelMapper mapperCity = new CityModelMapper();
            CityModelMapper mapper = new CityModelMapper();
            CityModel model = mapper.MapperT1T2(dto);

            cityModel.Code = model.Code;
            cityModel.Name = model.Name;
            //cityModel.CityList = mapperCity.MapperT1T2(dtoList);
            return View(cityModel);
        }

        // POST: City/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,CityId,Removed")] CityModel model)
        {
            if (ModelState.IsValid)
            {
                CityModelMapper mapper = new CityModelMapper();
                CityDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: City/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            CityModelMapper mapper = new CityModelMapper();
            CityModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Code,Name,City,Removed")] CityModel model)
        {
            CityModelMapper mapper = new CityModelMapper();
            CityDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);


        }


        private ActionResult ProcessResponse(int response, CityModel model)
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
