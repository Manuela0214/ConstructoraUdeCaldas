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
using ConstructoraModel.Model;
using PagedList;

namespace Constructora.Controllers.ParametersModule
{
    public class BlockController : BaseController
    {
        private BlockImplController capaNegocio = new BlockImplController();
        private ProjectImplController capaNegocioProject = new ProjectImplController();

        // GET: Block
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No, string filter = "")
        {
            if (!this.VerificarSession())
            {
                return RedirectToAction("Index", "Home");
            }
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                ViewBag.SortingName = string.IsNullOrEmpty(Sorting_Order) ? "name" : Sorting_Order;

                BlockModelMapper mapper = new BlockModelMapper();
                IEnumerable<BlockModel> BlockList = mapper.MapperT1T2(capaNegocio.RecordList(filter));
                //return View(BlockList);
                //--------------------------------------
                if (Search_Data != null)
                {
                    Page_No = 1;
                }
                else
                {
                    Search_Data = Filter_Value;
                }

                ViewBag.FilterValue = Search_Data;

                //var BlockList = from stu in db.PARAM_BLOCK select stu;

                if (!String.IsNullOrEmpty(Search_Data))
                {
                    BlockList = BlockList.Where(stu => stu.Name.ToUpper().Contains(Search_Data.ToUpper()));
                }
                //-----------------------------------------

                switch (Sorting_Order)
                {
                    case "name":
                        BlockList = BlockList.OrderByDescending(block => block.Name);
                        break;

                    default:
                        BlockList = BlockList.OrderBy(block => block.Name);
                        break;
                }
                int Size_Of_Page = 4;
                int No_Of_Page = (Page_No ?? 1);
                return View(BlockList.ToPagedList(No_Of_Page, Size_Of_Page));
            }
        }

        // GET: Block/Create
        public ActionResult Create()
        {
            if (!this.VerificarSession())
            {
                return RedirectToAction("Index", "Home");
            }
            BlockModel blockModel = new BlockModel();
            IEnumerable<ProjectDTO> dtoList = capaNegocioProject.RecordList(string.Empty);
            ProjectModelMapper mapper = new ProjectModelMapper();
            blockModel.ProjectList = mapper.MapperT1T2(dtoList);
            return View(blockModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,Description,ProjectId")] BlockModel model)
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
            if (!this.VerificarSession())
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlockDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            BlockModel blockModel = new BlockModel();
            IEnumerable<ProjectDTO> dtoList = capaNegocioProject.RecordList(string.Empty);
            ProjectModelMapper mapperProject = new ProjectModelMapper();
            BlockModelMapper mapper = new BlockModelMapper();
            BlockModel model = mapper.MapperT1T2(dto);

            blockModel.Code = model.Code;
            blockModel.Name = model.Name;
            blockModel.Description = model.Description;
            blockModel.ProjectList = mapperProject.MapperT1T2(dtoList);
            return View(blockModel);
        }

        // POST: Block/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Description,ProjectId,Removed")] BlockModel model)
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
            if (!this.VerificarSession())
            {
                return RedirectToAction("Index", "Home");
            }
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
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Code,Name,Description,Project,Removed")] BlockModel model)
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
