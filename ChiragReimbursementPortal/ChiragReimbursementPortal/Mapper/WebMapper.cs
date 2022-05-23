using AutoMapper;
using BusinessLayer.DTO;
using ChiragReimbursementPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiragReimbursementPortal.Mapper
{
    public class WebMapper :Profile
    {
        public WebMapper() : base("WebMapper")
        {
            CreateMap<RDetailModel, ReimbursementDTO>().ReverseMap();
            CreateMap<SignUpModel, ESignUpDTO>().ReverseMap();
            CreateMap<LoginModel, ELoginDTO>().ReverseMap();
        }
    }
}
