using AutoMapper;
using BusinessLayer.DTO;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepository _accountRepository = null;
        private readonly IMapper _mapper;
        public AccountServices(IAccountRepository accountRepository, IMapper mapper)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        public async Task<string> SignUp(ESignUpDTO userModel)
        {
            var userDomain = _mapper.Map<ESignUpDTO, EmployeeSignup>(userModel);
            return await _accountRepository.SignUp(userDomain);
        }

        public async Task<string> Login(ELoginDTO userModel)
        {
            var userDomain = _mapper.Map<ELoginDTO, EmployeeLogin>(userModel);
            return await _accountRepository.Login(userDomain);
        }

        public async Task<bool> Logout()
        {
            return await _accountRepository.Logout();
        }
    }
}
