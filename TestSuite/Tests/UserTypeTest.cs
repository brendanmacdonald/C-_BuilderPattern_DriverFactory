using NUnit.Framework;
using System;
using TestSuite.Model;

namespace TestSuite.Tests
{
    [TestFixture]
    public class UserTypeTest
    {
        [Test(Description = "Check User types - enum declared within User class")]
        public void VerifyUserTypeEnum()
        {
            User u2 = new UserBuilder().Username("u2").Usertype(User.UserType.Standard).Build();
            User u3 = new UserBuilder().Username("u3").Usertype(User.UserType.Super).Build();

            if (u2.usertype == User.UserType.Standard)
            {
                Console.WriteLine("u2 is a standard user");
            }
        }
    }
}
