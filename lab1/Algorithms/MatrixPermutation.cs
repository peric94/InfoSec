using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Algorithms
{
    class MatrixPermutation
    {
        private char[][] mat;
        private int n;
        private int m;

        private int[] iperm;
        private int[] jperm;

        public MatrixPermutation(int[] iperm, int[] jperm, char[][] mat)
        {
            this.iperm = iperm;
            this.jperm = jperm;
            this.mat = mat;

            n = this.iperm.Length;
            m = this.jperm.Length;
        }

        public char[][] getMatrix()
        {
            return mat;
        }

        public void ipermOperation()
        {
            char[][] matClone = new char[n][];

            for(int i = 0; i < n; i++)
            {
                matClone[i] = new char[m];
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    matClone[i][j] = mat[i][j];
                }
            }

            //nad mat cemo vrsiti permutacije pomocu ove kopije

            for(int i = 0; i < n; i++)
            {
                mat[i] = matClone[iperm[i] - 1]; //ima -1 zbog toga sto su iperm i jperm indeksi od 1 pa na dalje
            }
        }

        public void jpermOperation()
        {
            char[][] matClone = new char[n][];

            for (int i = 0; i < n; i++)
            {
                matClone[i] = new char[m];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matClone[i][j] = mat[i][j];
                }
            }

            //nad mat cemo vrsiti permutacije pomocu ove kopije

            for(int j = 0; j < m; j++)
            {
                for(int i = 0; i < n; i++)
                {
                    mat[i][j] = matClone[i][jperm[j] - 1];
                }
            }
        }

        public void ipermInverseOperation()
        {
            char[][] matClone = new char[n][];

            for (int i = 0; i < n; i++)
            {
                matClone[i] = new char[m];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matClone[i][j] = mat[i][j];
                }
            }

            //nad mat cemo vrsiti permutacije pomocu ove kopije

            for (int i = 0; i < n; i++)
            {
                mat[iperm[i] - 1] = matClone[i]; //ima -1 zbog toga sto su iperm i jperm indeksi od 1 pa na dalje
            }
        }

        public void jpermInverseOperation()
        {
            char[][] matClone = new char[n][];

            for (int i = 0; i < n; i++)
            {
                matClone[i] = new char[m];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matClone[i][j] = mat[i][j];
                }
            }

            //nad mat cemo vrsiti permutacije pomocu ove kopije

            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    mat[i][jperm[j] - 1] = matClone[i][j];
                }
            }
        }

    }
}
