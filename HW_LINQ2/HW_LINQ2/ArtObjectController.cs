using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace HW_LINQ2
{
    public class ArtObjectController
    {
        List<object> data;
        public ArtObjectController(List<object> data)
        {
            this.data = data;
        }

        public void RunAllMethod()
        {
            Console.WriteLine("All actors");
            PrintActorName();
            Console.WriteLine("Actors born in August");
            PrintActerBornIn();
            Console.WriteLine("\nThe oldest two");
            PrintOldestActors();
            Console.WriteLine("Authors articles");
            PrintArticleAmount();
            Console.WriteLine("Authors articles and director films");
            PrintArticleFilmAmount();
            Console.WriteLine($"Amount of Distinct Symbols {DistinctSymbols()}");
            Console.WriteLine("Articles sorted by authors name ");
            PrintSortedArticles();
            Console.WriteLine("All movie actors");
            PrintActorFilms();
            Console.WriteLine("Sum of int");
            PrintAmountOfInt();
            Console.WriteLine("Dictionary author articles");
            PrintDictionaryAuthorArticles();
        }

        public void PrintActorName()
        {
            var actors = data.OfType<Film>()
                .Aggregate(new List<Actor>(), (a, b) => a.Union(b.Actors).ToList())
                .Select(i => i.Name)
                .Aggregate((a, b) => string.Concat(a,",",b));
            Console.WriteLine(actors.ToString());
        }

        public void PrintActerBornIn()
        {
            data.OfType<Film>()
                .ToList()
                .ForEach(i =>
                {
                    i.Actors.Where(a => a.Birthdate.Month == 8).ToList().ForEach(a =>
                    {
                        Console.Write(String.Concat(a.Name, " "));
                    });
                });
        }

        public void PrintOldestActors()
        {
            data.OfType<Film>()
                .Select(i => i.Actors)
                .Aggregate(new List<Actor>(), (a, b) =>
                {
                    return a.Union(b).ToList();
                })
                .OrderByDescending(i => i.Birthdate)
                .Take(2).ToList().ForEach(i => Console.WriteLine(i.Name));
        }

        public void PrintArticleAmount()
        {
            data.OfType<Article>()
                .GroupBy(i => i.Author)
                .Select(i => new { Key = i.Key, Count = i.Count() })
                .ToList()
                .ForEach(i => Console.WriteLine(String.Concat(i.Key, " : ", i.Count)));
        }

        public void PrintArticleFilmAmount()
        {
            data.OfType<ArtObject>()
                .GroupBy(i => i.Author)
                .Select(i => new { Key = i.Key, Count = i.Count() })
                .ToList()
                .ForEach(i => Console.WriteLine(String.Concat(i.Key, " : ", i.Count)));
        }

        public int DistinctSymbols()
        {
            return data.OfType<Film>()
                .Select(i => i.Actors)
                .Aggregate(new StringBuilder(), (a, b) =>
                {
                    return a.Append(
                        b.Aggregate(new StringBuilder(), (f, s) =>
                        {
                            return f.Append(s.Name);
                        }));
                })
                .ToString().Distinct().Count();

        }

        public void PrintSortedArticles()
        {
            data.OfType<Article>()
                .OrderBy(i => i.Author).ThenBy(i => i.Pages)
                .ToList()
                .ForEach(i => Console.WriteLine(i.Name));
        }

        public void PrintActorFilms()
        {
            var actors = data
                .OfType<Film>()
                .Select(i => i.Actors)
                .Aggregate(new List<Actor>(), (a, b) =>
                {
                    return a.Union(b).ToList();
                })
                .GroupBy(i => i.Name)
                .Select(i => new
                {
                    Key = i.Key,
                    Films = data
                    .OfType<Film>()
                    .Where(f => f.Actors.Where(a => a.Name == i.Key).Any())
                });

            foreach (var actor in actors)
            {
                Console.WriteLine($"{actor.Key}");
                foreach (var film in actor.Films)
                {
                    Console.WriteLine($"\t{film.Name}");
                }
            }
        }
        
        public void PrintAmountOfInt()
        {
            var amount = data
                //.Where(i => i is Article )
                .Where(i => i is IEnumerable<int> || i.GetType().GetProperties().Where(i => Type.GetTypeCode(i.PropertyType) is TypeCode.Int32).Any())
                .Select(i =>
                {
                    if (i is IEnumerable<int> arr)
                    {
                        return arr.Sum();
                    }
                    int sum = 0;
                    foreach (var item in i.GetType().GetProperties().Where(i => Type.GetTypeCode(i.PropertyType) is TypeCode.Int32))
                    {
                        sum += Convert.ToInt32(item.GetValue(i));
                    }
                    return sum;
                }).Sum();
            Console.WriteLine(amount);
        }

        public void PrintDictionaryAuthorArticles()
        {
            var authors = data.OfType<Article>()
                .GroupBy(i => i.Author)
                .ToDictionary(i => i.Key);
            foreach (var author in authors)
            {
                Console.WriteLine(author.Key);
                foreach (var film in author.Value)
                {
                    Console.WriteLine(String.Concat("\t",film.Name));
                }
            }
        }

    }
}
