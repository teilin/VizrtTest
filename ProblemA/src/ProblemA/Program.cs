using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemA
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int numCases;
            var numList = new List<int>();
            var list = new List<string>();
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                if(int.TryParse(line, out var numValue))
                {
                    if(numList.Count == 2)
                    {
                        numCases = numList[0];
                        numList.Clear();
                        numList.Add(numCases);
                    }
                    numList.Add(numValue);
                    list.Clear();
                }
                else
                {
                    list.Add(line);

                    if(list.Count == numList[1])
                    {
                        Console.WriteLine(list.Distinct().Count());
                    }
                }
            }
        }
    }
}
