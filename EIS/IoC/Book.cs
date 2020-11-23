using System;
using System.Collections.Generic;
using System.Text;

namespace IoC
{
    public class Book
    {
        public Book()
        {
            Name = "Таинственный остров";
            Author = "Жюль Верн";
            Pages = 639;
        }

        public Book(string name, string author, int pages)
        {
            Name = name;
            Pages = pages;
            Author = author;
        }

        public string Name { get; set; }

        public int Pages { get; set; }

        public string Author { get; set; }
    }
}
