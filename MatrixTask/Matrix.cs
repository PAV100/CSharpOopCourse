using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VectorTask;

namespace MatrixTask
{
    internal class Matrix
    {
        private Vector[] matrix;

        public Matrix(int height, int width)
        {
            if (height <= 0)
            {
                throw new ArgumentException($"Matrix height = {height}, but it must be > 0", nameof(height));
            }

            if (width <= 0)
            {
                throw new ArgumentException($"Matrix width = {width}, but it must be > 0", nameof(width));
            }

            matrix = new Vector[height];

            for (int i = 0; i < height; i++)
            {
                matrix[i] = new Vector(width);
            }
        }

        public Matrix(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException("matrix must not be null", nameof(matrix));
            }

            this.matrix = new Vector[matrix.matrix.Length];

            Array.Copy(matrix.matrix, this.matrix, matrix.matrix.Length);
        }

        public Matrix(double[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException("array must not be null", nameof(array));
            }

            if (array.GetLength(0) == 0)
            {
                throw new ArgumentException("array height must be > 0", nameof(array));
            }

            if (array.GetLength(1) == 0)
            {
                throw new ArgumentException("array width must be > 0", nameof(array));
            }

            matrix = new Vector[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                double[] arrayRow = new double[array.GetLength(1)];

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    arrayRow[j] = array[i, j];
                }

                matrix[i] = new Vector(arrayRow);
            }
        }

        public Matrix(Vector[] vectorsArray)
        {
            if (vectorsArray is null)
            {
                throw new ArgumentNullException("vectorsArray must not be null", nameof(vectorsArray));
            }

            int vectorsArrayLength = vectorsArray.Length;

            if (vectorsArrayLength == 0)
            {
                throw new ArgumentException("vectorsArray length must be > 0", nameof(vectorsArray));
            }

            matrix = new Vector[vectorsArrayLength];

            int maxVectorSize = 0;

            foreach (Vector vector in vectorsArray)
            {
                int vectorSize = vector.GetSize();

                if (vectorSize > maxVectorSize)
                {
                    maxVectorSize = vectorSize;
                }
            }

            for (int i = 0; i < vectorsArrayLength; i++)
            {
                int vectorSize = vectorsArray[i].GetSize();

                if (vectorSize == maxVectorSize)
                {
                    matrix[i] = new Vector(vectorsArray[i]);
                }
                else
                {
                    matrix[i] = new Vector(maxVectorSize);

                    for (int j = 0; j < vectorSize; j++)
                    {
                        matrix[i].SetComponent(j, vectorsArray[i].GetComponent(j));
                    }
                }
            }
        }

        /// <summary>
        /// Gets matrix height (M nxm, size n)
        /// </summary>        
        public int GetHeight()
        {
            return matrix.Length;
        }

        /// <summary>
        /// Gets matrix width (M nxm, size m)
        /// </summary>        
        public int GetWidth()
        {
            return matrix[0].GetSize();
        }

        /// <summary>
        /// Gets a value of a current matrix Nth row (as vector) by index
        /// </summary>
        public Vector GetRowVector(int rowVectorIndex)
        {
            if (rowVectorIndex < 0 || rowVectorIndex >= matrix.Length)
            {
                throw new ArgumentOutOfRangeException($"rowVectorIndex = {rowVectorIndex}, but it must be in range [0; {matrix.Length - 1}]", nameof(rowVectorIndex));
            }

            return matrix[rowVectorIndex];
        }

        /// <summary>
        /// Sets a value of a current matrix Nth row (as vector) by index
        /// </summary>
        public void SetRowVector(int rowVectorIndex, Vector vector)
        {
            if (rowVectorIndex < 0 || rowVectorIndex >= matrix.Length)
            {
                throw new ArgumentOutOfRangeException($"rowVectorIndex = {rowVectorIndex}, but it must be in range [0; {matrix.Length - 1}]", nameof(rowVectorIndex));
            }

            int matrixWidth = matrix[0].GetSize();
            int vectorSize = vector.GetSize();

            for (int i = 0; i < matrixWidth; i++)
            {
                if (i < vectorSize)
                {
                    matrix[rowVectorIndex].SetComponent(i, vector.GetComponent(i));
                }
                else
                {
                    matrix[rowVectorIndex].SetComponent(i, 0);
                }

            }
        }

        /// <summary>
        /// Gets a value of a current matrix Nth column (as vector) by index
        /// </summary>
        public Vector GetColumnVector(int columnVectorIndex)
        {
            if (columnVectorIndex < 0 || columnVectorIndex >= matrix[0].GetSize())
            {
                throw new ArgumentOutOfRangeException($"columnVectorIndex = {columnVectorIndex}, but it must be in range [0; {matrix[0].GetSize() - 1}]", nameof(columnVectorIndex));
            }

            Vector columnVector = new Vector(matrix.Length);

            for (int i = 0; i < matrix.Length; i++)
            {
                columnVector.SetComponent(i, matrix[i].GetComponent(columnVectorIndex));
            }

            return columnVector;
        }

        /// <summary>
        /// Transposes a matrix
        /// </summary>
        public Matrix Transpose()
        {
            int matrixHeight = matrix.Length;
            int matrixWidth = matrix[0].GetSize();

            double[][] tranposedArray = new double[matrixWidth][];

            for (int i = 0; i < matrixWidth; i++)
            {
                tranposedArray[i] = new double[matrixHeight];

                for (int j = 0; j < matrixHeight; j++)
                {
                    tranposedArray[i][j] = matrix[j].GetComponent(i);
                }
            }

            Vector[] transposedMatrix = new Vector[matrixWidth];

            for (int i = 0; i < matrixWidth; i++)
            {
                transposedMatrix[i] = new Vector(tranposedArray[i]);
            }

            matrix = transposedMatrix;

            return this;
        }

        /// <summary>
        /// Multiplies a matrix by a scalar. Returns modified matrix
        /// </summary>
        public Matrix MultiplyByScalar(double value)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i].MultiplyByScalar(value);
            }

            return this;
        }

        public double GetDeterminant()
        {
            int matrixHeight = this.matrix.Length;
            int matrixWidth = this.matrix[0].GetSize();

            if (matrixHeight != matrixWidth)
            {
                throw new ArgumentException($"matrix dimensions are {matrixHeight}x{matrixWidth}, but matrix must be square");
            }

            double[,] matrix = new double[matrixHeight, matrixHeight];

            for (int i = 0; i < matrixHeight; i++)
            {
                for (int j = 0; j < matrixHeight; j++)
                {
                    matrix[i, j] = this.matrix[i].GetComponent(j);
                }
            }

            // Алгоритм Барейса с перестановкой строк
            double determinant = 1;
            int swapRowsCount = 0;

            for (int i = 0; i < matrixHeight - 1; i++)
            {
                int maxMatrixElementIndex = i;
                double maxMatrixElement = Math.Abs(matrix[i, i]);

                for (int j = i + 1; j < matrixHeight; j++)
                {
                    double temp1MatrixElement = Math.Abs(matrix[j, i]);

                    if (temp1MatrixElement > maxMatrixElement)
                    {
                        maxMatrixElementIndex = j;
                        maxMatrixElement = temp1MatrixElement;
                    }
                }

                if (maxMatrixElementIndex > i)
                {
                    SwapRows(matrix, i, maxMatrixElementIndex);
                    swapRowsCount++;
                }
                else
                {
                    if (maxMatrixElement == 0)
                    {
                        return 0;
                    }
                }

                double temp2MatrixElement = matrix[i, i];

                for (int j = i + 1; j < matrixHeight; j++)
                {
                    double temp3MatrixElement = matrix[j, i];
                    matrix[j, i] = 0;

                    for (int k = i + 1; k < matrixHeight; k++)
                    {
                        matrix[j, k] = (matrix[j, k] * temp2MatrixElement - matrix[i, k] * temp3MatrixElement) / determinant;
                    }
                }

                determinant = temp2MatrixElement;
            }

            if (swapRowsCount % 2 != 0)
            {
                return -matrix[matrixHeight - 1, matrixHeight - 1];
            }
            else
            {
                return matrix[matrixHeight - 1, matrixHeight - 1];
            }
        }

        /// <summary>
        /// Swaps two rows in an array adreessed by row1Index and row2Index
        /// </summary>        
        private static void SwapRows(double[,] array, int row1Index, int row2Index)
        {
            double temp;

            for (int k = 0; k < array.GetLength(1); k++)
            {
                temp = array[row1Index, k];
                array[row1Index, k] = array[row2Index, k];
                array[row2Index, k] = temp;
            }
        }

        /// <summary>
        /// Converts matrix to a string like {{M11, M12, ..., M1m},...,{Mn1, Mn2, ..., Mnm}}
        /// </summary>        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append('{');

            for (int i = 0; i < matrix.Length; i++)
            {
                if (i != 0)
                {
                    sb.Append(',');
                }

                sb.Append(matrix[i].ToString());
            }

            sb.Append('}');

            return sb.ToString();
        }

        /// <summary>
        /// Multiplies current matrix by column-vector
        /// </summary>        
        public Matrix MultiplyByColumnVector(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException("vector must not be null", nameof(vector));
            }

            int matrixWidth = matrix[0].GetSize();
            int vectorSize = vector.GetSize();

            if (matrixWidth != vectorSize)
            {
                throw new ArgumentException($"matrix width = {matrixWidth}, and vector size = {vectorSize} but they must be equal", nameof(vector));
            }

            int matrixHeight = matrix.Length;

            double[][] array = new double[matrixHeight][];

            Vector[] newMatrix = new Vector[matrixHeight];

            for (int i = 0; i < matrixHeight; i++)
            {
                array[i] = new double[1];

                for (int j = 0; j < matrixWidth; j++)
                {
                    array[i][0] += matrix[i].GetComponent(j) * vector.GetComponent(j);
                }

                newMatrix[i] = new Vector(array[i]);
            }

            matrix = newMatrix;

            return this;
        }

        /// <summary>
        /// Multiplies current matrix by row-vector
        /// </summary>        
        public Matrix MultiplyByRowVector(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException("vector must not be null", nameof(vector));
            }

            int matrixWidth = matrix[0].GetSize();

            if (matrixWidth != 1)
            {
                throw new ArgumentException($"matrix width = {matrixWidth}, but it must be = 1", nameof(vector));
            }

            int matrixHeight = matrix.Length;
            int vectorSize = vector.GetSize();

            double[][] array = new double[matrixHeight][];

            Vector[] newMatrix = new Vector[matrixHeight];

            for (int i = 0; i < matrixHeight; i++)
            {
                array[i] = new double[vectorSize];

                for (int j = 0; j < vectorSize; j++)
                {
                    array[i][j] += matrix[i].GetComponent(0) * vector.GetComponent(j);
                }

                newMatrix[i] = new Vector(array[i]);
            }

            matrix = newMatrix;

            return this;
        }

        /// <summary>
        /// Adds a matrix to current matrix
        /// </summary>        
        public Matrix Add(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException("matrix must not be null", nameof(matrix));
            }

            int matrix1Height = this.GetHeight();
            int matrix1Width = this.GetWidth();

            int matrix2Height = matrix.GetHeight();
            int matrix2Width = matrix.GetWidth();

            if (matrix1Height != matrix2Height || matrix1Width != matrix2Width)
            {
                throw new ArgumentException($"matrix1 is {matrix1Height}x{matrix1Width}, matrix2 is {matrix2Height}x{matrix2Width} but they must be equal", nameof(matrix));
            }

            for (int i = 0; i < matrix1Height; i++)
            {
                for (int j = 0; j < matrix1Width; j++)
                {
                    this.matrix[i].SetComponent(j, this.matrix[i].GetComponent(j) + matrix.matrix[i].GetComponent(j));
                }
            }

            return this;
        }

        /// <summary>
        /// Subtracts a matrix from current matrix
        /// </summary>        
        public Matrix Subtract(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException("matrix must not be null", nameof(matrix));
            }

            int matrix1Height = this.GetHeight();
            int matrix1Width = this.GetWidth();

            int matrix2Height = matrix.GetHeight();
            int matrix2Width = matrix.GetWidth();

            if (matrix1Height != matrix2Height || matrix1Width != matrix2Width)
            {
                throw new ArgumentException($"matrix1 is {matrix1Height}x{matrix1Width}, matrix2 is {matrix2Height}x{matrix2Width} but they must be equal", nameof(matrix));
            }

            for (int i = 0; i < matrix1Height; i++)
            {
                for (int j = 0; j < matrix1Width; j++)
                {
                    this.matrix[i].SetComponent(j, this.matrix[i].GetComponent(j) - matrix.matrix[i].GetComponent(j));
                }
            }

            return this;
        }

        /// <summary>
        /// Adds two matrices and returnes the result as a matrix object
        /// </summary>
        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 is null)
            {
                throw new ArgumentNullException("matrix1 must not be null", nameof(matrix1));
            }

            if (matrix2 is null)
            {
                throw new ArgumentNullException("matrix2 must not be null", nameof(matrix2));
            }

            return (new Matrix(matrix1)).Add(matrix2);
        }

        /// <summary>
        /// Subtracts matrices (matrix1 - matrix2) and returnes the result as a matrix object
        /// </summary>
        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 is null)
            {
                throw new ArgumentNullException("matrix1 must not be null", nameof(matrix1));
            }

            if (matrix2 is null)
            {
                throw new ArgumentNullException("matrix2 must not be null", nameof(matrix2));
            }

            return (new Matrix(matrix1)).Subtract(matrix2);
        }

        /// <summary>
        /// Multiplies two matrices and returnes the result as a matrix object
        /// </summary>
        public static Matrix GetMultiplicationProduct(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 is null)
            {
                throw new ArgumentNullException("matrix1 must not be null", nameof(matrix1));
            }

            if (matrix2 is null)
            {
                throw new ArgumentNullException("matrix2 must not be null", nameof(matrix2));
            }

            int matrix1Width = matrix1.GetWidth();
            int matrix2Height = matrix2.GetHeight();

            if (matrix1Width != matrix2Height)
            {
                throw new ArgumentException($"matrix1 width is {matrix1Width}, matrix2 height is {matrix2Height}, but they must be equal", nameof(matrix1) + ", " + nameof(matrix2));
            }

            int matrix1Height = matrix1.GetHeight();
            int matrix2Width = matrix2.GetWidth();

            double[,] array = new double[matrix1Height, matrix2Width];

            for (int i = 0; i < matrix1Height; i++)
            {
                for (int j = 0; j < matrix2Width; j++)
                {
                    for (int k = 0; k < matrix1Width; k++)
                    {
                        array[i, j] += matrix1.matrix[i].GetComponent(k) * matrix2.matrix[k].GetComponent(j);
                    }
                }
            }

            return new Matrix(array);
        }
    }
}