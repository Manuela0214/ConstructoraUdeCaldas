using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    public class ProjectController : BaseController
    {
        private ProjectImplController capaNegocio = new ProjectImplController();
        private CityImplController capaNegocioCity = new CityImplController();

        // GET: Project
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No, string filter = "")
        {
            if (!this.VerificarSession())
            {
                return RedirectToAction("Index", "Home");
            }
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                ViewBag.SortingName = string.IsNullOrEmpty(Sorting_Order) ? "name" : Sorting_Order;

                ProjectModelMapper mapper = new ProjectModelMapper();
                IEnumerable<ProjectModel> ProjectList = mapper.MapperT1T2(capaNegocio.RecordList(filter));
                //return View(ProjectList);
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

                //var ProjectList = from stu in db.PARAM_PROJECT select stu;

                if (!String.IsNullOrEmpty(Search_Data))
                {
                    ProjectList = ProjectList.Where(stu => stu.Name.ToUpper().Contains(Search_Data.ToUpper()));
                }
                //-----------------------------------------

                switch (Sorting_Order)
                {
                    case "name":
                        ProjectList = ProjectList.OrderByDescending(project => project.Name);
                        break;

                    default:
                        ProjectList = ProjectList.OrderBy(project => project.Name);
                        break;
                }
                int Size_Of_Page = 4;
                int No_Of_Page = (Page_No ?? 1);
                return View(ProjectList.ToPagedList(No_Of_Page, Size_Of_Page));
            }
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            if (!this.VerificarSession())
            {
                return RedirectToAction("Index", "Home");
            }
            ProjectModel projectModel = new ProjectModel();
            IEnumerable<CityDTO> dtoList = capaNegocioCity.RecordList(string.Empty);
            CityModelMapper mapper = new CityModelMapper();
            projectModel.CityList = mapper.MapperT1T2(dtoList);
            return View(projectModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,Description,Picture,CityId")] ProjectModel model)
        {
            if (ModelState.IsValid)
            {
                ProjectModelMapper mapper = new ProjectModelMapper();
                ProjectDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Project/Edit/5
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
            ProjectDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            ProjectModel projectModel = new ProjectModel();
            IEnumerable<CityDTO> dtoList = capaNegocioCity.RecordList(string.Empty);
            CityModelMapper mapperCity = new CityModelMapper();
            ProjectModelMapper mapper = new ProjectModelMapper();
            ProjectModel model = mapper.MapperT1T2(dto);

            projectModel.Code = model.Code;
            projectModel.Name = model.Name;
            projectModel.Description = model.Description;
            projectModel.Picture = model.Picture;
            projectModel.CityList = mapperCity.MapperT1T2(dtoList);
            return View(projectModel);
        }

        // POST: Project/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Description,Picture,CityId,Removed")] ProjectModel model)
        {

            if (ModelState.IsValid)
            {
                ProjectModelMapper mapper = new ProjectModelMapper();
                ProjectDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Project/Delete/5
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
            ProjectDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            ProjectModelMapper mapper = new ProjectModelMapper();
            ProjectModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Code,Name,Description,Picture,City,Removed")] ProjectModel model)
        {
            ProjectModelMapper mapper = new ProjectModelMapper();
            ProjectDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);
        }

        private ActionResult ProcessResponse(int response, ProjectModel model)
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



        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    Console.WriteLine(_path);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "Archivo cargado correctamente";
                return View();
            }
            catch
            {
                ViewBag.Message = "Error al cargar el archivo";
                return View();
            }
        }
    }
}
