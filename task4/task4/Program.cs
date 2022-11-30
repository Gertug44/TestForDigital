using System;
using System.Collections.Generic;
using System.IO;

namespace task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listInt = new List<int>();
            try
            {
                string s;
                StreamReader f = new StreamReader(args[0]);
                while ((s = f.ReadLine()) != null)
                {
                    listInt.Add(int.Parse(s));
                }
                f.Close();
            }
            catch (Exception e)
            {
                throw new ArgumentException("Exception: " + e.Message);
            }

            var a = listInt.ToArray();
            Array.Sort(a);
            var max = a[a.Length / 2];
            var count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                count += Math.Abs(max - a[i]);
            }
            Console.WriteLine(count);
        }
    }
}
