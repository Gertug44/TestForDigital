using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            float r;
            float[] center = new float[2];
            List<float[]> dots = new List<float[]>();
            if (args.Length != 2)
                throw new ArgumentException("Для выполения программы ожидается 2 аргумента");
            try{
                using (FileStream fstream = new FileStream(args[0], FileMode.Open))
                {
                    byte[] buffer = new byte[fstream.Length];
                    await fstream.ReadAsync(buffer);
                    string textFromFile = Encoding.Default.GetString(buffer);
                    var data = textFromFile.Split("\r");
                    var centeinStr = data[0].Split(" ");
                    center[0] = float.Parse(centeinStr[0]);
                    center[1] = float.Parse(centeinStr[1]);
                    textFromFile = data[1];
                    r = float.Parse(textFromFile);
                }
            }
            catch
            {
                throw new ArgumentException("Проблемы c 1 файлом");
            }
            try
            {
                string s;
                StreamReader f = new StreamReader(args[1]);
                while ((s = f.ReadLine()) != null)
                {
                    var dotInSTR = s.Split(" ");
                    var dotCoord = new float[2] {float.Parse(dotInSTR[0]), float.Parse(dotInSTR[1])};
                    dots.Add(dotCoord);
                }
                f.Close();
            }
            catch
            {
                throw new ArgumentException("Проблемы со 2 файлом");
            }

            foreach(var dot in dots)
            {
                var distanceTodot = Math.Sqrt(Math.Pow(center[0] - dot[0], 2) + Math.Pow(center[1] - dot[1], 2));
                if (distanceTodot == r)
                    Console.WriteLine("0");
                else if (distanceTodot > r)
                    Console.WriteLine("2");
                else
                    Console.WriteLine("1");
            }
        }
    }
}
