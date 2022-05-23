using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Services;
using ChiragReimbursementPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiragReimbursementPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountServices accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }
        //POST : /api/AccountController/SignUp
        [HttpPost]
        [Route("Register")]
        public async Task<Object> SignUp(SignUpModel userModel)
        {
            if (ModelState.IsValid)
            {
                var signUpDTO = _mapper.Map<SignUpModel, ESignUpDTO>(userModel);
                var result = await _accountService.SignUp(signUpDTO);
                if (result == "true")
                {
                    return Ok(result);
                }
            }
            return false;
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/AccountController/Login
        public async Task<ActionResult<bool>> Login(LoginModel userModel)
        {
            if (ModelState.IsValid)
            {
                var loginDTO = _mapper.Map<LoginModel, ELoginDTO>(userModel);
                var result = await _accountService.Login(loginDTO);
                if (result == "true")
                {
                    return true;
                }
            }
            return BadRequest(new { message = "Username or password is incorrect." });
        }
        [HttpPost]
        [Route("Logout")]
        //POST : /api/ApplicationUser/Logout
        public async Task<ActionResult<bool>> Logout()
        {
            var result = await _accountService.Logout();
            return result;
        }
    }
}
