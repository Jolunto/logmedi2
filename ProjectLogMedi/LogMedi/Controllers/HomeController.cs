using BusinessLogic;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogMedi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public bool Cambiar(string OldPassword, string NewPassword, string ConfirmPassword)
        {
            usuarioRepository cambiar = new usuarioRepository();
            Array comparar = cambiar.CompararContrasena(17);

            if (string.Compare(OldPassword,comparar.GetValue(0).ToString()) == 0)
            {
                bool bandera = false;
                bandera = cambiar.CambiarContrasena(17,NewPassword);
                return bandera;
            }
            else
            {
                return false;
            }
 

        }
    }
}