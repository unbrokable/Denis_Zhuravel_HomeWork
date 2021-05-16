using System;
using System.Collections.Generic;
using System.Text;

namespace HW_LINQ2
{
    abstract class ArtObject
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }

    class Film : ArtObject
    {

        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }

    class Actor
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

    class Article : ArtObject
    {
        public int Pages { get; set; }
    }


}
