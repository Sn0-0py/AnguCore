using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnguCore.Infrastructure.Data.Identity
{
    public class ApplicationIdentityUserClaim: IdentityUserClaim<int>
    {
    }
}
