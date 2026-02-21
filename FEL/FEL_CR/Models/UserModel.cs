using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FELCR.Models
{
    public partial class UserModel
    {
        public int Id { get; set; }
        public RoleModel role { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool UserStatus { get; set; }
        public string FullName { get; set; }
    }
}
