using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace task3
{
    internal class Program
    {
        class Test
        {
            public int id { get; set; }
            public string title { get; set; }
            public string value { get; set; }
            public List<Test> values { get; set; }

            public bool ChangeValue(int id, string val)
            {
                var answer = false;
                if (this.id == id)
                {
                    this.value = val;
                    answer = true;
                }
                else
                {
                    if (this.values!= null)
                        foreach (var v in this.values)
                        {
                           answer = v.ChangeValue(id, val);
                            if (answer) break;
                        }
                }
                return answer;
            }
        }
        class Values
        {
            public List<Value> values { get; set; }
        }
        class Value
        {
            public int id { get; set; }
            public string value { get; set; }
        }
        static void Main(string[] args)
        {
            string json1, json2;
            //args = new[] { @"C:\Users\user\Documents\GitHub\TestForDigital\task3\1.json", @"C:\Users\user\Documents\GitHub\TestForDigital\task3\2.json" };
            if (args.Length != 2)
                throw new ArgumentException("Ожидалось 2 аргумента, а используется "+ args.Length.ToString());
            try
            {
                json1 = File.ReadAllText(args[0]);
                json2 = File.ReadAllText(args[1]);
            }
            catch
            {
                throw new ArgumentException("Не удалось открыть файл");
            }
            var data1 = JsonSerializer.Deserialize<Test>(json1);
            var data2 = JsonSerializer.Deserialize<Values>(json2);
            foreach(var val in data2.values){
                var i = val.id;
                var v = val.value;
                data1.ChangeValue(i, v);
            }
            string jsonString = JsonSerializer.Serialize(data1);
            System.IO.File.WriteAllText(Environment.CurrentDirectory + @"\report.json", jsonString);
        }
    }
}
