using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YumYumExpress.View;

namespace YumYumExpress.Controller
{
    public class UserController
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public long ContactNo { get; set; }

        public UserType userType { get; set; }
    }
}
