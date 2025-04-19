namespace Library_Management_System.Models
{
    public class BorrowRequest
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;
        public string Status { get; set; } // Pending, Approved, Denied, Direct

        public DateTime? ApprovedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
