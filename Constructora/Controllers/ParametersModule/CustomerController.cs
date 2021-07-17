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
    public class CustomerController : BaseController
    {
        private CustomerImplController capaNegocio = new CustomerImplController();
        private CityImplController capaNegocioCity = new CityImplController();
        private FinancialImplController capaNegocioFinancial = new FinancialImplController();

        // GET: Customer
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No, string filter = "")
        {
            if (!this.VerificarSession())
            {
                return RedirectToAction("Index", "Home");
            }
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                ViewBag.SortingName = string.IsNullOrEmpty(Sorting_Order) ? "name" : Sorting_Order;

                CustomerModelMapper mapper = new CustomerModelMapper();
                IEnumerable<CustomerModel> CustomerList = mapper.MapperT1T2(capaNegocio.RecordList(filter));
                //return View(CustomerList);
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

                //var CustomerList = from stu in db.PARAM_CUSTOMER select stu;

                if (!String.IsNullOrEmpty(Search_Data))
                {
                    CustomerList = CustomerList.Where(stu => stu.Name.ToUpper().Contains(Search_Data.ToUpper()));
                }
                //-----------------------------------------

                switch (Sorting_Order)
                {
                    case "name":
                        CustomerList = CustomerList.OrderByDescending(customer => customer.Name);
                        break;

                    default:
                        CustomerList = CustomerList.OrderBy(customer => customer.Name);
                        break;
                }
                int Size_Of_Page = 4;
                int No_Of_Page = (Page_No ?? 1);
                return View(CustomerList.ToPagedList(No_Of_Page, Size_Of_Page));
            }
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            if (!this.VerificarSession())
            {
                return RedirectToAction("Index", "Home");
            }
            CustomerModel customerModel = new CustomerModel();
            IEnumerable<CityDTO> dtoList1 = capaNegocioCity.RecordList(string.Empty);
            IEnumerable<FinancialDTO> dtoList2 = capaNegocioFinancial.RecordList(string.Empty);
            CityModelMapper mapper1 = new CityModelMapper();
            FinancialModelMapper mapper2 = new FinancialModelMapper();
            customerModel.CityList = mapper1.MapperT1T2(dtoList1);
            customerModel.FinancialList = mapper2.MapperT1T2(dtoList2);
            return View(customerModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Document,Name,LastName,DateBirth,Picture,Cellphone,Email,Address,CityId,FinancialId")] CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerModelMapper mapper = new CustomerModelMapper();
                CustomerDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Customer/Edit/5
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
            CustomerDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            CustomerModel customerModel = new CustomerModel();
            IEnumerable<CityDTO> dtoList1 = capaNegocioCity.RecordList(string.Empty);
            IEnumerable<FinancialDTO> dtoList2 = capaNegocioFinancial.RecordList(string.Empty);
            CityModelMapper mapperCity = new CityModelMapper();
            FinancialModelMapper mapperFinancial = new FinancialModelMapper();
            CustomerModelMapper mapper = new CustomerModelMapper();
            CustomerModel model = mapper.MapperT1T2(dto);

            customerModel.Document = model.Document;
            customerModel.Name = model.Name;
            customerModel.LastName = model.LastName;
            customerModel.DateBirth = model.DateBirth;
            customerModel.Picture = model.Picture;
            customerModel.Cellphone = model.Cellphone;
            customerModel.Email = model.Cellphone;
            customerModel.Address = model.Address;
            customerModel.CityList = mapperCity.MapperT1T2(dtoList1);
            customerModel.FinancialList = mapperFinancial.MapperT1T2(dtoList2);
            return View(customerModel);
        }

        // POST: Customer/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Document,Name,LastName,DateBirth,Picture,Cellphone,Email,Address,CityId,FinancialId,Removed")] CustomerModel model)
        {

            if (ModelState.IsValid)
            {
                CustomerModelMapper mapper = new CustomerModelMapper();
                CustomerDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Customer/Delete/5
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
            CustomerDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            CustomerModelMapper mapper = new CustomerModelMapper();
            CustomerModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Code,Name,LastName,DateBirth,Picture,Cellphone,Email,Address,CityId,FinancialId,Removed")] CustomerModel model)
        {
            CustomerModelMapper mapper = new CustomerModelMapper();
            CustomerDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);
        }

        private ActionResult ProcessResponse(int response, CustomerModel model)
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
