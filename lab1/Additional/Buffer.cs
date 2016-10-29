using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Additional
{
    class Buffer
    {
        private List<string> buff;

        public Buffer(string[] fileArray)
        {
            buff = fileArray.Cast<string>().ToList();
        }

        public void deletedFile(string fileName)
        {
            buff.Remove(fileName);
        }

        public void createdFile(string fileName)
        {
            buff.Add(fileName);
        }

        public string getAndDeleteFirst()
        {
            if (buff.Count != 0)
            {
                string temp = buff.First();
                buff.Remove(temp);
                return temp;
            }

            return null;
        }

        public bool isEmpty()
        {
            if (buff.Count == 0) return true;
            else return false;
        }

    }
}
