using System;
using System.Collections.Generic;
using System.IO;

namespace Lab5Prog
{
    class Dictionary
    {
        string path { get; set; }
        public Dictionary()
        {
            
        }

        public Dictionary(string path)
        {
            this.path = path;
        }
        public void GetInfo()
        {
            string str;
            Dictionary<string, string> word = new Dictionary<string, string>(5)
            {
                { "рпивет", "привет" },
                { "пирвет", "привет" },
                { "првиет", "привет" },
                { "приевт", "привет" },
                { "привте", "привет" },
            };

            using (StreamReader reader = File.OpenText(path))
            {
                str = reader.ReadToEnd();
                Console.WriteLine(str);
            }

            foreach (string line in File.ReadLines(path))
            {
                string[] split = line.Split(' ');
                for (int counter = 0; counter < split.Length; ++counter)
                {
                    string someWord = split[counter];
                    foreach (string values in word.Values)
                    {
                        string rightWord = values;
                        foreach (string keys in word.Keys)
                        {
                            if (someWord == keys)
                            {
                                string wrongWord = someWord;
                                str = str.Replace(wrongWord, rightWord);
                            }
                        }
                    }
                }
            }
            using (StreamWriter file = new StreamWriter(path))
            {
                file.Write(str);
            }

            using (StreamReader reader = File.OpenText(path))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
}
