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
    public class RequestStatusController : BaseController
    {
        private RequestStatusImplController capaNegocio = new RequestStatusImplController();
        private RequestStatusImplController capaNegocioRequestStatus = new RequestStatusImplController();

        // GET: RequestStatus
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)//, string filter = "")
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                if (!this.VerificarSession())
                {
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.SortingName = string.IsNullOrEmpty(Sorting_Order) ? "name" : Sorting_Order;

                //RequestStatusModelMapper mapper = new RequestStatusModelMapper();
                //IEnumerable<RequestStatusModel> RequestStatusList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());
                //RequestStatusList = RequestStatusList.Where(x => x.Name.ToUpper().Contains(Search_Data.ToUpper()));

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

                var RequestStatusList = from stu in db.PARAM_REQUEST_STATUS select stu;

                if (!String.IsNullOrEmpty(Search_Data))
                {
                    RequestStatusList = RequestStatusList.Where(stu => stu.NAME.ToUpper().Contains(Search_Data.ToUpper()));
                }
                //-----------------------------------------

                switch (Sorting_Order)
                {
                    case "name":
                        RequestStatusList = RequestStatusList.OrderByDescending(requestStatus => requestStatus.NAME);
                        break;

                    default:
                        RequestStatusList = RequestStatusList.OrderBy(requestStatus => requestStatus.NAME);
                        break;
                }
                int Size_Of_Page = 4;
                int No_Of_Page = (Page_No ?? 1);
                return View(RequestStatusList.ToPagedList(No_Of_Page, Size_Of_Page));
            }
        }

        // GET: RequestStatus/Create
        public ActionResult Create()
        {
            RequestStatusModel cityModel = new RequestStatusModel();
            IEnumerable<RequestStatusDTO> dtoList = capaNegocioRequestStatus.RecordList(string.Empty);
            RequestStatusModelMapper mapper = new RequestStatusModelMapper();
            //cityModel.RequestStatusList = mapper.MapperT1T2(dtoList);
            return View(cityModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description")] RequestStatusModel model)
        {
            if (!this.VerificarSession())
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                RequestStatusModelMapper mapper = new RequestStatusModelMapper();
                RequestStatusDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: RequestStatus/Edit/5
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
            RequestStatusDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            RequestStatusModel cityModel = new RequestStatusModel();
            IEnumerable<RequestStatusDTO> dtoList = capaNegocioRequestStatus.RecordList(string.Empty);
            RequestStatusModelMapper mapperRequestStatus = new RequestStatusModelMapper();
            RequestStatusModelMapper mapper = new RequestStatusModelMapper();
            RequestStatusModel model = mapper.MapperT1T2(dto);

            cityModel.Name = model.Name;
            cityModel.Description = model.Description;
            //cityModel.RequestStatusList = mapperRequestStatus.MapperT1T2(dtoList);
            return View(cityModel);
        }

        // POST: RequestStatus/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] RequestStatusModel model)
        {
            if (ModelState.IsValid)
            {
                RequestStatusModelMapper mapper = new RequestStatusModelMapper();
                RequestStatusDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: RequestStatus/Delete/5
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
            RequestStatusDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            RequestStatusModelMapper mapper = new RequestStatusModelMapper();
            RequestStatusModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: RequestStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Name,Description")] RequestStatusModel model)
        {
            RequestStatusModelMapper mapper = new RequestStatusModelMapper();
            RequestStatusDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);


        }


        private ActionResult ProcessResponse(int response, RequestStatusModel model)
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
