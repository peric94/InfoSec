using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Algorithms
{
    class MatrixPermutation
    {
        public static char[][] rowPermutation(int[] rowPerm, int numberOfColumns, char[][] mat)
        {
            int n = rowPerm.Length;
            int m = numberOfColumns;

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

            //GORE JE NAPRAVLJENA KOPIJA PROSLEDJENE MATRICE

            for (int i = 0; i < n; i++)
            {
                matClone[i] = mat[rowPerm[i] - 1];
            }

            return matClone;

            //IZNAD JE IZVRSENA PERMUTACIJA NAD VRSTAMA
        }

        public static char[][] columnPermutation(int numberOfRows, int[] columnPerm, char[][] mat)
        {
            int n = numberOfRows;
            int m = columnPerm.Length;

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

            //PERMUTACIJE NAD KOLONAMA:

            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    matClone[i][j] = mat[i][columnPerm[j] - 1];
                }
            }

            return matClone;
        }

        public static char[][] rowPermutationInverse(int[] rowPerm, int numberOfColumns, char[][] mat)
        {
            int n = rowPerm.Length;
            int m = numberOfColumns;

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

            //GORE JE NAPRAVLJENA KOPIJA PROSLEDJENE MATRICE

            for (int i = 0; i < n; i++)
            {
                matClone[rowPerm[i] - 1] = mat[i];
            }

            return matClone;

            //IZNAD JE IZVRSENA INVERZNA PERMUTACIJA NAD VRSTAMA
        }

        public static char[][] columnPermutationInverse(int numberOfRows, int[] columnPerm, char[][] mat)
        {
            int n = numberOfRows;
            int m = columnPerm.Length;

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

            //INVERZNE PERMUTACIJE NAD KOLONAMA:

            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    matClone[i][columnPerm[j] - 1] = mat[i][j];
                }
            }

            return matClone;
        }

    }
}
