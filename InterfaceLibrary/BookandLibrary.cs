using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InterfaceLibrary
{
    class Book: IComparable, ICloneable
    {
        public string name { get; set; }
        public string author { get; set; }

        public Book() {
            name = "N/A";
            author = "N/A";
        }
        public Book(string name, string author)
        {
            this.name = name;
            this.author = author;
        }

        public object Clone()
        {
            return new Book(name,author);
        }

        public int CompareTo(object obj)
        {
            if (obj is Book)
                return name.CompareTo((obj as Book).name);

            throw new NotImplementedException();
        }
        public void Show() => Console.WriteLine("{0}   |   {1}", name, author);

        public class SortByName : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Book && obj2 is Book)
                    return (obj1 as Book).name.CompareTo((obj2 as Book).name);

                throw new NotImplementedException();
            }
        }
        public class SortByAuthor : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Book && obj2 is Book)
                    return (obj1 as Book).author.CompareTo((obj2 as Book).author);

                throw new NotImplementedException();
            }
        }
    }

    class Library: IEnumerable
    {
        Book[] book_list;

        public Library() {
            book_list = new Book[3];
        }
        public Library(params Book[] lists)
        {
            book_list = new Book[lists.Length];
            for (int i = 0; i < lists.Length; i++)
                book_list[i] = lists[i];
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < book_list.Length; i++)
                yield return book_list[i];
        }
    }
}
