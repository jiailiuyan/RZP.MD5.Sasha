using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLib;

namespace ConsoleApp
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            MD5 md5 = new MD5(MD5.StringToBytes("The quick brown fox jumps over the lazy dog"));
            uint[] t = md5.GetHash();
            for (int i = 0; i < t.Length; ++i)
            {
                string s = string.Format("{0, 8:X} ", t[i]);
                s = s.Replace(' ', '0');
                Console.Write(s);
            }
        }
    }
}
