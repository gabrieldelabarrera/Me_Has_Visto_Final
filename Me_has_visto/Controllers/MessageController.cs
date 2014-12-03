using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Me_has_visto.Models;

namespace Me_has_visto.Controllers
{
    public class MessageController : Controller
    {
        //
        // GET: /Message/

        public ActionResult Send()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Send(MessageModel modeloDelMensaje)
        {
            if (string.IsNullOrEmpty(modeloDelMensaje.From))
            {
                ModelState.AddModelError("From", "El campo From (De) es requerido");
            }
            if (string.IsNullOrEmpty(modeloDelMensaje.Email))
            {
                ModelState.AddModelError("Email", "El campo Email (Correo) es requerido");
            }
            if (string.IsNullOrEmpty(modeloDelMensaje.Message))
            {
                ModelState.AddModelError("Message", "El campo Message (Mensaje) es requerido");
            }
            if (ModelState.IsValid)

            {
                return RedirectToAction("ThankYou");
            }
            ModelState.AddModelError("", "Uno o mas errores fueron encontrados");
            return View(modeloDelMensaje);
 
            
        }

        public ActionResult ThankYou()
        {
            return View();
        }

    }
}
