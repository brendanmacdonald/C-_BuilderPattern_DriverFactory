using System;
using static TestSuite.Model.User;
namespace TestSuite.Model
{
	public class UserBuilder
	{
		public String username;
		public String password;
		public UserType usertype;

		public UserBuilder Username(String username)
		{
			this.username = username;
			return this;
		}

		public UserBuilder Password(String password)
		{
			this.password = password;
			return this;
		}

		public UserBuilder Usertype(UserType usertype)
		{
			this.usertype = usertype;
			return this;
		}

		public User Build()
		{
			return new User(this);
		}
	}
}
