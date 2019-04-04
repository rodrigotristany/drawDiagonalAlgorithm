using System;
using System.Collections.Generic;

namespace drawDiagonalAlgorithm
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int m = 16;
            int n = 24;
            int orientation = -1;
            Point point = new Point() { X = 4, Y = 5 };

            List<List<int>> matrix = new List<List<int>>();
            for(var i = 0; i < n; i++)
            {
                matrix.Insert(i, new List<int>());
                for (var j = 0; j < m; j++)
                {
                    matrix[i].Insert(j, 0);
                }
            }

            List<List<int>> matrixDiag = drawDiagonal(matrix, point, orientation, m, n);

            printMatrix(matrixDiag);
        }

        private static List<List<int>> drawDiagonal(List<List<int>> matrix, Point startPoint, int orientation, int m, int n)
        {
            Point advancedPositive = new Point() { X = startPoint.X + 1, Y = startPoint.Y + 1 * orientation};
            Point advancedNegative = new Point() { X = startPoint.X - 1, Y = startPoint.Y - 1 * orientation};
            matrix[startPoint.Y][startPoint.X] = 1;

            while(advancedPositive.X < m && (advancedPositive.Y < n && advancedPositive.Y >= 0))
            {
                matrix[advancedPositive.Y][advancedPositive.X] = 1;
                advancedPositive.X += 1;
                advancedPositive.Y += 1 * orientation;
            }

            while (advancedNegative.X >= 0 && (advancedNegative.Y >= 0 && advancedNegative.Y < n))
            {
                matrix[advancedNegative.Y][advancedNegative.X] = 1;
                advancedNegative.X -= 1;
                advancedNegative.Y -= 1 * orientation;
            }

            return matrix;
        }

        private static void printMatrix(List<List<int>> matrixDiag)
        {
            foreach(var line in matrixDiag)
            {
                foreach(var cell in line)
                {
                    Console.Write(cell + "  ");
                }
                Console.Write("\n");
            }
        }
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
