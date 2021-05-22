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
    public class BlockController : BaseController
    {
        private BlockImpController capaNegocio = new BlockImpController();
        private BlockImpController capaNegocioBlock = new BlockImpController();

        // GET: Block
        public ActionResult Index(string filter = "")
        {
            BlockModelMapper mapper = new BlockModelMapper();
            IEnumerable<BlockModel> roleList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());
            return View(roleList);
        }

        // GET: Block/Create
        public ActionResult Create()
        {
            BlockModel cityModel = new BlockModel();
            IEnumerable<BlockDTO> dtoList = capaNegocioBlock.RecordList(string.Empty);
            BlockModelMapper mapper = new BlockModelMapper();
            //cityModel.BlockList = mapper.MapperT1T2(dtoList);
            return View(cityModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,BlockId")] BlockModel model)
        {
            if (ModelState.IsValid)
            {
                BlockModelMapper mapper = new BlockModelMapper();
                BlockDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Block/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlockDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            BlockModel cityModel = new BlockModel();
            IEnumerable<BlockDTO> dtoList = capaNegocioBlock.RecordList(string.Empty);
            BlockModelMapper mapperBlock = new BlockModelMapper();
            BlockModelMapper mapper = new BlockModelMapper();
            BlockModel model = mapper.MapperT1T2(dto);

            cityModel.Code = model.Code;
            cityModel.Name = model.Name;
            //cityModel.BlockList = mapperBlock.MapperT1T2(dtoList);
            return View(cityModel);
        }

        // POST: Block/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,BlockId,Removed")] BlockModel model)
        {
            if (ModelState.IsValid)
            {
                BlockModelMapper mapper = new BlockModelMapper();
                BlockDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Block/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlockDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            BlockModelMapper mapper = new BlockModelMapper();
            BlockModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: Block/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Code,Name,Block,Removed")] BlockModel model)
        {
            BlockModelMapper mapper = new BlockModelMapper();
            BlockDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);


        }


        private ActionResult ProcessResponse(int response, BlockModel model)
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
