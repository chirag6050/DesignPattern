using AutoMapper;
using BusinessLayer.DTO;
using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapper
{
   public  class ProfileMapper :Profile
    {
        public ProfileMapper() : base("ProfileMapper")
        {
            CreateMap<ReimbursementDTO, ReimbursementD>().ReverseMap();
            CreateMap<ELoginDTO, EmployeeLogin>().ReverseMap();
            CreateMap<ESignUpDTO, EmployeeSignup>().ReverseMap();

        }
    }
}
