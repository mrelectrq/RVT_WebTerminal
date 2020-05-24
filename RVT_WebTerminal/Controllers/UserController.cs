using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RVT_W_BusinessLayer;
using RVT_W_BusinessLayer.BusinessModels;
using RVT_W_BusinessLayer.Interfaces;
using RVT_WebTerminal.Models;

namespace RVT_WebTerminal.Controllers
{
    public class UserController : Controller
    {
        private IConnection connection;
        public UserController()
        {
            var bl = new BusinessManager();
            connection = bl.GetConnection();
        }

        [HttpPost]
        public async Task<ActionResult> Registration(RegisterModel model)
        {
            //if (ModelState.IsValid)
            //{
                var data = new RegistrationModel();
                data.IDNP = model.IDNP;
                data.Name = model.Name;
                data.Surname = model.Surname;
                data.Email = model.Email;
                data.Birth_date = DateTime.ParseExact(model.Birth_date, "ddMMyyyy",
                    CultureInfo.InvariantCulture);
                data.RegisterDate = DateTime.Now;
                //data.Ip_address = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                data.Phone_Number = model.Phone_Number;

                var response = await connection.Registration(data);
                if (response.Status == true)
                return View();
                else
                {
                    return View();
                }
            //}
            //else
            //{
            //    return View();
            //}
        }
    }
}