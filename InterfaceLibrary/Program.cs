using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    internal class Program
    {
        static void Print(Book[] array)
        {
            Console.WriteLine("   Name                  Author");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(i + 1 + " - ");
                array[i].Show();
            }
        }
        static void Main(string[] args)
        {
            Book[] books = new Book[7];
            books[0] = new Book("Once upon a time","R.Martin");
            books[1] = new Book("An Amazing Book","An amazing Author");
            books[2] = new Book("Bad book", "Tom");
            books[3] = new Book("The ball", "Richard Tomson");
            books[4] = new Book("The black swen", "S.T");
            books[5] = new Book("Science for dummies","Enstein");
            books[6] = new Book("Yahoo!", "Someone");
            Console.WriteLine("Initial Array:");
            Print(books);
            Console.WriteLine();
            Array.Sort(books, new Book.SortByName());
            Console.WriteLine("Sorted by name:");
            Print(books);
            Console.WriteLine();
            Array.Sort(books, new Book.SortByAuthor());
            Console.WriteLine("Sorted by author:");
            Print(books);
            Console.WriteLine();
            Book book2 = books[0].Clone() as Book;
            books[0].name = "Name has been changed";
            Console.WriteLine("Deep copy of the first book was created. First book name of the array was changed. Deep copy of the first book:");
            book2.Show();
            Console.WriteLine("Original:");
            books[0].Show();
            Console.WriteLine();
            Console.WriteLine("Class 'Library' was created, Library via foreach:");
            Library library= new Library(books);

            int i = 1;
            foreach (Book item in library)
            {
                Console.Write(i + " - ");
                item.Show();
                i++;
            }
        }
    }
}
