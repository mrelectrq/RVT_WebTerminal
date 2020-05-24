using RVT_W_BusinessLayer.BusinessModels;
using RVT_W_BusinessLayer.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RVT_W_BusinessLayer.Interfaces
{
    public interface IRegister
    {
        public Task<RegistrationResponse> Registration(RegistrationModel data);
    }
}
