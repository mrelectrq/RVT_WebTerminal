using RVT_W_BusinessLayer.BusinessImplementation;
using RVT_W_BusinessLayer.BusinessModels;
using RVT_W_BusinessLayer.Interfaces;
using RVT_W_BusinessLayer.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RVT_W_BusinessLayer.Levels
{
    public class UserLevel : UserImplement, IConnection
    {
        public Task<RegistrationResponse> Registration(RegistrationModel data)
        {
            return RegistrationAction(data);
        }
    }
}
