using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01
{
    internal class Program
    {
        static bool dampenedIsSafe(int[] levels)
        {
            //generate subsets
            int[] subLevel = new int[levels.Length - 1];
            for (int leaveOut = 0; leaveOut < levels.Length; ++leaveOut)
            {
                int subIndex = 0;
                int levelsIndex = 0;
                while(subIndex < subLevel.Length)
                {
                    if(levelsIndex != leaveOut)
                    {
                        subLevel[subIndex] = levels[levelsIndex];
                        subIndex++;
                    }
                    
                    levelsIndex++;
                }
                if (isSafe(subLevel)) return true;
            }
            return false;
        }
        static bool isSafe(int[] levels)
        {
            bool isLower = false;
            bool isIncrease = false;

            int diff = 0;
            for (int i = 0; i < levels.Length-1; i++)
            {
                diff = Math.Abs(levels[i + 1] - levels[i]);
                if (diff < 4 && 0 < diff) { }
                else
                {
                    return false;
                }

                if (levels[i] < levels[i + 1])
                {
                    isIncrease = true;
                }
                if (levels[i] > levels[i + 1])
                {
                    isLower = true;
                }
            }

            return !(isLower && isIncrease);
        }

        static void Main(string[] args)
        {
            int safeNum = 0;

            StreamReader r = new StreamReader("input.txt");
            while (!r.EndOfStream)
            {
                string line = r.ReadLine();

                string[] parts = line.Split(' ');
                int[] levels = new int[parts.Length];
                for(int i =0; i < parts.Length; ++i)
                {
                    levels[i] = int.Parse(parts[i]);
                }

                if (dampenedIsSafe(levels))
                {
                    safeNum++;
                }
            }


            Console.WriteLine("Number of safe recods: {0}", safeNum);
            Console.ReadLine();
        }
    }
}
