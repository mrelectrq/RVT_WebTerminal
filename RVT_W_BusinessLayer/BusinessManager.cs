using RVT_W_BusinessLayer.Interfaces;
using RVT_W_BusinessLayer.Levels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVT_W_BusinessLayer
{
    public class BusinessManager
    {
        public IRegister GetConnection( )
        {
            return new RegisterLevel();
        }
        public ISessions GetSession()
        {
            return new SessionLevel();
        }
    }
}
