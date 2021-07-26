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
using Constructora.Models.SecurityModule;
using ConstructoraController.Services;

namespace Constructora.Controllers.ParametersModule
{
    public class RequestController : BaseController
    {
        private RequestImplController capaNegocio = new RequestImplController();
        private CustomerImplController capaNegocioCustomer = new CustomerImplController();
        private PropertyImplController capaNegocioProperty = new PropertyImplController();
        private RequestStatusImplController capaNegocioRequestStatus = new RequestStatusImplController();

        // GET: Request
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No, string filter = "")
        {
            /**if (!this.VerificarSession())
            {
                return RedirectToAction("Index", "Home");
            }**/
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                ViewBag.SortingName = string.IsNullOrEmpty(Sorting_Order) ? "name" : Sorting_Order;

                RequestModelMapper mapper = new RequestModelMapper();
                IEnumerable<RequestModel> RequestList = mapper.MapperT1T2(capaNegocio.RecordList(filter));
                //return View(RequestList);
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

                //var RequestList = from stu in db.PARAM_REQUEST select stu;

                if (!String.IsNullOrEmpty(Search_Data))
                {
                    RequestList = RequestList.Where(stu => stu.EconomicOffer.ToString().ToUpper().Contains(Search_Data.ToUpper()));
                }
                //-----------------------------------------

                switch (Sorting_Order)
                {
                    case "name":
                        RequestList = RequestList.OrderByDescending(request => request.EconomicOffer);
                        break;

                    default:
                        RequestList = RequestList.OrderBy(request => request.EconomicOffer);
                        break;
                }
                int Size_Of_Page = 4;
                int No_Of_Page = (Page_No ?? 1);
                return View(RequestList.ToPagedList(No_Of_Page, Size_Of_Page));
            }
        }

        // GET: Request/Create
        public ActionResult Create()
        {
            /**if (!this.VerificarSession())
            {
                return RedirectToAction("Index", "Home");
            }**/
            RequestModel requestModel = new RequestModel();
            IEnumerable<CustomerDTO> dtoList1 = capaNegocioCustomer.RecordList(string.Empty);
            IEnumerable<PropertyDTO> dtoList2 = capaNegocioProperty.RecordList(string.Empty);
            IEnumerable<RequestStatusDTO> dtoList3 = capaNegocioRequestStatus.RecordList(string.Empty);
            CustomerModelMapper mapper1 = new CustomerModelMapper();
            PropertyModelMapper mapper2 = new PropertyModelMapper();
            RequestStatusModelMapper mapper3 = new RequestStatusModelMapper();
            requestModel.CustomerList = mapper1.MapperT1T2(dtoList1);
            requestModel.PropertyList = mapper2.MapperT1T2(dtoList2);
            requestModel.RequestStatusList = mapper3.MapperT1T2(dtoList3);
            return View(requestModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliveryDate,ApprovedDate,EconomicOffer,Consignment,CustomerId,PropertyId,RequestStatusId")] RequestModel model)
        {
            if (ModelState.IsValid)
            {
                RequestModelMapper mapper = new RequestModelMapper();
                RequestDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Request/Edit/5
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
            RequestDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            RequestModel requestModel = new RequestModel();
            IEnumerable<CustomerDTO> dtoList1 = capaNegocioCustomer.RecordList(string.Empty);
            IEnumerable<PropertyDTO> dtoList2 = capaNegocioProperty.RecordList(string.Empty);
            IEnumerable<RequestStatusDTO> dtoList3 = capaNegocioRequestStatus.RecordList(string.Empty);
            CustomerModelMapper mapperCustomer = new CustomerModelMapper();
            PropertyModelMapper mapperProperty = new PropertyModelMapper();
            RequestStatusModelMapper mapperRequestStatus = new RequestStatusModelMapper();
            RequestModelMapper mapper = new RequestModelMapper();
            RequestModel model = mapper.MapperT1T2(dto);

            //requestModel.ApprovedDate = model.ApprovedDate;
            requestModel.DeliveryDate = model.DeliveryDate;
            requestModel.EconomicOffer = model.EconomicOffer;
            //requestModel.Consignment = model.Consignment;
            requestModel.CustomerList = mapperCustomer.MapperT1T2(dtoList1);
            requestModel.PropertyList = mapperProperty.MapperT1T2(dtoList2);
            requestModel.RequestStatusList = mapperRequestStatus.MapperT1T2(dtoList3);

            return View(requestModel);
        }

        // POST: Request/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeliveryDate,ApprovedDate,EconomicOffer,Consignment,CustomerId,PropertyId,RequestStatusId,Removed")] RequestModel model)
        {

            if (ModelState.IsValid)
            {
                RequestModelMapper mapper = new RequestModelMapper();
                RequestDTO dto = mapper.MapperT2T1(model);
                RequestResponse(dto);

                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Request/Delete/5
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
            RequestDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            RequestModelMapper mapper = new RequestModelMapper();
            RequestModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,DeliveryDate,ApprovedDate,EconomicOffer,Consignment,Customer,Property,RequestStatus,Removed")] RequestModel model)
        {
            RequestModelMapper mapper = new RequestModelMapper();
            RequestDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);
        }

        private ActionResult ProcessResponse(int response, RequestModel model)
        {
            switch (response)
            {
                case 1:
                    return RedirectToAction("Index");
                case 2:
                    ViewBag.Message = Messages.ExceptionMessage;
                    return View(model);
                case 3:
                    ViewBag.Message = Messages.alreadyExistMessage + model.Id;
                    return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult RequestResponse(RequestDTO model)
        {
            string estado = "";
            if (ModelState.IsValid)
            {

                if (model.RequestStatusId.Equals(3))
                {
                    estado = "ACEPTADA";
                }
                else if (model.RequestStatusId.Equals(2))
                {
                    estado = "DENEGADA";
                }
                else
                {
                    return View(model);
                }
                ConstructoraDBEntities db = new ConstructoraDBEntities();
                //var record = db.PARAM_CUSTOMER.Where(x => x.ID == model.CustomerId).FirstOrDefault();
                var email = (from customer in db.PARAM_CUSTOMER
                             where customer.ID.Equals(model.CustomerId)
                             select customer.EMAIL).FirstOrDefault();
                if (email != null)
                {
                    Console.WriteLine("Correo enviado a ", email);
                    String content = String.Format("Hola, " +
                    "<br /> Hemos recibido su solicitud de separacion de un inmueblede la Contructora UdeC S.A.S. " +
                    "Le informamos el estado de su solicitud. <br/>" +
                    " <ul>" +
                    "<li> Su solicitud ha sido " + estado + "</li>" +
                    "</ul>" +
                    "<br /> Cordial saludo, <br />" +
                    "Equipo Contructora UdeC S.A.S.");
                    //new Notifications().SendEmail("Cambio de contraseña usuario UdeC", content, email,email);
                    //new Notifications().SendEmail("Restablecimiento de contraseña", "Su contraseña temporal: "+newPassword, email, "angie.1701812633@ucaldas.edu.co");
                    string From = System.Configuration.ConfigurationSettings.AppSettings["EmailFromSendGrid"];
                    new Notifications().SendEmail("Respuesta a solicitud", content, email, From);
                }
            }
            return View(model);
        }

    }
}
