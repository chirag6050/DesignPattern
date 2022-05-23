using DataAccessLayer.Entity;
using DataAccessLayer.IdentityModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<string> SignUp(EmployeeSignup userModel)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = userModel.Email,
                FullName = userModel.Fullname,
                PanNumber = userModel.PanNumber,
                Bank = userModel.Bank,
                AccountNumber = userModel.BankAccountNumber
            };
         string result = "false";
            var check = await userManager.CreateAsync(applicationUser, userModel.Password);
            if (check.Succeeded)
            {
                // await signInManager.SignInAsync(applicationUser, isPersistent: false);
                result = "true";
            }
            return result;
        }

        public async Task<string> Login(EmployeeLogin  userModel)
        {
            string result = "false";
            var tempResult = await signInManager.PasswordSignInAsync(userModel.EmailId, userModel.password, false, false);

            if (tempResult.Succeeded)
            {
                result = "true";
                return result;
            }
            result = "Invalid Login Attempt";
            return result;
        }

        public async Task<bool> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
