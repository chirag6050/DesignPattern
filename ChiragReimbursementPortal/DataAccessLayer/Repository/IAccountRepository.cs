using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
   public  interface IAccountRepository
    {
        Task<string> Login(EmployeeLogin userModel);
        Task<bool> Logout();
        Task<string> SignUp(EmployeeSignup userModel);
    }
}
