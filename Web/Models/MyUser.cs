using Microsoft.AspNetCore.Identity;
using System.Drawing;

namespace Web.Models
{
    public class MyUser : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        //public string Role {  get; set; }

    }
}
