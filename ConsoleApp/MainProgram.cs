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
            Console.Write("String: ");
            string message = Console.ReadLine();
            Console.Write("{0, 8}", "Bytes: ");
            for (int i = 0; i < message.Length; ++i)
            {
                Console.Write("{0, 8:X} ", (byte)message[i]);
            }
            Console.WriteLine();
            MD5 md5 = new MD5(MD5.StringToBytes(message));
            uint[] t = md5.GetHash();
            Console.Write("MD5: ");
            for (int i = 0; i < t.Length; ++i)
            {
                Console.Write(string.Format("{0:X}", t[i]).PadLeft(8, '0'));
            }
            Console.WriteLine();
        }
    }
}
