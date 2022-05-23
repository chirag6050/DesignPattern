using DataAccessLayer.Data;
using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ReimbursementRepository : IReimbursementRepository
    {
        //instance of DB Context
        public ReimbDBContext _dbContext;

        //constructor
        public ReimbursementRepository(ReimbDBContext context)
        {
            _dbContext = context;
        }

        //add
        public async Task<bool> AddReimbursement(ReimbursementD reimbursementDetails)
        {
            _dbContext.ReimburesementDetailDb.Add(reimbursementDetails);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        //update
        public async Task<bool> Update(int id, ReimbursementD reimbursementDetails)
        {
            if(id!= reimbursementDetails.EmployeeId)
            {
                return false;
            }
            /*_dbContext.ReimburesementDetailDb.Update(reimbursementDetails);*/
            _dbContext.Entry(reimbursementDetails).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        //list of all reimburement claim
        public async Task<List<ReimbursementD>> GetAllReimbursement()
        {
            return await _dbContext.ReimburesementDetailDb.ToListAsync();
        }

        //get reimbursement by id
        public async Task<ReimbursementD> GetReimbursementById(int? id)
        {
            return await _dbContext.ReimburesementDetailDb.Where(x => x.EmployeeId == id).FirstAsync();
        }

        public async Task<bool> DeleteR(int id)
        {
            var ReimbDetail = await _dbContext.ReimburesementDetailDb.FindAsync(id);
            if (ReimbDetail == null)
            {
                return false;
            }

            _dbContext.ReimburesementDetailDb.Remove(ReimbDetail);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
