using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonProject.ViewModels.UserModels
{
    public class UserInformation
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public string CarRegistered { get; set; }

        public List<string> CarSubscribed { get; set; }
    }
}
