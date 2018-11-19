using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnguCore.Infrastructure.Data.Identity
{
    public class ApplicationIdentityUserRole : IdentityUserRole<int>
    {
        //[ForeignKey("RoleId")]
        //public ApplicationIdentityRole Role { get; set; }

        //[ForeignKey("UserId")]
        //public ApplicationIdentityUser User { get; set; }
    }
}
