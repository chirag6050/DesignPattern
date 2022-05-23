using BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IAccountServices
    {
        Task<string> Login(ELoginDTO userModel);
        Task<bool> Logout();
        Task<string> SignUp(ESignUpDTO userModel);
    }
}
