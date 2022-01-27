using ApiRestAtos.Area.Admin.Controllers;
using ApiRestAtosDataAccess.Data.Repository;
using ApiRestAtosModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace Test
{
    public class ControllerProfilesTestitory
    {
        [Fact]
        public void GetAll()
        {
            //Arrange
            var ProfileServiceMock = new Mock<IWorkContainer>();
            ProfileServiceMock.Setup(c => c.User.GetAll()).Returns(() => new List<Profile>());


            //Act
            var controller = new ProfilesController(ProfileServiceMock.Object);

            var result = controller.GetAll();
            var Profiles = result.Result;
            //Assert 
            Assert.Equal()
        }

    }
}