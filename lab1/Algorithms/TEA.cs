using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab1.Algorithms
{
    class TEA
    {
        public TEA(string key, string filePath)
        {
            this.key = key;
            this.filePath = filePath;
        }

        string key;


        private UInt32[] K = new UInt32[4];
        byte[] dataBytes;
        uint delta = 0x9e3779b9;

        string filePath;

        public string Key
        {
            get
            {
                return this.key;
            }
            set
            {
                this.key = value;
                string asciiKey = FromCharArrayToString(this.GetAsciiChars(this.key));

                int point = 0;
                for (int i = 0; i < K.Length; i++)
                {
                    uint output;
                    output = ((uint)asciiKey[point]);
                    output += ((uint)asciiKey[point + 1] << 8);
                    output += ((uint)asciiKey[point + 2] << 16);
                    output += ((uint)asciiKey[point + 3] << 24);
                    point += 4;
                    K[i] = output;
                }


            }
        }

        char[] GetAsciiChars(string source)
        {
            Encoding ascii = Encoding.ASCII;
            Encoding enc_default = Encoding.Default;

            byte[] asciiBytes = Encoding.Convert(enc_default, ascii, enc_default.GetBytes(this.key));
            char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];

            ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);

            return asciiChars;
        }

        string FromCharArrayToString(char[] start)
        {
            string ret = "";
            for (int i = 0; i < start.Length; i++)
            {
                ret += start[i];
            }

            return ret;
        }

        public void encryption()
        {
            int j = 0;
            uint L, R;
            UInt32 sum;

            byte[] cryptedData = new byte[dataBytes.Length];

            while (j != dataBytes.Length)
            {
                if (dataBytes.Length - 8 >= j)
                {
                    L = BitConverter.ToUInt32(dataBytes, j);
                    R = BitConverter.ToUInt32(dataBytes, j + 4);

                    sum = 0;

                    for (int i = 0; i < 32; i++)
                    {
                        sum += delta;
                        L += (((R << 4) + K[0]) ^ (R + sum) ^ ((R >> 5) + K[1]));
                        R += (((L << 4) + K[2]) ^ (L + sum) ^ ((L >> 5) + K[3]));
                    }

                    BitConverter.GetBytes(L).CopyTo(cryptedData, j);
                    BitConverter.GetBytes(R).CopyTo(cryptedData, j + 4);

                    j += 8;
                }
                else
                {
                    /*if(j == dataBytes.Length - 1)
                    {*/
                    //ako ostane zadnji bajt kada se istrose parovi necemo da ga kriptujemo


                    cryptedData[j] = dataBytes[j];
                    j++; //prepisujem ostatak za sad ako ima manje od 8 bajtova
                         /*
                     }
                     else
                     {
                         // L = dataBytes[j];
                         // R = dataBytes[j + 1];

                         byte l = dataBytes[j];
                         byte r = dataBytes[];

                         sum = 0;

                         for (int i = 0; i < 32; i++)
                         {
                             sum += delta;
                             L += (((R << 4) + K[0]) ^ (R + sum) ^ ((R >> 5) + K[1]));
                             R += (((L << 4) + K[2]) ^ (L + sum) ^ ((L >> 5) + K[3]));
                         }

                         BitConverter.GetBytes(L).CopyTo(cryptedData, j);
                         BitConverter.GetBytes(R).CopyTo(cryptedData, j + 1);
                     }

                     j+=2;
                 }*/
                }
            }

            dataBytes = cryptedData;
        }

        public void startEncryption()
        {
            if (checkKey() == false) return;
            if (openFile() == false) return;

            encryption();
        }

        public bool openFile()
        {
            if (File.Exists(filePath))
            {
                dataBytes = File.ReadAllBytes(filePath);
                return true;
            }
            else return false;
        }

        public bool checkKey()
        {
            if (key.Length != 16) return false;
            else return true;
        }

    }
}
