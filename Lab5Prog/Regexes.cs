using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab5Prog
{
    class Regexes
    {
        string path { get; set; }
        string path2 { get; set; }

        public Regexes()
        {

        }

        public Regexes(string path)
        {
            this.path = path;
        }

        
        public void GetNumbers()
        {
            string str;
            using (StreamReader reader = File.OpenText(path))
            {
                Console.WriteLine(reader.ReadToEnd());
                str = reader.ReadToEnd();
            }
            string strText;
            string lineOr;
            foreach (string line in File.ReadLines(path))
            {
                lineOr = line;
                strText = line;
                string strFind = @"([(]?\d{3}[)]?[\- ]?)?[\d\-]{9,15}";
                Regex regex = new Regex(strFind);
                MatchCollection matches = regex.Matches(strText);
                string strReplace = "+38 $0";
                int counter = 0;
                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                    string newRegex = Convert.ToString(match);
                    counter += 1;
                }
                strText = Regex.Replace(strText, @"[\(\)]", " ");
                strText = regex.Replace(strText, strReplace, counter);
                Console.WriteLine();
                Console.WriteLine(strText); 
                str = str + strText;
            }
            using (StreamWriter file = new StreamWriter(path))
            {
                file.Write(str);
            }
        }
    }
}
