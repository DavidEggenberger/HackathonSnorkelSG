using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string PictureUri { get; set; }
    }
}
