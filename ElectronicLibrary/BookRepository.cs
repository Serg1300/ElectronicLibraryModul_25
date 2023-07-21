using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ElectronicLibrary.Book;

namespace ElectronicLibrary
{
    public class BookRepository
    {
        public Book FindBookById(int id)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(u => u.Id == id);
                if (book is null) throw new NotFoundException();
                return book;
            }
        }
        public List<Book> FindByAllBook()
        {
            using (var db = new AppContext())
            {
                var book = db.Books.ToList();
                return book;
            }
        }
        public void CreateBook(Book book)
        {
            using (var db = new AppContext())
            {
                var isBook = db.Books.Contains(book);
                if (!isBook)
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                }
            }
        }
        public void DeleteBook(Book book)
        {
            using (var db = new AppContext())
            {
                var isBook = db.Books.Contains(book);
                if (isBook)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
        }
        public void UpdateYearRelease(DateTime date, int id)
        {
            using (var db = new AppContext())
            {
                var bookId = db.Books.FirstOrDefault(u => u.Id == id);
                if (bookId != null)
                {
                    bookId.YearRelease = date;                    
                    db.Books.Update(bookId);
                    db.SaveChanges();
                }

            }
        }
        public List<Book> FindByAllBookByGenreAndYear(Genre genre,DateTime date1, DateTime date2)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Where (b => b.GenreBook.Contains(genre.ToString()) && b.YearRelease > date1 && b.YearRelease < date2 ).ToList();
                return book;
            }
        }
        public int FindCountBookByAuthor(string author)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Where(b => b.Author.Contains(author)).Count();
                return book;
            }
        }
        public int FindCountBookByGenre(Genre genre)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Where(b => b.GenreBook.Contains(genre.ToString())).Count();
                return book;
            }
        }
        public bool IsFindBookByAuthorTitle(string author, string title)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Any(b => b.Author == author && b.TitleBook == title);
                return book;
            }
        }
        public bool IsFindBookByAuthorTitleInUser(Book book, User user)
        {
            using (var db = new AppContext())
            {
                var isbook = db.Books.Any(b => b.Author == book.Author && b.TitleBook == book.TitleBook && b.UserId > 0 && b.UserId == user.Id);
                return isbook;
            }
        }
        public int FindCountBookInUser(User user)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Where(b => b.UserId > 0 && b.UserId == user.Id).Count();
                return book;
            }
        }
        public Book FindBookByMaxYearRelease()
        {
            using (var db = new AppContext())
            {                
                var book = db.Books.OrderByDescending(b => b.YearRelease).First();
                return book;
            }
        }
        public List<Book> FindByAllBookOrderByTitle()
        {
            using (var db = new AppContext())
            {
                var book = db.Books.OrderBy(b => b.TitleBook).ToList();
                return book;
            }
        }
        public List<Book> FindByAllBookOrderByYearRelease()
        {
            using (var db = new AppContext())
            {
                var book = db.Books.OrderByDescending(b => b.YearRelease).ToList();
                return book;
            }
        }
    }
}
