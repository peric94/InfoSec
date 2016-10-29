using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab1.Algorithms
{
    class DoubleTranspositionCipher
    {
        private string fileSource;
        private string fileDestination;
        private int[] iperm;
        private int[] jperm;
        private string data;

        private string fileName;

        public DoubleTranspositionCipher(int[] rowPerm, int[] columnPerm, string fileSrc, string fileDest)
        {
            iperm = rowPerm;
            jperm = columnPerm;
            fileSource = fileSrc;
            fileDestination = fileDest;
        }

        public bool openAndReadTxt()
        {
            string extension = Path.GetExtension(fileSource);
            fileName = Path.GetFileNameWithoutExtension(fileSource);

            if(File.Exists(fileSource) && ( string.Equals(".txt", extension) || string.Equals(".dtc", extension) ))
            {
                using (StreamReader sr = File.OpenText(fileSource))
                {
                    data = sr.ReadToEnd();
                }

                return true;
            }
            else return false;
        }

        public bool saveToFile(string extension)
        {
            if (string.Equals(".txt", extension) || string.Equals(".dtc", extension))
            {
                File.WriteAllText(fileDestination + "\\" + fileName + extension, data);
                return true;
            }
            else return false;
        }

        public void parseData()
        {
            char[] parsedTemp;
            char[] unparsedTemp = data.ToCharArray();

            parsedTemp = new char[data.Length];
            int j = 0;

            for(int i = 0; i < data.Length; i++)
            {
                if(char.IsWhiteSpace(unparsedTemp[i]) == false && char.IsPunctuation(unparsedTemp[i]) == false)
                {
                    if(char.IsUpper(unparsedTemp[i]))
                    {
                        parsedTemp[j] = char.ToLower(unparsedTemp[i]);
                    }
                    else
                    {
                        parsedTemp[j] = unparsedTemp[i];
                    }

                    j++;
                }
            }

            data = new string(parsedTemp);
            data = data.Replace("\0", string.Empty);
        }

        public bool isKeyRequirementValid()
        {
            /*if (iperm.Length * jperm.Length != data.Length) return false;
            return true;*/

            if (iperm == null || jperm == null) return false;
            return true;
        }

        public bool encryptionDecryption(int mode) //mode = 0 za enkripciju, mode = 1 za dekripciju
        {
            if (mode != 0 && mode != 1) return false;
            if (openAndReadTxt() == false) return false;

            if(mode == 0)
            parseData();
            if (isKeyRequirementValid() == false) return false;

            char[] arrayTemp = data.ToCharArray();
            char[][] matTemp = new char[iperm.Length][];
            
            for(int i = 0; i < iperm.Length; i++)
            {
                matTemp[i] = new char[jperm.Length];
            }

            int k = 0;

            for (int i = 0; i < iperm.Length; i++)
            {
                for(int j = 0; j < jperm.Length; j++)
                {
                    if (k > arrayTemp.Length - 1) break;
                    matTemp[i][j] = arrayTemp[k];
                    k++;
                }
            }

            MatrixPermutation operation = new MatrixPermutation(iperm, jperm, matTemp);

            if (mode == 0)
            {
                operation.ipermOperation();
                operation.jpermOperation();
            }
            else
            {
                operation.jpermInverseOperation();
                operation.ipermInverseOperation();
            }

            matTemp = operation.getMatrix();

            arrayTemp = new char[iperm.Length * jperm.Length];

            k = 0;

            for (int i = 0; i < iperm.Length; i++)
            {
                for (int j = 0; j < jperm.Length; j++)
                {
                    arrayTemp[k] = matTemp[i][j];
                    k++;
                }
            }

            data = new string(arrayTemp);
            //data = data.Replace("\0", string.Empty);

            if(mode == 0)
            {
                if (saveToFile(".dtc") == false) return false;
            }
            else
            {
                data = data.Replace("\0", string.Empty);
                if (saveToFile(".txt") == false)
                {
                    return false;
                }
            }

            return true;
        }

        public bool encDec(int mode)
        {
            if (mode != 0 && mode != 1) return false;
            if (openAndReadTxt() == false) return false;
            if (mode == 0) parseData();

            char[] arrayTemp;
            char[][] matTemp;
            string buffer = string.Empty;
            int currentPosition = 0;
            MatrixPermutation operation;

            int k;

            while (data.Substring(currentPosition).Length > iperm.Length * jperm.Length)
            {
                arrayTemp = data.Substring(currentPosition).ToCharArray();

                matTemp = new char[iperm.Length][];

                for(int i = 0; i < iperm.Length; i++)
                {
                    matTemp[i] = new char[jperm.Length];
                }

                k = 0;

                for (int i = 0; i < iperm.Length; i++)
                {
                    for (int j = 0; j < jperm.Length; j++)
                    {
                        matTemp[i][j] = arrayTemp[k];
                        k++;
                    }
                }

                operation = new MatrixPermutation(iperm, jperm, matTemp);

                if (mode == 0)
                {
                    operation.ipermOperation();
                    operation.jpermOperation();
                }
                else
                {
                    operation.jpermInverseOperation();
                    operation.ipermInverseOperation();
                }

                matTemp = operation.getMatrix();

                arrayTemp = new char[iperm.Length * jperm.Length];

                k = 0;

                for (int i = 0; i < iperm.Length; i++)
                {
                    for (int j = 0; j < jperm.Length; j++)
                    {
                        arrayTemp[k] = matTemp[i][j];
                        k++;
                    }
                }

                buffer = buffer.Insert(buffer.Length, new string(arrayTemp));
                currentPosition += iperm.Length * jperm.Length;

            }

            //STARI KOD, KOJI VAZI KADA MATRICA NIJE MANJA OD TEKSTA



            arrayTemp = data.Substring(currentPosition).ToCharArray();
            matTemp = new char[iperm.Length][];

            for (int i = 0; i < iperm.Length; i++)
            {
                matTemp[i] = new char[jperm.Length];
            }

            k = 0;

            for (int i = 0; i < iperm.Length; i++)
            {
                for (int j = 0; j < jperm.Length; j++)
                {
                    if (k > arrayTemp.Length - 1) break;
                    matTemp[i][j] = arrayTemp[k];
                    k++;
                }
            }

            operation = new MatrixPermutation(iperm, jperm, matTemp);

            if (mode == 0)
            {
                operation.ipermOperation();
                operation.jpermOperation();
            }
            else
            {
                operation.jpermInverseOperation();
                operation.ipermInverseOperation();
            }

            matTemp = operation.getMatrix();

            arrayTemp = new char[iperm.Length * jperm.Length];

            k = 0;

            for (int i = 0; i < iperm.Length; i++)
            {
                for (int j = 0; j < jperm.Length; j++)
                {
                    arrayTemp[k] = matTemp[i][j];
                    k++;
                }
            }

            buffer = buffer.Insert(buffer.Length, new string(arrayTemp));
            //data = new string(arrayTemp);
            data = buffer;
            //data = data.Replace("\0", string.Empty);

            if (mode == 0)
            {
                if (saveToFile(".dtc") == false) return false;
            }
            else
            {
                data = data.Replace("\0", string.Empty);
                if (saveToFile(".txt") == false)
                {
                    return false;
                }
            }

            return true;


        }


    }
}
