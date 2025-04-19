using Microsoft.AspNetCore.Identity;

namespace Library_Management_System.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<BorrowRequest> BorrowRequests { get; set; }
    }
}
