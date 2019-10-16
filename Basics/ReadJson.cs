using Newtonsoft.Json;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System.IO;
using System;

namespace Basics
{
    class ReadJson
    {
        public static void Main111(String[] args)
        {
            JObject data= JObject.Parse(File.ReadAllText(@"D:\\csharp\\JsonData\\test1.json"));
         
            var data1 = (JArray)data["scriptstep"];
            Console.WriteLine(data1);
         
            var count=(data1.Count);
            Console.WriteLine(count);
           
            for (int i = 0; i <count; i++) {
                var data2 = data1[i];
                Console.WriteLine(data2["stepno"]);
                Console.WriteLine(data2["stepdescription"]);
        //        Console.WriteLine(data2["expected"]);
        //        Console.WriteLine(data2["screenname"]);
        //        Console.WriteLine(data2["fieldname"]);
       //         Console.WriteLine(data2["keyword"]);
         //       Console.WriteLine(data2["forder"]);
                
            }
            Console.ReadLine();

        }

    }

}
