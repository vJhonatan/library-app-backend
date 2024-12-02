namespace Library_Backend.Models
{
    public class RentalModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public int IdBook { get; set; }

        public DateTime RentalDate { get; set; }
    }
}
