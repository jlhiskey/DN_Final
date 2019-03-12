using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Maintain.NET.Models.ViewModels;

namespace MaintainNETTestSuite.ViewModelTests
{
    public class RegisterViewModelTest
    {
        [Fact]
        public void RegisterViewModelGetWorks()
        {
            //arrange
            LoginViewModel registerViewModel = new LoginViewModel();
            registerViewModel.FirstName = "Jason";

            //Assert
            Assert.Equal("Jason", registerViewModel.FirstName);
        }

        [Fact]
        public void RegisterViewModelGetWorks2()
        {
            //arrange
            LoginViewModel registerViewModel = new LoginViewModel();
            registerViewModel.FirstName = "Jason";
            registerViewModel.LastName = "Few";

            //Assert
            Assert.Equal("Few", registerViewModel.LastName);
        }

        [Fact]
        public void RegisterViewModelGetWorks3()
        {
            //arrange
            LoginViewModel registerViewModel = new LoginViewModel();
            registerViewModel.FirstName = "Jason";
            registerViewModel.LastName = "Few";
            registerViewModel.Email = "this@that.com";

            //Assert
            Assert.Equal("this@that.com", registerViewModel.Email);
        }

        [Fact]
        public void RegisterViewModelGetWorks4()
        {
            //arrange
            LoginViewModel registerViewModel = new LoginViewModel();
            registerViewModel.FirstName = "Jason";
            registerViewModel.LastName = "Few";
            registerViewModel.Email = "this@that.com";
            registerViewModel.Password = "hi";

            //Assert
            Assert.Equal("hi", registerViewModel.Password);
        }

        [Fact]
        public void RegisterViewModelGetWorks5()
        {
            //arrange
            LoginViewModel registerViewModel = new LoginViewModel();
            registerViewModel.FirstName = "Jason";
            registerViewModel.LastName = "Few";
            registerViewModel.Email = "this@that.com";
            registerViewModel.Password = "hi";
            registerViewModel.Zip = 98106;

            //Assert
            Assert.Equal(98106, registerViewModel.Zip);
        }

        [Fact]
        public void RegisterViewModelSetWorks()
        {
            //arrange
            LoginViewModel registerViewModel = new LoginViewModel();
            registerViewModel.FirstName = "Jason";
            registerViewModel.LastName = "Few";
            registerViewModel.Email = "this@that.com";
            registerViewModel.Password = "hi";

            //Act
            registerViewModel.FirstName = "Tom";

            //Assert
            Assert.Equal("Tom", registerViewModel.FirstName);
        }

        [Fact]
        public void RegisterViewModelSetWorks2()
        {
            //arrange
            LoginViewModel registerViewModel = new LoginViewModel();
            registerViewModel.FirstName = "Jason";
            registerViewModel.LastName = "Few";
            registerViewModel.Email = "this@that.com";
            registerViewModel.Password = "hi";

            //Act
            registerViewModel.LastName = "Jones";

            //Assert
            Assert.Equal("Jones", registerViewModel.LastName);
        }

        [Fact]
        public void RegisterViewModelSetWorks3()
        {
            //arrange
            LoginViewModel registerViewModel = new LoginViewModel();
            registerViewModel.FirstName = "Jason";
            registerViewModel.LastName = "Few";
            registerViewModel.Email = "this@that.com";
            registerViewModel.Password = "hi";

            //Act
            registerViewModel.Email = "that@that.com";

            //Assert
            Assert.Equal("that@that.com", registerViewModel.Email);
        }

        [Fact]
        public void RegisterViewModelSetWorks4()
        {
            //arrange
            LoginViewModel registerViewModel = new LoginViewModel();
            registerViewModel.FirstName = "Jason";
            registerViewModel.LastName = "Few";
            registerViewModel.Email = "this@that.com";
            registerViewModel.Password = "hi";

            //Act
            registerViewModel.Password = "bye";

            //Assert
            Assert.Equal("bye", registerViewModel.Password);
        }

        [Fact]
        public void RegisterViewModelSetWorks5()
        {
            //arrange
            LoginViewModel registerViewModel = new LoginViewModel();
            registerViewModel.FirstName = "Jason";
            registerViewModel.LastName = "Few";
            registerViewModel.Email = "this@that.com";
            registerViewModel.Password = "hi";
            registerViewModel.Zip = 98106;

            //Act
            registerViewModel.Zip = 98101;

            //Assert
            Assert.Equal(98106, registerViewModel.Zip);
        }


    }
}
