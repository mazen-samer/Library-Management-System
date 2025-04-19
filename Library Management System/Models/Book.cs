namespace Library_Management_System.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string CoverImagePath { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }

        public virtual ICollection<BorrowRequest> BorrowRequests { get; set; } = new List<BorrowRequest>();
    }
}
