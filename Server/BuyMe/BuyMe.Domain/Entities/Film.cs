using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Domain.Entities{
//film(|tytul |rezyser |ocena |czas trwania |data premiery |opis |cena |kategorie)
    class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public DateOnly Releasedate { get; set; }
        public string Describe { get; set; }
        public int Mark { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }
}