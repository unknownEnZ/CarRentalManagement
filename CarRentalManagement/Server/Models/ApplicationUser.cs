using Microsoft.AspNetCore.Identity;

namespace CarRentalManagement.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        //? is for able to detect/accept null otherwise the system will run into error
        public string? LastName { get; set; }

    }
}
