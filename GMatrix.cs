/*
 * Automated conversion
 */

using System;
using System.Text;

namespace NVecMath
{
	/// <summary>
	/// A double precision, general, dynamically-resizable,
	/// two-dimensional matrix class.
	/// </summary>
	/// <remarks>
	/// A double precision, general, dynamically-resizable,
	/// two-dimensional matrix class.  Row and column numbering begins with
	/// zero.  The representation is row major.
	/// </remarks>
	[System.Serializable]
	public class GMatrix : ICloneable
	{
		internal const long serialVersionUID = 2777097312029690941L;

		private const bool debug = false;

		internal int nRow;

		internal int nCol;

		internal double[][] values;

		private const double Eps = 1.0E-10;

		/// <summary>Constructs an nRow by NCol identity matrix.</summary>
		/// <remarks>
		/// Constructs an nRow by NCol identity matrix.
		/// Note that because row and column numbering begins with
		/// zero, nRow and nCol will be one larger than the maximum
		/// possible matrix index values.
		/// </remarks>
		/// <param name="nRow">number of rows in this matrix.</param>
		/// <param name="nCol">number of columns in this matrix.</param>
		public GMatrix(int nRow, int nCol)
		{
			// Compatible with 1.1
			// double dereference is slow 
			//values = new double[nRow][nCol];
			values = new double[][] { new double[7], new double[7], new double[7], new double
				[7], new double[7], new double[7], new double[7] };
			this.nRow = nRow;
			this.nCol = nCol;
			int i;
			int j;
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					values[i][j] = 0.0;
				}
			}
			int l;
			if (nRow < nCol)
			{
				l = nRow;
			}
			else
			{
				l = nCol;
			}
			for (i = 0; i < l; i++)
			{
				values[i][i] = 1.0;
			}
		}

		/// <summary>
		/// Constructs an nRow by nCol matrix initialized to the values
		/// in the matrix array.
		/// </summary>
		/// <remarks>
		/// Constructs an nRow by nCol matrix initialized to the values
		/// in the matrix array.  The array values are copied in one row at
		/// a time in row major fashion.  The array should be at least
		/// nRow*nCol in length.
		/// Note that because row and column numbering begins with
		/// zero, nRow and nCol will be one larger than the maximum
		/// possible matrix index values.
		/// </remarks>
		/// <param name="nRow">number of rows in this matrix.</param>
		/// <param name="nCol">number of columns in this matrix.</param>
		/// <param name="matrix">a 1D array that specifies a matrix in row major fashion</param>
		public GMatrix(int nRow, int nCol, double[] matrix)
		{
			// values = new double[nRow][nCol];
			values = new double[][] { new double[7], new double[7], new double[7], new double
				[7], new double[7], new double[7], new double[7] };
			this.nRow = nRow;
			this.nCol = nCol;
			int i;
			int j;
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					values[i][j] = matrix[i * nCol + j];
				}
			}
		}

		/// <summary>
		/// Constructs a new GMatrix and copies the initial values
		/// from the parameter matrix.
		/// </summary>
		/// <remarks>
		/// Constructs a new GMatrix and copies the initial values
		/// from the parameter matrix.
		/// </remarks>
		/// <param name="matrix">the source of the initial values of the new GMatrix</param>
		public GMatrix(GMatrix matrix)
		{
			nRow = matrix.nRow;
			nCol = matrix.nCol;
			//values = new double[nRow][nCol];
			values = new double[][] { new double[7], new double[7], new double[7], new double
				[7], new double[7], new double[7], new double[7] };
			int i;
			int j;
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					values[i][j] = matrix.values[i][j];
				}
			}
		}

		/// <summary>
		/// Sets the value of this matrix to the result of multiplying itself
		/// with matrix m1 (this = this * m1).
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the result of multiplying itself
		/// with matrix m1 (this = this * m1).
		/// </remarks>
		/// <param name="m1">the other matrix</param>
		public void Mul(GMatrix m1)
		{
			int i;
			int j;
			int k;
			if (nCol != m1.nRow || nCol != m1.nCol)
			{
				throw new MismatchedSizeException("GMatrix.mul:array dimension mismatch");
			}
			//double [][] tmp = new double[nRow][nCol];
			double[][] tmp = new double[][] { new double[7], new double[7], new double[7], new 
				double[7], new double[7], new double[7], new double[7] };
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					tmp[i][j] = 0.0;
					for (k = 0; k < nCol; k++)
					{
						tmp[i][j] += values[i][k] * m1.values[k][j];
					}
				}
			}
			values = tmp;
		}

		/// <summary>
		/// Sets the value of this matrix to the result of multiplying
		/// the two argument matrices together (this = m1 * m2).
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the result of multiplying
		/// the two argument matrices together (this = m1 * m2).
		/// </remarks>
		/// <param name="m1">the first matrix</param>
		/// <param name="m2">the second matrix</param>
		public void Mul(GMatrix m1, GMatrix m2)
		{
			int i;
			int j;
			int k;
			if (m1.nCol != m2.nRow || nRow != m1.nRow || nCol != m2.nCol)
			{
				throw new MismatchedSizeException("GMatrix.mul(GMatrix, GMatrix) dimension mismatch ");
			}
			//double[][] tmp = new double[nRow][nCol];
			double[][] tmp = new double[][] { new double[7], new double[7], new double[7], new 
				double[7], new double[7], new double[7], new double[7] };
			for (i = 0; i < m1.nRow; i++)
			{
				for (j = 0; j < m2.nCol; j++)
				{
					tmp[i][j] = 0.0;
					for (k = 0; k < m1.nCol; k++)
					{
						tmp[i][j] += m1.values[i][k] * m2.values[k][j];
					}
				}
			}
			values = tmp;
		}

		/// <summary>
		/// Computes the outer product of the two vectors; multiplies the
		/// the first vector by the transpose of the second vector and places
		/// the matrix result into this matrix.
		/// </summary>
		/// <remarks>
		/// Computes the outer product of the two vectors; multiplies the
		/// the first vector by the transpose of the second vector and places
		/// the matrix result into this matrix.  This matrix must be
		/// be as big or bigger than getSize(v1)xgetSize(v2).
		/// </remarks>
		/// <param name="v1">the first vector, treated as a row vector</param>
		/// <param name="v2">the second vector, treated as a column vector</param>
		public void Mul(GVector v1, GVector v2)
		{
			int i;
			int j;
			if (nRow < v1.GetSize())
			{
				throw new MismatchedSizeException("GMatrix.mul(GVector, GVector): matrix does not have enough rows");
			}
			if (nCol < v2.GetSize())
			{
				throw new MismatchedSizeException("GMatrix.mul(GVector, GVector): matrix does not have enough columns");
			}
			for (i = 0; i < v1.GetSize(); i++)
			{
				for (j = 0; j < v2.GetSize(); j++)
				{
					values[i][j] = v1.values[i] * v2.values[j];
				}
			}
		}

		/// <summary>Sets the value of this matrix to sum of itself and matrix m1.</summary>
		/// <remarks>Sets the value of this matrix to sum of itself and matrix m1.</remarks>
		/// <param name="m1">the other matrix</param>
		public void Add(GMatrix m1)
		{
			int i;
			int j;
			if (nRow != m1.nRow)
			{
				throw new MismatchedSizeException("GMatrix.add(GMatrix): row dimension mismatch");
			}
			if (nCol != m1.nCol)
			{
				throw new MismatchedSizeException("GMatrix.add(GMatrix): column dimension mismatch");
			}
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					values[i][j] = values[i][j] + m1.values[i][j];
				}
			}
		}

		/// <summary>Sets the value of this matrix to the matrix sum of matrices m1 and m2.</summary>
		/// <remarks>Sets the value of this matrix to the matrix sum of matrices m1 and m2.</remarks>
		/// <param name="m1">the first matrix</param>
		/// <param name="m2">the second matrix</param>
		public void Add(GMatrix m1, GMatrix m2)
		{
			int i;
			int j;
			if (m2.nRow != m1.nRow)
			{
				throw new MismatchedSizeException("GMatrix.add(GMatrix, GMatrix): row dimension mismatch");
			}
			if (m2.nCol != m1.nCol)
			{
				throw new MismatchedSizeException("GMatrix.add(GMatrix, GMatrix): column dimension mismatch");
			}
			if (nCol != m1.nCol || nRow != m1.nRow)
			{
				throw new MismatchedSizeException("GMatrix.add(GMatrix): input matrices dimensions do not match this matrix dimensions");
			}
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					values[i][j] = m1.values[i][j] + m2.values[i][j];
				}
			}
		}

		/// <summary>
		/// Sets the value of this matrix to the matrix difference of itself
		/// and matrix m1 (this = this - m1).
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the matrix difference of itself
		/// and matrix m1 (this = this - m1).
		/// </remarks>
		/// <param name="m1">the other matrix</param>
		public void Sub(GMatrix m1)
		{
			int i;
			int j;
			if (nRow != m1.nRow)
			{
				throw new MismatchedSizeException("GMatrix.sub(GMatrix): row dimension mismatch");
			}
			if (nCol != m1.nCol)
			{
				throw new MismatchedSizeException("GMatrix.sub(GMatrix): column dimension mismatch");
			}
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					values[i][j] = values[i][j] - m1.values[i][j];
				}
			}
		}

		/// <summary>
		/// Sets the value of this matrix to the matrix difference
		/// of matrices m1 and m2 (this = m1 - m2).
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the matrix difference
		/// of matrices m1 and m2 (this = m1 - m2).
		/// </remarks>
		/// <param name="m1">the first matrix</param>
		/// <param name="m2">the second matrix</param>
		public void Sub(GMatrix m1, GMatrix m2)
		{
			int i;
			int j;
			if (m2.nRow != m1.nRow)
			{
				throw new MismatchedSizeException("GMatrix.sub(GMatrix, GMatrix): row dimension mismatch");
			}
			if (m2.nCol != m1.nCol)
			{
				throw new MismatchedSizeException("GMatrix.sub(GMatrix, GMatrix): column dimension mismatch");
			}
			if (nRow != m1.nRow || nCol != m1.nCol)
			{
				throw new MismatchedSizeException("GMatrix.sub(GMatrix, GMatrix): input matrix dimensions do not match dimensions for this matrix");
			}
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					values[i][j] = m1.values[i][j] - m2.values[i][j];
				}
			}
		}

		/// <summary>Negates the value of this matrix: this = -this.</summary>
		/// <remarks>Negates the value of this matrix: this = -this.</remarks>
		public void Negate()
		{
			int i;
			int j;
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					values[i][j] = -values[i][j];
				}
			}
		}

		/// <summary>
		/// Sets the value of this matrix equal to the negation of
		/// of the GMatrix parameter.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix equal to the negation of
		/// of the GMatrix parameter.
		/// </remarks>
		/// <param name="m1">The source matrix</param>
		public void Negate(GMatrix m1)
		{
			int i;
			int j;
			if (nRow != m1.nRow || nCol != m1.nCol)
			{
				throw new MismatchedSizeException("GMatrix.negate(GMatrix, GMatrix): input matrix dimensions do not match dimensions for this matrix");
			}
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					values[i][j] = -m1.values[i][j];
				}
			}
		}

		/// <summary>Sets this GMatrix to the identity matrix.</summary>
		/// <remarks>Sets this GMatrix to the identity matrix.</remarks>
		public void SetIdentity()
		{
			int i;
			int j;
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					values[i][j] = 0.0;
				}
			}
			int l;
			if (nRow < nCol)
			{
				l = nRow;
			}
			else
			{
				l = nCol;
			}
			for (i = 0; i < l; i++)
			{
				values[i][i] = 1.0;
			}
		}

		/// <summary>Sets all the values in this matrix to zero.</summary>
		/// <remarks>Sets all the values in this matrix to zero.</remarks>
		public void SetZero()
		{
			int i;
			int j;
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					values[i][j] = 0.0;
				}
			}
		}

		/// <summary>
		/// Subtracts this matrix from the identity matrix and puts the values
		/// back into this (this = I - this).
		/// </summary>
		/// <remarks>
		/// Subtracts this matrix from the identity matrix and puts the values
		/// back into this (this = I - this).
		/// </remarks>
		public void IdentityMinus()
		{
			int i;
			int j;
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					values[i][j] = -values[i][j];
				}
			}
			int l;
			if (nRow < nCol)
			{
				l = nRow;
			}
			else
			{
				l = nCol;
			}
			for (i = 0; i < l; i++)
			{
				values[i][i] += 1.0;
			}
		}

		/// <summary>Inverts this matrix in place.</summary>
		/// <remarks>Inverts this matrix in place.</remarks>
		public void Invert()
		{
			InvertGeneral(this);
		}

		/// <summary>Inverts matrix m1 and places the new values into this matrix.</summary>
		/// <remarks>
		/// Inverts matrix m1 and places the new values into this matrix.  Matrix
		/// m1 is not modified.
		/// </remarks>
		/// <param name="m1">the matrix to be inverted</param>
		public void Invert(GMatrix m1)
		{
			InvertGeneral(m1);
		}

		/// <summary>Copies a sub-matrix derived from this matrix into the target matrix.</summary>
		/// <remarks>
		/// Copies a sub-matrix derived from this matrix into the target matrix.
		/// The upper left of the sub-matrix is located at (rowSource, colSource);
		/// the lower right of the sub-matrix is located at
		/// (lastRowSource,lastColSource).  The sub-matrix is copied into the
		/// the target matrix starting at (rowDest, colDest).
		/// </remarks>
		/// <param name="rowSource">the top-most row of the sub-matrix</param>
		/// <param name="colSource">the left-most column of the sub-matrix</param>
		/// <param name="numRow">the number of rows in the sub-matrix</param>
		/// <param name="numCol">the number of columns in the sub-matrix</param>
		/// <param name="rowDest">
		/// the top-most row of the position of the copied
		/// sub-matrix within the target matrix
		/// </param>
		/// <param name="colDest">
		/// the left-most column of the position of the copied
		/// sub-matrix within the target matrix
		/// </param>
		/// <param name="target">the matrix into which the sub-matrix will be copied</param>
		public void CopySubMatrix(int rowSource, int colSource, int numRow, int numCol, int
			 rowDest, int colDest, GMatrix target)
		{
			int i;
			int j;
			if (this != target)
			{
				for (i = 0; i < numRow; i++)
				{
					for (j = 0; j < numCol; j++)
					{
						target.values[rowDest + i][colDest + j] = values[rowSource + i][colSource + j];
					}
				}
			}
			else
			{
				//double[][] tmp = new double[numRow][numCol];
				double[][] tmp = new double[][] { new double[7], new double[7], new double[7], new 
					double[7], new double[7], new double[7], new double[7] };
				for (i = 0; i < numRow; i++)
				{
					for (j = 0; j < numCol; j++)
					{
						tmp[i][j] = values[rowSource + i][colSource + j];
					}
				}
				for (i = 0; i < numRow; i++)
				{
					for (j = 0; j < numCol; j++)
					{
						target.values[rowDest + i][colDest + j] = tmp[i][j];
					}
				}
			}
		}

		/// <summary>Changes the size of this matrix dynamically.</summary>
		/// <remarks>
		/// Changes the size of this matrix dynamically.  If the size is increased
		/// no data values will be lost.  If the size is decreased, only those data
		/// values whose matrix positions were eliminated will be lost.
		/// </remarks>
		/// <param name="nRow">number of desired rows in this matrix</param>
		/// <param name="nCol">number of desired columns in this matrix</param>
		public void SetSize(int nRow, int nCol)
		{
			//double[][] tmp = new double[nRow][nCol];
			double[][] tmp = new double[][] { new double[7], new double[7], new double[7], new 
				double[7], new double[7], new double[7], new double[7] };
			int i;
			int j;
			int maxRow;
			int maxCol;
			if (this.nRow < nRow)
			{
				maxRow = this.nRow;
			}
			else
			{
				maxRow = nRow;
			}
			if (this.nCol < nCol)
			{
				maxCol = this.nCol;
			}
			else
			{
				maxCol = nCol;
			}
			for (i = 0; i < maxRow; i++)
			{
				for (j = 0; j < maxCol; j++)
				{
					tmp[i][j] = values[i][j];
				}
			}
			this.nRow = nRow;
			this.nCol = nCol;
			values = tmp;
		}

		/// <summary>Sets the value of this matrix to the values found in the array parameter.
		/// 	</summary>
		/// <remarks>
		/// Sets the value of this matrix to the values found in the array parameter.
		/// The values are copied in one row at a time, in row major
		/// fashion.  The array should be at least equal in length to
		/// the number of matrix rows times the number of matrix columns
		/// in this matrix.
		/// </remarks>
		/// <param name="matrix">the row major source array</param>
		public void Set(double[] matrix)
		{
			int i;
			int j;
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					values[i][j] = matrix[nCol * i + j];
				}
			}
		}

		/// <summary>Sets the value of this matrix to that of the Matrix3f provided.</summary>
		/// <remarks>Sets the value of this matrix to that of the Matrix3f provided.</remarks>
		/// <param name="m1">the matrix</param>
		public void Set(Matrix3f m1)
		{
			int i;
			int j;
			if (nCol < 3 || nRow < 3)
			{
				// expand matrix if too small 
				nCol = 3;
				nRow = 3;
				//values = new double[nRow][nCol];
				values = new double[][] { new double[3], new double[3], new double[3] };
			}
			values[0][0] = m1.m00;
			values[0][1] = m1.m01;
			values[0][2] = m1.m02;
			values[1][0] = m1.m10;
			values[1][1] = m1.m11;
			values[1][2] = m1.m12;
			values[2][0] = m1.m20;
			values[2][1] = m1.m21;
			values[2][2] = m1.m22;
			for (i = 3; i < nRow; i++)
			{
				// pad rest or matrix with zeros 
				for (j = 3; j < nCol; j++)
				{
					values[i][j] = 0.0;
				}
			}
		}

		/// <summary>Sets the value of this matrix to that of the Matrix3d provided.</summary>
		/// <remarks>Sets the value of this matrix to that of the Matrix3d provided.</remarks>
		/// <param name="m1">the matrix</param>
		public void Set(Matrix3d m1)
		{
			if (nRow < 3 || nCol < 3)
			{
				values = new double[][] { new double[3], new double[3], new double[3] };
				nRow = 3;
				nCol = 3;
			}
			values[0][0] = m1.m00;
			values[0][1] = m1.m01;
			values[0][2] = m1.m02;
			values[1][0] = m1.m10;
			values[1][1] = m1.m11;
			values[1][2] = m1.m12;
			values[2][0] = m1.m20;
			values[2][1] = m1.m21;
			values[2][2] = m1.m22;
			for (int i = 3; i < nRow; i++)
			{
				// pad rest or matrix with zeros 
				for (int j = 3; j < nCol; j++)
				{
					values[i][j] = 0.0;
				}
			}
		}

		/// <summary>Sets the value of this matrix to that of the Matrix4f provided.</summary>
		/// <remarks>Sets the value of this matrix to that of the Matrix4f provided.</remarks>
		/// <param name="m1">the matrix</param>
		public void Set(Matrix4f m1)
		{
			if (nRow < 4 || nCol < 4)
			{
				values = new double[][] { new double[4], new double[4], new double[4], new double
					[4] };
				nRow = 4;
				nCol = 4;
			}
			values[0][0] = m1.m00;
			values[0][1] = m1.m01;
			values[0][2] = m1.m02;
			values[0][3] = m1.m03;
			values[1][0] = m1.m10;
			values[1][1] = m1.m11;
			values[1][2] = m1.m12;
			values[1][3] = m1.m13;
			values[2][0] = m1.m20;
			values[2][1] = m1.m21;
			values[2][2] = m1.m22;
			values[2][3] = m1.m23;
			values[3][0] = m1.m30;
			values[3][1] = m1.m31;
			values[3][2] = m1.m32;
			values[3][3] = m1.m33;
			for (int i = 4; i < nRow; i++)
			{
				// pad rest or matrix with zeros 
				for (int j = 4; j < nCol; j++)
				{
					values[i][j] = 0.0;
				}
			}
		}

		/// <summary>Sets the value of this matrix to that of the Matrix4d provided.</summary>
		/// <remarks>Sets the value of this matrix to that of the Matrix4d provided.</remarks>
		/// <param name="m1">the matrix</param>
		public void Set(Matrix4d m1)
		{
			if (nRow < 4 || nCol < 4)
			{
				values = new double[][] { new double[4], new double[4], new double[4], new double
					[4] };
				nRow = 4;
				nCol = 4;
			}
			values[0][0] = m1.m00;
			values[0][1] = m1.m01;
			values[0][2] = m1.m02;
			values[0][3] = m1.m03;
			values[1][0] = m1.m10;
			values[1][1] = m1.m11;
			values[1][2] = m1.m12;
			values[1][3] = m1.m13;
			values[2][0] = m1.m20;
			values[2][1] = m1.m21;
			values[2][2] = m1.m22;
			values[2][3] = m1.m23;
			values[3][0] = m1.m30;
			values[3][1] = m1.m31;
			values[3][2] = m1.m32;
			values[3][3] = m1.m33;
			for (int i = 4; i < nRow; i++)
			{
				// pad rest or matrix with zeros 
				for (int j = 4; j < nCol; j++)
				{
					values[i][j] = 0.0;
				}
			}
		}

		/// <summary>Sets the value of this matrix to the values found in matrix m1.</summary>
		/// <remarks>Sets the value of this matrix to the values found in matrix m1.</remarks>
		/// <param name="m1">the source matrix</param>
		public void Set(GMatrix m1)
		{
			int i;
			int j;
			if (nRow < m1.nRow || nCol < m1.nCol)
			{
				nRow = m1.nRow;
				nCol = m1.nCol;
				//values = new double[nRow][nCol];
				values = new double[][] { new double[7], new double[7], new double[7], new double
					[7], new double[7], new double[7], new double[7] };
			}
			for (i = 0; i < Math.Min(nRow, m1.nRow); i++)
			{
				for (j = 0; j < Math.Min(nCol, m1.nCol); j++)
				{
					values[i][j] = m1.values[i][j];
				}
			}
			for (i = m1.nRow; i < nRow; i++)
			{
				// pad rest or matrix with zeros 
				for (j = m1.nCol; j < nCol; j++)
				{
					values[i][j] = 0.0;
				}
			}
		}

		/// <summary>Returns the number of rows in this matrix.</summary>
		/// <remarks>Returns the number of rows in this matrix.</remarks>
		/// <returns>number of rows in this matrix</returns>
		public int GetNumRow()
		{
			return (nRow);
		}

		/// <summary>Returns the number of colmuns in this matrix.</summary>
		/// <remarks>Returns the number of colmuns in this matrix.</remarks>
		/// <returns>number of columns in this matrix</returns>
		public int GetNumCol()
		{
			return (nCol);
		}

		/// <summary>Retrieves the value at the specified row and column of this matrix.</summary>
		/// <remarks>Retrieves the value at the specified row and column of this matrix.</remarks>
		/// <param name="row">the row number to be retrieved (zero indexed)</param>
		/// <param name="column">the column number to be retrieved (zero indexed)</param>
		/// <returns>the value at the indexed element</returns>
		public double GetElement(int row, int column)
		{
			return (values[row][column]);
		}

		/// <summary>Modifies the value at the specified row and column of this matrix.</summary>
		/// <remarks>Modifies the value at the specified row and column of this matrix.</remarks>
		/// <param name="row">the row number to be modified (zero indexed)</param>
		/// <param name="column">the column number to be modified (zero indexed)</param>
		/// <param name="value">the new matrix element value</param>
		public void SetElement(int row, int column, double value)
		{
			values[row][column] = value;
		}

		/// <summary>Places the values of the specified row into the array parameter.</summary>
		/// <remarks>Places the values of the specified row into the array parameter.</remarks>
		/// <param name="row">the target row number</param>
		/// <param name="array">the array into which the row values will be placed</param>
		public void GetRow(int row, double[] array)
		{
			for (int i = 0; i < nCol; i++)
			{
				array[i] = values[row][i];
			}
		}

		/// <summary>Places the values of the specified row into the vector parameter.</summary>
		/// <remarks>Places the values of the specified row into the vector parameter.</remarks>
		/// <param name="row">the target row number</param>
		/// <param name="vector">the vector into which the row values will be placed</param>
		public void GetRow(int row, GVector vector)
		{
			if (vector.GetSize() < nCol)
			{
				vector.SetSize(nCol);
			}
			for (int i = 0; i < nCol; i++)
			{
				vector.values[i] = values[row][i];
			}
		}

		/// <summary>Places the values of the specified column into the array parameter.</summary>
		/// <remarks>Places the values of the specified column into the array parameter.</remarks>
		/// <param name="col">the target column number</param>
		/// <param name="array">the array into which the column values will be placed</param>
		public void GetColumn(int col, double[] array)
		{
			for (int i = 0; i < nRow; i++)
			{
				array[i] = values[i][col];
			}
		}

		/// <summary>Places the values of the specified column into the vector parameter.</summary>
		/// <remarks>Places the values of the specified column into the vector parameter.</remarks>
		/// <param name="col">the target column number</param>
		/// <param name="vector">the vector into which the column values will be placed</param>
		public void GetColumn(int col, GVector vector)
		{
			if (vector.GetSize() < nRow)
			{
				vector.SetSize(nRow);
			}
			for (int i = 0; i < nRow; i++)
			{
				vector.values[i] = values[i][col];
			}
		}

		/// <summary>
		/// Places the values in the upper 3x3 of this GMatrix into
		/// the matrix m1.
		/// </summary>
		/// <remarks>
		/// Places the values in the upper 3x3 of this GMatrix into
		/// the matrix m1.
		/// </remarks>
		/// <param name="m1">The matrix that will hold the new values</param>
		public void Get(Matrix3d m1)
		{
			if (nRow < 3 || nCol < 3)
			{
				m1.SetZero();
				if (nCol > 0)
				{
					if (nRow > 0)
					{
						m1.m00 = values[0][0];
						if (nRow > 1)
						{
							m1.m10 = values[1][0];
							if (nRow > 2)
							{
								m1.m20 = values[2][0];
							}
						}
					}
					if (nCol > 1)
					{
						if (nRow > 0)
						{
							m1.m01 = values[0][1];
							if (nRow > 1)
							{
								m1.m11 = values[1][1];
								if (nRow > 2)
								{
									m1.m21 = values[2][1];
								}
							}
						}
						if (nCol > 2)
						{
							if (nRow > 0)
							{
								m1.m02 = values[0][2];
								if (nRow > 1)
								{
									m1.m12 = values[1][2];
									if (nRow > 2)
									{
										m1.m22 = values[2][2];
									}
								}
							}
						}
					}
				}
			}
			else
			{
				m1.m00 = values[0][0];
				m1.m01 = values[0][1];
				m1.m02 = values[0][2];
				m1.m10 = values[1][0];
				m1.m11 = values[1][1];
				m1.m12 = values[1][2];
				m1.m20 = values[2][0];
				m1.m21 = values[2][1];
				m1.m22 = values[2][2];
			}
		}

		/// <summary>
		/// Places the values in the upper 3x3 of this GMatrix into
		/// the matrix m1.
		/// </summary>
		/// <remarks>
		/// Places the values in the upper 3x3 of this GMatrix into
		/// the matrix m1.
		/// </remarks>
		/// <param name="m1">The matrix that will hold the new values</param>
		public void Get(Matrix3f m1)
		{
			if (nRow < 3 || nCol < 3)
			{
				m1.SetZero();
				if (nCol > 0)
				{
					if (nRow > 0)
					{
						m1.m00 = (float)values[0][0];
						if (nRow > 1)
						{
							m1.m10 = (float)values[1][0];
							if (nRow > 2)
							{
								m1.m20 = (float)values[2][0];
							}
						}
					}
					if (nCol > 1)
					{
						if (nRow > 0)
						{
							m1.m01 = (float)values[0][1];
							if (nRow > 1)
							{
								m1.m11 = (float)values[1][1];
								if (nRow > 2)
								{
									m1.m21 = (float)values[2][1];
								}
							}
						}
						if (nCol > 2)
						{
							if (nRow > 0)
							{
								m1.m02 = (float)values[0][2];
								if (nRow > 1)
								{
									m1.m12 = (float)values[1][2];
									if (nRow > 2)
									{
										m1.m22 = (float)values[2][2];
									}
								}
							}
						}
					}
				}
			}
			else
			{
				m1.m00 = (float)values[0][0];
				m1.m01 = (float)values[0][1];
				m1.m02 = (float)values[0][2];
				m1.m10 = (float)values[1][0];
				m1.m11 = (float)values[1][1];
				m1.m12 = (float)values[1][2];
				m1.m20 = (float)values[2][0];
				m1.m21 = (float)values[2][1];
				m1.m22 = (float)values[2][2];
			}
		}

		/// <summary>
		/// Places the values in the upper 4x4 of this GMatrix into
		/// the matrix m1.
		/// </summary>
		/// <remarks>
		/// Places the values in the upper 4x4 of this GMatrix into
		/// the matrix m1.
		/// </remarks>
		/// <param name="m1">The matrix that will hold the new values</param>
		public void Get(Matrix4d m1)
		{
			if (nRow < 4 || nCol < 4)
			{
				m1.SetZero();
				if (nCol > 0)
				{
					if (nRow > 0)
					{
						m1.m00 = values[0][0];
						if (nRow > 1)
						{
							m1.m10 = values[1][0];
							if (nRow > 2)
							{
								m1.m20 = values[2][0];
								if (nRow > 3)
								{
									m1.m30 = values[3][0];
								}
							}
						}
					}
					if (nCol > 1)
					{
						if (nRow > 0)
						{
							m1.m01 = values[0][1];
							if (nRow > 1)
							{
								m1.m11 = values[1][1];
								if (nRow > 2)
								{
									m1.m21 = values[2][1];
									if (nRow > 3)
									{
										m1.m31 = values[3][1];
									}
								}
							}
						}
						if (nCol > 2)
						{
							if (nRow > 0)
							{
								m1.m02 = values[0][2];
								if (nRow > 1)
								{
									m1.m12 = values[1][2];
									if (nRow > 2)
									{
										m1.m22 = values[2][2];
										if (nRow > 3)
										{
											m1.m32 = values[3][2];
										}
									}
								}
							}
							if (nCol > 3)
							{
								if (nRow > 0)
								{
									m1.m03 = values[0][3];
									if (nRow > 1)
									{
										m1.m13 = values[1][3];
										if (nRow > 2)
										{
											m1.m23 = values[2][3];
											if (nRow > 3)
											{
												m1.m33 = values[3][3];
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				m1.m00 = values[0][0];
				m1.m01 = values[0][1];
				m1.m02 = values[0][2];
				m1.m03 = values[0][3];
				m1.m10 = values[1][0];
				m1.m11 = values[1][1];
				m1.m12 = values[1][2];
				m1.m13 = values[1][3];
				m1.m20 = values[2][0];
				m1.m21 = values[2][1];
				m1.m22 = values[2][2];
				m1.m23 = values[2][3];
				m1.m30 = values[3][0];
				m1.m31 = values[3][1];
				m1.m32 = values[3][2];
				m1.m33 = values[3][3];
			}
		}

		/// <summary>
		/// Places the values in the upper 4x4 of this GMatrix into
		/// the matrix m1.
		/// </summary>
		/// <remarks>
		/// Places the values in the upper 4x4 of this GMatrix into
		/// the matrix m1.
		/// </remarks>
		/// <param name="m1">The matrix that will hold the new values</param>
		public void Get(Matrix4f m1)
		{
			if (nRow < 4 || nCol < 4)
			{
				m1.SetZero();
				if (nCol > 0)
				{
					if (nRow > 0)
					{
						m1.m00 = (float)values[0][0];
						if (nRow > 1)
						{
							m1.m10 = (float)values[1][0];
							if (nRow > 2)
							{
								m1.m20 = (float)values[2][0];
								if (nRow > 3)
								{
									m1.m30 = (float)values[3][0];
								}
							}
						}
					}
					if (nCol > 1)
					{
						if (nRow > 0)
						{
							m1.m01 = (float)values[0][1];
							if (nRow > 1)
							{
								m1.m11 = (float)values[1][1];
								if (nRow > 2)
								{
									m1.m21 = (float)values[2][1];
									if (nRow > 3)
									{
										m1.m31 = (float)values[3][1];
									}
								}
							}
						}
						if (nCol > 2)
						{
							if (nRow > 0)
							{
								m1.m02 = (float)values[0][2];
								if (nRow > 1)
								{
									m1.m12 = (float)values[1][2];
									if (nRow > 2)
									{
										m1.m22 = (float)values[2][2];
										if (nRow > 3)
										{
											m1.m32 = (float)values[3][2];
										}
									}
								}
							}
							if (nCol > 3)
							{
								if (nRow > 0)
								{
									m1.m03 = (float)values[0][3];
									if (nRow > 1)
									{
										m1.m13 = (float)values[1][3];
										if (nRow > 2)
										{
											m1.m23 = (float)values[2][3];
											if (nRow > 3)
											{
												m1.m33 = (float)values[3][3];
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				m1.m00 = (float)values[0][0];
				m1.m01 = (float)values[0][1];
				m1.m02 = (float)values[0][2];
				m1.m03 = (float)values[0][3];
				m1.m10 = (float)values[1][0];
				m1.m11 = (float)values[1][1];
				m1.m12 = (float)values[1][2];
				m1.m13 = (float)values[1][3];
				m1.m20 = (float)values[2][0];
				m1.m21 = (float)values[2][1];
				m1.m22 = (float)values[2][2];
				m1.m23 = (float)values[2][3];
				m1.m30 = (float)values[3][0];
				m1.m31 = (float)values[3][1];
				m1.m32 = (float)values[3][2];
				m1.m33 = (float)values[3][3];
			}
		}

		/// <summary>
		/// Places the values in the this GMatrix into the matrix m1;
		/// m1 should be at least as large as this GMatrix.
		/// </summary>
		/// <remarks>
		/// Places the values in the this GMatrix into the matrix m1;
		/// m1 should be at least as large as this GMatrix.
		/// </remarks>
		/// <param name="m1">The matrix that will hold the new values</param>
		public void Get(GMatrix m1)
		{
			int i;
			int j;
			int nc;
			int nr;
			if (nCol < m1.nCol)
			{
				nc = nCol;
			}
			else
			{
				nc = m1.nCol;
			}
			if (nRow < m1.nRow)
			{
				nr = nRow;
			}
			else
			{
				nr = m1.nRow;
			}
			for (i = 0; i < nr; i++)
			{
				for (j = 0; j < nc; j++)
				{
					m1.values[i][j] = values[i][j];
				}
			}
			for (i = nr; i < m1.nRow; i++)
			{
				for (j = 0; j < m1.nCol; j++)
				{
					m1.values[i][j] = 0.0;
				}
			}
			for (j = nc; j < m1.nCol; j++)
			{
				for (i = 0; i < nr; i++)
				{
					m1.values[i][j] = 0.0;
				}
			}
		}

		/// <summary>
		/// Copy the values from the array into the specified row of this
		/// matrix.
		/// </summary>
		/// <remarks>
		/// Copy the values from the array into the specified row of this
		/// matrix.
		/// </remarks>
		/// <param name="row">
		/// the row of this matrix into which the array values
		/// will be copied.
		/// </param>
		/// <param name="array">the source array</param>
		public void SetRow(int row, double[] array)
		{
			for (int i = 0; i < nCol; i++)
			{
				values[row][i] = array[i];
			}
		}

		/// <summary>
		/// Copy the values from the vector into the specified row of this
		/// matrix.
		/// </summary>
		/// <remarks>
		/// Copy the values from the vector into the specified row of this
		/// matrix.
		/// </remarks>
		/// <param name="row">
		/// the row of this matrix into which the array values
		/// will be copied
		/// </param>
		/// <param name="vector">the source vector</param>
		public void SetRow(int row, GVector vector)
		{
			for (int i = 0; i < nCol; i++)
			{
				values[row][i] = vector.values[i];
			}
		}

		/// <summary>
		/// Copy the values from the array into the specified column of this
		/// matrix.
		/// </summary>
		/// <remarks>
		/// Copy the values from the array into the specified column of this
		/// matrix.
		/// </remarks>
		/// <param name="col">
		/// the column of this matrix into which the array values
		/// will be copied
		/// </param>
		/// <param name="array">the source array</param>
		public void SetColumn(int col, double[] array)
		{
			for (int i = 0; i < nRow; i++)
			{
				values[i][col] = array[i];
			}
		}

		/// <summary>
		/// Copy the values from the vector into the specified column of this
		/// matrix.
		/// </summary>
		/// <remarks>
		/// Copy the values from the vector into the specified column of this
		/// matrix.
		/// </remarks>
		/// <param name="col">
		/// the column of this matrix into which the array values
		/// will be copied
		/// </param>
		/// <param name="vector">the source vector</param>
		public void SetColumn(int col, GVector vector)
		{
			for (int i = 0; i < nRow; i++)
			{
				values[i][col] = vector.values[i];
			}
		}

		/// <summary>
		/// Multiplies the transpose of matrix m1 times the transpose of matrix
		/// m2, and places the result into this.
		/// </summary>
		/// <remarks>
		/// Multiplies the transpose of matrix m1 times the transpose of matrix
		/// m2, and places the result into this.
		/// </remarks>
		/// <param name="m1">The matrix on the left hand side of the multiplication</param>
		/// <param name="m2">The matrix on the right hand side of the multiplication</param>
		public void MulTransposeBoth(GMatrix m1, GMatrix m2)
		{
			int i;
			int j;
			int k;
			if (m1.nRow != m2.nCol || nRow != m1.nCol || nCol != m2.nRow)
			{
				throw new MismatchedSizeException("GMatrix.mulTransposeBoth matrix dimension mismatch");
			}
			if (m1 == this || m2 == this)
			{
				//double[][] tmp = new double[nRow][nCol];
				double[][] tmp = new double[][] { new double[7], new double[7], new double[7], new 
					double[7], new double[7], new double[7], new double[7] };
				for (i = 0; i < nRow; i++)
				{
					for (j = 0; j < nCol; j++)
					{
						tmp[i][j] = 0.0;
						for (k = 0; k < m1.nRow; k++)
						{
							tmp[i][j] += m1.values[k][i] * m2.values[j][k];
						}
					}
				}
				values = tmp;
			}
			else
			{
				for (i = 0; i < nRow; i++)
				{
					for (j = 0; j < nCol; j++)
					{
						values[i][j] = 0.0;
						for (k = 0; k < m1.nRow; k++)
						{
							values[i][j] += m1.values[k][i] * m2.values[j][k];
						}
					}
				}
			}
		}

		/// <summary>
		/// Multiplies matrix m1 times the transpose of matrix m2, and
		/// places the result into this.
		/// </summary>
		/// <remarks>
		/// Multiplies matrix m1 times the transpose of matrix m2, and
		/// places the result into this.
		/// </remarks>
		/// <param name="m1">The matrix on the left hand side of the multiplication</param>
		/// <param name="m2">The matrix on the right hand side of the multiplication</param>
		public void MulTransposeRight(GMatrix m1, GMatrix m2)
		{
			int i;
			int j;
			int k;
			if (m1.nCol != m2.nCol || nCol != m2.nRow || nRow != m1.nRow)
			{
				throw new MismatchedSizeException("GMatrix.mulTransposeRight matrix dimension mismatch");
			}
			if (m1 == this || m2 == this)
			{
				//double[][] tmp = new double[nRow][nCol];
				double[][] tmp = new double[][] { new double[7], new double[7], new double[7], new 
					double[7], new double[7], new double[7], new double[7] };
				for (i = 0; i < nRow; i++)
				{
					for (j = 0; j < nCol; j++)
					{
						tmp[i][j] = 0.0;
						for (k = 0; k < m1.nCol; k++)
						{
							tmp[i][j] += m1.values[i][k] * m2.values[j][k];
						}
					}
				}
				values = tmp;
			}
			else
			{
				for (i = 0; i < nRow; i++)
				{
					for (j = 0; j < nCol; j++)
					{
						values[i][j] = 0.0;
						for (k = 0; k < m1.nCol; k++)
						{
							values[i][j] += m1.values[i][k] * m2.values[j][k];
						}
					}
				}
			}
		}

		/// <summary>
		/// Multiplies the transpose of matrix m1 times matrix m2, and
		/// places the result into this.
		/// </summary>
		/// <remarks>
		/// Multiplies the transpose of matrix m1 times matrix m2, and
		/// places the result into this.
		/// </remarks>
		/// <param name="m1">The matrix on the left hand side of the multiplication</param>
		/// <param name="m2">The matrix on the right hand side of the multiplication</param>
		public void MulTransposeLeft(GMatrix m1, GMatrix m2)
		{
			int i;
			int j;
			int k;
			if (m1.nRow != m2.nRow || nCol != m2.nCol || nRow != m1.nCol)
			{
				throw new MismatchedSizeException("GMatrix.mulTransposeLeft matrix dimension mismatch");
			}
			if (m1 == this || m2 == this)
			{
				//double[][] tmp = new double[nRow][nCol];
				double[][] tmp = new double[][] { new double[7], new double[7], new double[7], new 
					double[7], new double[7], new double[7], new double[7] };
				for (i = 0; i < nRow; i++)
				{
					for (j = 0; j < nCol; j++)
					{
						tmp[i][j] = 0.0;
						for (k = 0; k < m1.nRow; k++)
						{
							tmp[i][j] += m1.values[k][i] * m2.values[k][j];
						}
					}
				}
				values = tmp;
			}
			else
			{
				for (i = 0; i < nRow; i++)
				{
					for (j = 0; j < nCol; j++)
					{
						values[i][j] = 0.0;
						for (k = 0; k < m1.nRow; k++)
						{
							values[i][j] += m1.values[k][i] * m2.values[k][j];
						}
					}
				}
			}
		}

		/// <summary>Transposes this matrix in place.</summary>
		/// <remarks>Transposes this matrix in place.</remarks>
		public void Transpose()
		{
			int i;
			int j;
			if (nRow != nCol)
			{
				double[][] tmp;
				i = nRow;
				nRow = nCol;
				nCol = i;
				//tmp = new double[nRow][nCol];
				tmp = new double[][] { new double[7], new double[7], new double[7], new double[7]
					, new double[7], new double[7], new double[7] };
				for (i = 0; i < nRow; i++)
				{
					for (j = 0; j < nCol; j++)
					{
						tmp[i][j] = values[j][i];
					}
				}
				values = tmp;
			}
			else
			{
				double swap;
				for (i = 0; i < nRow; i++)
				{
					for (j = 0; j < i; j++)
					{
						swap = values[i][j];
						values[i][j] = values[j][i];
						values[j][i] = swap;
					}
				}
			}
		}

		/// <summary>Places the matrix values of the transpose of matrix m1 into this matrix.
		/// 	</summary>
		/// <remarks>Places the matrix values of the transpose of matrix m1 into this matrix.
		/// 	</remarks>
		/// <param name="m1">the matrix to be transposed (but not modified)</param>
		public void Transpose(GMatrix m1)
		{
			int i;
			int j;
			if (nRow != m1.nCol || nCol != m1.nRow)
			{
				throw new MismatchedSizeException("GMatrix.transpose(GMatrix) mismatch in matrix dimensions");
			}
			if (m1 != this)
			{
				for (i = 0; i < nRow; i++)
				{
					for (j = 0; j < nCol; j++)
					{
						values[i][j] = m1.values[j][i];
					}
				}
			}
			else
			{
				Transpose();
			}
		}

		/// <summary>Returns a string that contains the values of this GMatrix.</summary>
		/// <remarks>Returns a string that contains the values of this GMatrix.</remarks>
		/// <returns>the String representation</returns>
		public override string ToString()
		{
			StringBuilder buffer = new StringBuilder(nRow * nCol * 8);
			int i;
			int j;
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					buffer.Append(values[i][j]).Append(" ");
				}
				buffer.Append("\n");
			}
			return buffer.ToString();
		}

		private static void CheckMatrix(GMatrix m)
		{
			int i;
			int j;
			for (i = 0; i < m.nRow; i++)
			{
				for (j = 0; j < m.nCol; j++)
				{
					if (Math.Abs(m.values[i][j]) < 0.0000000001)
					{
						System.Console.Out.Write(" 0.0     ");
					}
					else
					{
						System.Console.Out.Write(" " + m.values[i][j]);
					}
				}
				System.Console.Out.Write("\n");
			}
		}

		/// <summary>
		/// Returns a hash code value based on the data values in this
		/// object.
		/// </summary>
		/// <remarks>
		/// Returns a hash code value based on the data values in this
		/// object.  Two different GMatrix objects with identical data
		/// values (i.e., GMatrix.equals returns true) will return the
		/// same hash number.  Two GMatrix objects with different data
		/// members may return the same hash value, although this is not
		/// likely.
		/// </remarks>
		/// <returns>the integer hash code value</returns>
		public override int GetHashCode()
		{
			long bits = 1L;
			bits = 31L * bits + (long)nRow;
			bits = 31L * bits + (long)nCol;
			for (int i = 0; i < nRow; i++)
			{
				for (int j = 0; j < nCol; j++)
				{
					bits = 31L * bits + VecMathUtil.DoubleToLongBits(values[i][j]);
				}
			}
			return (int)(bits ^ (bits >> 32));
		}

		/// <summary>
		/// Returns true if all of the data members of GMatrix m1 are
		/// equal to the corresponding data members in this GMatrix.
		/// </summary>
		/// <remarks>
		/// Returns true if all of the data members of GMatrix m1 are
		/// equal to the corresponding data members in this GMatrix.
		/// </remarks>
		/// <param name="m1">The matrix with which the comparison is made.</param>
		/// <returns>true or false</returns>
		public virtual bool Equals(GMatrix m1)
		{
			try
			{
				int i;
				int j;
				if (nRow != m1.nRow || nCol != m1.nCol)
				{
					return false;
				}
				for (i = 0; i < nRow; i++)
				{
					for (j = 0; j < nCol; j++)
					{
						if (values[i][j] != m1.values[i][j])
						{
							return false;
						}
					}
				}
				return true;
			}
			catch (ArgumentNullException)
			{
				return false;
			}
		}

		/// <summary>
		/// Returns true if the Object o1 is of type GMatrix and all of the
		/// data members of o1 are equal to the corresponding data members in
		/// this GMatrix.
		/// </summary>
		/// <remarks>
		/// Returns true if the Object o1 is of type GMatrix and all of the
		/// data members of o1 are equal to the corresponding data members in
		/// this GMatrix.
		/// </remarks>
		/// <param name="o1">The object with which the comparison is made.</param>
		/// <returns>true or false</returns>
		public override bool Equals(object o1)
		{
			try
			{
				GMatrix m2 = (GMatrix)o1;
				int i;
				int j;
				if (nRow != m2.nRow || nCol != m2.nCol)
				{
					return false;
				}
				for (i = 0; i < nRow; i++)
				{
					for (j = 0; j < nCol; j++)
					{
						if (values[i][j] != m2.values[i][j])
						{
							return false;
						}
					}
				}
				return true;
			}
			catch (InvalidCastException)
			{
				return false;
			}
			catch (ArgumentNullException)
			{
				return false;
			}
		}

		[System.ObsoleteAttribute(@"Use epsilonEquals(GMatrix, double) instead")]
		public virtual bool EpsilonEquals(GMatrix m1, float epsilon)
		{
			return EpsilonEquals(m1, (double)epsilon);
		}

		/// <summary>
		/// Returns true if the L-infinite distance between this matrix
		/// and matrix m1 is less than or equal to the epsilon parameter,
		/// otherwise returns false.
		/// </summary>
		/// <remarks>
		/// Returns true if the L-infinite distance between this matrix
		/// and matrix m1 is less than or equal to the epsilon parameter,
		/// otherwise returns false.  The L-infinite
		/// distance is equal to
		/// MAX[i=0,1,2, . . .n ; j=0,1,2, . . .n ; abs(this.m(i,j) - m1.m(i,j)]
		/// </remarks>
		/// <param name="m1">The matrix to be compared to this matrix</param>
		/// <param name="epsilon">the threshold value</param>
		public virtual bool EpsilonEquals(GMatrix m1, double epsilon)
		{
			int i;
			int j;
			double diff;
			if (nRow != m1.nRow || nCol != m1.nCol)
			{
				return false;
			}
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					diff = values[i][j] - m1.values[i][j];
					if ((diff < 0 ? -diff : diff) > epsilon)
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>Returns the trace of this matrix.</summary>
		/// <remarks>Returns the trace of this matrix.</remarks>
		/// <returns>the trace of this matrix</returns>
		public double Trace()
		{
			int i;
			int l;
			double t;
			if (nRow < nCol)
			{
				l = nRow;
			}
			else
			{
				l = nCol;
			}
			t = 0.0;
			for (i = 0; i < l; i++)
			{
				t += values[i][i];
			}
			return t;
		}

		/// <summary>
		/// Finds the singular value decomposition (SVD) of this matrix
		/// such that this = U*W*transpose(V); and returns the rank of
		/// this matrix; the values of U,W,V are all overwritten.
		/// </summary>
		/// <remarks>
		/// Finds the singular value decomposition (SVD) of this matrix
		/// such that this = U*W*transpose(V); and returns the rank of
		/// this matrix; the values of U,W,V are all overwritten.  Note
		/// that the matrix V is output as V, and
		/// not transpose(V).  If this matrix is mxn, then U is mxm, W
		/// is a diagonal matrix that is mxn, and V is nxn.  Using the
		/// notation W = diag(w), then the inverse of this matrix is:
		/// inverse(this) = V*diag(1/w)*tranpose(U), where diag(1/w)
		/// is the same matrix as W except that the reciprocal of each
		/// of the diagonal components is used.
		/// </remarks>
		/// <param name="U">The computed U matrix in the equation this = U*W*transpose(V)</param>
		/// <param name="W">The computed W matrix in the equation this = U*W*transpose(V)</param>
		/// <param name="V">The computed V matrix in the equation this = U*W*transpose(V)</param>
		/// <returns>The rank of this matrix.</returns>
		public int Svd(GMatrix U, GMatrix W, GMatrix V)
		{
			// check for consistancy in dimensions 
			if (nCol != V.nCol || nCol != V.nRow)
			{
				throw new MismatchedSizeException("GMatrix.SVD: dimension mismatch with V matrix");
			}
			if (nRow != U.nRow || nRow != U.nCol)
			{
				throw new MismatchedSizeException("GMatrix.SVD: dimension mismatch with U matrix");
			}
			if (nRow != W.nRow || nCol != W.nCol)
			{
				throw new MismatchedSizeException("GMatrix.SVD: dimension mismatch with W matrix");
			}
			// Fix ArrayIndexOutOfBounds for 2x2 matrices, which partially
			// addresses bug 4348562 for J3D 1.2.1.
			//
			// Does *not* fix the following problems reported in 4348562,
			// which will wait for J3D 1.3:
			//
			//   1) no output of W
			//   2) wrong transposition of U
			//   3) wrong results for 4x4 matrices
			//   4) slow performance
			if (nRow == 2 && nCol == 2)
			{
				if (values[1][0] == 0.0)
				{
					U.SetIdentity();
					V.SetIdentity();
					if (values[0][1] == 0.0)
					{
						return 2;
					}
					double[] sinl = new double[1];
					double[] sinr = new double[1];
					double[] cosl = new double[1];
					double[] cosr = new double[1];
					double[] single_values = new double[2];
					single_values[0] = values[0][0];
					single_values[1] = values[1][1];
					Compute_2X2(values[0][0], values[0][1], values[1][1], single_values, sinl, cosl, 
						sinr, cosr, 0);
					Update_u(0, U, cosl, sinl);
					Update_v(0, V, cosr, sinr);
					return 2;
				}
			}
			// else call computeSVD() and check for 2x2 there
			return ComputeSVD(this, U, W, V);
		}

		/// <summary>
		/// LU Decomposition: this matrix must be a square matrix and the
		/// LU GMatrix parameter must be the same size as this matrix.
		/// </summary>
		/// <remarks>
		/// LU Decomposition: this matrix must be a square matrix and the
		/// LU GMatrix parameter must be the same size as this matrix.
		/// The matrix LU will be overwritten as the combination of a
		/// lower diagonal and upper diagonal matrix decompostion of this
		/// matrix; the diagonal
		/// elements of L (unity) are not stored.  The GVector parameter
		/// records the row permutation effected by the partial pivoting,
		/// and is used as a parameter to the GVector method LUDBackSolve
		/// to solve sets of linear equations.
		/// This method returns +/- 1 depending on whether the number
		/// of row interchanges was even or odd, respectively.
		/// </remarks>
		/// <param name="Lu">
		/// The matrix into which the lower and upper decompositions
		/// will be placed.
		/// </param>
		/// <param name="permutation">
		/// The row permutation effected by the partial
		/// pivoting
		/// </param>
		/// <returns>
		/// +-1 depending on whether the number of row interchanges
		/// was even or odd respectively
		/// </returns>
		public int Lud(GMatrix Lu, GVector permutation)
		{
			int size = Lu.nRow * Lu.nCol;
			double[] temp = new double[size];
			int[] even_row_exchange = new int[1];
			int[] row_perm = new int[Lu.nRow];
			int i;
			int j;
			if (nRow != nCol)
			{
				throw new MismatchedSizeException("cannot perform LU decomposition on a non square matrix");
			}
			if (nRow != Lu.nRow)
			{
				throw new MismatchedSizeException("LU must have same dimensions as this matrix");
			}
			if (nCol != Lu.nCol)
			{
				throw new MismatchedSizeException("LU must have same dimensions as this matrix");
			}
			if (Lu.nRow != permutation.GetSize())
			{
				throw new MismatchedSizeException("row permutation must be same dimension as matrix");
			}
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					temp[i * nCol + j] = values[i][j];
				}
			}
			// Calculate LU decomposition: Is the matrix singular? 
			if (!LuDecomposition(Lu.nRow, temp, row_perm, even_row_exchange))
			{
				// Matrix has no inverse 
				throw new SingularMatrixException("cannot invert matrix");
			}
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					Lu.values[i][j] = temp[i * nCol + j];
				}
			}
			for (i = 0; i < Lu.nRow; i++)
			{
				permutation.values[i] = (double)row_perm[i];
			}
			return even_row_exchange[0];
		}

		/// <summary>
		/// Sets this matrix to a uniform scale matrix; all of the
		/// values are reset.
		/// </summary>
		/// <remarks>
		/// Sets this matrix to a uniform scale matrix; all of the
		/// values are reset.
		/// </remarks>
		/// <param name="scale">The new scale value</param>
		public void SetScale(double scale)
		{
			int i;
			int j;
			int l;
			if (nRow < nCol)
			{
				l = nRow;
			}
			else
			{
				l = nCol;
			}
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					values[i][j] = 0.0;
				}
			}
			for (i = 0; i < l; i++)
			{
				values[i][i] = scale;
			}
		}

		/// <summary>General invert routine.</summary>
		/// <remarks>
		/// General invert routine.  Inverts m1 and places the result in "this".
		/// Note that this routine handles both the "this" version and the
		/// non-"this" version.
		/// Also note that since this routine is slow anyway, we won't worry
		/// about allocating a little bit of garbage.
		/// </remarks>
		internal void InvertGeneral(GMatrix m1)
		{
			int size = m1.nRow * m1.nCol;
			double[] temp = new double[size];
			double[] result = new double[size];
			int[] row_perm = new int[m1.nRow];
			int[] even_row_exchange = new int[1];
			int i;
			int j;
			// Use LU decomposition and backsubstitution code specifically
			// for floating-point nxn matrices.
			if (m1.nRow != m1.nCol)
			{
				// Matrix is either under or over determined 
				throw new MismatchedSizeException("cannot invert non square matrix");
			}
			// Copy source matrix to temp 
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					temp[i * nCol + j] = m1.values[i][j];
				}
			}
			// Calculate LU decomposition: Is the matrix singular? 
			if (!LuDecomposition(m1.nRow, temp, row_perm, even_row_exchange))
			{
				// Matrix has no inverse 
				throw new SingularMatrixException("cannot invert matrix");
			}
			// Perform back substitution on the identity matrix 
			for (i = 0; i < size; i++)
			{
				result[i] = 0.0;
			}
			for (i = 0; i < nCol; i++)
			{
				result[i + i * nCol] = 1.0;
			}
			LuBacksubstitution(m1.nRow, temp, row_perm, result);
			for (i = 0; i < nRow; i++)
			{
				for (j = 0; j < nCol; j++)
				{
					values[i][j] = result[i * nCol + j];
				}
			}
		}

		/// <summary>
		/// Given a nxn array "matrix0", this function replaces it with the
		/// LU decomposition of a row-wise permutation of itself.
		/// </summary>
		/// <remarks>
		/// Given a nxn array "matrix0", this function replaces it with the
		/// LU decomposition of a row-wise permutation of itself.  The input
		/// parameters are "matrix0" and "dim".  The array "matrix0" is also
		/// an output parameter.  The vector "row_perm[]" is an output
		/// parameter that contains the row permutations resulting from partial
		/// pivoting.  The output parameter "even_row_xchg" is 1 when the
		/// number of row exchanges is even, or -1 otherwise.  Assumes data
		/// type is always double.
		/// </remarks>
		/// <returns>true if the matrix is nonsingular, or false otherwise.</returns>
		internal static bool LuDecomposition(int dim, double[] matrix0, int[] row_perm, int
			[] even_row_xchg)
		{
			//
			// Reference: Press, Flannery, Teukolsky, Vetterling, 
			//	      _Numerical_Recipes_in_C_, Cambridge University Press, 
			//	      1988, pp 40-45.
			//
			double[] row_scale = new double[dim];
			// Determine implicit scaling information by looping over rows 
			int i;
			int j;
			int ptr;
			int rs;
			int mtx;
			double big;
			double temp;
			ptr = 0;
			rs = 0;
			even_row_xchg[0] = 1;
			// For each row ... 
			i = dim;
			while (i-- != 0)
			{
				big = 0.0;
				// For each column, find the largest element in the row 
				j = dim;
				while (j-- != 0)
				{
					temp = matrix0[ptr++];
					temp = Math.Abs(temp);
					if (temp > big)
					{
						big = temp;
					}
				}
				// Is the matrix singular? 
				if (big == 0.0)
				{
					return false;
				}
				row_scale[rs++] = 1.0 / big;
			}
			// For all columns, execute Crout's method 
			mtx = 0;
			for (j = 0; j < dim; j++)
			{
				int imax;
				int k;
				int target;
				int p1;
				int p2;
				double sum;
				// Determine elements of upper diagonal matrix U 
				for (i = 0; i < j; i++)
				{
					target = mtx + (dim * i) + j;
					sum = matrix0[target];
					k = i;
					p1 = mtx + (dim * i);
					p2 = mtx + j;
					while (k-- != 0)
					{
						sum -= matrix0[p1] * matrix0[p2];
						p1++;
						p2 += dim;
					}
					matrix0[target] = sum;
				}
				// Search for largest pivot element and calculate
				// intermediate elements of lower diagonal matrix L.
				big = 0.0;
				imax = -1;
				for (i = j; i < dim; i++)
				{
					target = mtx + (dim * i) + j;
					sum = matrix0[target];
					k = j;
					p1 = mtx + (dim * i);
					p2 = mtx + j;
					while (k-- != 0)
					{
						sum -= matrix0[p1] * matrix0[p2];
						p1++;
						p2 += dim;
					}
					matrix0[target] = sum;
					// Is this the best pivot so far? 
					if ((temp = row_scale[i] * Math.Abs(sum)) >= big)
					{
						big = temp;
						imax = i;
					}
				}
				if (imax < 0)
				{
					throw new Exception("Logic error: imax < 0");
				}
				// Is a row exchange necessary? 
				if (j != imax)
				{
					// Yes: exchange rows 
					k = dim;
					p1 = mtx + (dim * imax);
					p2 = mtx + (dim * j);
					while (k-- != 0)
					{
						temp = matrix0[p1];
						matrix0[p1++] = matrix0[p2];
						matrix0[p2++] = temp;
					}
					// Record change in scale factor 
					row_scale[imax] = row_scale[j];
					even_row_xchg[0] = -even_row_xchg[0];
				}
				// change exchange parity
				// Record row permutation 
				row_perm[j] = imax;
				// Is the matrix singular 
				if (matrix0[(mtx + (dim * j) + j)] == 0.0)
				{
					return false;
				}
				// Divide elements of lower diagonal matrix L by pivot 
				if (j != (dim - 1))
				{
					temp = 1.0 / (matrix0[(mtx + (dim * j) + j)]);
					target = mtx + (dim * (j + 1)) + j;
					i = (dim - 1) - j;
					while (i-- != 0)
					{
						matrix0[target] *= temp;
						target += dim;
					}
				}
			}
			return true;
		}

		/// <summary>Solves a set of linear equations.</summary>
		/// <remarks>
		/// Solves a set of linear equations.  The input parameters "matrix1",
		/// and "row_perm" come from luDecompostion and do not change
		/// here.  The parameter "matrix2" is a set of column vectors assembled
		/// into a nxn matrix of floating-point values.  The procedure takes each
		/// column of "matrix2" in turn and treats it as the right-hand side of the
		/// matrix equation Ax = LUx = b.  The solution vector replaces the
		/// original column of the matrix.
		/// If "matrix2" is the identity matrix, the procedure replaces its contents
		/// with the inverse of the matrix from which "matrix1" was originally
		/// derived.
		/// </remarks>
		internal static void LuBacksubstitution(int dim, double[] matrix1, int[] row_perm
			, double[] matrix2)
		{
			//
			// Reference: Press, Flannery, Teukolsky, Vetterling, 
			//	      _Numerical_Recipes_in_C_, Cambridge University Press, 
			//	      1988, pp 44-45.
			//
			int i;
			int ii;
			int ip;
			int j;
			int k;
			int rp;
			int cv;
			int rv;
			int ri;
			double tt;
			// rp = row_perm;
			rp = 0;
			// For each column vector of matrix2 ... 
			for (k = 0; k < dim; k++)
			{
				// cv = &(matrix2[0][k]);
				cv = k;
				ii = -1;
				// Forward substitution 
				for (i = 0; i < dim; i++)
				{
					double sum;
					ip = row_perm[rp + i];
					sum = matrix2[cv + dim * ip];
					matrix2[cv + dim * ip] = matrix2[cv + dim * i];
					if (ii >= 0)
					{
						// rv = &(matrix1[i][0]);
						rv = i * dim;
						for (j = ii; j <= i - 1; j++)
						{
							sum -= matrix1[rv + j] * matrix2[cv + dim * j];
						}
					}
					else
					{
						if (sum != 0.0)
						{
							ii = i;
						}
					}
					matrix2[cv + dim * i] = sum;
				}
				// Backsubstitution 
				for (i = 0; i < dim; i++)
				{
					ri = (dim - 1 - i);
					rv = dim * (ri);
					tt = 0.0;
					for (j = 1; j <= i; j++)
					{
						tt += matrix1[rv + dim - j] * matrix2[cv + dim * (dim - j)];
					}
					matrix2[cv + dim * ri] = (matrix2[cv + dim * ri] - tt) / matrix1[rv + ri];
				}
			}
		}

		internal static int ComputeSVD(GMatrix mat, GMatrix U, GMatrix
			 W, GMatrix V)
		{
			int i;
			int j;
			int k;
			int nr;
			int nc;
			int si;
			int converged;
			int rank;
			double cs;
			double sn;
			double r;
			double mag;
			double scale;
			double t;
			int eLength;
			int sLength;
			int vecLength;
			GMatrix tmp = new GMatrix(mat.nRow, mat.nCol);
			GMatrix u = new GMatrix(mat.nRow, mat.nCol);
			GMatrix v = new GMatrix(mat.nRow, mat.nCol);
			GMatrix m = new GMatrix(mat);
			// compute the number of singular values
			if (m.nRow >= m.nCol)
			{
				sLength = m.nCol;
				eLength = m.nCol - 1;
			}
			else
			{
				sLength = m.nRow;
				eLength = m.nRow;
			}
			if (m.nRow > m.nCol)
			{
				vecLength = m.nRow;
			}
			else
			{
				vecLength = m.nCol;
			}
			double[] vec = new double[vecLength];
			double[] single_values = new double[sLength];
			double[] e = new double[eLength];
			rank = 0;
			U.SetIdentity();
			V.SetIdentity();
			nr = m.nRow;
			nc = m.nCol;
			// householder reduction 
			for (si = 0; si < sLength; si++)
			{
				// for each singular value
				if (nr > 1)
				{
					// zero out column
					// compute reflector
					mag = 0.0;
					for (i = 0; i < nr; i++)
					{
						mag += m.values[i + si][si] * m.values[i + si][si];
					}
					mag = Math.Sqrt(mag);
					if (m.values[si][si] == 0.0)
					{
						vec[0] = mag;
					}
					else
					{
						vec[0] = m.values[si][si] + D_sign(mag, m.values[si][si]);
					}
					for (i = 1; i < nr; i++)
					{
						vec[i] = m.values[si + i][si];
					}
					scale = 0.0;
					for (i = 0; i < nr; i++)
					{
						scale += vec[i] * vec[i];
					}
					scale = 2.0 / scale;
					for (j = si; j < m.nRow; j++)
					{
						for (k = si; k < m.nRow; k++)
						{
							u.values[j][k] = -scale * vec[j - si] * vec[k - si];
						}
					}
					for (i = si; i < m.nRow; i++)
					{
						u.values[i][i] += 1.0;
					}
					// compute s
					t = 0.0;
					for (i = si; i < m.nRow; i++)
					{
						t += u.values[si][i] * m.values[i][si];
					}
					m.values[si][si] = t;
					// apply reflector
					for (j = si; j < m.nRow; j++)
					{
						for (k = si + 1; k < m.nCol; k++)
						{
							tmp.values[j][k] = 0.0;
							for (i = si; i < m.nCol; i++)
							{
								tmp.values[j][k] += u.values[j][i] * m.values[i][k];
							}
						}
					}
					for (j = si; j < m.nRow; j++)
					{
						for (k = si + 1; k < m.nCol; k++)
						{
							m.values[j][k] = tmp.values[j][k];
						}
					}
					// update U matrix
					for (j = si; j < m.nRow; j++)
					{
						for (k = 0; k < m.nCol; k++)
						{
							tmp.values[j][k] = 0.0;
							for (i = si; i < m.nCol; i++)
							{
								tmp.values[j][k] += u.values[j][i] * U.values[i][k];
							}
						}
					}
					for (j = si; j < m.nRow; j++)
					{
						for (k = 0; k < m.nCol; k++)
						{
							U.values[j][k] = tmp.values[j][k];
						}
					}
					nr--;
				}
				if (nc > 2)
				{
					// zero out row
					mag = 0.0;
					for (i = 1; i < nc; i++)
					{
						mag += m.values[si][si + i] * m.values[si][si + i];
					}
					// generate the reflection vector, compute the first entry and
					// copy the rest from the row to be zeroed
					mag = Math.Sqrt(mag);
					if (m.values[si][si + 1] == 0.0)
					{
						vec[0] = mag;
					}
					else
					{
						vec[0] = m.values[si][si + 1] + D_sign(mag, m.values[si][si + 1]);
					}
					for (i = 1; i < nc - 1; i++)
					{
						vec[i] = m.values[si][si + i + 1];
					}
					// use reflection vector to compute v matrix
					scale = 0.0;
					for (i = 0; i < nc - 1; i++)
					{
						scale += vec[i] * vec[i];
					}
					scale = 2.0 / scale;
					for (j = si + 1; j < nc; j++)
					{
						for (k = si + 1; k < m.nCol; k++)
						{
							v.values[j][k] = -scale * vec[j - si - 1] * vec[k - si - 1];
						}
					}
					for (i = si + 1; i < m.nCol; i++)
					{
						v.values[i][i] += 1.0;
					}
					t = 0.0;
					for (i = si; i < m.nCol; i++)
					{
						t += v.values[i][si + 1] * m.values[si][i];
					}
					m.values[si][si + 1] = t;
					// apply reflector
					for (j = si + 1; j < m.nRow; j++)
					{
						for (k = si + 1; k < m.nCol; k++)
						{
							tmp.values[j][k] = 0.0;
							for (i = si + 1; i < m.nCol; i++)
							{
								tmp.values[j][k] += v.values[i][k] * m.values[j][i];
							}
						}
					}
					for (j = si + 1; j < m.nRow; j++)
					{
						for (k = si + 1; k < m.nCol; k++)
						{
							m.values[j][k] = tmp.values[j][k];
						}
					}
					// update V matrix
					for (j = 0; j < m.nRow; j++)
					{
						for (k = si + 1; k < m.nCol; k++)
						{
							tmp.values[j][k] = 0.0;
							for (i = si + 1; i < m.nCol; i++)
							{
								tmp.values[j][k] += v.values[i][k] * V.values[j][i];
							}
						}
					}
					for (j = 0; j < m.nRow; j++)
					{
						for (k = si + 1; k < m.nCol; k++)
						{
							V.values[j][k] = tmp.values[j][k];
						}
					}
					nc--;
				}
			}
			for (i = 0; i < sLength; i++)
			{
				single_values[i] = m.values[i][i];
			}
			for (i = 0; i < eLength; i++)
			{
				e[i] = m.values[i][i + 1];
			}
			// Fix ArrayIndexOutOfBounds for 2x2 matrices, which partially
			// addresses bug 4348562 for J3D 1.2.1.
			//
			// Does *not* fix the following problems reported in 4348562,
			// which will wait for J3D 1.3:
			//
			//   1) no output of W
			//   2) wrong transposition of U
			//   3) wrong results for 4x4 matrices
			//   4) slow performance
			if (m.nRow == 2 && m.nCol == 2)
			{
				double[] cosl = new double[1];
				double[] cosr = new double[1];
				double[] sinl = new double[1];
				double[] sinr = new double[1];
				Compute_2X2(single_values[0], e[0], single_values[1], single_values, sinl, cosl, 
					sinr, cosr, 0);
				Update_u(0, U, cosl, sinl);
				Update_v(0, V, cosr, sinr);
				return 2;
			}
			// compute_qr causes ArrayIndexOutOfBounds for 2x2 matrices
			Compute_qr(0, e.Length - 1, single_values, e, U, V);
			// compute rank = number of non zero singular values
			rank = single_values.Length;
			// sort by order of size of single values
			// and check for zero's
			return rank;
		}

		internal static void Compute_qr(int start, int end, double[] s, double[] e, GMatrix
			 u, GMatrix v)
		{
			int i;
			int j;
			int k;
			int n;
			int sl;
			bool converged;
			double shift;
			double r;
			double utemp;
			double vtemp;
			double f;
			double g;
			double[] cosl = new double[1];
			double[] cosr = new double[1];
			double[] sinl = new double[1];
			double[] sinr = new double[1];
			GMatrix m = new GMatrix(u.nCol, v.nRow);
			int MaxInterations = 2;
			double ConvergeTol = 4.89E-15;
			double c_b48 = 1.0;
			double c_b71 = -1.0;
			converged = false;
			f = 0.0;
			g = 0.0;
			for (k = 0; k < MaxInterations && !converged; k++)
			{
				for (i = start; i <= end; i++)
				{
					// if at start of iterfaction compute shift 
					if (i == start)
					{
						if (e.Length == s.Length)
						{
							sl = end;
						}
						else
						{
							sl = end + 1;
						}
						shift = Compute_shift(s[sl - 1], e[end], s[sl]);
						f = (Math.Abs(s[i]) - shift) * (D_sign(c_b48, s[i]) + shift / s[i]);
						g = e[i];
					}
					r = Compute_rot(f, g, sinr, cosr);
					if (i != start)
					{
						e[i - 1] = r;
					}
					f = cosr[0] * s[i] + sinr[0] * e[i];
					e[i] = cosr[0] * e[i] - sinr[0] * s[i];
					g = sinr[0] * s[i + 1];
					s[i + 1] = cosr[0] * s[i + 1];
					// if (debug) print_se(s,e);
					Update_v(i, v, cosr, sinr);
					r = Compute_rot(f, g, sinl, cosl);
					s[i] = r;
					f = cosl[0] * e[i] + sinl[0] * s[i + 1];
					s[i + 1] = cosl[0] * s[i + 1] - sinl[0] * e[i];
					if (i < end)
					{
						// if not last
						g = sinl[0] * e[i + 1];
						e[i + 1] = cosl[0] * e[i + 1];
					}
					//if (debug) print_se(s,e);
					Update_u(i, u, cosl, sinl);
				}
				// if extra off diagonal perform one more right side rotation
				if (s.Length == e.Length)
				{
					r = Compute_rot(f, g, sinr, cosr);
					f = cosr[0] * s[i] + sinr[0] * e[i];
					e[i] = cosr[0] * e[i] - sinr[0] * s[i];
					s[i + 1] = cosr[0] * s[i + 1];
					Update_v(i, v, cosr, sinr);
				}
				// check for convergence on off diagonals and reduce 
				while ((end - start > 1) && (Math.Abs(e[end]) < ConvergeTol))
				{
					end--;
				}
				// check if need to split
				for (n = end - 2; n > start; n--)
				{
					if (Math.Abs(e[n]) < ConvergeTol)
					{
						// split
						Compute_qr(n + 1, end, s, e, u, v);
						// do lower matrix
						end = n - 1;
						// do upper matrix
						// check for convergence on off diagonals and reduce 
						while ((end - start > 1) && (Math.Abs(e[end]) < ConvergeTol))
						{
							end--;
						}
					}
				}
				if ((end - start <= 1) && (Math.Abs(e[start + 1]) < ConvergeTol))
				{
					converged = true;
				}
			}
			// check if zero on the diagonal
			if (Math.Abs(e[1]) < ConvergeTol)
			{
				Compute_2X2(s[start], e[start], s[start + 1], s, sinl, cosl, sinr, cosr, 0);
				e[start] = 0.0;
				e[start + 1] = 0.0;
			}
			i = start;
			Update_u(i, u, cosl, sinl);
			Update_v(i, v, cosr, sinr);
			return;
		}

		private static void Print_se(double[] s, double[] e)
		{
			System.Console.Out.WriteLine("\ns =" + s[0] + " " + s[1] + " " + s[2]);
			System.Console.Out.WriteLine("e =" + e[0] + " " + e[1]);
		}

		private static void Update_v(int index, GMatrix v, double[] cosr, double[]
			 sinr)
		{
			int j;
			double vtemp;
			for (j = 0; j < v.nRow; j++)
			{
				vtemp = v.values[j][index];
				v.values[j][index] = cosr[0] * vtemp + sinr[0] * v.values[j][index + 1];
				v.values[j][index + 1] = -sinr[0] * vtemp + cosr[0] * v.values[j][index + 1];
			}
		}

		private static void Chase_up(double[] s, double[] e, int k, GMatrix v)
		{
			double f;
			double g;
			double r;
			double[] cosr = new double[1];
			double[] sinr = new double[1];
			int i;
			GMatrix t = new GMatrix(v.nRow, v.nCol);
			GMatrix m = new GMatrix(v.nRow, v.nCol);
			f = e[k];
			g = s[k];
			for (i = k; i > 0; i--)
			{
				r = Compute_rot(f, g, sinr, cosr);
				f = -e[i - 1] * sinr[0];
				g = s[i - 1];
				s[i] = r;
				e[i - 1] = e[i - 1] * cosr[0];
				Update_v_split(i, k + 1, v, cosr, sinr, t, m);
			}
			s[i + 1] = Compute_rot(f, g, sinr, cosr);
			Update_v_split(i, k + 1, v, cosr, sinr, t, m);
		}

		private static void Chase_across(double[] s, double[] e, int k, GMatrix u
			)
		{
			double f;
			double g;
			double r;
			double[] cosl = new double[1];
			double[] sinl = new double[1];
			int i;
			GMatrix t = new GMatrix(u.nRow, u.nCol);
			GMatrix m = new GMatrix(u.nRow, u.nCol);
			g = e[k];
			f = s[k + 1];
			for (i = k; i < u.nCol - 2; i++)
			{
				r = Compute_rot(f, g, sinl, cosl);
				g = -e[i + 1] * sinl[0];
				f = s[i + 2];
				s[i + 1] = r;
				e[i + 1] = e[i + 1] * cosl[0];
				Update_u_split(k, i + 1, u, cosl, sinl, t, m);
			}
			s[i + 1] = Compute_rot(f, g, sinl, cosl);
			Update_u_split(k, i + 1, u, cosl, sinl, t, m);
		}

		private static void Update_v_split(int topr, int bottomr, GMatrix v, double
			[] cosr, double[] sinr, GMatrix t, GMatrix m)
		{
			int j;
			double vtemp;
			for (j = 0; j < v.nRow; j++)
			{
				vtemp = v.values[j][topr];
				v.values[j][topr] = cosr[0] * vtemp - sinr[0] * v.values[j][bottomr];
				v.values[j][bottomr] = sinr[0] * vtemp + cosr[0] * v.values[j][bottomr];
			}
			System.Console.Out.WriteLine("topr    =" + topr);
			System.Console.Out.WriteLine("bottomr =" + bottomr);
			System.Console.Out.WriteLine("cosr =" + cosr[0]);
			System.Console.Out.WriteLine("sinr =" + sinr[0]);
			System.Console.Out.WriteLine("\nm =");
			CheckMatrix(m);
			System.Console.Out.WriteLine("\nv =");
			CheckMatrix(t);
			m.Mul(m, t);
			System.Console.Out.WriteLine("\nt*m =");
			CheckMatrix(m);
		}

		private static void Update_u_split(int topr, int bottomr, GMatrix u, double
			[] cosl, double[] sinl, GMatrix t, GMatrix m)
		{
			int j;
			double utemp;
			for (j = 0; j < u.nCol; j++)
			{
				utemp = u.values[topr][j];
				u.values[topr][j] = cosl[0] * utemp - sinl[0] * u.values[bottomr][j];
				u.values[bottomr][j] = sinl[0] * utemp + cosl[0] * u.values[bottomr][j];
			}
			System.Console.Out.WriteLine("\nm=");
			CheckMatrix(m);
			System.Console.Out.WriteLine("\nu=");
			CheckMatrix(t);
			m.Mul(t, m);
			System.Console.Out.WriteLine("\nt*m=");
			CheckMatrix(m);
		}

		private static void Update_u(int index, GMatrix u, double[] cosl, double[]
			 sinl)
		{
			int j;
			double utemp;
			for (j = 0; j < u.nCol; j++)
			{
				utemp = u.values[index][j];
				u.values[index][j] = cosl[0] * utemp + sinl[0] * u.values[index + 1][j];
				u.values[index + 1][j] = -sinl[0] * utemp + cosl[0] * u.values[index + 1][j];
			}
		}

		private static void Print_m(GMatrix m, GMatrix u, GMatrix
			 v)
		{
			GMatrix mtmp = new GMatrix(m.nCol, m.nRow);
			mtmp.Mul(u, mtmp);
			mtmp.Mul(mtmp, v);
			System.Console.Out.WriteLine("\n m = \n" + GMatrix.ToString(mtmp));
		}

		private static string ToString(GMatrix m)
		{
			StringBuilder buffer = new StringBuilder(m.nRow * m.nCol * 8);
			int i;
			int j;
			for (i = 0; i < m.nRow; i++)
			{
				for (j = 0; j < m.nCol; j++)
				{
					if (Math.Abs(m.values[i][j]) < .000000001)
					{
						buffer.Append("0.0000 ");
					}
					else
					{
						buffer.Append(m.values[i][j]).Append(" ");
					}
				}
				buffer.Append("\n");
			}
			return buffer.ToString();
		}

		private static void Print_svd(double[] s, double[] e, GMatrix u, GMatrix
			 v)
		{
			int i;
			GMatrix mtmp = new GMatrix(u.nCol, v.nRow);
			System.Console.Out.WriteLine(" \ns = ");
			for (i = 0; i < s.Length; i++)
			{
				System.Console.Out.WriteLine(" " + s[i]);
			}
			System.Console.Out.WriteLine(" \ne = ");
			for (i = 0; i < e.Length; i++)
			{
				System.Console.Out.WriteLine(" " + e[i]);
			}
			System.Console.Out.WriteLine(" \nu  = \n" + u.ToString());
			System.Console.Out.WriteLine(" \nv  = \n" + v.ToString());
			mtmp.SetIdentity();
			for (i = 0; i < s.Length; i++)
			{
				mtmp.values[i][i] = s[i];
			}
			for (i = 0; i < e.Length; i++)
			{
				mtmp.values[i][i + 1] = e[i];
			}
			System.Console.Out.WriteLine(" \nm  = \n" + mtmp.ToString());
			mtmp.MulTransposeLeft(u, mtmp);
			mtmp.MulTransposeRight(mtmp, v);
			System.Console.Out.WriteLine(" \n u.transpose*m*v.transpose  = \n" + mtmp.ToString
				());
		}

		internal static double Max(double a, double b)
		{
			if (a > b)
			{
				return a;
			}
			else
			{
				return b;
			}
		}

		internal static double Min(double a, double b)
		{
			if (a < b)
			{
				return a;
			}
			else
			{
				return b;
			}
		}

		internal static double Compute_shift(double f, double g, double h)
		{
			double d__1;
			double d__2;
			double fhmn;
			double fhmx;
			double c;
			double fa;
			double ga;
			double ha;
			double @as;
			double at;
			double au;
			double ssmin;
			fa = Math.Abs(f);
			ga = Math.Abs(g);
			ha = Math.Abs(h);
			fhmn = Min(fa, ha);
			fhmx = Max(fa, ha);
			if (fhmn == 0.0)
			{
				ssmin = 0.0;
				if (fhmx == 0.0)
				{
				}
				else
				{
					d__1 = Min(fhmx, ga) / Max(fhmx, ga);
				}
			}
			else
			{
				if (ga < fhmx)
				{
					@as = fhmn / fhmx + 1.0;
					at = (fhmx - fhmn) / fhmx;
					d__1 = ga / fhmx;
					au = d__1 * d__1;
					c = 2.0 / (Math.Sqrt(@as * @as + au) + Math.Sqrt(at * at + au));
					ssmin = fhmn * c;
				}
				else
				{
					au = fhmx / ga;
					if (au == 0.0)
					{
						ssmin = fhmn * fhmx / ga;
					}
					else
					{
						@as = fhmn / fhmx + 1.0;
						at = (fhmx - fhmn) / fhmx;
						d__1 = @as * au;
						d__2 = at * au;
						c = 1.0 / (Math.Sqrt(d__1 * d__1 + 1.0) + Math.Sqrt(d__2 * d__2 + 1.0));
						ssmin = fhmn * c * au;
						ssmin += ssmin;
					}
				}
			}
			return ssmin;
		}

		internal static int Compute_2X2(double f, double g, double h, double[] single_values
			, double[] snl, double[] csl, double[] snr, double[] csr, int index)
		{
			double c_b3 = 2.0;
			double c_b4 = 1.0;
			double d__1;
			int pmax;
			double temp;
			bool swap;
			double a;
			double d;
			double l;
			double m;
			double r;
			double s;
			double t;
			double tsign;
			double fa;
			double ga;
			double ha;
			double ft;
			double gt;
			double ht;
			double mm;
			bool gasmal;
			double tt;
			double clt;
			double crt;
			double slt;
			double srt;
			double ssmin;
			double ssmax;
			ssmax = single_values[0];
			ssmin = single_values[1];
			clt = 0.0;
			crt = 0.0;
			slt = 0.0;
			srt = 0.0;
			tsign = 0.0;
			ft = f;
			fa = Math.Abs(ft);
			ht = h;
			ha = Math.Abs(h);
			pmax = 1;
			if (ha > fa)
			{
				swap = true;
			}
			else
			{
				swap = false;
			}
			if (swap)
			{
				pmax = 3;
				temp = ft;
				ft = ht;
				ht = temp;
				temp = fa;
				fa = ha;
				ha = temp;
			}
			gt = g;
			ga = Math.Abs(gt);
			if (ga == 0.0)
			{
				single_values[1] = ha;
				single_values[0] = fa;
				clt = 1.0;
				crt = 1.0;
				slt = 0.0;
				srt = 0.0;
			}
			else
			{
				gasmal = true;
				if (ga > fa)
				{
					pmax = 2;
					if (fa / ga < Eps)
					{
						gasmal = false;
						ssmax = ga;
						if (ha > 1.0)
						{
							ssmin = fa / (ga / ha);
						}
						else
						{
							ssmin = fa / ga * ha;
						}
						clt = 1.0;
						slt = ht / gt;
						srt = 1.0;
						crt = ft / gt;
					}
				}
				if (gasmal)
				{
					d = fa - ha;
					if (d == fa)
					{
						l = 1.0;
					}
					else
					{
						l = d / fa;
					}
					m = gt / ft;
					t = 2.0 - l;
					mm = m * m;
					tt = t * t;
					s = Math.Sqrt(tt + mm);
					if (l == 0.0)
					{
						r = Math.Abs(m);
					}
					else
					{
						r = Math.Sqrt(l * l + mm);
					}
					a = (s + r) * 0.5;
					if (ga > fa)
					{
						pmax = 2;
						if (fa / ga < Eps)
						{
							gasmal = false;
							ssmax = ga;
							if (ha > 1.0)
							{
								ssmin = fa / (ga / ha);
							}
							else
							{
								ssmin = fa / ga * ha;
							}
							clt = 1.0;
							slt = ht / gt;
							srt = 1.0;
							crt = ft / gt;
						}
					}
					if (gasmal)
					{
						d = fa - ha;
						if (d == fa)
						{
							l = 1.0;
						}
						else
						{
							l = d / fa;
						}
						m = gt / ft;
						t = 2.0 - l;
						mm = m * m;
						tt = t * t;
						s = Math.Sqrt(tt + mm);
						if (l == 0.0)
						{
							r = Math.Abs(m);
						}
						else
						{
							r = Math.Sqrt(l * l + mm);
						}
						a = (s + r) * 0.5;
						ssmin = ha / a;
						ssmax = fa * a;
						if (mm == 0.0)
						{
							if (l == 0.0)
							{
								t = D_sign(c_b3, ft) * D_sign(c_b4, gt);
							}
							else
							{
								t = gt / D_sign(d, ft) + m / t;
							}
						}
						else
						{
							t = (m / (s + t) + m / (r + l)) * (a + 1.0);
						}
						l = Math.Sqrt(t * t + 4.0);
						crt = 2.0 / l;
						srt = t / l;
						clt = (crt + srt * m) / a;
						slt = ht / ft * srt / a;
					}
				}
				if (swap)
				{
					csl[0] = srt;
					snl[0] = crt;
					csr[0] = slt;
					snr[0] = clt;
				}
				else
				{
					csl[0] = clt;
					snl[0] = slt;
					csr[0] = crt;
					snr[0] = srt;
				}
				if (pmax == 1)
				{
					tsign = D_sign(c_b4, csr[0]) * D_sign(c_b4, csl[0]) * D_sign(c_b4, f);
				}
				if (pmax == 2)
				{
					tsign = D_sign(c_b4, snr[0]) * D_sign(c_b4, csl[0]) * D_sign(c_b4, g);
				}
				if (pmax == 3)
				{
					tsign = D_sign(c_b4, snr[0]) * D_sign(c_b4, snl[0]) * D_sign(c_b4, h);
				}
				single_values[index] = D_sign(ssmax, tsign);
				d__1 = tsign * D_sign(c_b4, f) * D_sign(c_b4, h);
				single_values[index + 1] = D_sign(ssmin, d__1);
			}
			return 0;
		}

		internal static double Compute_rot(double f, double g, double[] sin, double[] cos
			)
		{
			int i__1;
			double d__1;
			double d__2;
			double cs;
			double sn;
			int i;
			double scale;
			int count;
			double f1;
			double g1;
			double r;
			double safmn2 = 2.002083095183101E-146;
			double safmx2 = 4.994797680505588E+145;
			if (g == 0.0)
			{
				cs = 1.0;
				sn = 0.0;
				r = f;
			}
			else
			{
				if (f == 0.0)
				{
					cs = 0.0;
					sn = 1.0;
					r = g;
				}
				else
				{
					f1 = f;
					g1 = g;
					scale = Max(Math.Abs(f1), Math.Abs(g1));
					if (scale >= safmx2)
					{
						count = 0;
						while (scale >= safmx2)
						{
							++count;
							f1 *= safmn2;
							g1 *= safmn2;
							scale = Max(Math.Abs(f1), Math.Abs(g1));
						}
						r = Math.Sqrt(f1 * f1 + g1 * g1);
						cs = f1 / r;
						sn = g1 / r;
						i__1 = count;
						for (i = 1; i <= count; ++i)
						{
							r *= safmx2;
						}
					}
					else
					{
						if (scale <= safmn2)
						{
							count = 0;
							while (scale <= safmn2)
							{
								++count;
								f1 *= safmx2;
								g1 *= safmx2;
								scale = Max(Math.Abs(f1), Math.Abs(g1));
							}
							r = Math.Sqrt(f1 * f1 + g1 * g1);
							cs = f1 / r;
							sn = g1 / r;
							i__1 = count;
							for (i = 1; i <= count; ++i)
							{
								r *= safmn2;
							}
						}
						else
						{
							r = Math.Sqrt(f1 * f1 + g1 * g1);
							cs = f1 / r;
							sn = g1 / r;
						}
					}
					if (Math.Abs(f) > Math.Abs(g) && cs < 0.0)
					{
						cs = -cs;
						sn = -sn;
						r = -r;
					}
				}
			}
			sin[0] = sn;
			cos[0] = cs;
			return r;
		}

		internal static double D_sign(double a, double b)
		{
			double x;
			x = (a >= 0 ? a : -a);
			return (b >= 0 ? x : -x);
		}

		/// <summary>Creates a new object of the same class as this object.</summary>
		/// <remarks>Creates a new object of the same class as this object.</remarks>
		/// <returns>a clone of this instance.</returns>
		/// <exception>
		/// OutOfMemoryError
		/// if there is not enough memory.
		/// </exception>
		/// <seealso cref="System.ICloneable">System.ICloneable</seealso>
		/// <since>vecmath 1.3</since>
		public virtual object Clone()
		{
			GMatrix m1 = null;
			m1 = (GMatrix)base.MemberwiseClone();
			// this shouldn't happen, since we are Cloneable
			// Also need to clone array of values
			// m1.values = new double[nRow][nCol];
			m1.values = new double[][] { new double[7], new double[7], new double[7], new double
				[7], new double[7], new double[7], new double[7] };
			for (int i = 0; i < nRow; i++)
			{
				for (int j = 0; j < nCol; j++)
				{
					m1.values[i][j] = values[i][j];
				}
			}
			return m1;
		}
	}
}
