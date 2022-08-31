using System;
using System.Text;

using VectorTask;

namespace MatrixTask
{
    internal class Matrix
    {
        private Vector[] rows;

        private const double Epsilon = 1.0e-10;

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

            rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i] = new Vector(columnsCount);
            }
        }

        public Matrix(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix must not be null");
            }

            rows = new Vector[matrix.rows.Length];

            for (int i = 0; i < matrix.rows.Length; i++)
            {
                rows[i] = new Vector(matrix.rows[i]);
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

            rows = new Vector[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                double[] arrayRow = new double[array.GetLength(1)];

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    arrayRow[j] = array[i, j];
                }

                rows[i] = new Vector(arrayRow);
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

            rows = new Vector[vectorsArrayLength];

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
                rows[i] = new Vector(maxVectorSize).Add(vectorsArray[i]);
            }
        }

        /// <summary>
        /// Gets number of matrix rows (Matrix M rows x columns)
        /// </summary>        
        public int GetRowsCount()
        {
            return rows.Length;
        }

        /// <summary>
        /// Gets number of matrix columns (Matrix M rows x columns)
        /// </summary>        
        public int GetColumnsCount()
        {
            return rows[0].GetSize();
        }

        /// <summary>
        /// Gets a value of a current matrix Nth row (as vector) by index
        /// </summary>
        public Vector GetRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= rows.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(rowIndex), $"RowIndex = {rowIndex}, but it must be in range [0; {rows.Length - 1}]");
            }

            return new Vector(rows[rowIndex]);
        }

        /// <summary>
        /// Sets a value of a current matrix Nth row (as vector) by index
        /// </summary>
        public void SetRow(int rowIndex, Vector vector)
        {
            int rowsCount = rows.Length;

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
                rows[rowIndex].SetComponent(i, vector.GetComponent(i));
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

            Vector columnVector = new Vector(rows.Length);

            for (int i = 0; i < rows.Length; i++)
            {
                columnVector.SetComponent(i, rows[i].GetComponent(columnIndex));
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

            rows = transposedMatrixRows;

            return this;
        }

        /// <summary>
        /// Multiplies a matrix by a scalar. Returns modified matrix
        /// </summary>
        public Matrix MultiplyByScalar(double value)
        {
            foreach (Vector vector in rows)
            {
                vector.MultiplyByScalar(value);
            }

            return this;
        }

        public double GetDeterminant()
        {
            int rowsCount = rows.Length;
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
                    matrix[i, j] = rows[i].GetComponent(j);
                }
            }

            // Алгоритм Барейса с перестановкой строк
            double determinant = 1;
            int swapRowsCount = 0;

            for (int i = 0; i < rowsCount - 1; i++)
            {
                int maxMatrixElementAbsValueIndex = i;
                double maxMatrixElementAbsValue = Math.Abs(matrix[i, i]);

                for (int j = i + 1; j < rowsCount; j++)
                {
                    double matrixElementAbsValue = Math.Abs(matrix[j, i]);

                    if (matrixElementAbsValue > maxMatrixElementAbsValue)
                    {
                        maxMatrixElementAbsValueIndex = j;
                        maxMatrixElementAbsValue = matrixElementAbsValue;
                    }
                }

                if (maxMatrixElementAbsValueIndex > i)
                {
                    SwapRows(matrix, i, maxMatrixElementAbsValueIndex);
                    swapRowsCount++;
                }
                else
                {
                    if (Math.Abs(maxMatrixElementAbsValue) <= Epsilon) // maxMatrixElementAbsValue == 0
                    {
                        return 0;
                    }
                }

                double matrixMainDiagonalElement = matrix[i, i];

                for (int j = i + 1; j < rowsCount; j++)
                {
                    double currentMatrixElement = matrix[j, i];
                    matrix[j, i] = 0;

                    for (int k = i + 1; k < rowsCount; k++)
                    {
                        matrix[j, k] = (matrix[j, k] * matrixMainDiagonalElement - matrix[i, k] * currentMatrixElement) / determinant;
                    }
                }

                determinant = matrixMainDiagonalElement;
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

            foreach (Vector vector in rows)
            {
                sb.Append(vector).Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append('}');

            return sb.ToString();
        }

        /// <summary>
        /// Multiplies current matrix by column-vector. Returns new vector
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

            int rowsCount = rows.Length;

            double[] vectorComponentsArray = new double[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                vectorComponentsArray[i] = Vector.GetScalarProduct(rows[i], vector);
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
                rows[i].Add(matrix.rows[i]);
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
                rows[i].Subtract(matrix.rows[i]);
            }

            return this;
        }

        /// <summary>
        /// Adds two matrices and returns the result as a matrix object
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
        /// Subtracts matrices (matrix1 - matrix2) and returns the result as a matrix object
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
        /// Multiplies two matrices and returns the result as a matrix object
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
                        array[i, j] += matrix1.rows[i].GetComponent(k) * matrix2.rows[k].GetComponent(j);
                    }
                }
            }

            return new Matrix(array);
        }
    }
}