using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Maintain.NET.Models;

namespace MaintainNETTestSuite.ModelTests
{
    public class UserMaintenanceTaskModelTestSuite
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
            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();

            testUserMaintenanceTask.ID = 100;

            Assert.Equal(100, testUserMaintenanceTask.ID);
        }

        [Fact]
        public void TestIDGet()
        {
            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();

            Assert.Equal(1, testUserMaintenanceTask.ID);
        }

        [Fact]
        public void TestUserIDSet()
        {

            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();

            testUserMaintenanceTask.UserID = "ImATest@test.com";

            Assert.Equal("ImATest@test.com", testUserMaintenanceTask.UserID);
        }

        [Fact]
        public void TestUserIDGet()
        {
            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();
            
            Assert.Equal("jimbob@test.com", testUserMaintenanceTask.UserID);
        }

        [Fact]
        public void TestMaintenanceTaskIDSet()
        {

            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();

            testUserMaintenanceTask.MaintenanceTaskID = 100;

            Assert.Equal(100, testUserMaintenanceTask.MaintenanceTaskID);
        }

        [Fact]
        public void TestMaintenanceTaskIDGet()
        {
            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();
            MaintenanceTask testMaintenanceTask = CreateMaintenanceTask();

            Assert.Equal(testMaintenanceTask.ID, testUserMaintenanceTask.MaintenanceTaskID);
        }

        [Fact]
        public void TestLastCompleteSet()
        {
            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();

            testUserMaintenanceTask.LastComplete = 100;

            Assert.Equal(100, testUserMaintenanceTask.LastComplete);
        }

        [Fact]
        public void TestLastCompleteGet()
        {
            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();

            Assert.Equal(1, testUserMaintenanceTask.LastComplete);
        }

        [Fact]
        public void TestNextCompleteSet()
        {
            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();

            testUserMaintenanceTask.NextComplete = 100;

            Assert.Equal(100, testUserMaintenanceTask.NextComplete);
        }

        [Fact]
        public void TestNextCompleteGet()
        {
            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();

            Assert.Equal(2, testUserMaintenanceTask.NextComplete);
        }

        [Fact]
        public void TestMaintenanceTaskSet()
        {
            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();
            MaintenanceTask testMaintenanceTask = CreateMaintenanceTask();
            testMaintenanceTask.ID = 2;

            testUserMaintenanceTask.MaintenanceTask = testMaintenanceTask;


            Assert.Equal(testMaintenanceTask, testUserMaintenanceTask.MaintenanceTask);
        }

        [Fact]
        public void TestMaintenanceTaskGet()
        {
            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();

            Assert.Equal(2, testUserMaintenanceTask.NextComplete);
        }

        [Fact]
        public void TestUserMaintenanceHistorySet()
        {
            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();

            UserMaintenanceHistory testHistoryOne = CreateUserMaintenanceHistory();
            UserMaintenanceHistory testHistoryTwo = CreateUserMaintenanceHistory();
            testHistoryTwo.ID = 2;

            List<UserMaintenanceHistory> expected = new List<UserMaintenanceHistory>() { testHistoryOne };

            testUserMaintenanceTask.UserMaintenanceHistory = expected;

            expected.Add(testHistoryTwo);

            testUserMaintenanceTask.UserMaintenanceHistory = expected;

            Assert.Same(expected, testUserMaintenanceTask.UserMaintenanceHistory);
        }

        [Fact]
        public void TestUserMaintenanceHistoryGet()
        {
            UserMaintenanceTask testUserMaintenanceTask = CreateUserMaintenanceTask();

            UserMaintenanceHistory testHistoryOne = CreateUserMaintenanceHistory();

            List<UserMaintenanceHistory> expected = new List<UserMaintenanceHistory>() { testHistoryOne };

            testUserMaintenanceTask.UserMaintenanceHistory = expected;

            Assert.Same(expected, testUserMaintenanceTask.UserMaintenanceHistory);
        }
    }
}
