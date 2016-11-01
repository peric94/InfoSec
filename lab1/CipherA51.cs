using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab1
{
    class CipherA51
    {
        private string sourceFile;
        private string destinationFile;
        private string key;

        public CipherA51(string key, string srcFile, string dstFile)
        {
            this.key = key;
            sourceFile = srcFile;
            destinationFile = dstFile;
        }

        public bool checkKey()
        {
            if (key.Length != 8) //64-bit kljuc!!!!!!
            {
                return false;
            }

            return true;
        }

        public string GetBits(string input)
        {
            StringBuilder sb = new StringBuilder();
            byte[] Bytes = Encoding.ASCII.GetBytes(key);

            foreach (byte b in Bytes)
            {
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public bool encryptionDecryption()
        {
            if (checkKey() == false) return false;

            if (File.Exists(sourceFile))
            {
               // string wtf = GetBits(key);
                Algorithms.A51 cipher = new Algorithms.A51(GetBits(key));
                string temp;
                byte temp2;

                using (BinaryReader reader = new BinaryReader(File.Open(sourceFile, FileMode.Open)))
                {
                    using (FileStream fileStream = new FileStream(destinationFile, FileMode.Create))
                    {
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            temp2 = reader.ReadByte();
                            temp = Convert.ToString(temp2, 2).PadLeft(8, '0');
                            temp = cipher.Crypt(temp); //izvrsava se kriptovanje
                            fileStream.WriteByte(Convert.ToByte(temp, 2));
                        }
                    }
                }

                return true;
            }
            else return false;
        }

    }
}
