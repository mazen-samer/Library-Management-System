namespace Library_Management_System.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
