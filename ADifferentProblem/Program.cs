using System;

namespace ADifferentProblem
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var line = string.Empty;
            while ((line = Console.ReadLine()) != null)
            {
                var split = line.Split(new char[] { ' ' }, StringSplitOptions.None);
                long a = Int64.Parse(split[0]);
                long b = Int64.Parse(split[1]);

                var res = a - b;
                Console.WriteLine(Math.Abs(res));
            }
        }
    }
}
