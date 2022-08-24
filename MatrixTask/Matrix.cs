using System;
using System.Text;

using VectorTask;

namespace MatrixTask
{
    internal class Matrix
    {
        private Vector[] matrixRows;

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0)
            {
                throw new ArgumentException($"Number of rows in Matrix is {rowsCount}, but it must be > 0", nameof(rowsCount));
            }

            if (columnsCount <= 0)
            {
                throw new ArgumentException($"Number of columns in Matrix is {columnsCount}, but it must be > 0", nameof(columnsCount));
            }

            matrixRows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                matrixRows[i] = new Vector(columnsCount);
            }
        }

        public Matrix(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix must not be null");
            }

            matrixRows = new Vector[matrix.matrixRows.Length];

            for (int i = 0; i < matrix.matrixRows.Length; i++)
            {
                matrixRows[i] = new Vector(matrix.matrixRows[i]);
            }
        }

        public Matrix(double[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array must not be null");
            }

            if (array.GetLength(0) == 0)
            {
                throw new ArgumentException("Number of rows in array must be > 0", nameof(array));
            }

            if (array.GetLength(1) == 0)
            {
                throw new ArgumentException("Number of columns in array must be > 0", nameof(array));
            }

            matrixRows = new Vector[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                double[] arrayRow = new double[array.GetLength(1)];

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    arrayRow[j] = array[i, j];
                }

                matrixRows[i] = new Vector(arrayRow);
            }
        }

        public Matrix(Vector[] vectorsArray)
        {
            if (vectorsArray is null)
            {
                throw new ArgumentNullException(nameof(vectorsArray), "VectorsArray must not be null");
            }

            int vectorsArrayLength = vectorsArray.Length;

            if (vectorsArrayLength == 0)
            {
                throw new ArgumentException("VectorsArray length must be > 0", nameof(vectorsArray));
            }

            matrixRows = new Vector[vectorsArrayLength];

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
                matrixRows[i] = new Vector(maxVectorSize).Add(vectorsArray[i]);
            }
        }

        /// <summary>
        /// Gets number of matrix rows (Matrix M rows x columns)
        /// </summary>        
        public int GetRowsCount()
        {
            return matrixRows.Length;
        }

        /// <summary>
        /// Gets number of matrix columns (Matrix M rows x columns)
        /// </summary>        
        public int GetColumnsCount()
        {
            return matrixRows[0].GetSize();
        }

        /// <summary>
        /// Gets a value of a current matrix Nth row (as vector) by index
        /// </summary>
        public Vector GetRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= matrixRows.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(rowIndex), $"RowIndex = {rowIndex}, but it must be in range [0; {matrixRows.Length - 1}]");
            }

            return new Vector(matrixRows[rowIndex]);
        }

        /// <summary>
        /// Sets a value of a current matrix Nth row (as vector) by index
        /// </summary>
        public void SetRow(int rowIndex, Vector vector)
        {
            int rowsCount = matrixRows.Length;

            if (rowIndex < 0 || rowIndex >= rowsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(rowIndex), $"RowIndex = {rowIndex}, but it must be in range [0; {rowsCount - 1}]");
            }

            int columnsCount = GetColumnsCount();
            int vectorSize = vector.GetSize();

            if (columnsCount != vectorSize)
            {
                throw new ArgumentException($"Matrix has {columnsCount} column(s), vector size is {vectorSize}, but they must be equal", nameof(vector));
            }

            for (int i = 0; i < columnsCount; i++)
            {
                matrixRows[rowIndex].SetComponent(i, vector.GetComponent(i));
            }
        }

        /// <summary>
        /// Gets a value of a current matrix Nth column (as vector) by index
        /// </summary>
        public Vector GetColumn(int columnIndex)
        {
            int columnsCount = GetColumnsCount();

            if (columnIndex < 0 || columnIndex >= columnsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(columnIndex), $"ColumnIndex = {columnIndex}, but it must be in range [0; {columnsCount - 1}]");
            }

            Vector columnVector = new Vector(matrixRows.Length);

            for (int i = 0; i < matrixRows.Length; i++)
            {
                columnVector.SetComponent(i, matrixRows[i].GetComponent(columnIndex));
            }

            return columnVector;
        }

        /// <summary>
        /// Transposes a matrix
        /// </summary>
        public Matrix Transpose()
        {
            int columnsCount = GetColumnsCount();

            Vector[] transposedMatrixRows = new Vector[columnsCount];

            for (int i = 0; i < columnsCount; i++)
            {
                transposedMatrixRows[i] = new Vector(GetColumn(i));
            }

            matrixRows = transposedMatrixRows;

            return this;
        }

        /// <summary>
        /// Multiplies a matrix by a scalar. Returns modified matrix
        /// </summary>
        public Matrix MultiplyByScalar(double value)
        {
            foreach (Vector vector in matrixRows)
            {
                vector.MultiplyByScalar(value);
            }

            return this;
        }

        public double GetDeterminant()
        {
            int rowsCount = matrixRows.Length;
            int columnsCount = GetColumnsCount();

            if (rowsCount != columnsCount)
            {
                throw new InvalidOperationException($"Matrix dimensions are {rowsCount}x{columnsCount}, but matrix must be square");
            }

            double[,] matrix = new double[rowsCount, rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < rowsCount; j++)
                {
                    matrix[i, j] = matrixRows[i].GetComponent(j);
                }
            }

            // Алгоритм Барейса с перестановкой строк
            double determinant = 1;
            int swapRowsCount = 0;

            for (int i = 0; i < rowsCount - 1; i++)
            {
                int maxMatrixElementIndex = i;
                double maxMatrixElement = Math.Abs(matrix[i, i]);

                for (int j = i + 1; j < rowsCount; j++)
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

                for (int j = i + 1; j < rowsCount; j++)
                {
                    double temp3MatrixElement = matrix[j, i];
                    matrix[j, i] = 0;

                    for (int k = i + 1; k < rowsCount; k++)
                    {
                        matrix[j, k] = (matrix[j, k] * temp2MatrixElement - matrix[i, k] * temp3MatrixElement) / determinant;
                    }
                }

                determinant = temp2MatrixElement;
            }

            if (swapRowsCount % 2 != 0)
            {
                return -matrix[rowsCount - 1, rowsCount - 1];
            }

            return matrix[rowsCount - 1, rowsCount - 1];
        }

        /// <summary>
        /// Swaps two rows in an array adreessed by row1Index and row2Index
        /// </summary>        
        private static void SwapRows(double[,] array, int row1Index, int row2Index)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                double temp = array[row1Index, i];
                array[row1Index, i] = array[row2Index, i];
                array[row2Index, i] = temp;
            }
        }

        /// <summary>
        /// Converts matrix to a string like {{M11, M12, ..., M1m},...,{Mn1, Mn2, ..., Mnm}}
        /// </summary>        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append('{');

            foreach (Vector vector in matrixRows)
            {
                sb.Append(vector).Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append('}');

            return sb.ToString();
        }

        /// <summary>
        /// Multiplies current matrix by column-vector. Returnes new vector
        /// </summary>        
        public Vector MultiplyByColumnVector(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), "Vector must not be null");
            }

            int columnsCount = GetColumnsCount();
            int vectorSize = vector.GetSize();

            if (columnsCount != vectorSize)
            {
                throw new ArgumentException($"Matrix has {columnsCount} column(s), vector size is {vectorSize}, but they must be equal", nameof(vector));
            }

            int rowsCount = matrixRows.Length;

            double[] vectorComponentsArray = new double[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                vectorComponentsArray[i] = Vector.GetScalarProduct(matrixRows[i], vector);
            }

            return new Vector(vectorComponentsArray);
        }

        /// <summary>
        /// Adds a matrix to current matrix
        /// </summary>        
        public Matrix Add(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix must not be null");
            }

            CheckMatrixSizesEqual(this, matrix);

            int thisMatrixRowsCount = GetRowsCount();

            for (int i = 0; i < thisMatrixRowsCount; i++)
            {
                matrixRows[i].Add(matrix.matrixRows[i]);
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
                throw new ArgumentNullException(nameof(matrix), "Matrix must not be null");
            }

            CheckMatrixSizesEqual(this, matrix);

            int thisMatrixRowsCount = GetRowsCount();

            for (int i = 0; i < thisMatrixRowsCount; i++)
            {
                matrixRows[i].Subtract(matrix.matrixRows[i]);
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
                throw new ArgumentNullException(nameof(matrix1), "Matrix1 must not be null");
            }

            if (matrix2 is null)
            {
                throw new ArgumentNullException(nameof(matrix2), "Matrix2 must not be null");
            }

            CheckMatrixSizesEqual(matrix1, matrix2);

            return new Matrix(matrix1).Add(matrix2);
        }

        /// <summary>
        /// Subtracts matrices (matrix1 - matrix2) and returnes the result as a matrix object
        /// </summary>
        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 is null)
            {
                throw new ArgumentNullException(nameof(matrix1), "Matrix1 must not be null");
            }

            if (matrix2 is null)
            {
                throw new ArgumentNullException(nameof(matrix2), "Matrix2 must not be null");
            }

            CheckMatrixSizesEqual(matrix1, matrix2);

            return new Matrix(matrix1).Subtract(matrix2);
        }

        /// <summary>
        /// Checks if two matrices have the same sizes and can be added (subtracted). If no - throws an exception
        /// </summary>
        private static void CheckMatrixSizesEqual(Matrix matrix1, Matrix matrix2)
        {
            int matrix1RowsCount = matrix1.GetRowsCount();
            int matrix1ColumnsCount = matrix1.GetColumnsCount();

            int matrix2RowsCount = matrix2.GetRowsCount();
            int matrix2ColumnsCount = matrix2.GetColumnsCount();

            if (matrix1RowsCount != matrix2RowsCount || matrix1ColumnsCount != matrix2ColumnsCount)
            {
                throw new ArgumentException($"Matrix1 is {matrix1RowsCount}x{matrix1ColumnsCount}, matrix2 is {matrix2RowsCount}x{matrix2ColumnsCount}, but they must be equal",
                    nameof(matrix1) + ", " + nameof(matrix2));
            }
        }

        /// <summary>
        /// Multiplies two matrices and returnes the result as a matrix object
        /// </summary>
        public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 is null)
            {
                throw new ArgumentNullException(nameof(matrix1), "Matrix1 must not be null");
            }

            if (matrix2 is null)
            {
                throw new ArgumentNullException(nameof(matrix2), "Matrix2 must not be null");
            }

            int matrix1ColumnsCount = matrix1.GetColumnsCount();
            int matrix2RowsCount = matrix2.GetRowsCount();

            if (matrix1ColumnsCount != matrix2RowsCount)
            {
                throw new ArgumentException($"Matrix1 has {matrix1ColumnsCount} column(s), matrix2 has {matrix2RowsCount} row(s), but they must have equal",
                    nameof(matrix1) + ", " + nameof(matrix2));
            }

            int matrix1RowsCount = matrix1.GetRowsCount();
            int matrix2ColumnsCount = matrix2.GetColumnsCount();

            double[,] array = new double[matrix1RowsCount, matrix2ColumnsCount];

            for (int i = 0; i < matrix1RowsCount; i++)
            {
                for (int j = 0; j < matrix2ColumnsCount; j++)
                {
                    for (int k = 0; k < matrix1ColumnsCount; k++)
                    {
                        array[i, j] += matrix1.matrixRows[i].GetComponent(k) * matrix2.matrixRows[k].GetComponent(j);
                    }
                }
            }

            return new Matrix(array);
        }
    }
}