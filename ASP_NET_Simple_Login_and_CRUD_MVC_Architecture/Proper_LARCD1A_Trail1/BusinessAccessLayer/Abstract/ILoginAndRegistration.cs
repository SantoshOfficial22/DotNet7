using ModelAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Abstract
{
    public interface ILoginAndRegistration
    {
        bool Register(LoginAndRegistrationModel loginAndRegistrationModel);
        bool Login(LoginAndRegistrationModel loginAndRegistrationModel);
        int Temp();
    }
}
