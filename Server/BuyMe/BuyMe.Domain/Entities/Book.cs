using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Domain.Entities
{
//book(|tytul |autor |ocena |wydawnictwo |data premiery |liczba stron |opis |cena |kategorie)
    class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Mark { get; set; }
        public string Publishinghosue { get; set; }
        public DateOnly Releasedate { get; set; }
        public int NumofPag { get; set; }
        public string Describe { get; set; }
        public double Price { get; set; }
        public int Category { get; set; }
    }
}








