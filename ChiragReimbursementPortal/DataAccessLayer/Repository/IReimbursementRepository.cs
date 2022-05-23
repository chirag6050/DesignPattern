using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public  interface IReimbursementRepository
    {
        Task<bool> AddReimbursement(ReimbursementD reimbursementDetails);
        Task<List<ReimbursementD>> GetAllReimbursement();
        Task<ReimbursementD> GetReimbursementById(int? id);

        Task<bool> Update(int id, ReimbursementD reimbursementDetails);

        Task<bool> DeleteR(int id);

    }
}