using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace byudigs.Models
{
	public class PasswordHasher : IPasswordHasher<IdentityBuilder>
	{
		//an instance of the default password hasher
		IPasswordHasher<IdentityBuilder> _identityPasswordHasher = new PasswordHasher<IdentityBuilder>();

		//Hashes the password using old algorithm from the days of ASP.NET Membership
		internal static string HashPasswordInOldFormat(string password)
		{
			var sha1 = new SHA1CryptoServiceProvider();
			var data = Encoding.ASCII.GetBytes(password);
			var sha1data = sha1.ComputeHash(data);
			return Convert.ToBase64String(sha1data);
		}

		//the passwords of the new users will be hashed with new algorithm
		public string HashPassword(IdentityBuilder user, string password)
		{
			return _identityPasswordHasher.HashPassword(user, password);
		}

		public PasswordVerificationResult VerifyHashedPassword(IdentityBuilder user,
					string hashedPassword, string providedPassword)
		{
			string pwdHash2 = HashPasswordInOldFormat(providedPassword);


			if (hashedPassword == pwdHash2)
			{
				//first we check the hashed password with "old" hash
				return PasswordVerificationResult.Success;
			}
			else
			{
				//if old hash doesn't work - use the default approach 
				return _identityPasswordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
			}
		}
	}
}





