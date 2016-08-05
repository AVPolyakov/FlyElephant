using System;
using System.Collections.Generic;
using System.Linq;

namespace FlyElephant
{
    public class Program
    {
        public static void Main()
        {
            var path = FindPath("КОТ", "ТОН", new[] {"КОТ", "ТОН", "НОТА", "КОТЫ", "РОТ", "РОТА", "ТОТ"});
            if (path != null)
                foreach (var wordInfo in path)
                    Console.WriteLine(wordInfo);
            else
                Console.WriteLine("Цепочки не существует.");
        }

        public static IEnumerable<string> FindPath(string start, string end, IEnumerable<string> words)
        {
            var wordLength = start.Length;
            var strings = words.Where(value => value.Length == wordLength).ToArray();
            var startIndex = Array.IndexOf(strings, start);
            if (startIndex < 0) return null;
            var endIndex = Array.IndexOf(strings, end);
            if (endIndex < 0) return null;
            var groupings = Enumerable.Range(0, wordLength).SelectMany(
                i => Enumerable.Range(0, strings.Length).GroupBy(index => strings[index].Remove(i, 1))
                    .Where(grouping => grouping.Skip(1).Any())
                    .SelectMany(grouping => grouping.Select(index => new {index, grouping})))
                .ToLookup(_ => _.index, _ => _.grouping);
            var parents = BreadthFirstSearch(startIndex, endIndex, 
                current => groupings[current].SelectMany(grouping => grouping));
            return parents.ContainsKey(endIndex)
                ? GetPath(startIndex, endIndex, parents).Reverse().Select(index => strings[index])
                : null;
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

        private static IEnumerable<int> GetPath(int start, int end, Dictionary<int, int> parents)
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
