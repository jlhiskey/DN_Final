using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Maintain.NET.Models;

namespace MaintainNETTestSuite.ModelTests
{
    public class MaintenanceTaskModelTestSuite
    {
        public UserMaintenanceTask CreateUserMaintenanceTask()
        {
            UserMaintenanceTask testUserMaintenanceTask = new UserMaintenanceTask("jimbob@test.com", 1)
            {
                LastComplete = 1,
                NextComplete = 2,              
            };
            return testUserMaintenanceTask;
        }

        public MaintenanceTask CreateMaintenanceTask()
        {
            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();

            List<UserMaintenanceTask> userMaintenanceTasks = new List<UserMaintenanceTask>();
            userMaintenanceTasks.Add(testUserMaintenanceTask);


            MaintenanceTask testMaintenanceTask = new MaintenanceTask("testName")
            {
                ID = 1,
                RecommendedInterval = 12,
                UserMaintenanceTasks = userMaintenanceTasks
            };
            return testMaintenanceTask;
        }


        [Fact]
        public void TestIDSet()
        {
            MaintenanceTask testMaintenanceTask = CreateMaintenanceTask();

            testMaintenanceTask.ID = 100;

            Assert.Equal(100, testMaintenanceTask.ID);
        }

        [Fact]
        public void TestIDGet()
        {
            MaintenanceTask testMaintenanceTask = CreateMaintenanceTask();

            Assert.Equal(1, testMaintenanceTask.ID);
        }

        [Fact]
        public void TestNameSet()
        {
            MaintenanceTask testMaintenanceTask = CreateMaintenanceTask();

            testMaintenanceTask.Name = "JimBob";

            Assert.Equal("JimBob", testMaintenanceTask.Name);
        }

        [Fact]
        public void TestNameGet()
        {
            MaintenanceTask testMaintenanceTask = CreateMaintenanceTask();

            Assert.Equal("testName", testMaintenanceTask.Name);
        }

        [Fact]
        public void TestRecommendedIntervalSet()
        {
            MaintenanceTask testMaintenanceTask = CreateMaintenanceTask();

            testMaintenanceTask.RecommendedInterval = 100;

            Assert.Equal(100, testMaintenanceTask.RecommendedInterval);
        }

        [Fact]
        public void TestRecommendedIntervalGet()
        {
            MaintenanceTask testMaintenanceTask = CreateMaintenanceTask();

            Assert.Equal(12, testMaintenanceTask.RecommendedInterval);
        }

        [Fact]
        public void TestUserMaintenanceTasksSet()
        {
            MaintenanceTask testMaintenanceTask = CreateMaintenanceTask();

            UserMaintenanceTask testTaskOne = CreateUserMaintenanceTask();
            UserMaintenanceTask testTaskTwo = CreateUserMaintenanceTask();
            testTaskTwo.ID = 2;

            testMaintenanceTask.UserMaintenanceTasks.Add(testTaskTwo);

            List<UserMaintenanceTask> expected = new List<UserMaintenanceTask>() { testTaskOne, testTaskTwo };

            Assert.Same(expected, testMaintenanceTask.UserMaintenanceTasks);
        }

        [Fact]
        public void TestUserMaintenanceTasksGet()
        {
            MaintenanceTask testMaintenanceTask = CreateMaintenanceTask();

            UserMaintenanceTask testTaskOne = CreateUserMaintenanceTask();            

            List<UserMaintenanceTask> expected = new List<UserMaintenanceTask>() { testTaskOne };

            Assert.Same(expected, testMaintenanceTask.UserMaintenanceTasks);
        }
        
    }
}
