using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace test1
{
    class TakeCWD
    {
        public static void Main(String[] args)
        {
   
            string path = System.IO.Directory.GetCurrentDirectory();
            String cwd = Directory.GetCurrentDirectory();
            var path1 = Directory.GetParent(path);
            var path2 =Directory.GetParent(path1.ToString());
            Console.WriteLine("Current working directory : " + path2);
            Console.ReadLine();

        }
    }
}

