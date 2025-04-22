namespace Library_Management_System.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        //cont...
        public virtual ICollection<BorrowRequest> BorrowRequests { get; set; }
    }
}
