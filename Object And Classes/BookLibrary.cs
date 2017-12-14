using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Book_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var listOfBooks = new List<Book>();
            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split();

                string title = input[0];
                string author = input[1];
                string publisher = input[2];
                string dat1 = input[3];
                var date = DateTime.ParseExact(dat1, "dd.MM.yyyy", CultureInfo.InvariantCulture);

                int isbNum = int.Parse(input[4]);

                double price = double.Parse(input[5]);


                var book = new Book();

                book.Title = title;
                book.Author = author;
                book.Publisher = publisher;
                book.ReleaseDate = date;
                book.IsbNum = isbNum;
                book.Price = price;

                listOfBooks.Add(book);
            }

            var givenDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            foreach (var book in listOfBooks.Where(x=> x.ReleaseDate > givenDate).OrderBy(x=> x.ReleaseDate).ThenBy(x=> x.Title))
            {
                Console.WriteLine($"{book.Title} -> {String.Format("{0:dd.MM.yyyy}", book.ReleaseDate)}");
                
            }

        }

    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int IsbNum { get; set; }
        public double Price { get; set; }


        //title, author, publisher, release date (in dd.MM.yyyy format), ISBN-number and price. 

    }


}
