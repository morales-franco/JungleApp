using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JungleApp.Batch.Entities
{
    public class MyLazyAuthor
    {
        public readonly string Name;

        //TODO: Lazy
        //The books property will be loaded when I invoke it doesn't before!
        //Lazy is threadSafe ! Books.Value is thread safe!
        public Lazy<IList<MyLazyBook>> Books => new Lazy<IList<MyLazyBook>>(() => GetMyBooks());

        private IList<MyLazyBook> GetMyBooks()
        {
            Console.WriteLine("Lazy loading! Loading books...");

            List<MyLazyBook> books = new List<MyLazyBook>();
            for (int i = 1; i <= 10; i++)
                books.Add(new MyLazyBook($"Book - Number: {i}"));

            return books;
        }

        public MyLazyAuthor(string name)
        {
            Console.WriteLine("[Constructor] Init Author! - In this moment, I don't load my books!");
            Name = name;
        }
    }

    public class MyLazyBook
    {
        public readonly string Name;
        public MyLazyBook(string name)
        {
            Name = name;
        }
    }
}
