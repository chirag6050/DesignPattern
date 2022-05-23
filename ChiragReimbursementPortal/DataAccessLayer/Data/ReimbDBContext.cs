using DataAccessLayer.Entity;
using DataAccessLayer.IdentityModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
   public  class ReimbDBContext : IdentityDbContext
    {

        public ReimbDBContext(DbContextOptions<ReimbDBContext> options) : base(options)
        {

        }

        public DbSet<ReimbursementD> ReimburesementDetailDb { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


    }
}

