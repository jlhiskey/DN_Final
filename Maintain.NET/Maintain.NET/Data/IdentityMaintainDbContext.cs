using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain.NET.Data
{
    public class IdentityMaintainDbContext : DbContext
    {
        public IdentityMaintainDbContext(DbContextOptions<IdentityMaintainDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Add Seeds here


        }

        //TODO: Add table references here.

    }
}
