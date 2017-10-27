using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Book
    {
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Title { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.DisplayBookData();
        }


        const int leftLength = 11;
        const int centreLength = 27;
        const int rightLength = 31;
        private int lineLength = leftLength+centreLength+rightLength+10;
        private const string path = "BookData.csv";

        public void DisplayBookData()
        {
            var bookRows = LoadBookData(path);
            var headerString = FormatHeader();
            var bookStrings = FormatBooks(bookRows);

            DisplayBooks(headerString, bookStrings);
        }



        public List<string> FormatBooks(List<Book> bookRows)
        {
            var formattedRows = new List<string>();
            foreach (var book in bookRows)
            {
                formattedRows.Add(FormatRow(book.PublishedDate.ToString("dd MMM yyyy"), book.Title, book.Author).ToString());
            }
            return formattedRows;
        }

        public string FormatHeader()
        {
            var headerLeft = "Pub Date";
            var headerCentre = "Title";
            var headerRight = "Authors";
            var builder = FormatRow(headerLeft, headerCentre, headerRight);
            return builder.ToString();
        }

        public void DisplayBooks(string header, List<string> bookOutput)
        {
            DisplayHeader(header);
            DisplayHorizontalLine();
            DisplayData(bookOutput);
        }

        public void DisplayData(List<string> outputRows)
        {
            foreach (var row in outputRows)
            {
                Console.WriteLine(row);
            }
        }

        public void DisplayHeader(string header)
        {
            Console.WriteLine(header);
        }

        public string[] LoadHeader()
        {
            using (StreamReader sr = new StreamReader("C:/Work/Training/Strings/Strings/BookData.csv"))
            {
                //Skip over header
                var line = sr.ReadLine();
                var read = line.Split(',');
                if (read.Length != 3)
                {
                    Console.WriteLine("Header entry was incorrectly formatted");

                }
                return read;
            }

        }

        public List<Book> LoadBookData(string path)
        {
            var books = new List<Book>();
            using (StreamReader sr = new StreamReader(path))
            {
                //Skip over header
                var line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    var read = line.Split(',');
                    if (read.Length != 3)
                    {
                        Console.WriteLine("Book entry was incorrectly formatted");
                        continue;
                    }
                    books.Add(new Book() { Author = read[2], PublishedDate = DateTime.Parse(read[0]), Title = read[1] });
                }
            }
            return books;
        }

        public StringBuilder FormatRow(string left, string centre, string right)
        {
            left = ShortenIfNecessary(left, leftLength);
            centre = ShortenIfNecessary(centre, centreLength);
            right = ShortenIfNecessary(right, rightLength);

            left = left.PadRight(leftLength);
            centre = centre.PadLeft(centreLength);
            right = right.PadRight(rightLength);
            return new StringBuilder().Append("| ").Append(left).Append(" | ").Append(centre).Append(" | ").Append(right).Append(" |");
        }

        public string ShortenIfNecessary(string toShorten, int length)
        {
            if (toShorten.Length > length)
            {
                toShorten = toShorten.Substring(0, length - 3) + "...";
            }
            return toShorten;
        }

        public void DisplayHorizontalLine()
        {
            var line = new StringBuilder();
            line.Append("|");
            for (int i = 0; i < lineLength - 2; i++)
            {
                line.Append("=");
            }
            line.Append("|");
            Console.WriteLine(line);
        }
    }
}
