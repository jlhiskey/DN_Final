using Maintain.NET.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain.NET.Data
{
    public class IdentityMaintainDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityMaintainDbContext(DbContextOptions<IdentityMaintainDbContext> options) : base(options)
        {

        }

     

    }
}
