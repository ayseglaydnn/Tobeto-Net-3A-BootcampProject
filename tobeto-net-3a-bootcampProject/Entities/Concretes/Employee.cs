using Core.Utilities.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Employee : User
    {
        public string Position { get; set; }

        public Employee(int id, string userName, string firstName, string lastName, DateTime dateOfBirth, 
            string nationalIdentity, string email, byte[] passwordHash, byte[] passwordSalt, string position)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Position = position;
        }

        public Employee()
        {
            
        }
    }
}
