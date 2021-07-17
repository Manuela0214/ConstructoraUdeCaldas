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
    public class FinancialController : BaseController
    {
        private FinancialImplController capaNegocio = new FinancialImplController();
        private FinancialImplController capaNegocioFinancial = new FinancialImplController();

        // GET: Financial
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)//, string filter = "")
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                if (!this.VerificarSession())
                {
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.SortingName = string.IsNullOrEmpty(Sorting_Order) ? "name" : Sorting_Order;

                //FinancialModelMapper mapper = new FinancialModelMapper();
                //IEnumerable<FinancialModel> FinancialList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());
                //FinancialList = FinancialList.Where(x => x.Name.ToUpper().Contains(Search_Data.ToUpper()));

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

                var FinancialList = from stu in db.PARAM_FINANCIAL select stu;

                if (!String.IsNullOrEmpty(Search_Data))
                {
                    FinancialList = FinancialList.Where(stu => stu.NAMEJOB.ToUpper().Contains(Search_Data.ToUpper()));
                }
                //-----------------------------------------

                switch (Sorting_Order)
                {
                    case "name":
                        FinancialList = FinancialList.OrderByDescending(financial => financial.NAMEJOB);
                        break;

                    default:
                        FinancialList = FinancialList.OrderBy(financial => financial.NAMEJOB);
                        break;
                }
                int Size_Of_Page = 4;
                int No_Of_Page = (Page_No ?? 1);
                return View(FinancialList.ToPagedList(No_Of_Page, Size_Of_Page));
            }
        }

        // GET: Financial/Create
        public ActionResult Create()
        {
            FinancialModel financialModel = new FinancialModel();
            IEnumerable<FinancialDTO> dtoList = capaNegocioFinancial.RecordList(string.Empty);
            FinancialModelMapper mapper = new FinancialModelMapper();
            //financialModel.FinancialList = mapper.MapperT1T2(dtoList);
            return View(financialModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NameJob,PhoneJob,TotalInCome,TimeCurrentJob,NameFamilyRef,CellphoneFamilyRef,NamePersonalRef,CellphonePersonalRef")] FinancialModel model)
        {
            if (!this.VerificarSession())
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                FinancialModelMapper mapper = new FinancialModelMapper();
                FinancialDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Financial/Edit/5
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
            FinancialDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            FinancialModel financialModel = new FinancialModel();
            IEnumerable<FinancialDTO> dtoList = capaNegocioFinancial.RecordList(string.Empty);
            FinancialModelMapper mapperFinancial = new FinancialModelMapper();
            FinancialModelMapper mapper = new FinancialModelMapper();
            FinancialModel model = mapper.MapperT1T2(dto);

            financialModel.NameJob = model.NameJob;
            financialModel.PhoneJob = model.PhoneJob;
            financialModel.TotalInCome = model.TotalInCome;
            financialModel.TimeCurrentJob = model.TimeCurrentJob;
            financialModel.NameFamilyRef = model.NameFamilyRef;
            financialModel.CellphoneFamilyRef = model.CellphoneFamilyRef;
            financialModel.NamePersonalRef = model.NamePersonalRef;
            financialModel.CellphonePersonalRef = model.CellphonePersonalRef;
            //financialModel.FinancialList = mapperFinancial.MapperT1T2(dtoList);
            return View(financialModel);
        }

        // POST: Financial/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameJob,PhoneJob,TotalInCome,TimeCurrentJob,NameFamilyRef,CellphoneFamilyRef,NamePersonalRef,CellphonePersonalRef")] FinancialModel model)
        {
            if (ModelState.IsValid)
            {
                FinancialModelMapper mapper = new FinancialModelMapper();
                FinancialDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Financial/Delete/5
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
            FinancialDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            FinancialModelMapper mapper = new FinancialModelMapper();
            FinancialModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: Financial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,NameJob,PhoneJob,TotalInCome,TimeCurrentJob,NameFamilyRef,CellphoneFamilyRef,NamePersonalRef,CellphonePersonalRef")] FinancialModel model)
        {
            FinancialModelMapper mapper = new FinancialModelMapper();
            FinancialDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);


        }


        private ActionResult ProcessResponse(int response, FinancialModel model)
        {
            switch (response)
            {
                case 1:
                    return RedirectToAction("Index");
                case 2:
                    ViewBag.Message = Messages.ExceptionMessage;
                    return View(model);
                case 3:
                    ViewBag.Message = Messages.alreadyExistMessage + model.NameJob;
                    return View(model);
            }
            return RedirectToAction("Index");
        }

    }
}
