using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Maintain.NET.Models.ViewModels;

namespace MaintainNETTestSuite.ViewModelTests
{
    public class LoginViewModelTests
    {
        [Fact]
        public void LoginViewModelGetWorks()
        {
            //arrange
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Email = "j@j.com";

            //Assert
            Assert.Equal("j@j.com", loginViewModel.Email);
        }

        [Fact]
        public void LoginViewModelGetWorks2()
        {
            //arrange
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Email = "j@j.com";
            loginViewModel.Password = "123";

            //Assert
            Assert.Equal("123", loginViewModel.Password);
        }

        [Fact]
        public void LoginViewModelSetWorks()
        {
            //arrange
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Email = "j@j.com";
            loginViewModel.Password = "123";

            //Act
            loginViewModel.Email = "j@a.com";

            //Assert
            Assert.Equal("j@a.com", loginViewModel.Email);
        }

        [Fact]
        public void LoginViewModelSetWorks2()
        {
            //arrange
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Email = "j@j.com";
            loginViewModel.Password = "123";

            //Act
            loginViewModel.Password = "321";

            //Assert
            Assert.Equal("321", loginViewModel.Password);
        }
    }
}
