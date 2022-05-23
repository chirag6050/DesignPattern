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
    public class ReimbursementService : IReimbursementService
    {
        private readonly IReimbursementRepository reimbursementRepository;
        private readonly IMapper mapper;
        public ReimbursementService(IReimbursementRepository _reimbursementRepository, IMapper _mapper)
        {
            mapper = _mapper;
            reimbursementRepository = _reimbursementRepository;
        }
        public async Task<bool> AddReimbursement(ReimbursementDTO reimbursementDetail)
        {
            var newReimbursement = mapper.Map<ReimbursementDTO, ReimbursementD>(reimbursementDetail);
            await reimbursementRepository.AddReimbursement(newReimbursement);
            return true;
        }

        public async Task<List<ReimbursementDTO>> GetAllReimbursement()
        {
            var listOfReimbursement = await reimbursementRepository.GetAllReimbursement();
            return mapper.Map<List<ReimbursementD>, List<ReimbursementDTO>>(listOfReimbursement);
        }


        public async Task<ReimbursementDTO> GetReimbursementById(int? id)
        {
            var reimbursementById = await reimbursementRepository.GetReimbursementById(id);
            return mapper.Map<ReimbursementD, ReimbursementDTO>(reimbursementById);
        }

        public async Task<bool> Update(int id, ReimbursementDTO reimbursementDetail)
        {
            var newReimbursement = mapper.Map<ReimbursementDTO, ReimbursementD>(reimbursementDetail);
            await reimbursementRepository.Update(id,newReimbursement);
            return true;
        }

        public async Task<bool> DeleteR(int id)
        {
            return await reimbursementRepository.DeleteR(id);
           
        }
    }
}
