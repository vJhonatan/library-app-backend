using Library_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library_Backend.Requests;

namespace Library_Backend.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<BookModel> Books = new List<BookModel>
        {
            new BookModel
            {
                Id = 1,
                Name = "Dom Casmurro",
                AuthorName = "Machado de Assis",
                ReleaseYear = 1899,
                Quantity = 2
            },

            new BookModel
            {
                Id = 2,
                Name = "Memórias Póstumas de Brás Cubas",
                AuthorName = "Machado de Assis",
                ReleaseYear = 1881,
                Quantity = 3
            },

            new BookModel
            {
                Id = 3,
                Name = "Grande Sertão: Veredas",
                AuthorName = "João Guimarães Rosa",
                ReleaseYear = 1956,
                Quantity = 4
            },

            new BookModel
            {
                Id = 4,
                Name = "O Cortiço",
                AuthorName = "Aluísio Azevedo",
                ReleaseYear = 1890,
                Quantity = 4
            },

            new BookModel
            {
                Id = 5,
                Name = "Iracema",
                AuthorName = "José de Alencar",
                ReleaseYear = 1865,
                Quantity = 1
            },

            new BookModel
            {
                Id = 6,
                Name = "Macunaíma",
                AuthorName = "Mário de Andrade",
                ReleaseYear = 1928,
                Quantity = 11
            },

            new BookModel
            {
                Id = 7,
                Name = "Capitães da Areia",
                AuthorName = "Jorge Amado",
                ReleaseYear = 1937,
                Quantity = 2
            },

            new BookModel
            {
                Id = 8,
                Name = "Vidas Secas",
                AuthorName = "Graciliano Ramos",
                ReleaseYear = 1938,
                Quantity = 9
            },

            new BookModel
            {
                Id = 9,
                Name = "A Moreninha",
                AuthorName = "Joaquim Manuel de Macedo",
                ReleaseYear = 1844,
                Quantity = 2
            },

            new BookModel
            {
                Id = 10,
                Name = "O Tempo e o Vento",
                AuthorName = "Erico Verissimo",
                ReleaseYear = 1949,
                Quantity = 1
            },

            new BookModel
            {
                Id = 11,
                Name = "A Hora da Estrela",
                AuthorName = "Clarice Lispector",
                ReleaseYear = 1977,
                Quantity = 1
            },

            new BookModel
            {
                Id = 12,
                Name = "O Quinze",
                AuthorName = "Rachel de Queiroz",
                ReleaseYear = 1930,
                Quantity = 1
            },

            new BookModel
            {
                Id = 13,
                Name = "Menino do Engenho",
                AuthorName = "José Lins do Rego",
                ReleaseYear = 1932,
                Quantity = 5
            },

            new BookModel
            {
                Id = 14,
                Name = "Sagarana",
                AuthorName = "João Guimarães Rosa",
                ReleaseYear = 1946,
                Quantity = 3
            },

            new BookModel
            {
                Id = 15,
                Name = "Fogo Morto",
                AuthorName = "José Lins do Rego",
                ReleaseYear = 1943,
                Quantity = 1
            }
        };

        private static List<RentModel> Rents = new List<RentModel>();

        [HttpGet]
        public ActionResult<List<BookModel>> ListBooks()
        {
            return Ok(Books);
        }

        [HttpGet("{id}")]
        public ActionResult GetBookQuantityById(int id)
        {
            var book = Books.FirstOrDefault(x => x.Id == id);

            if (book == null) return NotFound("Book not found");

            var bookDetails = new
            {
                Name = book.Name,
                Quantity = book.Quantity
            };

            return Ok(bookDetails);
        }


        [HttpPost("rent/{bookId}")] 
        public ActionResult RentBook(int bookId, [FromBody] RentRequests request)
        {
            if (string.IsNullOrWhiteSpace(request.Name) || request.Name == "string") return BadRequest(new { message = "The renter's name is required." });

            var book = Books.FirstOrDefault(x => x.Id == bookId);

            if(book == null) return NotFound(new { message = "Book not found."});

            if (book.Quantity <= 0) return BadRequest(new { message = "There are no books to rent." });

            var rent = new RentModel
            {
                Id = Rents.Count + 1,
                Name = request.Name,
                BirthDate = request.BirthDate,
                BookId = book.Id,
                Created_at = DateTime.Now,
                Updated_at = null
            };

            Rents.Add(rent);
            book.Quantity--;

            return Ok(new { message = $"Successfully rented book {book.Name} for rental {rent.Name}!" });
        }

        [HttpPut("return/{rentId}")]
        public ActionResult ReturnBook(int rentId)
        {
            var rent = Rents.FirstOrDefault(r => r.Id == rentId);

            if (rent == null) return NotFound("Rent not found.");

            var book = Books.FirstOrDefault(b => b.Id == rent.BookId);

            if (book == null) return NotFound("Book not found.");

            book.Quantity++;

            Rents.Remove(rent);

            return Ok($"Book {book.Name} returned successfully.");
        }

        [HttpGet("rents")]
        public ActionResult<List<RentModel>> GetRents()
        {
            return Ok(Rents);
        }
    }
}
