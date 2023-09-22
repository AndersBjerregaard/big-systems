namespace exampleApi {
    public class BookRepository {
        public List<Book> Books { get; set; }
        public BookRepository()
        {
            Books = new List<Book> {
                new Book {
                    Id = Guid.NewGuid(),
                    Title = "MONG",
                    AuthorName = "Monkey",
                    Genre = "Horror"
                },
                new Book {
                    Id = Guid.NewGuid(),
                    Title = "Foobar",
                    AuthorName = "Michael",
                    Genre = "Autobiography"
                },
                new Book {
                    Id = Guid.NewGuid(),
                    Title = "Runes Cookbook",
                    AuthorName = "Rune",
                    Genre = "Fantasy"
                },
            };
        }
    }
}