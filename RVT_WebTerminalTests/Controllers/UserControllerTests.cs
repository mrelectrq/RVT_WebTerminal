using Microsoft.VisualStudio.TestTools.UnitTesting;
using RVT_WebTerminal.Controllers;
using RVT_WebTerminal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVT_WebTerminal.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void RegistrationTest()
        {
            var testModel = new RegisterModel();
            testModel.IDNP = "51231253216";
            testModel.Birth_date = "20032014";
            var controller = new UserController();
            controller.Registration(testModel);



            Assert.Fail();
        }
    }
}
