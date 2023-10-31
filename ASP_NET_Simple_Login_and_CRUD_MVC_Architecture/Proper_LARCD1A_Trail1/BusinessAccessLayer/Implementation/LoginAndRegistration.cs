using BusinessAccessLayer.Abstract;
using DataAccessLayer.Entity_DB;
using ModelAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Implementation
{
    public class LoginAndRegistration : ILoginAndRegistration
    {
        private PracticeEntities db = new PracticeEntities();
        public bool Register(LoginAndRegistrationModel loginAndRegistrationModel)
        {
            Trail1LoginAndRegis trail1LoginAndRegis = new Trail1LoginAndRegis
            {
                Name = loginAndRegistrationModel.Name,
                Email = loginAndRegistrationModel.Email,
                Password = loginAndRegistrationModel.Password
            };
            db.Trail1LoginAndRegis.Add(trail1LoginAndRegis);
            var Result = db.SaveChanges();
            if(Result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public bool Login(LoginAndRegistrationModel loginAndRegistrationModel)
        {
            var CheckDetails = (from userlist in db.Trail1LoginAndRegis
                              where userlist.Email == loginAndRegistrationModel.Email && userlist.Password == loginAndRegistrationModel.Password
                              select new
                              {
                                  userlist.Email,
                                  userlist.Password
                              }).ToList();
            if (CheckDetails.FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int Temp()
        {

            int a = 10;
            return a;
        }
    }
}
