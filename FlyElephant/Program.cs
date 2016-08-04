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
            var wordInfos = words.Where(value => value.Length == wordLength)
                .Select((value, i) => new WordInfo(value, i)).ToList();
            var startWord = wordInfos.SingleOrDefault(_ => _.Value == start);
            if (startWord == null) return null;
            var endWord = wordInfos.SingleOrDefault(_ => _.Value == end);
            if (endWord == null) return null;
            //заполняем списки WordInfo.Groupings
            foreach (var i in Enumerable.Range(0, wordLength))
                foreach (var grouping in wordInfos.GroupBy(info => info.Value.Remove(i, 1)))
                    if (grouping.Skip(1).Any())
                        foreach (var wordInfo in grouping)
                            wordInfo.Groupings.Add(grouping);
            return BreadthFirstSearch(startWord, endWord)
                ? GetPath(startWord, endWord).Reverse().Select(_ => _.Value)
                : null;
        }

        /// <summary>
        /// https://en.wikipedia.org/wiki/Breadth-first_search#Pseudocode
        /// </summary>
        private static bool BreadthFirstSearch(WordInfo startWord, WordInfo endWord)
        {
            var queue = new Queue<WordInfo>();
            startWord.Parent = startWord; //помечаем первоначальное слово как просмотренное
            if (startWord.Index == endWord.Index) return true;
            queue.Enqueue(startWord);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var adjacent in current.Groupings.SelectMany(grouping => grouping))
                    if (adjacent.Parent == null)
                    {
                        adjacent.Parent = current;
                        if (adjacent.Index == endWord.Index) return true;
                        queue.Enqueue(adjacent);
                    }
            }
            return false;
        }

        private class WordInfo
        {
            public string Value { get; }
            public int Index { get; }
            public readonly List<IGrouping<string, WordInfo>> Groupings = new List<IGrouping<string, WordInfo>>();
            public WordInfo Parent { get; set; }

            public WordInfo(string value, int index)
            {
                Value = value;
                Index = index;
            }
        }

        private static IEnumerable<WordInfo> GetPath(WordInfo startWord, WordInfo endWord)
        {
            var current = endWord;
            while (current.Index != startWord.Index)
            {
                yield return current;
                current = current.Parent;
            }
            yield return startWord;
        }
    }
}