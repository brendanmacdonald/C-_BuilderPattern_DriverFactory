using System; 

namespace TestSuite.Model
{
	public class User
	{
		public String username { get; }

		public String password { get; }

		public UserType usertype { get;  }

		public enum UserType
		{
			Standard,
			Admin,
			Super
		};

		public User(UserBuilder builder)
		{
			this.username = builder.username;
			this.password = builder.password;
			this.usertype = builder.usertype;
		}
	}

}