using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Maintain.NET.Models.Services;
using Maintain.NET.Data;
using Microsoft.EntityFrameworkCore;
using Maintain.NET.Models;

namespace MaintainNETTestSuite.ServiceTests
{
    public class UserTaskManagementTests
    {
        [Fact]
        public async void CanCreateUserTask()
        {
            DbContextOptions<MaintainDbContext> options =
                new DbContextOptionsBuilder<MaintainDbContext>().UseInMemoryDatabase("CreateUserTask").Options;

            using(MaintainDbContext context = new MaintainDbContext(options))
            {
                UserMaintenanceTask userMaintenance = new UserMaintenanceTask();

            }
        }
    }
}
