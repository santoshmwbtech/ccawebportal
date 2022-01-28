using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBT.DLCustomerCreation
{
    public class Login
    {
        [Required(ErrorMessage = " Enter EmailID")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = " Enter Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class UserLogin
    {
        public int UserId { get; set; }
        public string FName { get; set; }
        public int RoleID { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string OrgID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string OrgName { get; set; }
        public string Message { get; set; }
        public string EmailID { get; set; }
        public bool IsServiceInstalled { get; set; }
        public bool IsTallyUsing { get; set; }
    }
}
