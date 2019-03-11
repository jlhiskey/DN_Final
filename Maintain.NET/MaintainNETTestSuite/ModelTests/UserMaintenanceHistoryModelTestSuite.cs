using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Maintain.NET.Models;

namespace MaintainNETTestSuite.ModelTests
{
    public class UserMaintenanceHistoryModelTestSuite
    {

        public UserMaintenanceTask CreateUserMaintenanceTask()
        {
            MaintenanceTask testMaintenanceTask = CreateMaintenanceTask();

            UserMaintenanceTask testUserMaintenanceTask = new UserMaintenanceTask("jimbob@test.com", testMaintenanceTask.ID)
            {
                ID = 1,
                LastComplete = 1,
                NextComplete = 2,
                MaintenanceTask = testMaintenanceTask
            };
            return testUserMaintenanceTask;
        }

        public MaintenanceTask CreateMaintenanceTask()
        {
            MaintenanceTask testMaintenanceTask = new MaintenanceTask("testName")
            {
                ID = 1,
                RecommendedInterval = 12,
            };
            return testMaintenanceTask;
        }

        public UserMaintenanceHistory CreateUserMaintenanceHistory()
        {
            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();
            UserMaintenanceHistory testUserMaintenanceHistory = new UserMaintenanceHistory()
            {
                ID = 1,
                UserID = testUserMaintenanceTask.UserID,
                UserMaintenanceTaskID = testUserMaintenanceTask.ID,
                TimeComplete = DateTime.Now,
                UserMaintenanceTask = testUserMaintenanceTask
            };
            return testUserMaintenanceHistory;
        }

        [Fact]
        public void TestIDSet()
        {
            UserMaintenanceHistory testUserMaintenanceHistory = CreateUserMaintenanceHistory();

            testUserMaintenanceHistory.ID = 100;

            Assert.Equal(100, testUserMaintenanceHistory.ID);
        }

        [Fact]
        public void TestIDGet()
        {
            UserMaintenanceHistory testUserMaintenanceHistory = CreateUserMaintenanceHistory();

            Assert.Equal(1, testUserMaintenanceHistory.ID);
        }

        [Fact]
        public void TestUserIDSet()
        {

            UserMaintenanceHistory testUserMaintenanceHistory = CreateUserMaintenanceHistory();

            testUserMaintenanceHistory.UserID = "ImATest@test.com";

            Assert.Equal("ImATest@test.com", testUserMaintenanceHistory.UserID);
        }

        [Fact]
        public void TestUserIDGet()
        {
            UserMaintenanceHistory testUserMaintenanceHistory = CreateUserMaintenanceHistory();

            Assert.Equal("jimbob@test.com", testUserMaintenanceHistory.UserID);
        }

        [Fact]
        public void TestUserMaintenanceTaskIDSet()
        {

            UserMaintenanceHistory testUserMaintenanceHistory = CreateUserMaintenanceHistory();

            testUserMaintenanceHistory.UserMaintenanceTaskID = 100;

            Assert.Equal(100, testUserMaintenanceHistory.UserMaintenanceTaskID);
        }

        [Fact]
        public void TestUserMaintenanceTaskIDGet()
        {
            UserMaintenanceHistory testUserMaintenanceHistory = CreateUserMaintenanceHistory();

            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();

            Assert.Equal(testUserMaintenanceTask.ID, testUserMaintenanceHistory.UserMaintenanceTaskID);
        }

        [Fact]
        public void TestTimeCompleteSet()
        {

            UserMaintenanceHistory testUserMaintenanceHistory = CreateUserMaintenanceHistory();

            DateTime testTime = DateTime.Today;

            testUserMaintenanceHistory.TimeComplete = testTime;

            Assert.Equal(testTime, testUserMaintenanceHistory.TimeComplete);
        }

        [Fact]
        public void TestTimeCompleteGet()
        {
            UserMaintenanceHistory testUserMaintenanceHistory = CreateUserMaintenanceHistory();

            DateTime currentTime = testUserMaintenanceHistory.TimeComplete;

            Assert.Equal(currentTime, testUserMaintenanceHistory.TimeComplete);
        }

        [Fact]
        public void TestUserMaintenanceTaskSet()
        {

            UserMaintenanceHistory testUserMaintenanceHistory = CreateUserMaintenanceHistory();

            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();
            testUserMaintenanceTask.ID = 2;

            testUserMaintenanceHistory.UserMaintenanceTask = testUserMaintenanceTask;

            Assert.Equal(testUserMaintenanceTask, testUserMaintenanceHistory.UserMaintenanceTask);
        }

        [Fact]
        public void TestUserMaintenanceTaskGet()
        {
            UserMaintenanceHistory testUserMaintenanceHistory = CreateUserMaintenanceHistory();

            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();


            Assert.Equal(testUserMaintenanceTask.ID, testUserMaintenanceHistory.UserMaintenanceTask.ID);
        }
    }
}
