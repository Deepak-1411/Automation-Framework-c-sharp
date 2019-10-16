using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    class jsoncreat
    {
        public String name = "Deepak ";
        public String lastname = "Pal";
        public int employeeId = 0117;
        public String Designation = "Test Engineer";

        public static void Mainwewe(String[] args) {
            jsoncreat j = new jsoncreat();
            string jsonresult = JsonConvert.SerializeObject(j);
            String path = @"D:\json\test1.json";

            var tw = new StreamWriter(path, true);
            tw.WriteLine(jsonresult.ToString());
            tw.Close();

        }
    }
    class jsonread
    {

    }
}
   

