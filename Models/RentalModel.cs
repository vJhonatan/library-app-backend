namespace Library_Backend.Models
{
    public class RentalModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public DateTime BirthDate { get; set; }

        public int BookId { get; set; }

        public DateTime Created_at { get; set; }

        public DateTime? Updated_at { get; set; }
    }
}
