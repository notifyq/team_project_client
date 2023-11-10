using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team_project.Model
{
    internal class User
    {
        public int idUser { get; set; }
        public string userLogin { get; set; }
        public object userPassword { get; set; }
        public object userName { get; set; }
        public string userEmail { get; set; }
        public object userImage { get; set; }
        public object userRole { get; set; }
        public object userStatus { get; set; }
        public UserRoleNavigation userRoleNavigation { get; set; }
        public object userStatusNavigation { get; set; }
        public List<object> libraries { get; set; }
        public static string token { get; set; }

        
    }
}
