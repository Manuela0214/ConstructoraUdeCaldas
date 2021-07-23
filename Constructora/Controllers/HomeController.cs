using Constructora.Mapper.ParametersModule;
using Constructora.Models.ParametersModule;
using ConstructoraController.Implementation.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Constructora.Controllers
{
    public class HomeController : Controller
    {
        private ProjectImplController capaNegocio = new ProjectImplController();
        public ActionResult Index(string filter = "")
        {
            ProjectModelMapper mapper = new ProjectModelMapper();
            IEnumerable<ProjectModel> ProjectList = mapper.MapperT1T2(capaNegocio.RecordList(filter));
            return View(ProjectList);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}