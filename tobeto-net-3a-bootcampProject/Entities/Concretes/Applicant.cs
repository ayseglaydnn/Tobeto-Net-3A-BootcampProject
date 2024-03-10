using Core.Utilities.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Applicant : User
    {
        public string About { get; set; }

        public virtual ICollection<Application>? Applications { get; set; }
        public virtual Blacklist? Blacklist { get; set; }

        public Applicant(int id,string userName, string firstName, string lastName, DateTime dateOfBirth, 
            string nationalIdentity, string email, byte[] passwordHash, byte[] passwordSalt, string about) : this()
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
            About = about;
        }
        public Applicant()
        {
            Applications = new HashSet<Application>();
        }

    }
}
