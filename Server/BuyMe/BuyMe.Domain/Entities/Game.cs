using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Domain.Entities{
    //game(|tytul |producent |ocena |dystrybutor |data premiery |opis |cena |kategorie |nośnik |wersja językowa)
    class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Producer { get; set; }
        public int Mark { get; set; }
        public string Distributor { get; set; }
        public DateOnly Releasedate { get; set; }
        public string Describe { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Carrier { get; set; }
        public string Languageversion { get; set; }

    }
}