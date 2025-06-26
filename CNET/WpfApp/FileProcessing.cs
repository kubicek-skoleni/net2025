using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    class FileProcessing
    {
        private static List<string> LoadFiles()
        {
            string dir = @"C:\PROJECTS\skoleni2025\github\net2025\bigfiles";

            List<string> files = Directory.EnumerateFiles(dir, "*.txt")
                                         .ToList();

            return files;
        }
        public static Dictionary<string,int> StatsAllFiles()
        {
            var files = LoadFiles();

            Dictionary<string, int> stats = new();

            foreach (var file in files)
            {
                var words = File.ReadLines(file);

                foreach (var word in words)
                {
                    if (stats.ContainsKey(word))
                        stats[word]++;
                    else
                        stats.Add(word, 1);
                }
            }
            
            var top10 = stats.OrderByDescending(x => x.Value).Take(10);

            return top10.ToDictionary();
        }

        public static Dictionary<string, int> StatsSingleFile(string file)
        {
            Dictionary<string, int> stats = new();
            var words = File.ReadLines(file);

            foreach (var word in words)
            {
                if (stats.ContainsKey(word))
                    stats[word]++;
                else
                    stats.Add(word, 1);
            }

            var top10 = stats.OrderByDescending(x => x.Value).Take(10);
            return top10.ToDictionary();
        }

        public static Dictionary<string, int> GlobalStatWithProgress(IProgress<string> progress)
        {
            var files = LoadFiles();

            Dictionary<string, int> stats = new();

            foreach (var file in files)
            {
                progress.Report(file);

                var words = File.ReadLines(file);

                foreach (var word in words)
                {
                    if (stats.ContainsKey(word))
                        stats[word]++;
                    else
                        stats.Add(word, 1);
                }
            }

            var top10 = stats.OrderByDescending(x => x.Value).Take(10);

            return top10.ToDictionary();
        }
    }
}
