using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemB
{
    class KingUtopia
    {
        private int index = 0;
        private int numPeople = 0;
        private int numClaiments = 0;
        private IDictionary<string, double> relatedBlood = new Dictionary<string, double>();
        private IDictionary<string, string> people = new Dictionary<string, string>();
        private IList<string> claiments = new List<string>();

        public void Run()
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                if (index == 0)
                {
                    var split = line.Split(new char[] { ' ' }, StringSplitOptions.None);
                    numPeople = int.Parse(split[0]);
                    numClaiments = int.Parse(split[1]);
                }
                else if (index == 1)
                {
                    relatedBlood.Add(line, 1.0);
                }

                if (index > 1)
                {
                    var split = line.Split(new char[] { ' ' }, StringSplitOptions.None);
                    if (split.Length == 3)
                    {
                        people.Add(split[0], split[1] + " " + split[2]);
                    }
                    else if (split.Length == 1)
                    {
                        claiments.Add(split[0]);
                    }
                }

                if (numClaiments == claiments.Count)
                {
                    break;
                }

                index++;
            }

            var rs = new Dictionary<string, double>();
            foreach (var c in claiments)
            {
                if (people.ContainsKey(c))
                {
                    var split = people[c].Split(new char[] { ' ' }, StringSplitOptions.None);
                    var score = FindScore(split[0], split[1]);
                    rs.Add(c, score);
                }
                else
                {
                    rs.Add(c, 0.0);
                }
            }

            Console.WriteLine(rs.OrderByDescending(o => o.Value).FirstOrDefault().Key);
        }

        private double GetScore(string name)
        {
            if (relatedBlood.ContainsKey(name))
            {
                return relatedBlood[name];
            }

            if (people.ContainsKey(name))
            {
                var split = people[name].Split(new char[] { ' ' }, StringSplitOptions.None);
                var score = FindScore(split[0], split[1]);
                relatedBlood.Add(name, score);
                return score;
            }

            return 0.0;
        }

        private double FindScore(string name1, string name2)
        {
            return GetScore(name1) / 2 + GetScore(name2) / 2;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            var kingChallenge = new KingUtopia();
            kingChallenge.Run();
        }
    }
}
