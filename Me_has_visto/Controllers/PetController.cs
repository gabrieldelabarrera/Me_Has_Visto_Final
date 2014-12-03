using Me_has_visto.Models;
using Me_has_visto.Models.Bussines;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Me_has_visto.Controllers
{
    public class PetController : Controller
    {
        //
        // GET: /Pet/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult  Display()
        {
            var name = (string)RouteData.Values["id"];
           //var model = PetManagement.GetByBame(name);
           if (null == null)
               return RedirectToAction("NotFound");
            return View(/*model*/);
        }
        public ActionResult NotFound()
        {
            return View();
        }
        public FileResult DownLoadPicture()
        {
           var name = (string)RouteData.Values["id"];
            var picture = "/Content/Uploads/" + name + ".jpg";
            var contentType = "image/jpg";
            var fileName = name + ".jpg";
            return File(picture, contentType, fileName); 
           
            /* var name = (string)RouteData.Values["id"];
            var picture = "/Content/Uploads/" + name + ".jpg";
            //var contentType = "image/jpg";
            var fileName = name + ".jpg";
            return File(picture,/* contentType,*/ //fileName);*/
        }
        public HttpStatusCodeResult UnauthorizedError()
        {
            return new HttpUnauthorizedResult("Error de acceso no autorizado");
        }
        public ActionResult NotFoundError()
        {
            return HttpNotFound("nadapor aqui....");
        }

        public ActionResult PictureUpload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PictureUpload(PictureModel model)
        {
            if(model.PictureFile.ContentLength>0)
            {
                var fileName= Path.GetFileName(model.PictureFile.FileName);
                var filePath= Server.MapPath("/Content/Uploads");
                string savedFileName=Path.Combine(filePath,fileName);
                model.PictureFile.SaveAs(savedFileName);
                PetManagment.CreateThumbnail(fileName,filePath,100,100,true);
            }
            return View(model);
        }


    }
}
