using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib
{
    public class MD5
    {
        public List<string> rounds { get; } = new List<string>();

        public byte[] message;

        public MD5(byte[] message)
        {
            this.message = (byte[])message.Clone();
        }

        public MD5(string message)
        {
            this.message = StringToBytes(message);
        }

        private int b => message.Length;

        uint[] X = new uint[0];

        public uint[] GetHash()
        {
            List<byte> extMessage = new List<byte>();
            extMessage.AddRange(message);
            extMessage.Add(128);
            while ((extMessage.Count * 8) % 512 != 448)
            {
                extMessage.Add(0);
            }
            extMessage.AddRange(BitConverter.GetBytes((ulong)b * 8));
            uint[] M = new uint[extMessage.Count / 4];
            {
                byte[] tmp = extMessage.ToArray();
                for (int i = 0; i < extMessage.Count / 4; ++i)
                {
                    M[i] = BitConverter.ToUInt32(tmp, i * 4);
                }
            }
            uint
                A = 0x67452301,
                B = 0xEFCDAB89,
                C = 0x98BADCFE,
                D = 0x10325476;
            for (int i = 0; i <= M.Length / 16 - 1; ++i)
            {
                X = new uint[16];
                for (int j = 0; j <= 15; ++j)
                {
                    X[j] = M[i * 16 + j];
                }
                uint
                    AA = A,
                    BB = B,
                    CC = C,
                    DD = D;
                Round1(ref A, B, C, D, 0, 7, 1);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round1(ref D, A, B, C, 1, 12, 2);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round1(ref C, D, A, B, 2, 17, 3);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round1(ref B, C, D, A, 3, 22, 4);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round1(ref A, B, C, D, 4, 7, 5);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round1(ref D, A, B, C, 5, 12, 6);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round1(ref C, D, A, B, 6, 17, 7);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round1(ref B, C, D, A, 7, 22, 8);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round1(ref A, B, C, D, 8, 7, 9);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round1(ref D, A, B, C, 9, 12, 10);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round1(ref C, D, A, B, 10, 17, 11);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round1(ref B, C, D, A, 11, 22, 12);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round1(ref A, B, C, D, 12, 7, 13);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round1(ref D, A, B, C, 13, 12, 14);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round1(ref C, D, A, B, 14, 17, 15);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round1(ref B, C, D, A, 15, 22, 16);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round2(ref A, B, C, D, 1, 5, 17);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round2(ref D, A, B, C, 6, 9, 18);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round2(ref C, D, A, B, 11, 14, 19);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round2(ref B, C, D, A, 0, 20, 20);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round2(ref A, B, C, D, 5, 5, 21);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round2(ref D, A, B, C, 10, 9, 22);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round2(ref C, D, A, B, 15, 14, 23);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round2(ref B, C, D, A, 4, 20, 24);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round2(ref A, B, C, D, 9, 5, 25);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round2(ref D, A, B, C, 14, 9, 26);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round2(ref C, D, A, B, 3, 14, 27);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round2(ref B, C, D, A, 8, 20, 28);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round2(ref A, B, C, D, 13, 5, 29);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round2(ref D, A, B, C, 2, 9, 30);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round2(ref C, D, A, B, 7, 14, 31);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round2(ref B, C, D, A, 12, 20, 32);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round3(ref A, B, C, D, 5, 4, 33);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round3(ref D, A, B, C, 8, 11, 34);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round3(ref C, D, A, B, 11, 16, 35);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round3(ref B, C, D, A, 14, 23, 36);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round3(ref A, B, C, D, 1, 4, 37);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round3(ref D, A, B, C, 4, 11, 38);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round3(ref C, D, A, B, 7, 16, 39);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round3(ref B, C, D, A, 10, 23, 40);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round3(ref A, B, C, D, 13, 4, 41);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round3(ref D, A, B, C, 0, 11, 42);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round3(ref C, D, A, B, 3, 16, 43);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round3(ref B, C, D, A, 6, 23, 44);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round3(ref A, B, C, D, 9, 4, 45);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round3(ref D, A, B, C, 12, 11, 46);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round3(ref C, D, A, B, 15, 16, 47);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round3(ref B, C, D, A, 2, 23, 48);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round4(ref A, B, C, D, 0, 6, 49);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round4(ref D, A, B, C, 7, 10, 50);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round4(ref C, D, A, B, 14, 15, 51);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round4(ref B, C, D, A, 5, 21, 52);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round4(ref A, B, C, D, 12, 6, 53);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round4(ref D, A, B, C, 3, 10, 54);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round4(ref C, D, A, B, 10, 15, 55);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round4(ref B, C, D, A, 1, 21, 56);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round4(ref A, B, C, D, 8, 6, 57);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round4(ref D, A, B, C, 15, 10, 58);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round4(ref C, D, A, B, 6, 15, 59);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round4(ref B, C, D, A, 13, 21, 60);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round4(ref A, B, C, D, 4, 6, 61);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round4(ref D, A, B, C, 11, 10, 62);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round4(ref C, D, A, B, 2, 15, 63);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                Round4(ref B, C, D, A, 9, 21, 64);
                rounds.Add(Convert.ToString(A, 2).PadLeft(32, '0') + Convert.ToString(B, 2).PadLeft(32, '0') + Convert.ToString(C, 2).PadLeft(32, '0') + Convert.ToString(D, 2).PadLeft(32, '0'));
                A += AA;
                B += BB;
                C += CC;
                D += DD;
            }
            A = BitConverter.ToUInt32(BitConverter.GetBytes(A).Reverse().ToArray(), 0);
            B = BitConverter.ToUInt32(BitConverter.GetBytes(B).Reverse().ToArray(), 0);
            C = BitConverter.ToUInt32(BitConverter.GetBytes(C).Reverse().ToArray(), 0);
            D = BitConverter.ToUInt32(BitConverter.GetBytes(D).Reverse().ToArray(), 0);
            return new uint[] { A, B, C, D };
        }

        public string GetStringHash()
        {
            uint[] t = GetHash();
            string ans = "";
            for (int i = 0; i < t.Length; ++i)
            {
                string s = string.Format("{0:X}", t[i]);
                while (s.Length < 8) s = "0" + s;
                ans += s;
            }
            return ans;
        }

        private uint F(uint x, uint y, uint z) => (x & y) | (~x & z);
        private uint G(uint x, uint y, uint z) => (x & z) | (~z & y);
        private uint H(uint x, uint y, uint z) => x ^ y ^ z;
        private uint I(uint x, uint y, uint z) => y ^ (~z | x);

        private uint ROTL(uint x, int c) => (x << c) | (x >> (32 - c));

        private void Round1(ref uint a, uint b, uint c, uint d, int k, int s, int i)
        {
            a = b + (ROTL(a + F(b, c, d) + X[k] + T[i], s));
        }
        private void Round2(ref uint a, uint b, uint c, uint d, int k, int s, int i)
        {
            a = b + (ROTL(a + G(b, c, d) + X[k] + T[i], s));
        }
        private void Round3(ref uint a, uint b, uint c, uint d, int k, int s, int i)
        {
            a = b + (ROTL(a + H(b, c, d) + X[k] + T[i], s));
        }
        private void Round4(ref uint a, uint b, uint c, uint d, int k, int s, int i)
        {
            a = b + (ROTL(a + I(b, c, d) + X[k] + T[i], s));
        }

        private readonly uint[] T = new uint[65]
        {
            0,
            0xd76aa478, 0xe8c7b756, 0x242070db, 0xc1bdceee,
            0xf57c0faf, 0x4787c62a, 0xa8304613, 0xfd469501,
            0x698098d8, 0x8b44f7af, 0xffff5bb1, 0x895cd7be,
            0x6b901122, 0xfd987193, 0xa679438e, 0x49b40821,
            0xf61e2562, 0xc040b340, 0x265e5a51, 0xe9b6c7aa,
            0xd62f105d, 0x02441453, 0xd8a1e681, 0xe7d3fbc8,
            0x21e1cde6, 0xc33707d6, 0xf4d50d87, 0x455a14ed,
            0xa9e3e905, 0xfcefa3f8, 0x676f02d9, 0x8d2a4c8a,
            0xfffa3942, 0x8771f681, 0x6d9d6122, 0xfde5380c,
            0xa4beea44, 0x4bdecfa9, 0xf6bb4b60, 0xbebfbc70,
            0x289b7ec6, 0xeaa127fa, 0xd4ef3085, 0x04881d05,
            0xd9d4d039, 0xe6db99e5, 0x1fa27cf8, 0xc4ac5665,
            0xf4292244, 0x432aff97, 0xab9423a7, 0xfc93a039,
            0x655b59c3, 0x8f0ccc92, 0xffeff47d, 0x85845dd1,
            0x6fa87e4f, 0xfe2ce6e0, 0xa3014314, 0x4e0811a1,
            0xf7537e82, 0xbd3af235, 0x2ad7d2bb, 0xeb86d391
        };

        private byte[] StringToBytes(string str)
        {
            return str.Select(new Func<char, byte>((char c) => (byte)c)).ToArray();
        }
    }
}