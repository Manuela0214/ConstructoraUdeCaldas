using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
using System.Web.UI.WebControls;

namespace Constructora.Controllers.ParametersModule
{
    public class PropertyController : BaseController
    {
        private PropertyImplController capaNegocio = new PropertyImplController();
        private BlockImplController capaNegocioBlock = new BlockImplController();

        // GET: Property
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No, string filter = "")
        {
            /**if (!this.VerificarSession())
            {
                return RedirectToAction("Index", "Home");
            }**/
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                ViewBag.SortingName = string.IsNullOrEmpty(Sorting_Order) ? "name" : Sorting_Order;

                PropertyModelMapper mapper = new PropertyModelMapper();
                IEnumerable<PropertyModel> PropertyList = mapper.MapperT1T2(capaNegocio.RecordList(filter));
                //return View(PropertyList);
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

                //var PropertyList = from stu in db.PARAM_PROPERTY select stu;

                if (!String.IsNullOrEmpty(Search_Data))
                {
                    PropertyList = PropertyList.Where(stu => stu.Name.ToUpper().Contains(Search_Data.ToUpper()));
                }
                //-----------------------------------------

                switch (Sorting_Order)
                {
                    case "name":
                        PropertyList = PropertyList.OrderByDescending(property => property.Name);
                        break;

                    default:
                        PropertyList = PropertyList.OrderBy(property => property.Name);
                        break;
                }
                int Size_Of_Page = 4;
                int No_Of_Page = (Page_No ?? 1);
                return View(PropertyList.ToPagedList(No_Of_Page, Size_Of_Page));
            }
        }

        // GET: Property/Create
        public ActionResult Create()
        {
            /*if (!this.VerificarSession())
            {
                return RedirectToAction("Index", "Home");
            }**/
            PropertyModel propertyModel = new PropertyModel();
            IEnumerable<BlockDTO> dtoList = capaNegocioBlock.RecordList(string.Empty);
            BlockModelMapper mapper = new BlockModelMapper();
            propertyModel.BlockList = mapper.MapperT1T2(dtoList);
            return View(propertyModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,Valor,BlockId")] PropertyModel model)
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
            /**if (!this.VerificarSession())
            {
                return RedirectToAction("Index", "Home");
            }**/
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            PropertyModel propertyModel = new PropertyModel();
            IEnumerable<BlockDTO> dtoList = capaNegocioBlock.RecordList(string.Empty);
            BlockModelMapper mapperBlock = new BlockModelMapper();
            PropertyModelMapper mapper = new PropertyModelMapper();
            PropertyModel model = mapper.MapperT1T2(dto);

            propertyModel.Code = model.Code;
            propertyModel.Name = model.Name;
            propertyModel.Valor = model.Valor;
            propertyModel.BlockList = mapperBlock.MapperT1T2(dtoList);
            return View(propertyModel);
        }

        // POST: Property/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Valor,BlockId,Removed")] PropertyModel model)
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
            /**if (!this.VerificarSession())
            {
                return RedirectToAction("Index", "Home");
            }**/
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
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Code,Name,Valor,Block,Removed")] PropertyModel model)
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
