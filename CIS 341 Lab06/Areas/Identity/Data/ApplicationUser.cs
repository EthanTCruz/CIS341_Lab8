using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CIS_341_Lab06.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    /* This is used to link the Identity user account to the application user.
     * Think of it as a cross-database foreign key.
     */
    public int UserAccountId { get; set; }
}

