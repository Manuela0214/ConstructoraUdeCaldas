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
    public class PaymentsController : BaseController
    {
        private PaymentsImplController capaNegocio = new PaymentsImplController();
        private RequestImplController capaNegocioRequest = new RequestImplController();

        // GET: Payments
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No, string filter = "")
        {
            //if (!this.VerificarSession())
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                ViewBag.SortingName = string.IsNullOrEmpty(Sorting_Order) ? "name" : Sorting_Order;

                PaymentsModelMapper mapper = new PaymentsModelMapper();
                IEnumerable<PaymentsModel> PaymentsList = mapper.MapperT1T2(capaNegocio.RecordList(filter));
                //return View(PaymentsList);
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

                //var PaymentsList = from stu in db.PARAM_PAYMENTS select stu;

                if (!String.IsNullOrEmpty(Search_Data))
                {
                    PaymentsList = PaymentsList.Where(stu => stu.Name.ToUpper().Contains(Search_Data.ToUpper()));
                }
                //-----------------------------------------

                switch (Sorting_Order)
                {
                    case "name":
                        PaymentsList = PaymentsList.OrderByDescending(payments => payments.Name);
                        break;

                    default:
                        PaymentsList = PaymentsList.OrderBy(payments => payments.Name);
                        break;
                }
                int Size_Of_Page = 4;
                int No_Of_Page = (Page_No ?? 1);
                return View(PaymentsList.ToPagedList(No_Of_Page, Size_Of_Page));
            }
        }

        // GET: Payments/Create
        public ActionResult Create()
        {
            //if (!this.VerificarSession())
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            PaymentsModel paymentsModel = new PaymentsModel();
            IEnumerable<RequestDTO> dtoList = capaNegocioRequest.RecordList(string.Empty);
            RequestModelMapper mapper = new RequestModelMapper();
            paymentsModel.RequestList = mapper.MapperT1T2(dtoList);
            return View(paymentsModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,Date,RequestId")] PaymentsModel model)
        {
            if (ModelState.IsValid)
            {
                PaymentsModelMapper mapper = new PaymentsModelMapper();
                PaymentsDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (!this.VerificarSession())
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentsDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            PaymentsModel paymentsModel = new PaymentsModel();
            IEnumerable<RequestDTO> dtoList = capaNegocioRequest.RecordList(string.Empty);
            RequestModelMapper mapperRequest = new RequestModelMapper();
            PaymentsModelMapper mapper = new PaymentsModelMapper();
            PaymentsModel model = mapper.MapperT1T2(dto);


            paymentsModel.Name = model.Name;
            paymentsModel.Description = model.Description;
            paymentsModel.Date = model.Date;
            paymentsModel.RequestList = mapperRequest.MapperT1T2(dtoList);
            return View(paymentsModel);
        }

        // POST: Payments/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Date,RequestId,Removed")] PaymentsModel model)
        {

            if (ModelState.IsValid)
            {
                PaymentsModelMapper mapper = new PaymentsModelMapper();
                PaymentsDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (!this.VerificarSession())
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentsDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            PaymentsModelMapper mapper = new PaymentsModelMapper();
            PaymentsModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Name,Description,Date,Request,Removed")] PaymentsModel model)
        {
            PaymentsModelMapper mapper = new PaymentsModelMapper();
            PaymentsDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);
        }

        private ActionResult ProcessResponse(int response, PaymentsModel model)
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
