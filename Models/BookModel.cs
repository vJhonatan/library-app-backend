﻿namespace Library_Backend.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? AuthorName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Quantity { get; set; }
    }
}
