using Core.Rules;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class UserTest
    {
        private readonly IUserRule _userRule;
        
        public UserTest(IUserRule user)
        {
            _userRule = user;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var user = _userRule.ListUser("tadeu.leao", "tadeuleao");
            Assert.AreEqual("tadeu.leao" , user.Login);
        }
    }
}