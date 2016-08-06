using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlyElephant
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FindChain(args, File.ReadLines);
        }

        public static void FindChain(string[] args, Func<string, IEnumerable<string>> readLines)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Не задан путь к файлу, в котором указано начальное и конечное слово.");
                return;
            }
            var startEndPath = args[0];
            IEnumerable<string> startEndLines;
            try
            {
                startEndLines = readLines(startEndPath);
            }
            catch (Exception e)
            {
                WriteException(e);
                return;
            }
            var startEnd = startEndLines.Take(2).ToArray();
            if (startEnd.Length < 1)
            {
                Console.WriteLine("Не указано начальное слово.");
                return;
            }
            var start = startEnd[0];
            if (startEnd.Length < 2)
            {
                Console.WriteLine("Не указано конечное слово.");
                return;
            }
            var end = startEnd[1];
            if (args.Length < 2)
            {
                Console.WriteLine("Не задан путь к файлу, который содержит словарь.");
                return;
            }
            var dictionaryPath = args[1];
            IEnumerable<string> dictionaryLines;
            try
            {
                dictionaryLines = readLines(dictionaryPath);
            }
            catch (Exception e)
            {
                WriteException(e);
                return;
            }
            var chain = FindChain(start, end, dictionaryLines);
            if (chain.HasValue)
                foreach (var word in chain.Value)
                    Console.WriteLine(word);
            else
                Console.WriteLine("Цепочки не существует.");
        }

        private static void WriteException(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        public static Option<IEnumerable<string>> FindChain(string start, string end, IEnumerable<string> words)
        {
            var wordLength = start.Length;
            var strings = words.Where(value => value.Length == wordLength).ToArray();
            var startIndex = Array.IndexOf(strings, start);
            if (startIndex < 0) return new Option<IEnumerable<string>>();
            var endIndex = Array.IndexOf(strings, end);
            if (endIndex < 0) return new Option<IEnumerable<string>>();
            var groupings = Enumerable.Range(0, wordLength).SelectMany(
                i => Enumerable.Range(0, strings.Length).GroupBy(index => strings[index].Remove(i, 1))
                    .Where(grouping => grouping.Skip(1).Any())
                    .SelectMany(grouping => grouping.Select(index => new {index, grouping})))
                .ToLookup(_ => _.index, _ => _.grouping);
            var parents = BreadthFirstSearch(startIndex, endIndex, 
                current => groupings[current].SelectMany(grouping => grouping));
            return parents.ContainsKey(endIndex)
                ? GetChain(startIndex, endIndex, parents).Reverse().Select(index => strings[index]).AsOption()
                : new Option<IEnumerable<string>>();
        }

        /// <summary>
        /// https://en.wikipedia.org/wiki/Breadth-first_search#Pseudocode
        /// </summary>
        private static Dictionary<int, int> BreadthFirstSearch(int start, int end, Func<int, IEnumerable<int>> adjacents)
        {
            var dictionary = new Dictionary<int, int> {{start, -1}};
            if (start == end) return dictionary;
            var queue = new Queue<int>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var adjacent in adjacents(current))
                    if (!dictionary.ContainsKey(adjacent))
                    {
                        dictionary.Add(adjacent, current);
                        if (adjacent == end) return dictionary;
                        queue.Enqueue(adjacent);
                    }
            }
            return dictionary;
        }

        private static IEnumerable<int> GetChain(int start, int end, Dictionary<int, int> parents)
        {
            var current = end;
            while (current != start)
            {
                yield return current;
                current = parents[current];
            }
            yield return start;
        }
    }
}
