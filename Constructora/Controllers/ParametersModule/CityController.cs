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
    public class CityController : BaseController
    {
        private CityImplController capaNegocio = new CityImplController();
        private CountryImplController capaNegocioCountry = new CountryImplController();
        private ConstructoraDBEntities db = new ConstructoraDBEntities();

        // GET: City
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)//, string filter = "")
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                ViewBag.SortingName = string.IsNullOrEmpty(Sorting_Order) ? "name" : Sorting_Order;

                //CityModelMapper mapper = new CityModelMapper();
                //IEnumerable<CityModel> CityList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());
                //CityList = CityList.Where(x => x.Name.ToUpper().Contains(Search_Data.ToUpper()));

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

                var CityList = from c in db.PARAM_CITY select c;

                //var countryList = from stu in db.PARAM_COUNTRY select stu;
                //var countryList = from c in db.PARAM_COUNTRY join x in db.PARAM_CITY on db.PARAM_COUNTRY.
                //---------------------------
                /**var countryList = (
                from city in db.PARAM_CITY
                from country in db.PARAM_COUNTRY
                where city.COUNTRYID == country.ID
                select new
                {
                    Name = city.NAME,
                    Code = city.CODE,
                    CountryId = country.ID,
                    Country = country.NAME
                }).ToList();

                ViewBag.CountryName = (from city in db.PARAM_CITY
                                       from country in db.PARAM_COUNTRY
                                       where city.COUNTRYID == country.ID
                                       select country.NAME);**/

                //-------------------------------

                if (!String.IsNullOrEmpty(Search_Data))
                {
                    CityList = CityList.Where(c => c.NAME.ToUpper().Contains(Search_Data.ToUpper()));
                }
                switch (Sorting_Order)
                {
                    case "name":
                        CityList = CityList.OrderByDescending(country => country.NAME);
                        break;

                    default:
                        CityList = CityList.OrderBy(country => country.NAME);
                        break;
                }
                int Size_Of_Page = 4;
                int No_Of_Page = (Page_No ?? 1);
                return View(CityList.ToPagedList(No_Of_Page, Size_Of_Page));
            }
        }

        public ActionResult Create()
        {
            CityModel cityModel = new CityModel();
            IEnumerable<CountryDTO> dtoList = capaNegocioCountry.RecordList(string.Empty);
            CountryModelMapper mapper = new CountryModelMapper();
            cityModel.CountryList = mapper.MapperT1T2(dtoList);
            return View(cityModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,CountryId")] CityModel model)
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
            IEnumerable<CountryDTO> dtoList = capaNegocioCountry.RecordList(string.Empty);
            CountryModelMapper mapperCountry = new CountryModelMapper();
            CityModelMapper mapper = new CityModelMapper();
            CityModel model = mapper.MapperT1T2(dto);

            cityModel.Code = model.Code;
            cityModel.Name = model.Name;
            cityModel.CountryList = mapperCountry.MapperT1T2(dtoList);
            return View(cityModel);
        }

        // POST: City/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,CountryId,Removed")] CityModel model)
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

        /**private void CountryDropDownList(object selectedCountry = null)
        {
            var departmentsQuery = from d in db.PARAM_COUNTRY
                                   orderby d.NAME
                                   select d;
            ViewBag.CountryId = new SelectList(departmentsQuery, "CountryId", "Name", selectedCountry);
        }**/

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
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Code,Name,Country")] CityModel model)
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
