using System;
using System.Collections.Generic;
using System.Text;

namespace task1
{
    public class RoundArray
    {
        private readonly int step;
        private readonly List<int> roundArr;
        public int currentElement = 0;
        private int count;

        public RoundArray(int step, int arrayCountNumbers)
        {
            this.step = step;
            roundArr = new List<int>();
            for (int i = 0; i < arrayCountNumbers; i++)
                roundArr.Add(i+1);
            count = arrayCountNumbers;
        }
        public string nextChannel()
        {
            var r = roundArr[currentElement].ToString();
            currentElement += step-1;
            while (currentElement > count-1)
            {
                var c = currentElement - count;
                currentElement = 0+c;
            }
            return r;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            if (args.Length != 2)
                throw new ArgumentException("Для выполения программы ожидается 2 аргумента");
            try
            {
                n = int.Parse(args[0]);
                m = int.Parse(args[1]);
            }
            catch 
            { 
                throw new ArgumentException("Аргументами должны выступать целые числа"); 
            }
            var arr = new RoundArray(m, n);
            //var arr = new RoundArray(5, 4);
            var answer = new StringBuilder(arr.nextChannel());
            while (arr.currentElement != 0)
            {
                answer.Append(arr.nextChannel());
            }
            Console.Write(answer.ToString());
        }
    }
}
