using System.Collections.Generic;

namespace Task4_Eraasoft
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public bool Availability { get; set; } 

        public Book(string title, string author, string isbn, bool availability)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            Availability = availability;
        }
    }
    public class Library
    {
        public List<Book> books { get; set; }

        public Library()
        {
            this.books = new List < Book > ();
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public Book SearchBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.ToLower().Contains(title.ToLower()) && books[i].Availability == true)
                {
                    return books[i];
                }
            }
            return null;
        }
        public bool BorrowBook(string title)
        {
            for (int i = 0; i < books.Count; i++) 
            {
                if (books[i].Title.ToLower().Contains(title.ToLower()) && books[i].Availability == true)
                {
                    books[i].Availability = false;
                    return true;
                }                    
            }
            return false;
        }
        public bool ReturnBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.ToLower().Contains(title.ToLower()) && books[i].Availability == false)
                {
                    books[i].Availability = true;
                    return true;
                }                   
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565", true));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084", true));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935", true));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            if(library.BorrowBook("Gatsby"))
                Console.WriteLine("Gatsby Borrowed successfully"); 
            else
                Console.WriteLine("This book is not in the library");

            if (library.BorrowBook("1984"))
                Console.WriteLine("1984 Borrowed successfully");
            else
                Console.WriteLine("This book is not in the library");

            if (library.BorrowBook("Harry Potter"))
                Console.WriteLine("Borrowed successfully");
            else
                Console.WriteLine("Harry Potter book is not in the library");

            //library.BorrowBook("Gatsby");
            //library.BorrowBook("1984");
            //library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            if (library.ReturnBook("Gatsby"))
                Console.WriteLine("Gatsby Returned successfully");
            else
                Console.WriteLine("This book is not borrowed");

            if (library.ReturnBook("Harry Potter"))
                Console.WriteLine("Returned successfully");
            else
                Console.WriteLine("This book is not borrowed");
            //library.ReturnBook("Gatsby");
            //library.ReturnBook("Harry Potter"); // This book is not borrowed
            
            Console.ReadLine();
        }
    }
}
