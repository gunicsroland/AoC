using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> l1 = new List<int>();
            List<int> l2 = new List<int>();

            StreamReader r = new StreamReader("input.txt");

            while (!r.EndOfStream)
            {
                string line = r.ReadLine();
                string[] parts = line.Split(' ');

                l1.Add(int.Parse(parts[0]));
                l2.Add(int.Parse(parts[3]));
            }

            l1.Sort();
            l2.Sort();

            int sum = 0;
            for(int i = 0; i < l1.Count; ++i)
            {
                sum += Math.Abs(l2[i] - l1[i]);
            }

            int simScore = 0;
            foreach(int elem in l1)
            {
                simScore += elem * l2.Count(e => e == elem);
            }


            Console.WriteLine("The sum of distances is: {0}", sum);
            Console.WriteLine("The similarity score is {0}", simScore);
            Console.ReadLine();
        }
    }
}
