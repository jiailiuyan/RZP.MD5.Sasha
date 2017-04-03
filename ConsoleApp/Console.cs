using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib;

namespace ConsoleApp
{
    class Console
    {
        static void Main(string[] args)
        {
            string str = System.Console.ReadLine();
            MD5 md5 = new MD5(str);
            uint[] t = md5.GetHash();
            for (int i = 0; i < t.Length; ++i)
            {
                string s = string.Format("{0:X}", t[i]);
                while (s.Length < 8) s = "0" + s;
                System.Console.Write(s + " ");
            }
            System.Console.WriteLine();
        }
    }
}
