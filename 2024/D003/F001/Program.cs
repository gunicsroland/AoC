using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> StartsWithM = new List<string>();
            string pattern @"";

            StreamReader reader = new StreamReader("input.txt");
            while(!reader.EndOfStream){
                string line = reader.ReadLine();

                foreach (string part in line.Split('m'))
                {
                    StartsWithM.Add(part);
                }
            }

            

            Console.ReadLine();
        }
    }
}
