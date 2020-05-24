using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RVT_W_BusinessLayer;
using RVT_W_BusinessLayer.BusinessModels;
using RVT_W_BusinessLayer.Interfaces;
using RVTWebTerminal.Models;

namespace RVTWebTerminal.Controllers
{
    public class RegisterController : Controller
    {

        private IRegister connection;
        public RegisterController()
        {
            var bl = new BusinessManager();
            connection = bl.GetConnection();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(RegisterModel model)
        {
            var data = new RegistrationModel();
            data.IDNP = model.IDNP;
            data.Name = model.Name;
            data.Surname = model.Surname;
            data.Gender = model.Gender;
            data.Region = model.Region;
            data.Email = model.Email;
            data.Birth_date = DateTime.Parse(model.Birth_date);
            data.RegisterDate = DateTime.Now;
            data.Ip_address = Request.HttpContext.Connection.RemoteIpAddress.ToString(); ;
            data.Phone_Number = model.Phone_Number;

            var response = await connection.Registration(data);
            if (response.Status == true)
                return RedirectToAction("Login", "User");
            else
            {

                return View();
            }
        }
        public IActionResult Vote()
        {
            return View();
        }
    }
}