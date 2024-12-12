namespace Library_Backend.Models
{
    public class RentModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public int BirthDate { get; set; }

        public int BookId { get; set; }

        public DateTime Created_at { get; set; }

        public DateTime? Updated_at { get; set; }
    }
}
