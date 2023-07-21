using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazarGalic10420.Business
{
    public class RegisterUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? IdentityNumber { get; set; }
        public string? PhoneNumber { get; set; }
    }


    public class AdminSelectRegisteredUsersDto
    {
        public int Id { get; set; }
        public SelectRoleAdmin? Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string? IdentityNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastUpdatedAt { get; set; }
        public string DeletedAt { get; set; }
    }

    public class SelectRoleAdmin
    {
        public int RoleId { get; set; }
        public string NameRole { get; set; }
    }

    public class UpdateOneUserDto
    {
        public int IdUserToUpdate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }  //Nikad nece stizati sa fronta
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityNumber { get; set; }

        //Posts
    }


}
