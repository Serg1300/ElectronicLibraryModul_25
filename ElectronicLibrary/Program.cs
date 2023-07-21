namespace ElectronicLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Проверка методов--------------------------------
            
            UserRepository userRepository = new UserRepository();
            BookRepository bookRepository = new BookRepository();
            var book = new Book() { Author = "Толстой", TitleBook = "Годы идут" };
            var user = new User() { Id = 2, Name = "Andrei" };
            
            DateTime date = new DateTime(1930, 7, 1);
            DateTime date1 = DateTime.Now;
            var genre1 = Book.Genre.комедия;

            var bookGenreAll = bookRepository.FindByAllBookOrderByYearRelease();

            foreach (var b in bookGenreAll)
            {
                Console.WriteLine($"{b.Id}.{b.GenreBook} - {b.YearRelease}");
            }

            var bookauthor = bookRepository.FindCountBookByAuthor("Иванов");
            
            Console.WriteLine(bookauthor);

            var bookGenre = bookRepository.FindCountBookByGenre(genre1);

            Console.WriteLine(bookGenre);

            var isbook = bookRepository.FindBookByMaxYearRelease();
            
            Console.WriteLine(isbook.TitleBook);
        }
    }
}