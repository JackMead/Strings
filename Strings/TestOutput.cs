using System.Collections.Generic;
using NUnit.Framework;

namespace Strings
{
    [TestFixture]
    class TestOutput
    {
        [Test]
        public void Output_Formats_Exactly()
        {
            var compareString = "| 16 Sep 2013 |               Head First C# | Jennifer Greene & Andrew Ste... |";
            var p = new Program();
            var path = "C:/Work/Training/Strings/Strings/BookData.csv";
            var books = p.LoadBookData(path);
            var stringToOutput = p.FormatBooks(books);

            Assert.AreEqual(stringToOutput[1],compareString);

        }

    }
}
