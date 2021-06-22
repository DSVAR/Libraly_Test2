using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using Libraly.BLL.Configures;
using Libraly.BLL.Interfaces;
using Libraly.BLL.Models.UserDTO;
using Libraly.BLL.Services;
using Libraly.Data.Entities;
using Libraly_Test2.Controllers;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using static Microsoft.AspNetCore.Identity.IdentityResult;

namespace Libraly_Test2.Test.Libraly.BLL.Serices
{
    public class CheckUserService
    {
     



    private User first = new User();
        private User second = new User();
        private RegisterViewModel newUser = new RegisterViewModel();
       
        void SetingUsers()
        {
            first.Password = "First";
            first.UserName = "First";
            first.Email = "First@mail.ru";
            
            newUser.Password = "NewUser";
            newUser.UserName = "NewUser";
            newUser.Email = "NewUser@mail.ru";
            
            second.Password = "second";
            second.UserName = "second";
            second.Email = "second@mail.ru";
        }
        
        
        
        
        [Test]
        public void CheckGetUsers()
        {
            SetingUsers();            
            //добавляем пользователей и данные в них
            var imapper = new Mock<IMapper>();
            var moc = new Mock<IUserService>();
            moc.Setup(a=>a.GetUsers()).Returns( new List<User>(){first,second}.AsQueryable() );
            //настраиваем moc 
            
           var userController = new TestController(moc.Object);
                     // прокидываем в контроллер. сервис
            var countUsers = userController.getUser();
            // получаем пользователей

            Assert.AreEqual(2,countUsers.Count());
            //проверяем

        }

        [Test]
        public void CheckAddUser()
        {
            SetingUsers();
            
            var moc = new Mock<IUserService>();
            moc.Setup(c => c.Create(It.IsAny<RegisterViewModel>()))
                .Returns<IdentityResult>("не знаю что тут возращать");
            

            var userController = new TestController(moc.Object);

            var result = userController.Create(newUser).Result;
        }
        
    }
}