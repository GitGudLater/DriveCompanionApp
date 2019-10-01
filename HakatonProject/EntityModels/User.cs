using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace HakatonProject.EntityModels
{
    public class User//:IdentityUser
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        //Driver entity(one-to-one)
        public Car Car { get; set; }

        //Companion entity(many-to-one)
        public UserCar UserCar { get; set; }

        public ICollection<CompanionRequest> CompanionRequest { get; set; }

        public User()
        {
            CompanionRequest = new List<CompanionRequest>();
        }
    }
}
