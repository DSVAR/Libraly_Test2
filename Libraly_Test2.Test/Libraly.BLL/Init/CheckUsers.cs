using System.Collections.Generic;
using Libraly.BLL.Initialization;
using NUnit.Framework;

namespace Libraly_Test2.Test.Libraly.BLL.Init
{
    public class CheckUsers
    {
        [Test]
        public void Test_CheckSum()
        {
            var count = new DefaultUsers().Users().Count;
            Assert.AreEqual(3,count);
        }
        [Test]
        public void Test_Users()
        {
          
            string admin = "Администратор";
            string libr = "Библиотекарь";
            string simpleUser="Пользователь";
            
            
            var users = new DefaultUsers().Users();
    
            Assert.AreEqual(admin,users[0].UserName);
            Assert.AreEqual(libr,users[1].UserName);
            Assert.AreEqual(simpleUser,users[2].UserName);
            
            
        }
    }
}