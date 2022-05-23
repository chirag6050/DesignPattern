using BusinessLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IReimbursementService
    {
        Task<bool> AddReimbursement(ReimbursementDTO reimbursementDetail);
        Task<List<ReimbursementDTO>> GetAllReimbursement();
        Task<ReimbursementDTO> GetReimbursementById(int? id);
        Task<bool> Update(int id, ReimbursementDTO reimbursementDetail);
        
        Task<bool> DeleteR(int id);
    }
}