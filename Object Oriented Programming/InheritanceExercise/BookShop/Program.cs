using System;

namespace BookShop
{
    class Program
    {
        static void Main()
        {
            

            try
            {

                var author = Console.ReadLine();

                var title = Console.ReadLine();

                var price = decimal.Parse(Console.ReadLine());

                var book = new Book(author, title, price);

                var goldenBook = new GoldenEditionBook(author, title, price);

                Console.WriteLine(book.ToString());
                Console.WriteLine(goldenBook.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }



        }
    }
}
