/*
 * Automated conversion
 */

using System;

namespace NVecMath
{
	/// <summary>A double precision floating point 3 by 3 matrix.</summary>
	/// <remarks>
	/// A double precision floating point 3 by 3 matrix.
	/// Primarily to support 3D rotations.
	/// </remarks>
	[System.Serializable]
	public class Matrix3d : ICloneable
	{
		internal const long serialVersionUID = 6837536777072402710L;

		/// <summary>The first matrix element in the first row.</summary>
		/// <remarks>The first matrix element in the first row.</remarks>
		public double m00;

		/// <summary>The second matrix element in the first row.</summary>
		/// <remarks>The second matrix element in the first row.</remarks>
		public double m01;

		/// <summary>The third matrix element in the first row.</summary>
		/// <remarks>The third matrix element in the first row.</remarks>
		public double m02;

		/// <summary>The first matrix element in the second row.</summary>
		/// <remarks>The first matrix element in the second row.</remarks>
		public double m10;

		/// <summary>The second matrix element in the second row.</summary>
		/// <remarks>The second matrix element in the second row.</remarks>
		public double m11;

		/// <summary>The third matrix element in the second row.</summary>
		/// <remarks>The third matrix element in the second row.</remarks>
		public double m12;

		/// <summary>The first matrix element in the third row.</summary>
		/// <remarks>The first matrix element in the third row.</remarks>
		public double m20;

		/// <summary>The second matrix element in the third row.</summary>
		/// <remarks>The second matrix element in the third row.</remarks>
		public double m21;

		/// <summary>The third matrix element in the third row.</summary>
		/// <remarks>The third matrix element in the third row.</remarks>
		public double m22;

		private const double Eps = 1.110223024E-16;

		private const double ErrEps = 1.0E-8;

		private static double xin;

		private static double yin;

		private static double zin;

		private static double xout;

		private static double yout;

		private static double zout;

		/// <summary>Constructs and initializes a Matrix3d from the specified nine values.</summary>
		/// <remarks>Constructs and initializes a Matrix3d from the specified nine values.</remarks>
		/// <param name="m00">the [0][0] element</param>
		/// <param name="m01">the [0][1] element</param>
		/// <param name="m02">the [0][2] element</param>
		/// <param name="m10">the [1][0] element</param>
		/// <param name="m11">the [1][1] element</param>
		/// <param name="m12">the [1][2] element</param>
		/// <param name="m20">the [2][0] element</param>
		/// <param name="m21">the [2][1] element</param>
		/// <param name="m22">the [2][2] element</param>
		public Matrix3d(double m00, double m01, double m02, double m10, double m11, double
			 m12, double m20, double m21, double m22)
		{
			// Compatible with 1.1
			//double[]    tmp = new double[9];  // scratch matrix
			//double[]    tmp_rot = new double[9];  // scratch matrix
			//double[]    tmp_scale = new double[3];  // scratch matrix
			this.m00 = m00;
			this.m01 = m01;
			this.m02 = m02;
			this.m10 = m10;
			this.m11 = m11;
			this.m12 = m12;
			this.m20 = m20;
			this.m21 = m21;
			this.m22 = m22;
		}

		/// <summary>
		/// Constructs and initializes a Matrix3d from the specified nine-
		/// element array.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a Matrix3d from the specified nine-
		/// element array.
		/// </remarks>
		/// <param name="v">the array of length 9 containing in order</param>
		public Matrix3d(double[] v)
		{
			this.m00 = v[0];
			this.m01 = v[1];
			this.m02 = v[2];
			this.m10 = v[3];
			this.m11 = v[4];
			this.m12 = v[5];
			this.m20 = v[6];
			this.m21 = v[7];
			this.m22 = v[8];
		}

		/// <summary>
		/// Constructs a new matrix with the same values as the
		/// Matrix3d parameter.
		/// </summary>
		/// <remarks>
		/// Constructs a new matrix with the same values as the
		/// Matrix3d parameter.
		/// </remarks>
		/// <param name="m1">the source matrix</param>
		public Matrix3d(Matrix3d m1)
		{
			this.m00 = m1.m00;
			this.m01 = m1.m01;
			this.m02 = m1.m02;
			this.m10 = m1.m10;
			this.m11 = m1.m11;
			this.m12 = m1.m12;
			this.m20 = m1.m20;
			this.m21 = m1.m21;
			this.m22 = m1.m22;
		}

		/// <summary>
		/// Constructs a new matrix with the same values as the
		/// Matrix3f parameter.
		/// </summary>
		/// <remarks>
		/// Constructs a new matrix with the same values as the
		/// Matrix3f parameter.
		/// </remarks>
		/// <param name="m1">the source matrix</param>
		public Matrix3d(Matrix3f m1)
		{
			this.m00 = m1.m00;
			this.m01 = m1.m01;
			this.m02 = m1.m02;
			this.m10 = m1.m10;
			this.m11 = m1.m11;
			this.m12 = m1.m12;
			this.m20 = m1.m20;
			this.m21 = m1.m21;
			this.m22 = m1.m22;
		}

		/// <summary>Constructs and initializes a Matrix3d to all zeros.</summary>
		/// <remarks>Constructs and initializes a Matrix3d to all zeros.</remarks>
		public Matrix3d()
		{
			this.m00 = 0.0;
			this.m01 = 0.0;
			this.m02 = 0.0;
			this.m10 = 0.0;
			this.m11 = 0.0;
			this.m12 = 0.0;
			this.m20 = 0.0;
			this.m21 = 0.0;
			this.m22 = 0.0;
		}

		/// <summary>Returns a string that contains the values of this Matrix3d.</summary>
		/// <remarks>Returns a string that contains the values of this Matrix3d.</remarks>
		/// <returns>the String representation</returns>
		public override string ToString()
		{
			return this.m00 + ", " + this.m01 + ", " + this.m02 + "\n" + this.m10 + ", " + this
				.m11 + ", " + this.m12 + "\n" + this.m20 + ", " + this.m21 + ", " + this.m22 + "\n";
		}

		/// <summary>Sets this Matrix3d to identity.</summary>
		/// <remarks>Sets this Matrix3d to identity.</remarks>
		public void SetIdentity()
		{
			this.m00 = 1.0;
			this.m01 = 0.0;
			this.m02 = 0.0;
			this.m10 = 0.0;
			this.m11 = 1.0;
			this.m12 = 0.0;
			this.m20 = 0.0;
			this.m21 = 0.0;
			this.m22 = 1.0;
		}

		/// <summary>
		/// Sets the scale component of the current matrix by factoring
		/// out the current scale (by doing an SVD) and multiplying by
		/// the new scale.
		/// </summary>
		/// <remarks>
		/// Sets the scale component of the current matrix by factoring
		/// out the current scale (by doing an SVD) and multiplying by
		/// the new scale.
		/// </remarks>
		/// <param name="scale">the new scale amount</param>
		public void SetScale(double scale)
		{
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			GetScaleRotate(tmp_scale, tmp_rot);
			this.m00 = tmp_rot[0] * scale;
			this.m01 = tmp_rot[1] * scale;
			this.m02 = tmp_rot[2] * scale;
			this.m10 = tmp_rot[3] * scale;
			this.m11 = tmp_rot[4] * scale;
			this.m12 = tmp_rot[5] * scale;
			this.m20 = tmp_rot[6] * scale;
			this.m21 = tmp_rot[7] * scale;
			this.m22 = tmp_rot[8] * scale;
		}

		/// <summary>Sets the specified element of this matrix3f to the value provided.</summary>
		/// <remarks>Sets the specified element of this matrix3f to the value provided.</remarks>
		/// <param name="row">the row number to be modified (zero indexed)</param>
		/// <param name="column">the column number to be modified (zero indexed)</param>
		/// <param name="value">the new value</param>
		public void SetElement(int row, int column, double value)
		{
			switch (row)
			{
				case 0:
				{
					switch (column)
					{
						case 0:
						{
							this.m00 = value;
							break;
						}

						case 1:
						{
							this.m01 = value;
							break;
						}

						case 2:
						{
							this.m02 = value;
							break;
						}

						default:
						{
							throw new IndexOutOfRangeException("Matrix3d setElement");
						}
					}
					break;
				}

				case 1:
				{
					switch (column)
					{
						case 0:
						{
							this.m10 = value;
							break;
						}

						case 1:
						{
							this.m11 = value;
							break;
						}

						case 2:
						{
							this.m12 = value;
							break;
						}

						default:
						{
							throw new IndexOutOfRangeException("Matrix3d setElement");
						}
					}
					break;
				}

				case 2:
				{
					switch (column)
					{
						case 0:
						{
							this.m20 = value;
							break;
						}

						case 1:
						{
							this.m21 = value;
							break;
						}

						case 2:
						{
							this.m22 = value;
							break;
						}

						default:
						{
							throw new IndexOutOfRangeException("Matrix3d setElement");
						}
					}
					break;
				}

				default:
				{
					throw new IndexOutOfRangeException("Matrix3d setElement");
				}
			}
		}

		/// <summary>
		/// Retrieves the value at the specified row and column of the specified
		/// matrix.
		/// </summary>
		/// <remarks>
		/// Retrieves the value at the specified row and column of the specified
		/// matrix.
		/// </remarks>
		/// <param name="row">the row number to be retrieved (zero indexed)</param>
		/// <param name="column">the column number to be retrieved (zero indexed)</param>
		/// <returns>the value at the indexed element.</returns>
		public double GetElement(int row, int column)
		{
			switch (row)
			{
				case 0:
				{
					switch (column)
					{
						case 0:
						{
							return (this.m00);
						}

						case 1:
						{
							return (this.m01);
						}

						case 2:
						{
							return (this.m02);
						}

						default:
						{
							break;
							break;
						}
					}
					break;
				}

				case 1:
				{
					switch (column)
					{
						case 0:
						{
							return (this.m10);
						}

						case 1:
						{
							return (this.m11);
						}

						case 2:
						{
							return (this.m12);
						}

						default:
						{
							break;
							break;
						}
					}
					break;
				}

				case 2:
				{
					switch (column)
					{
						case 0:
						{
							return (this.m20);
						}

						case 1:
						{
							return (this.m21);
						}

						case 2:
						{
							return (this.m22);
						}

						default:
						{
							break;
							break;
						}
					}
					break;
				}

				default:
				{
					break;
					break;
				}
			}
			throw new IndexOutOfRangeException("Matrix3d getElement");
		}

		/// <summary>Copies the matrix values in the specified row into the vector parameter.
		/// 	</summary>
		/// <remarks>Copies the matrix values in the specified row into the vector parameter.
		/// 	</remarks>
		/// <param name="row">the matrix row</param>
		/// <param name="v">the vector into which the matrix row values will be copied</param>
		public void GetRow(int row, Vector3d v)
		{
			if (row == 0)
			{
				v.x = m00;
				v.y = m01;
				v.z = m02;
			}
			else
			{
				if (row == 1)
				{
					v.x = m10;
					v.y = m11;
					v.z = m12;
				}
				else
				{
					if (row == 2)
					{
						v.x = m20;
						v.y = m21;
						v.z = m22;
					}
					else
					{
						throw new IndexOutOfRangeException("Matrix3d getRow");
					}
				}
			}
		}

		/// <summary>Copies the matrix values in the specified row into the array parameter.</summary>
		/// <remarks>Copies the matrix values in the specified row into the array parameter.</remarks>
		/// <param name="row">the matrix row</param>
		/// <param name="v">the array into which the matrix row values will be copied</param>
		public void GetRow(int row, double[] v)
		{
			if (row == 0)
			{
				v[0] = m00;
				v[1] = m01;
				v[2] = m02;
			}
			else
			{
				if (row == 1)
				{
					v[0] = m10;
					v[1] = m11;
					v[2] = m12;
				}
				else
				{
					if (row == 2)
					{
						v[0] = m20;
						v[1] = m21;
						v[2] = m22;
					}
					else
					{
						throw new IndexOutOfRangeException("Matrix3d getRow");
					}
				}
			}
		}

		/// <summary>
		/// Copies the matrix values in the specified column into the vector
		/// parameter.
		/// </summary>
		/// <remarks>
		/// Copies the matrix values in the specified column into the vector
		/// parameter.
		/// </remarks>
		/// <param name="column">the matrix column</param>
		/// <param name="v">the vector into which the matrix row values will be copied</param>
		public void GetColumn(int column, Vector3d v)
		{
			if (column == 0)
			{
				v.x = m00;
				v.y = m10;
				v.z = m20;
			}
			else
			{
				if (column == 1)
				{
					v.x = m01;
					v.y = m11;
					v.z = m21;
				}
				else
				{
					if (column == 2)
					{
						v.x = m02;
						v.y = m12;
						v.z = m22;
					}
					else
					{
						throw new IndexOutOfRangeException("Matrix3d getColumn");
					}
				}
			}
		}

		/// <summary>
		/// Copies the matrix values in the specified column into the array
		/// parameter.
		/// </summary>
		/// <remarks>
		/// Copies the matrix values in the specified column into the array
		/// parameter.
		/// </remarks>
		/// <param name="column">the matrix column</param>
		/// <param name="v">the array into which the matrix row values will be copied</param>
		public void GetColumn(int column, double[] v)
		{
			if (column == 0)
			{
				v[0] = m00;
				v[1] = m10;
				v[2] = m20;
			}
			else
			{
				if (column == 1)
				{
					v[0] = m01;
					v[1] = m11;
					v[2] = m21;
				}
				else
				{
					if (column == 2)
					{
						v[0] = m02;
						v[1] = m12;
						v[2] = m22;
					}
					else
					{
						throw new IndexOutOfRangeException("Matrix3d getColumn");
					}
				}
			}
		}

		/// <summary>Sets the specified row of this matrix3d to the 4 values provided.</summary>
		/// <remarks>Sets the specified row of this matrix3d to the 4 values provided.</remarks>
		/// <param name="row">the row number to be modified (zero indexed)</param>
		/// <param name="x">the first column element</param>
		/// <param name="y">the second column element</param>
		/// <param name="z">the third column element</param>
		public void SetRow(int row, double x, double y, double z)
		{
			switch (row)
			{
				case 0:
				{
					this.m00 = x;
					this.m01 = y;
					this.m02 = z;
					break;
				}

				case 1:
				{
					this.m10 = x;
					this.m11 = y;
					this.m12 = z;
					break;
				}

				case 2:
				{
					this.m20 = x;
					this.m21 = y;
					this.m22 = z;
					break;
				}

				default:
				{
					throw new IndexOutOfRangeException("Matrix3d setRow");
				}
			}
		}

		/// <summary>Sets the specified row of this matrix3d to the Vector provided.</summary>
		/// <remarks>Sets the specified row of this matrix3d to the Vector provided.</remarks>
		/// <param name="row">the row number to be modified (zero indexed)</param>
		/// <param name="v">the replacement row</param>
		public void SetRow(int row, Vector3d v)
		{
			switch (row)
			{
				case 0:
				{
					this.m00 = v.x;
					this.m01 = v.y;
					this.m02 = v.z;
					break;
				}

				case 1:
				{
					this.m10 = v.x;
					this.m11 = v.y;
					this.m12 = v.z;
					break;
				}

				case 2:
				{
					this.m20 = v.x;
					this.m21 = v.y;
					this.m22 = v.z;
					break;
				}

				default:
				{
					throw new IndexOutOfRangeException("Matrix3d setRow");
				}
			}
		}

		/// <summary>Sets the specified row of this matrix3d to the three values provided.</summary>
		/// <remarks>Sets the specified row of this matrix3d to the three values provided.</remarks>
		/// <param name="row">the row number to be modified (zero indexed)</param>
		/// <param name="v">the replacement row</param>
		public void SetRow(int row, double[] v)
		{
			switch (row)
			{
				case 0:
				{
					this.m00 = v[0];
					this.m01 = v[1];
					this.m02 = v[2];
					break;
				}

				case 1:
				{
					this.m10 = v[0];
					this.m11 = v[1];
					this.m12 = v[2];
					break;
				}

				case 2:
				{
					this.m20 = v[0];
					this.m21 = v[1];
					this.m22 = v[2];
					break;
				}

				default:
				{
					throw new IndexOutOfRangeException("Matrix3d setRow");
				}
			}
		}

		/// <summary>Sets the specified column of this matrix3d to the three values provided.
		/// 	</summary>
		/// <remarks>Sets the specified column of this matrix3d to the three values provided.
		/// 	</remarks>
		/// <param name="column">the column number to be modified (zero indexed)</param>
		/// <param name="x">the first row element</param>
		/// <param name="y">the second row element</param>
		/// <param name="z">the third row element</param>
		public void SetColumn(int column, double x, double y, double z)
		{
			switch (column)
			{
				case 0:
				{
					this.m00 = x;
					this.m10 = y;
					this.m20 = z;
					break;
				}

				case 1:
				{
					this.m01 = x;
					this.m11 = y;
					this.m21 = z;
					break;
				}

				case 2:
				{
					this.m02 = x;
					this.m12 = y;
					this.m22 = z;
					break;
				}

				default:
				{
					throw new IndexOutOfRangeException("Matrix3d setColumn");
				}
			}
		}

		/// <summary>Sets the specified column of this matrix3d to the vector provided.</summary>
		/// <remarks>Sets the specified column of this matrix3d to the vector provided.</remarks>
		/// <param name="column">the column number to be modified (zero indexed)</param>
		/// <param name="v">the replacement column</param>
		public void SetColumn(int column, Vector3d v)
		{
			switch (column)
			{
				case 0:
				{
					this.m00 = v.x;
					this.m10 = v.y;
					this.m20 = v.z;
					break;
				}

				case 1:
				{
					this.m01 = v.x;
					this.m11 = v.y;
					this.m21 = v.z;
					break;
				}

				case 2:
				{
					this.m02 = v.x;
					this.m12 = v.y;
					this.m22 = v.z;
					break;
				}

				default:
				{
					throw new IndexOutOfRangeException("Matrix3d setColumn");
				}
			}
		}

		/// <summary>Sets the specified column of this matrix3d to the three values provided.
		/// 	</summary>
		/// <remarks>Sets the specified column of this matrix3d to the three values provided.
		/// 	</remarks>
		/// <param name="column">the column number to be modified (zero indexed)</param>
		/// <param name="v">the replacement column</param>
		public void SetColumn(int column, double[] v)
		{
			switch (column)
			{
				case 0:
				{
					this.m00 = v[0];
					this.m10 = v[1];
					this.m20 = v[2];
					break;
				}

				case 1:
				{
					this.m01 = v[0];
					this.m11 = v[1];
					this.m21 = v[2];
					break;
				}

				case 2:
				{
					this.m02 = v[0];
					this.m12 = v[1];
					this.m22 = v[2];
					break;
				}

				default:
				{
					throw new IndexOutOfRangeException("Matrix3d setColumn");
				}
			}
		}

		/// <summary>
		/// Performs an SVD normalization of this matrix to calculate
		/// and return the uniform scale factor.
		/// </summary>
		/// <remarks>
		/// Performs an SVD normalization of this matrix to calculate
		/// and return the uniform scale factor. If the matrix has non-uniform
		/// scale factors, the largest of the x, y, and z scale factors will
		/// be returned. This matrix is not modified.
		/// </remarks>
		/// <returns>the scale factor of this matrix</returns>
		public double GetScale()
		{
			double[] tmp_scale = new double[3];
			// scratch matrix
			double[] tmp_rot = new double[9];
			// scratch matrix
			GetScaleRotate(tmp_scale, tmp_rot);
			return (Max3(tmp_scale));
		}

		/// <summary>Adds a scalar to each component of this matrix.</summary>
		/// <remarks>Adds a scalar to each component of this matrix.</remarks>
		/// <param name="scalar">the scalar adder</param>
		public void Add(double scalar)
		{
			m00 += scalar;
			m01 += scalar;
			m02 += scalar;
			m10 += scalar;
			m11 += scalar;
			m12 += scalar;
			m20 += scalar;
			m21 += scalar;
			m22 += scalar;
		}

		/// <summary>
		/// Adds a scalar to each component of the matrix m1 and places
		/// the result into this.
		/// </summary>
		/// <remarks>
		/// Adds a scalar to each component of the matrix m1 and places
		/// the result into this.  Matrix m1 is not modified.
		/// </remarks>
		/// <param name="scalar">the scalar adder</param>
		/// <param name="m1">the original matrix values</param>
		public void Add(double scalar, Matrix3d m1)
		{
			this.m00 = m1.m00 + scalar;
			this.m01 = m1.m01 + scalar;
			this.m02 = m1.m02 + scalar;
			this.m10 = m1.m10 + scalar;
			this.m11 = m1.m11 + scalar;
			this.m12 = m1.m12 + scalar;
			this.m20 = m1.m20 + scalar;
			this.m21 = m1.m21 + scalar;
			this.m22 = m1.m22 + scalar;
		}

		/// <summary>Sets the value of this matrix to the matrix sum of matrices m1 and m2.</summary>
		/// <remarks>Sets the value of this matrix to the matrix sum of matrices m1 and m2.</remarks>
		/// <param name="m1">the first matrix</param>
		/// <param name="m2">the second matrix</param>
		public void Add(Matrix3d m1, Matrix3d m2)
		{
			this.m00 = m1.m00 + m2.m00;
			this.m01 = m1.m01 + m2.m01;
			this.m02 = m1.m02 + m2.m02;
			this.m10 = m1.m10 + m2.m10;
			this.m11 = m1.m11 + m2.m11;
			this.m12 = m1.m12 + m2.m12;
			this.m20 = m1.m20 + m2.m20;
			this.m21 = m1.m21 + m2.m21;
			this.m22 = m1.m22 + m2.m22;
		}

		/// <summary>Sets the value of this matrix to the sum of itself and matrix m1.</summary>
		/// <remarks>Sets the value of this matrix to the sum of itself and matrix m1.</remarks>
		/// <param name="m1">the other matrix</param>
		public void Add(Matrix3d m1)
		{
			this.m00 += m1.m00;
			this.m01 += m1.m01;
			this.m02 += m1.m02;
			this.m10 += m1.m10;
			this.m11 += m1.m11;
			this.m12 += m1.m12;
			this.m20 += m1.m20;
			this.m21 += m1.m21;
			this.m22 += m1.m22;
		}

		/// <summary>
		/// Sets the value of this matrix to the matrix difference
		/// of matrices m1 and m2.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the matrix difference
		/// of matrices m1 and m2.
		/// </remarks>
		/// <param name="m1">the first matrix</param>
		/// <param name="m2">the second matrix</param>
		public void Sub(Matrix3d m1, Matrix3d m2)
		{
			this.m00 = m1.m00 - m2.m00;
			this.m01 = m1.m01 - m2.m01;
			this.m02 = m1.m02 - m2.m02;
			this.m10 = m1.m10 - m2.m10;
			this.m11 = m1.m11 - m2.m11;
			this.m12 = m1.m12 - m2.m12;
			this.m20 = m1.m20 - m2.m20;
			this.m21 = m1.m21 - m2.m21;
			this.m22 = m1.m22 - m2.m22;
		}

		/// <summary>
		/// Sets the value of this matrix to the matrix difference of itself and
		/// matrix m1 (this = this - m1).
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the matrix difference of itself and
		/// matrix m1 (this = this - m1).
		/// </remarks>
		/// <param name="m1">the other matrix</param>
		public void Sub(Matrix3d m1)
		{
			this.m00 -= m1.m00;
			this.m01 -= m1.m01;
			this.m02 -= m1.m02;
			this.m10 -= m1.m10;
			this.m11 -= m1.m11;
			this.m12 -= m1.m12;
			this.m20 -= m1.m20;
			this.m21 -= m1.m21;
			this.m22 -= m1.m22;
		}

		/// <summary>Sets the value of this matrix to its transpose.</summary>
		/// <remarks>Sets the value of this matrix to its transpose.</remarks>
		public void Transpose()
		{
			double temp;
			temp = this.m10;
			this.m10 = this.m01;
			this.m01 = temp;
			temp = this.m20;
			this.m20 = this.m02;
			this.m02 = temp;
			temp = this.m21;
			this.m21 = this.m12;
			this.m12 = temp;
		}

		/// <summary>Sets the value of this matrix to the transpose of the argument matrix.</summary>
		/// <remarks>Sets the value of this matrix to the transpose of the argument matrix.</remarks>
		/// <param name="m1">the matrix to be transposed</param>
		public void Transpose(Matrix3d m1)
		{
			if (this != m1)
			{
				this.m00 = m1.m00;
				this.m01 = m1.m10;
				this.m02 = m1.m20;
				this.m10 = m1.m01;
				this.m11 = m1.m11;
				this.m12 = m1.m21;
				this.m20 = m1.m02;
				this.m21 = m1.m12;
				this.m22 = m1.m22;
			}
			else
			{
				this.Transpose();
			}
		}

		/// <summary>
		/// Sets the value of this matrix to the matrix conversion of the
		/// double precision quaternion argument.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the matrix conversion of the
		/// double precision quaternion argument.
		/// </remarks>
		/// <param name="q1">the quaternion to be converted</param>
		public void Set(Quat4d q1)
		{
			this.m00 = (1.0 - 2.0 * q1.y * q1.y - 2.0 * q1.z * q1.z);
			this.m10 = (2.0 * (q1.x * q1.y + q1.w * q1.z));
			this.m20 = (2.0 * (q1.x * q1.z - q1.w * q1.y));
			this.m01 = (2.0 * (q1.x * q1.y - q1.w * q1.z));
			this.m11 = (1.0 - 2.0 * q1.x * q1.x - 2.0 * q1.z * q1.z);
			this.m21 = (2.0 * (q1.y * q1.z + q1.w * q1.x));
			this.m02 = (2.0 * (q1.x * q1.z + q1.w * q1.y));
			this.m12 = (2.0 * (q1.y * q1.z - q1.w * q1.x));
			this.m22 = (1.0 - 2.0 * q1.x * q1.x - 2.0 * q1.y * q1.y);
		}

		/// <summary>
		/// Sets the value of this matrix to the matrix conversion of the
		/// double precision axis and angle argument.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the matrix conversion of the
		/// double precision axis and angle argument.
		/// </remarks>
		/// <param name="a1">the axis and angle to be converted</param>
		public void Set(AxisAngle4d a1)
		{
			double mag = Math.Sqrt(a1.x * a1.x + a1.y * a1.y + a1.z * a1.z);
			if (mag < Eps)
			{
				m00 = 1.0;
				m01 = 0.0;
				m02 = 0.0;
				m10 = 0.0;
				m11 = 1.0;
				m12 = 0.0;
				m20 = 0.0;
				m21 = 0.0;
				m22 = 1.0;
			}
			else
			{
				mag = 1.0 / mag;
				double ax = a1.x * mag;
				double ay = a1.y * mag;
				double az = a1.z * mag;
				double sinTheta = Math.Sin(a1.angle);
				double cosTheta = Math.Cos(a1.angle);
				double t = 1.0 - cosTheta;
				double xz = ax * az;
				double xy = ax * ay;
				double yz = ay * az;
				m00 = t * ax * ax + cosTheta;
				m01 = t * xy - sinTheta * az;
				m02 = t * xz + sinTheta * ay;
				m10 = t * xy + sinTheta * az;
				m11 = t * ay * ay + cosTheta;
				m12 = t * yz - sinTheta * ax;
				m20 = t * xz - sinTheta * ay;
				m21 = t * yz + sinTheta * ax;
				m22 = t * az * az + cosTheta;
			}
		}

		/// <summary>
		/// Sets the value of this matrix to the matrix conversion of the
		/// single precision quaternion argument.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the matrix conversion of the
		/// single precision quaternion argument.
		/// </remarks>
		/// <param name="q1">the quaternion to be converted</param>
		public void Set(Quat4f q1)
		{
			this.m00 = (1.0 - 2.0 * q1.y * q1.y - 2.0 * q1.z * q1.z);
			this.m10 = (2.0 * (q1.x * q1.y + q1.w * q1.z));
			this.m20 = (2.0 * (q1.x * q1.z - q1.w * q1.y));
			this.m01 = (2.0 * (q1.x * q1.y - q1.w * q1.z));
			this.m11 = (1.0 - 2.0 * q1.x * q1.x - 2.0 * q1.z * q1.z);
			this.m21 = (2.0 * (q1.y * q1.z + q1.w * q1.x));
			this.m02 = (2.0 * (q1.x * q1.z + q1.w * q1.y));
			this.m12 = (2.0 * (q1.y * q1.z - q1.w * q1.x));
			this.m22 = (1.0 - 2.0 * q1.x * q1.x - 2.0 * q1.y * q1.y);
		}

		/// <summary>
		/// Sets the value of this matrix to the matrix conversion of the
		/// single precision axis and angle argument.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the matrix conversion of the
		/// single precision axis and angle argument.
		/// </remarks>
		/// <param name="a1">the axis and angle to be converted</param>
		public void Set(AxisAngle4f a1)
		{
			double mag = Math.Sqrt(a1.x * a1.x + a1.y * a1.y + a1.z * a1.z);
			if (mag < Eps)
			{
				m00 = 1.0;
				m01 = 0.0;
				m02 = 0.0;
				m10 = 0.0;
				m11 = 1.0;
				m12 = 0.0;
				m20 = 0.0;
				m21 = 0.0;
				m22 = 1.0;
			}
			else
			{
				mag = 1.0 / mag;
				double ax = a1.x * mag;
				double ay = a1.y * mag;
				double az = a1.z * mag;
				double sinTheta = Math.Sin(a1.angle);
				double cosTheta = Math.Cos(a1.angle);
				double t = 1.0 - cosTheta;
				double xz = ax * az;
				double xy = ax * ay;
				double yz = ay * az;
				m00 = t * ax * ax + cosTheta;
				m01 = t * xy - sinTheta * az;
				m02 = t * xz + sinTheta * ay;
				m10 = t * xy + sinTheta * az;
				m11 = t * ay * ay + cosTheta;
				m12 = t * yz - sinTheta * ax;
				m20 = t * xz - sinTheta * ay;
				m21 = t * yz + sinTheta * ax;
				m22 = t * az * az + cosTheta;
			}
		}

		/// <summary>
		/// Sets the value of this matrix to the double value of the Matrix3f
		/// argument.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the double value of the Matrix3f
		/// argument.
		/// </remarks>
		/// <param name="m1">the matrix3d to be converted to double</param>
		public void Set(Matrix3f m1)
		{
			this.m00 = m1.m00;
			this.m01 = m1.m01;
			this.m02 = m1.m02;
			this.m10 = m1.m10;
			this.m11 = m1.m11;
			this.m12 = m1.m12;
			this.m20 = m1.m20;
			this.m21 = m1.m21;
			this.m22 = m1.m22;
		}

		/// <summary>
		/// Sets the value of this matrix to the value of the Matrix3d
		/// argument.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the value of the Matrix3d
		/// argument.
		/// </remarks>
		/// <param name="m1">the source matrix3d</param>
		public void Set(Matrix3d m1)
		{
			this.m00 = m1.m00;
			this.m01 = m1.m01;
			this.m02 = m1.m02;
			this.m10 = m1.m10;
			this.m11 = m1.m11;
			this.m12 = m1.m12;
			this.m20 = m1.m20;
			this.m21 = m1.m21;
			this.m22 = m1.m22;
		}

		/// <summary>
		/// Sets the values in this Matrix3d equal to the row-major
		/// array parameter (ie, the first three elements of the
		/// array will be copied into the first row of this matrix, etc.).
		/// </summary>
		/// <remarks>
		/// Sets the values in this Matrix3d equal to the row-major
		/// array parameter (ie, the first three elements of the
		/// array will be copied into the first row of this matrix, etc.).
		/// </remarks>
		/// <param name="m">the double precision array of length 9</param>
		public void Set(double[] m)
		{
			m00 = m[0];
			m01 = m[1];
			m02 = m[2];
			m10 = m[3];
			m11 = m[4];
			m12 = m[5];
			m20 = m[6];
			m21 = m[7];
			m22 = m[8];
		}

		/// <summary>
		/// Sets the value of this matrix to the matrix inverse
		/// of the passed matrix m1.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the matrix inverse
		/// of the passed matrix m1.
		/// </remarks>
		/// <param name="m1">the matrix to be inverted</param>
		public void Invert(Matrix3d m1)
		{
			InvertGeneral(m1);
		}

		/// <summary>Inverts this matrix in place.</summary>
		/// <remarks>Inverts this matrix in place.</remarks>
		public void Invert()
		{
			InvertGeneral(this);
		}

		/// <summary>General invert routine.</summary>
		/// <remarks>
		/// General invert routine.  Inverts m1 and places the result in "this".
		/// Note that this routine handles both the "this" version and the
		/// non-"this" version.
		/// Also note that since this routine is slow anyway, we won't worry
		/// about allocating a little bit of garbage.
		/// </remarks>
		private void InvertGeneral(Matrix3d m1)
		{
			double[] result = new double[9];
			int[] row_perm = new int[3];
			int i;
			int r;
			int c;
			double[] tmp = new double[9];
			// scratch matrix
			// Use LU decomposition and backsubstitution code specifically
			// for floating-point 3x3 matrices.
			// Copy source matrix to t1tmp
			tmp[0] = m1.m00;
			tmp[1] = m1.m01;
			tmp[2] = m1.m02;
			tmp[3] = m1.m10;
			tmp[4] = m1.m11;
			tmp[5] = m1.m12;
			tmp[6] = m1.m20;
			tmp[7] = m1.m21;
			tmp[8] = m1.m22;
			// Calculate LU decomposition: Is the matrix singular?
			if (!LuDecomposition(tmp, row_perm))
			{
				// Matrix has no inverse
				throw new SingularMatrixException("cannot invert matrix");
			}
			// Perform back substitution on the identity matrix
			for (i = 0; i < 9; i++)
			{
				result[i] = 0.0;
			}
			result[0] = 1.0;
			result[4] = 1.0;
			result[8] = 1.0;
			LuBacksubstitution(tmp, row_perm, result);
			this.m00 = result[0];
			this.m01 = result[1];
			this.m02 = result[2];
			this.m10 = result[3];
			this.m11 = result[4];
			this.m12 = result[5];
			this.m20 = result[6];
			this.m21 = result[7];
			this.m22 = result[8];
		}

		/// <summary>
		/// Given a 3x3 array "matrix0", this function replaces it with the
		/// LU decomposition of a row-wise permutation of itself.
		/// </summary>
		/// <remarks>
		/// Given a 3x3 array "matrix0", this function replaces it with the
		/// LU decomposition of a row-wise permutation of itself.  The input
		/// parameters are "matrix0" and "dimen".  The array "matrix0" is also
		/// an output parameter.  The vector "row_perm[3]" is an output
		/// parameter that contains the row permutations resulting from partial
		/// pivoting.  The output parameter "even_row_xchg" is 1 when the
		/// number of row exchanges is even, or -1 otherwise.  Assumes data
		/// type is always double.
		/// This function is similar to luDecomposition, except that it
		/// is tuned specifically for 3x3 matrices.
		/// </remarks>
		/// <returns>true if the matrix is nonsingular, or false otherwise.</returns>
		internal static bool LuDecomposition(double[] matrix0, int[] row_perm)
		{
			//
			// Reference: Press, Flannery, Teukolsky, Vetterling,
			//	      _Numerical_Recipes_in_C_, Cambridge University Press,
			//	      1988, pp 40-45.
			//
			double[] row_scale = new double[3];
			{
				// Determine implicit scaling information by looping over rows
				int i;
				int j;
				int ptr;
				int rs;
				double big;
				double temp;
				ptr = 0;
				rs = 0;
				// For each row ...
				i = 3;
				while (i-- != 0)
				{
					big = 0.0;
					// For each column, find the largest element in the row
					j = 3;
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
			}
			{
				int j;
				int mtx;
				mtx = 0;
				// For all columns, execute Crout's method
				for (j = 0; j < 3; j++)
				{
					int i;
					int imax;
					int k;
					int target;
					int p1;
					int p2;
					double sum;
					double big;
					double temp;
					// Determine elements of upper diagonal matrix U
					for (i = 0; i < j; i++)
					{
						target = mtx + (3 * i) + j;
						sum = matrix0[target];
						k = i;
						p1 = mtx + (3 * i);
						p2 = mtx + j;
						while (k-- != 0)
						{
							sum -= matrix0[p1] * matrix0[p2];
							p1++;
							p2 += 3;
						}
						matrix0[target] = sum;
					}
					// Search for largest pivot element and calculate
					// intermediate elements of lower diagonal matrix L.
					big = 0.0;
					imax = -1;
					for (i = j; i < 3; i++)
					{
						target = mtx + (3 * i) + j;
						sum = matrix0[target];
						k = j;
						p1 = mtx + (3 * i);
						p2 = mtx + j;
						while (k-- != 0)
						{
							sum -= matrix0[p1] * matrix0[p2];
							p1++;
							p2 += 3;
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
						k = 3;
						p1 = mtx + (3 * imax);
						p2 = mtx + (3 * j);
						while (k-- != 0)
						{
							temp = matrix0[p1];
							matrix0[p1++] = matrix0[p2];
							matrix0[p2++] = temp;
						}
						// Record change in scale factor
						row_scale[imax] = row_scale[j];
					}
					// Record row permutation
					row_perm[j] = imax;
					// Is the matrix singular
					if (matrix0[(mtx + (3 * j) + j)] == 0.0)
					{
						return false;
					}
					// Divide elements of lower diagonal matrix L by pivot
					if (j != (3 - 1))
					{
						temp = 1.0 / (matrix0[(mtx + (3 * j) + j)]);
						target = mtx + (3 * (j + 1)) + j;
						i = 2 - j;
						while (i-- != 0)
						{
							matrix0[target] *= temp;
							target += 3;
						}
					}
				}
			}
			return true;
		}

		/// <summary>Solves a set of linear equations.</summary>
		/// <remarks>
		/// Solves a set of linear equations.  The input parameters "matrix1",
		/// and "row_perm" come from luDecompostionD3x3 and do not change
		/// here.  The parameter "matrix2" is a set of column vectors assembled
		/// into a 3x3 matrix of floating-point values.  The procedure takes each
		/// column of "matrix2" in turn and treats it as the right-hand side of the
		/// matrix equation Ax = LUx = b.  The solution vector replaces the
		/// original column of the matrix.
		/// If "matrix2" is the identity matrix, the procedure replaces its contents
		/// with the inverse of the matrix from which "matrix1" was originally
		/// derived.
		/// </remarks>
		internal static void LuBacksubstitution(double[] matrix1, int[] row_perm, double[]
			 matrix2)
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
			//	rp = row_perm;
			rp = 0;
			// For each column vector of matrix2 ...
			for (k = 0; k < 3; k++)
			{
				//	    cv = &(matrix2[0][k]);
				cv = k;
				ii = -1;
				// Forward substitution
				for (i = 0; i < 3; i++)
				{
					double sum;
					ip = row_perm[rp + i];
					sum = matrix2[cv + 3 * ip];
					matrix2[cv + 3 * ip] = matrix2[cv + 3 * i];
					if (ii >= 0)
					{
						//		    rv = &(matrix1[i][0]);
						rv = i * 3;
						for (j = ii; j <= i - 1; j++)
						{
							sum -= matrix1[rv + j] * matrix2[cv + 3 * j];
						}
					}
					else
					{
						if (sum != 0.0)
						{
							ii = i;
						}
					}
					matrix2[cv + 3 * i] = sum;
				}
				// Backsubstitution
				//	    rv = &(matrix1[3][0]);
				rv = 2 * 3;
				matrix2[cv + 3 * 2] /= matrix1[rv + 2];
				rv -= 3;
				matrix2[cv + 3 * 1] = (matrix2[cv + 3 * 1] - matrix1[rv + 2] * matrix2[cv + 3 * 2
					]) / matrix1[rv + 1];
				rv -= 3;
				matrix2[cv + 4 * 0] = (matrix2[cv + 3 * 0] - matrix1[rv + 1] * matrix2[cv + 3 * 1
					] - matrix1[rv + 2] * matrix2[cv + 3 * 2]) / matrix1[rv + 0];
			}
		}

		/// <summary>Computes the determinant of this matrix.</summary>
		/// <remarks>Computes the determinant of this matrix.</remarks>
		/// <returns>the determinant of the matrix</returns>
		public double Determinant()
		{
			double total;
			total = this.m00 * (this.m11 * this.m22 - this.m12 * this.m21) + this.m01 * (this
				.m12 * this.m20 - this.m10 * this.m22) + this.m02 * (this.m10 * this.m21 - this.
				m11 * this.m20);
			return total;
		}

		/// <summary>
		/// Sets the value of this matrix to a scale matrix with
		/// the passed scale amount.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to a scale matrix with
		/// the passed scale amount.
		/// </remarks>
		/// <param name="scale">the scale factor for the matrix</param>
		public void Set(double scale)
		{
			this.m00 = scale;
			this.m01 = 0.0;
			this.m02 = 0.0;
			this.m10 = 0.0;
			this.m11 = scale;
			this.m12 = 0.0;
			this.m20 = 0.0;
			this.m21 = 0.0;
			this.m22 = scale;
		}

		/// <summary>
		/// Sets the value of this matrix to a counter clockwise rotation
		/// about the x axis.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to a counter clockwise rotation
		/// about the x axis.
		/// </remarks>
		/// <param name="angle">the angle to rotate about the X axis in radians</param>
		public void RotX(double angle)
		{
			double sinAngle;
			double cosAngle;
			sinAngle = Math.Sin(angle);
			cosAngle = Math.Cos(angle);
			this.m00 = 1.0;
			this.m01 = 0.0;
			this.m02 = 0.0;
			this.m10 = 0.0;
			this.m11 = cosAngle;
			this.m12 = -sinAngle;
			this.m20 = 0.0;
			this.m21 = sinAngle;
			this.m22 = cosAngle;
		}

		/// <summary>
		/// Sets the value of this matrix to a counter clockwise rotation
		/// about the y axis.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to a counter clockwise rotation
		/// about the y axis.
		/// </remarks>
		/// <param name="angle">the angle to rotate about the Y axis in radians</param>
		public void RotY(double angle)
		{
			double sinAngle;
			double cosAngle;
			sinAngle = Math.Sin(angle);
			cosAngle = Math.Cos(angle);
			this.m00 = cosAngle;
			this.m01 = 0.0;
			this.m02 = sinAngle;
			this.m10 = 0.0;
			this.m11 = 1.0;
			this.m12 = 0.0;
			this.m20 = -sinAngle;
			this.m21 = 0.0;
			this.m22 = cosAngle;
		}

		/// <summary>
		/// Sets the value of this matrix to a counter clockwise rotation
		/// about the z axis.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to a counter clockwise rotation
		/// about the z axis.
		/// </remarks>
		/// <param name="angle">the angle to rotate about the Z axis in radians</param>
		public void RotZ(double angle)
		{
			double sinAngle;
			double cosAngle;
			sinAngle = Math.Sin(angle);
			cosAngle = Math.Cos(angle);
			this.m00 = cosAngle;
			this.m01 = -sinAngle;
			this.m02 = 0.0;
			this.m10 = sinAngle;
			this.m11 = cosAngle;
			this.m12 = 0.0;
			this.m20 = 0.0;
			this.m21 = 0.0;
			this.m22 = 1.0;
		}

		/// <summary>Multiplies each element of this matrix by a scalar.</summary>
		/// <remarks>Multiplies each element of this matrix by a scalar.</remarks>
		/// <param name="scalar">The scalar multiplier.</param>
		public void Mul(double scalar)
		{
			m00 *= scalar;
			m01 *= scalar;
			m02 *= scalar;
			m10 *= scalar;
			m11 *= scalar;
			m12 *= scalar;
			m20 *= scalar;
			m21 *= scalar;
			m22 *= scalar;
		}

		/// <summary>
		/// Multiplies each element of matrix m1 by a scalar and places
		/// the result into this.
		/// </summary>
		/// <remarks>
		/// Multiplies each element of matrix m1 by a scalar and places
		/// the result into this.  Matrix m1 is not modified.
		/// </remarks>
		/// <param name="scalar">the scalar multiplier</param>
		/// <param name="m1">the original matrix</param>
		public void Mul(double scalar, Matrix3d m1)
		{
			this.m00 = scalar * m1.m00;
			this.m01 = scalar * m1.m01;
			this.m02 = scalar * m1.m02;
			this.m10 = scalar * m1.m10;
			this.m11 = scalar * m1.m11;
			this.m12 = scalar * m1.m12;
			this.m20 = scalar * m1.m20;
			this.m21 = scalar * m1.m21;
			this.m22 = scalar * m1.m22;
		}

		/// <summary>
		/// Sets the value of this matrix to the result of multiplying itself
		/// with matrix m1.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the result of multiplying itself
		/// with matrix m1.
		/// </remarks>
		/// <param name="m1">the other matrix</param>
		public void Mul(Matrix3d m1)
		{
			double m00;
			double m01;
			double m02;
			double m10;
			double m11;
			double m12;
			double m20;
			double m21;
			double m22;
			m00 = this.m00 * m1.m00 + this.m01 * m1.m10 + this.m02 * m1.m20;
			m01 = this.m00 * m1.m01 + this.m01 * m1.m11 + this.m02 * m1.m21;
			m02 = this.m00 * m1.m02 + this.m01 * m1.m12 + this.m02 * m1.m22;
			m10 = this.m10 * m1.m00 + this.m11 * m1.m10 + this.m12 * m1.m20;
			m11 = this.m10 * m1.m01 + this.m11 * m1.m11 + this.m12 * m1.m21;
			m12 = this.m10 * m1.m02 + this.m11 * m1.m12 + this.m12 * m1.m22;
			m20 = this.m20 * m1.m00 + this.m21 * m1.m10 + this.m22 * m1.m20;
			m21 = this.m20 * m1.m01 + this.m21 * m1.m11 + this.m22 * m1.m21;
			m22 = this.m20 * m1.m02 + this.m21 * m1.m12 + this.m22 * m1.m22;
			this.m00 = m00;
			this.m01 = m01;
			this.m02 = m02;
			this.m10 = m10;
			this.m11 = m11;
			this.m12 = m12;
			this.m20 = m20;
			this.m21 = m21;
			this.m22 = m22;
		}

		/// <summary>
		/// Sets the value of this matrix to the result of multiplying
		/// the two argument matrices together.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the result of multiplying
		/// the two argument matrices together.
		/// </remarks>
		/// <param name="m1">the first matrix</param>
		/// <param name="m2">the second matrix</param>
		public void Mul(Matrix3d m1, Matrix3d m2)
		{
			if (this != m1 && this != m2)
			{
				this.m00 = m1.m00 * m2.m00 + m1.m01 * m2.m10 + m1.m02 * m2.m20;
				this.m01 = m1.m00 * m2.m01 + m1.m01 * m2.m11 + m1.m02 * m2.m21;
				this.m02 = m1.m00 * m2.m02 + m1.m01 * m2.m12 + m1.m02 * m2.m22;
				this.m10 = m1.m10 * m2.m00 + m1.m11 * m2.m10 + m1.m12 * m2.m20;
				this.m11 = m1.m10 * m2.m01 + m1.m11 * m2.m11 + m1.m12 * m2.m21;
				this.m12 = m1.m10 * m2.m02 + m1.m11 * m2.m12 + m1.m12 * m2.m22;
				this.m20 = m1.m20 * m2.m00 + m1.m21 * m2.m10 + m1.m22 * m2.m20;
				this.m21 = m1.m20 * m2.m01 + m1.m21 * m2.m11 + m1.m22 * m2.m21;
				this.m22 = m1.m20 * m2.m02 + m1.m21 * m2.m12 + m1.m22 * m2.m22;
			}
			else
			{
				double m00;
				double m01;
				double m02;
				double m10;
				double m11;
				double m12;
				double m20;
				double m21;
				double m22;
				// vars for temp result matrix
				m00 = m1.m00 * m2.m00 + m1.m01 * m2.m10 + m1.m02 * m2.m20;
				m01 = m1.m00 * m2.m01 + m1.m01 * m2.m11 + m1.m02 * m2.m21;
				m02 = m1.m00 * m2.m02 + m1.m01 * m2.m12 + m1.m02 * m2.m22;
				m10 = m1.m10 * m2.m00 + m1.m11 * m2.m10 + m1.m12 * m2.m20;
				m11 = m1.m10 * m2.m01 + m1.m11 * m2.m11 + m1.m12 * m2.m21;
				m12 = m1.m10 * m2.m02 + m1.m11 * m2.m12 + m1.m12 * m2.m22;
				m20 = m1.m20 * m2.m00 + m1.m21 * m2.m10 + m1.m22 * m2.m20;
				m21 = m1.m20 * m2.m01 + m1.m21 * m2.m11 + m1.m22 * m2.m21;
				m22 = m1.m20 * m2.m02 + m1.m21 * m2.m12 + m1.m22 * m2.m22;
				this.m00 = m00;
				this.m01 = m01;
				this.m02 = m02;
				this.m10 = m10;
				this.m11 = m11;
				this.m12 = m12;
				this.m20 = m20;
				this.m21 = m21;
				this.m22 = m22;
			}
		}

		/// <summary>
		/// Multiplies this matrix by matrix m1, does an SVD normalization
		/// of the result, and places the result back into this matrix
		/// this = SVDnorm(this*m1).
		/// </summary>
		/// <remarks>
		/// Multiplies this matrix by matrix m1, does an SVD normalization
		/// of the result, and places the result back into this matrix
		/// this = SVDnorm(this*m1).
		/// </remarks>
		/// <param name="m1">the matrix on the right hand side of the multiplication</param>
		public void MulNormalize(Matrix3d m1)
		{
			double[] tmp = new double[9];
			// scratch matrix
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			tmp[0] = this.m00 * m1.m00 + this.m01 * m1.m10 + this.m02 * m1.m20;
			tmp[1] = this.m00 * m1.m01 + this.m01 * m1.m11 + this.m02 * m1.m21;
			tmp[2] = this.m00 * m1.m02 + this.m01 * m1.m12 + this.m02 * m1.m22;
			tmp[3] = this.m10 * m1.m00 + this.m11 * m1.m10 + this.m12 * m1.m20;
			tmp[4] = this.m10 * m1.m01 + this.m11 * m1.m11 + this.m12 * m1.m21;
			tmp[5] = this.m10 * m1.m02 + this.m11 * m1.m12 + this.m12 * m1.m22;
			tmp[6] = this.m20 * m1.m00 + this.m21 * m1.m10 + this.m22 * m1.m20;
			tmp[7] = this.m20 * m1.m01 + this.m21 * m1.m11 + this.m22 * m1.m21;
			tmp[8] = this.m20 * m1.m02 + this.m21 * m1.m12 + this.m22 * m1.m22;
			Compute_svd(tmp, tmp_scale, tmp_rot);
			this.m00 = tmp_rot[0];
			this.m01 = tmp_rot[1];
			this.m02 = tmp_rot[2];
			this.m10 = tmp_rot[3];
			this.m11 = tmp_rot[4];
			this.m12 = tmp_rot[5];
			this.m20 = tmp_rot[6];
			this.m21 = tmp_rot[7];
			this.m22 = tmp_rot[8];
		}

		/// <summary>
		/// Multiplies matrix m1 by matrix m2, does an SVD normalization
		/// of the result, and places the result into this matrix
		/// this = SVDnorm(m1*m2).
		/// </summary>
		/// <remarks>
		/// Multiplies matrix m1 by matrix m2, does an SVD normalization
		/// of the result, and places the result into this matrix
		/// this = SVDnorm(m1*m2).
		/// </remarks>
		/// <param name="m1">the matrix on the left hand side of the multiplication</param>
		/// <param name="m2">the matrix on the right hand side of the multiplication</param>
		public void MulNormalize(Matrix3d m1, Matrix3d m2)
		{
			double[] tmp = new double[9];
			// scratch matrix
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			tmp[0] = m1.m00 * m2.m00 + m1.m01 * m2.m10 + m1.m02 * m2.m20;
			tmp[1] = m1.m00 * m2.m01 + m1.m01 * m2.m11 + m1.m02 * m2.m21;
			tmp[2] = m1.m00 * m2.m02 + m1.m01 * m2.m12 + m1.m02 * m2.m22;
			tmp[3] = m1.m10 * m2.m00 + m1.m11 * m2.m10 + m1.m12 * m2.m20;
			tmp[4] = m1.m10 * m2.m01 + m1.m11 * m2.m11 + m1.m12 * m2.m21;
			tmp[5] = m1.m10 * m2.m02 + m1.m11 * m2.m12 + m1.m12 * m2.m22;
			tmp[6] = m1.m20 * m2.m00 + m1.m21 * m2.m10 + m1.m22 * m2.m20;
			tmp[7] = m1.m20 * m2.m01 + m1.m21 * m2.m11 + m1.m22 * m2.m21;
			tmp[8] = m1.m20 * m2.m02 + m1.m21 * m2.m12 + m1.m22 * m2.m22;
			Compute_svd(tmp, tmp_scale, tmp_rot);
			this.m00 = tmp_rot[0];
			this.m01 = tmp_rot[1];
			this.m02 = tmp_rot[2];
			this.m10 = tmp_rot[3];
			this.m11 = tmp_rot[4];
			this.m12 = tmp_rot[5];
			this.m20 = tmp_rot[6];
			this.m21 = tmp_rot[7];
			this.m22 = tmp_rot[8];
		}

		/// <summary>
		/// Multiplies the transpose of matrix m1 times the transpose of matrix
		/// m2, and places the result into this.
		/// </summary>
		/// <remarks>
		/// Multiplies the transpose of matrix m1 times the transpose of matrix
		/// m2, and places the result into this.
		/// </remarks>
		/// <param name="m1">the matrix on the left hand side of the multiplication</param>
		/// <param name="m2">the matrix on the right hand side of the multiplication</param>
		public void MulTransposeBoth(Matrix3d m1, Matrix3d m2)
		{
			if (this != m1 && this != m2)
			{
				this.m00 = m1.m00 * m2.m00 + m1.m10 * m2.m01 + m1.m20 * m2.m02;
				this.m01 = m1.m00 * m2.m10 + m1.m10 * m2.m11 + m1.m20 * m2.m12;
				this.m02 = m1.m00 * m2.m20 + m1.m10 * m2.m21 + m1.m20 * m2.m22;
				this.m10 = m1.m01 * m2.m00 + m1.m11 * m2.m01 + m1.m21 * m2.m02;
				this.m11 = m1.m01 * m2.m10 + m1.m11 * m2.m11 + m1.m21 * m2.m12;
				this.m12 = m1.m01 * m2.m20 + m1.m11 * m2.m21 + m1.m21 * m2.m22;
				this.m20 = m1.m02 * m2.m00 + m1.m12 * m2.m01 + m1.m22 * m2.m02;
				this.m21 = m1.m02 * m2.m10 + m1.m12 * m2.m11 + m1.m22 * m2.m12;
				this.m22 = m1.m02 * m2.m20 + m1.m12 * m2.m21 + m1.m22 * m2.m22;
			}
			else
			{
				double m00;
				double m01;
				double m02;
				double m10;
				double m11;
				double m12;
				double m20;
				double m21;
				double m22;
				// vars for temp result matrix
				m00 = m1.m00 * m2.m00 + m1.m10 * m2.m01 + m1.m20 * m2.m02;
				m01 = m1.m00 * m2.m10 + m1.m10 * m2.m11 + m1.m20 * m2.m12;
				m02 = m1.m00 * m2.m20 + m1.m10 * m2.m21 + m1.m20 * m2.m22;
				m10 = m1.m01 * m2.m00 + m1.m11 * m2.m01 + m1.m21 * m2.m02;
				m11 = m1.m01 * m2.m10 + m1.m11 * m2.m11 + m1.m21 * m2.m12;
				m12 = m1.m01 * m2.m20 + m1.m11 * m2.m21 + m1.m21 * m2.m22;
				m20 = m1.m02 * m2.m00 + m1.m12 * m2.m01 + m1.m22 * m2.m02;
				m21 = m1.m02 * m2.m10 + m1.m12 * m2.m11 + m1.m22 * m2.m12;
				m22 = m1.m02 * m2.m20 + m1.m12 * m2.m21 + m1.m22 * m2.m22;
				this.m00 = m00;
				this.m01 = m01;
				this.m02 = m02;
				this.m10 = m10;
				this.m11 = m11;
				this.m12 = m12;
				this.m20 = m20;
				this.m21 = m21;
				this.m22 = m22;
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
		/// <param name="m1">the matrix on the left hand side of the multiplication</param>
		/// <param name="m2">the matrix on the right hand side of the multiplication</param>
		public void MulTransposeRight(Matrix3d m1, Matrix3d m2)
		{
			if (this != m1 && this != m2)
			{
				this.m00 = m1.m00 * m2.m00 + m1.m01 * m2.m01 + m1.m02 * m2.m02;
				this.m01 = m1.m00 * m2.m10 + m1.m01 * m2.m11 + m1.m02 * m2.m12;
				this.m02 = m1.m00 * m2.m20 + m1.m01 * m2.m21 + m1.m02 * m2.m22;
				this.m10 = m1.m10 * m2.m00 + m1.m11 * m2.m01 + m1.m12 * m2.m02;
				this.m11 = m1.m10 * m2.m10 + m1.m11 * m2.m11 + m1.m12 * m2.m12;
				this.m12 = m1.m10 * m2.m20 + m1.m11 * m2.m21 + m1.m12 * m2.m22;
				this.m20 = m1.m20 * m2.m00 + m1.m21 * m2.m01 + m1.m22 * m2.m02;
				this.m21 = m1.m20 * m2.m10 + m1.m21 * m2.m11 + m1.m22 * m2.m12;
				this.m22 = m1.m20 * m2.m20 + m1.m21 * m2.m21 + m1.m22 * m2.m22;
			}
			else
			{
				double m00;
				double m01;
				double m02;
				double m10;
				double m11;
				double m12;
				double m20;
				double m21;
				double m22;
				// vars for temp result matrix
				m00 = m1.m00 * m2.m00 + m1.m01 * m2.m01 + m1.m02 * m2.m02;
				m01 = m1.m00 * m2.m10 + m1.m01 * m2.m11 + m1.m02 * m2.m12;
				m02 = m1.m00 * m2.m20 + m1.m01 * m2.m21 + m1.m02 * m2.m22;
				m10 = m1.m10 * m2.m00 + m1.m11 * m2.m01 + m1.m12 * m2.m02;
				m11 = m1.m10 * m2.m10 + m1.m11 * m2.m11 + m1.m12 * m2.m12;
				m12 = m1.m10 * m2.m20 + m1.m11 * m2.m21 + m1.m12 * m2.m22;
				m20 = m1.m20 * m2.m00 + m1.m21 * m2.m01 + m1.m22 * m2.m02;
				m21 = m1.m20 * m2.m10 + m1.m21 * m2.m11 + m1.m22 * m2.m12;
				m22 = m1.m20 * m2.m20 + m1.m21 * m2.m21 + m1.m22 * m2.m22;
				this.m00 = m00;
				this.m01 = m01;
				this.m02 = m02;
				this.m10 = m10;
				this.m11 = m11;
				this.m12 = m12;
				this.m20 = m20;
				this.m21 = m21;
				this.m22 = m22;
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
		/// <param name="m1">the matrix on the left hand side of the multiplication</param>
		/// <param name="m2">the matrix on the right hand side of the multiplication</param>
		public void MulTransposeLeft(Matrix3d m1, Matrix3d m2)
		{
			if (this != m1 && this != m2)
			{
				this.m00 = m1.m00 * m2.m00 + m1.m10 * m2.m10 + m1.m20 * m2.m20;
				this.m01 = m1.m00 * m2.m01 + m1.m10 * m2.m11 + m1.m20 * m2.m21;
				this.m02 = m1.m00 * m2.m02 + m1.m10 * m2.m12 + m1.m20 * m2.m22;
				this.m10 = m1.m01 * m2.m00 + m1.m11 * m2.m10 + m1.m21 * m2.m20;
				this.m11 = m1.m01 * m2.m01 + m1.m11 * m2.m11 + m1.m21 * m2.m21;
				this.m12 = m1.m01 * m2.m02 + m1.m11 * m2.m12 + m1.m21 * m2.m22;
				this.m20 = m1.m02 * m2.m00 + m1.m12 * m2.m10 + m1.m22 * m2.m20;
				this.m21 = m1.m02 * m2.m01 + m1.m12 * m2.m11 + m1.m22 * m2.m21;
				this.m22 = m1.m02 * m2.m02 + m1.m12 * m2.m12 + m1.m22 * m2.m22;
			}
			else
			{
				double m00;
				double m01;
				double m02;
				double m10;
				double m11;
				double m12;
				double m20;
				double m21;
				double m22;
				// vars for temp result matrix
				m00 = m1.m00 * m2.m00 + m1.m10 * m2.m10 + m1.m20 * m2.m20;
				m01 = m1.m00 * m2.m01 + m1.m10 * m2.m11 + m1.m20 * m2.m21;
				m02 = m1.m00 * m2.m02 + m1.m10 * m2.m12 + m1.m20 * m2.m22;
				m10 = m1.m01 * m2.m00 + m1.m11 * m2.m10 + m1.m21 * m2.m20;
				m11 = m1.m01 * m2.m01 + m1.m11 * m2.m11 + m1.m21 * m2.m21;
				m12 = m1.m01 * m2.m02 + m1.m11 * m2.m12 + m1.m21 * m2.m22;
				m20 = m1.m02 * m2.m00 + m1.m12 * m2.m10 + m1.m22 * m2.m20;
				m21 = m1.m02 * m2.m01 + m1.m12 * m2.m11 + m1.m22 * m2.m21;
				m22 = m1.m02 * m2.m02 + m1.m12 * m2.m12 + m1.m22 * m2.m22;
				this.m00 = m00;
				this.m01 = m01;
				this.m02 = m02;
				this.m10 = m10;
				this.m11 = m11;
				this.m12 = m12;
				this.m20 = m20;
				this.m21 = m21;
				this.m22 = m22;
			}
		}

		/// <summary>Performs singular value decomposition normalization of this matrix.</summary>
		/// <remarks>Performs singular value decomposition normalization of this matrix.</remarks>
		public void Normalize()
		{
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			GetScaleRotate(tmp_scale, tmp_rot);
			this.m00 = tmp_rot[0];
			this.m01 = tmp_rot[1];
			this.m02 = tmp_rot[2];
			this.m10 = tmp_rot[3];
			this.m11 = tmp_rot[4];
			this.m12 = tmp_rot[5];
			this.m20 = tmp_rot[6];
			this.m21 = tmp_rot[7];
			this.m22 = tmp_rot[8];
		}

		/// <summary>
		/// Perform singular value decomposition normalization of matrix m1 and
		/// place the normalized values into this.
		/// </summary>
		/// <remarks>
		/// Perform singular value decomposition normalization of matrix m1 and
		/// place the normalized values into this.
		/// </remarks>
		/// <param name="m1">Provides the matrix values to be normalized</param>
		public void Normalize(Matrix3d m1)
		{
			double[] tmp = new double[9];
			// scratch matrix
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			tmp[0] = m1.m00;
			tmp[1] = m1.m01;
			tmp[2] = m1.m02;
			tmp[3] = m1.m10;
			tmp[4] = m1.m11;
			tmp[5] = m1.m12;
			tmp[6] = m1.m20;
			tmp[7] = m1.m21;
			tmp[8] = m1.m22;
			Compute_svd(tmp, tmp_scale, tmp_rot);
			this.m00 = tmp_rot[0];
			this.m01 = tmp_rot[1];
			this.m02 = tmp_rot[2];
			this.m10 = tmp_rot[3];
			this.m11 = tmp_rot[4];
			this.m12 = tmp_rot[5];
			this.m20 = tmp_rot[6];
			this.m21 = tmp_rot[7];
			this.m22 = tmp_rot[8];
		}

		/// <summary>Perform cross product normalization of this matrix.</summary>
		/// <remarks>Perform cross product normalization of this matrix.</remarks>
		public void NormalizeCP()
		{
			double mag = 1.0 / Math.Sqrt(m00 * m00 + m10 * m10 + m20 * m20);
			m00 = m00 * mag;
			m10 = m10 * mag;
			m20 = m20 * mag;
			mag = 1.0 / Math.Sqrt(m01 * m01 + m11 * m11 + m21 * m21);
			m01 = m01 * mag;
			m11 = m11 * mag;
			m21 = m21 * mag;
			m02 = m10 * m21 - m11 * m20;
			m12 = m01 * m20 - m00 * m21;
			m22 = m00 * m11 - m01 * m10;
		}

		/// <summary>
		/// Perform cross product normalization of matrix m1 and place the
		/// normalized values into this.
		/// </summary>
		/// <remarks>
		/// Perform cross product normalization of matrix m1 and place the
		/// normalized values into this.
		/// </remarks>
		/// <param name="m1">Provides the matrix values to be normalized</param>
		public void NormalizeCP(Matrix3d m1)
		{
			double mag = 1.0 / Math.Sqrt(m1.m00 * m1.m00 + m1.m10 * m1.m10 + m1.m20 * m1.m20);
			m00 = m1.m00 * mag;
			m10 = m1.m10 * mag;
			m20 = m1.m20 * mag;
			mag = 1.0 / Math.Sqrt(m1.m01 * m1.m01 + m1.m11 * m1.m11 + m1.m21 * m1.m21);
			m01 = m1.m01 * mag;
			m11 = m1.m11 * mag;
			m21 = m1.m21 * mag;
			m02 = m10 * m21 - m11 * m20;
			m12 = m01 * m20 - m00 * m21;
			m22 = m00 * m11 - m01 * m10;
		}

		/// <summary>
		/// Returns true if all of the data members of Matrix3d m1 are
		/// equal to the corresponding data members in this Matrix3d.
		/// </summary>
		/// <remarks>
		/// Returns true if all of the data members of Matrix3d m1 are
		/// equal to the corresponding data members in this Matrix3d.
		/// </remarks>
		/// <param name="m1">the matrix with which the comparison is made</param>
		/// <returns>true or false</returns>
		public virtual bool Equals(Matrix3d m1)
		{
			try
			{
				return (this.m00 == m1.m00 && this.m01 == m1.m01 && this.m02 == m1.m02 && this.m10
					 == m1.m10 && this.m11 == m1.m11 && this.m12 == m1.m12 && this.m20 == m1.m20 && 
					this.m21 == m1.m21 && this.m22 == m1.m22);
			}
			catch (ArgumentNullException)
			{
				return false;
			}
		}

		/// <summary>
		/// Returns true if the Object t1 is of type Matrix3d and all of the
		/// data members of t1 are equal to the corresponding data members in
		/// this Matrix3d.
		/// </summary>
		/// <remarks>
		/// Returns true if the Object t1 is of type Matrix3d and all of the
		/// data members of t1 are equal to the corresponding data members in
		/// this Matrix3d.
		/// </remarks>
		/// <param name="t1">the matrix with which the comparison is made</param>
		/// <returns>true or false</returns>
		public override bool Equals(object t1)
		{
			try
			{
				Matrix3d m2 = (Matrix3d)t1;
				return (this.m00 == m2.m00 && this.m01 == m2.m01 && this.m02 == m2.m02 && this.m10
					 == m2.m10 && this.m11 == m2.m11 && this.m12 == m2.m12 && this.m20 == m2.m20 && 
					this.m21 == m2.m21 && this.m22 == m2.m22);
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
		/// MAX[i=0,1,2 ; j=0,1,2 ; abs(this.m(i,j) - m1.m(i,j)]
		/// </remarks>
		/// <param name="m1">the matrix to be compared to this matrix</param>
		/// <param name="epsilon">the threshold value</param>
		public virtual bool EpsilonEquals(Matrix3d m1, double epsilon)
		{
			double diff;
			diff = m00 - m1.m00;
			if ((diff < 0 ? -diff : diff) > epsilon)
			{
				return false;
			}
			diff = m01 - m1.m01;
			if ((diff < 0 ? -diff : diff) > epsilon)
			{
				return false;
			}
			diff = m02 - m1.m02;
			if ((diff < 0 ? -diff : diff) > epsilon)
			{
				return false;
			}
			diff = m10 - m1.m10;
			if ((diff < 0 ? -diff : diff) > epsilon)
			{
				return false;
			}
			diff = m11 - m1.m11;
			if ((diff < 0 ? -diff : diff) > epsilon)
			{
				return false;
			}
			diff = m12 - m1.m12;
			if ((diff < 0 ? -diff : diff) > epsilon)
			{
				return false;
			}
			diff = m20 - m1.m20;
			if ((diff < 0 ? -diff : diff) > epsilon)
			{
				return false;
			}
			diff = m21 - m1.m21;
			if ((diff < 0 ? -diff : diff) > epsilon)
			{
				return false;
			}
			diff = m22 - m1.m22;
			if ((diff < 0 ? -diff : diff) > epsilon)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// Returns a hash code value based on the data values in this
		/// object.
		/// </summary>
		/// <remarks>
		/// Returns a hash code value based on the data values in this
		/// object.  Two different Matrix3d objects with identical data values
		/// (i.e., Matrix3d.equals returns true) will return the same hash
		/// code value.  Two objects with different data members may return the
		/// same hash value, although this is not likely.
		/// </remarks>
		/// <returns>the integer hash code value</returns>
		public override int GetHashCode()
		{
			long bits = 1L;
			bits = 31L * bits + VecMathUtil.DoubleToLongBits(m00);
			bits = 31L * bits + VecMathUtil.DoubleToLongBits(m01);
			bits = 31L * bits + VecMathUtil.DoubleToLongBits(m02);
			bits = 31L * bits + VecMathUtil.DoubleToLongBits(m10);
			bits = 31L * bits + VecMathUtil.DoubleToLongBits(m11);
			bits = 31L * bits + VecMathUtil.DoubleToLongBits(m12);
			bits = 31L * bits + VecMathUtil.DoubleToLongBits(m20);
			bits = 31L * bits + VecMathUtil.DoubleToLongBits(m21);
			bits = 31L * bits + VecMathUtil.DoubleToLongBits(m22);
			return (int)(bits ^ (bits >> 32));
		}

		/// <summary>Sets this matrix to all zeros.</summary>
		/// <remarks>Sets this matrix to all zeros.</remarks>
		public void SetZero()
		{
			m00 = 0.0;
			m01 = 0.0;
			m02 = 0.0;
			m10 = 0.0;
			m11 = 0.0;
			m12 = 0.0;
			m20 = 0.0;
			m21 = 0.0;
			m22 = 0.0;
		}

		/// <summary>Negates the value of this matrix: this = -this.</summary>
		/// <remarks>Negates the value of this matrix: this = -this.</remarks>
		public void Negate()
		{
			this.m00 = -this.m00;
			this.m01 = -this.m01;
			this.m02 = -this.m02;
			this.m10 = -this.m10;
			this.m11 = -this.m11;
			this.m12 = -this.m12;
			this.m20 = -this.m20;
			this.m21 = -this.m21;
			this.m22 = -this.m22;
		}

		/// <summary>
		/// Sets the value of this matrix equal to the negation of
		/// of the Matrix3d parameter.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix equal to the negation of
		/// of the Matrix3d parameter.
		/// </remarks>
		/// <param name="m1">the source matrix</param>
		public void Negate(Matrix3d m1)
		{
			this.m00 = -m1.m00;
			this.m01 = -m1.m01;
			this.m02 = -m1.m02;
			this.m10 = -m1.m10;
			this.m11 = -m1.m11;
			this.m12 = -m1.m12;
			this.m20 = -m1.m20;
			this.m21 = -m1.m21;
			this.m22 = -m1.m22;
		}

		/// <summary>
		/// Multiply this matrix by the tuple t and place the result
		/// back into the tuple (t = this*t).
		/// </summary>
		/// <remarks>
		/// Multiply this matrix by the tuple t and place the result
		/// back into the tuple (t = this*t).
		/// </remarks>
		/// <param name="t">the tuple to be multiplied by this matrix and then replaced</param>
		public void Transform(Tuple3d t)
		{
			double x;
			double y;
			double z;
			x = m00 * t.x + m01 * t.y + m02 * t.z;
			y = m10 * t.x + m11 * t.y + m12 * t.z;
			z = m20 * t.x + m21 * t.y + m22 * t.z;
			t.Set(x, y, z);
		}

		/// <summary>
		/// Multiply this matrix by the tuple t and and place the result
		/// into the tuple "result" (result = this*t).
		/// </summary>
		/// <remarks>
		/// Multiply this matrix by the tuple t and and place the result
		/// into the tuple "result" (result = this*t).
		/// </remarks>
		/// <param name="t">the tuple to be multiplied by this matrix</param>
		/// <param name="result">the tuple into which the product is placed</param>
		public void Transform(Tuple3d t, Tuple3d result)
		{
			double x;
			double y;
			double z;
			x = m00 * t.x + m01 * t.y + m02 * t.z;
			y = m10 * t.x + m11 * t.y + m12 * t.z;
			result.z = m20 * t.x + m21 * t.y + m22 * t.z;
			result.x = x;
			result.y = y;
		}

		/// <summary>perform SVD (if necessary to get rotational component</summary>
		internal void GetScaleRotate(double[] scales, double[] rots)
		{
			double[] tmp = new double[9];
			// scratch matrix
			tmp[0] = m00;
			tmp[1] = m01;
			tmp[2] = m02;
			tmp[3] = m10;
			tmp[4] = m11;
			tmp[5] = m12;
			tmp[6] = m20;
			tmp[7] = m21;
			tmp[8] = m22;
			Compute_svd(tmp, scales, rots);
			return;
		}

		internal static void Compute_svd(double[] m, double[] outScale, double[] outRot)
		{
			int i;
			int j;
			double g;
			double scale;
			double[] u1 = new double[9];
			double[] v1 = new double[9];
			double[] t1 = new double[9];
			double[] t2 = new double[9];
			double[] tmp = t1;
			double[] single_values = t2;
			double[] rot = new double[9];
			double[] e = new double[3];
			double[] scales = new double[3];
			int converged;
			int negCnt = 0;
			double cs;
			double sn;
			double c1;
			double c2;
			double c3;
			double c4;
			double s1;
			double s2;
			double s3;
			double s4;
			double cl1;
			double cl2;
			double cl3;
			for (i = 0; i < 9; i++)
			{
				rot[i] = m[i];
			}
			// u1
			if (m[3] * m[3] < Eps)
			{
				u1[0] = 1.0;
				u1[1] = 0.0;
				u1[2] = 0.0;
				u1[3] = 0.0;
				u1[4] = 1.0;
				u1[5] = 0.0;
				u1[6] = 0.0;
				u1[7] = 0.0;
				u1[8] = 1.0;
			}
			else
			{
				if (m[0] * m[0] < Eps)
				{
					tmp[0] = m[0];
					tmp[1] = m[1];
					tmp[2] = m[2];
					m[0] = m[3];
					m[1] = m[4];
					m[2] = m[5];
					m[3] = -tmp[0];
					// zero
					m[4] = -tmp[1];
					m[5] = -tmp[2];
					u1[0] = 0.0;
					u1[1] = 1.0;
					u1[2] = 0.0;
					u1[3] = -1.0;
					u1[4] = 0.0;
					u1[5] = 0.0;
					u1[6] = 0.0;
					u1[7] = 0.0;
					u1[8] = 1.0;
				}
				else
				{
					g = 1.0 / Math.Sqrt(m[0] * m[0] + m[3] * m[3]);
					c1 = m[0] * g;
					s1 = m[3] * g;
					tmp[0] = c1 * m[0] + s1 * m[3];
					tmp[1] = c1 * m[1] + s1 * m[4];
					tmp[2] = c1 * m[2] + s1 * m[5];
					m[3] = -s1 * m[0] + c1 * m[3];
					// zero
					m[4] = -s1 * m[1] + c1 * m[4];
					m[5] = -s1 * m[2] + c1 * m[5];
					m[0] = tmp[0];
					m[1] = tmp[1];
					m[2] = tmp[2];
					u1[0] = c1;
					u1[1] = s1;
					u1[2] = 0.0;
					u1[3] = -s1;
					u1[4] = c1;
					u1[5] = 0.0;
					u1[6] = 0.0;
					u1[7] = 0.0;
					u1[8] = 1.0;
				}
			}
			// u2
			if (m[6] * m[6] < Eps)
			{
			}
			else
			{
				if (m[0] * m[0] < Eps)
				{
					tmp[0] = m[0];
					tmp[1] = m[1];
					tmp[2] = m[2];
					m[0] = m[6];
					m[1] = m[7];
					m[2] = m[8];
					m[6] = -tmp[0];
					// zero
					m[7] = -tmp[1];
					m[8] = -tmp[2];
					tmp[0] = u1[0];
					tmp[1] = u1[1];
					tmp[2] = u1[2];
					u1[0] = u1[6];
					u1[1] = u1[7];
					u1[2] = u1[8];
					u1[6] = -tmp[0];
					// zero
					u1[7] = -tmp[1];
					u1[8] = -tmp[2];
				}
				else
				{
					g = 1.0 / Math.Sqrt(m[0] * m[0] + m[6] * m[6]);
					c2 = m[0] * g;
					s2 = m[6] * g;
					tmp[0] = c2 * m[0] + s2 * m[6];
					tmp[1] = c2 * m[1] + s2 * m[7];
					tmp[2] = c2 * m[2] + s2 * m[8];
					m[6] = -s2 * m[0] + c2 * m[6];
					m[7] = -s2 * m[1] + c2 * m[7];
					m[8] = -s2 * m[2] + c2 * m[8];
					m[0] = tmp[0];
					m[1] = tmp[1];
					m[2] = tmp[2];
					tmp[0] = c2 * u1[0];
					tmp[1] = c2 * u1[1];
					u1[2] = s2;
					tmp[6] = -u1[0] * s2;
					tmp[7] = -u1[1] * s2;
					u1[8] = c2;
					u1[0] = tmp[0];
					u1[1] = tmp[1];
					u1[6] = tmp[6];
					u1[7] = tmp[7];
				}
			}
			// v1
			if (m[2] * m[2] < Eps)
			{
				v1[0] = 1.0;
				v1[1] = 0.0;
				v1[2] = 0.0;
				v1[3] = 0.0;
				v1[4] = 1.0;
				v1[5] = 0.0;
				v1[6] = 0.0;
				v1[7] = 0.0;
				v1[8] = 1.0;
			}
			else
			{
				if (m[1] * m[1] < Eps)
				{
					tmp[2] = m[2];
					tmp[5] = m[5];
					tmp[8] = m[8];
					m[2] = -m[1];
					m[5] = -m[4];
					m[8] = -m[7];
					m[1] = tmp[2];
					// zero
					m[4] = tmp[5];
					m[7] = tmp[8];
					v1[0] = 1.0;
					v1[1] = 0.0;
					v1[2] = 0.0;
					v1[3] = 0.0;
					v1[4] = 0.0;
					v1[5] = -1.0;
					v1[6] = 0.0;
					v1[7] = 1.0;
					v1[8] = 0.0;
				}
				else
				{
					g = 1.0 / Math.Sqrt(m[1] * m[1] + m[2] * m[2]);
					c3 = m[1] * g;
					s3 = m[2] * g;
					tmp[1] = c3 * m[1] + s3 * m[2];
					// can assign to m[1]?
					m[2] = -s3 * m[1] + c3 * m[2];
					// zero
					m[1] = tmp[1];
					tmp[4] = c3 * m[4] + s3 * m[5];
					m[5] = -s3 * m[4] + c3 * m[5];
					m[4] = tmp[4];
					tmp[7] = c3 * m[7] + s3 * m[8];
					m[8] = -s3 * m[7] + c3 * m[8];
					m[7] = tmp[7];
					v1[0] = 1.0;
					v1[1] = 0.0;
					v1[2] = 0.0;
					v1[3] = 0.0;
					v1[4] = c3;
					v1[5] = -s3;
					v1[6] = 0.0;
					v1[7] = s3;
					v1[8] = c3;
				}
			}
			// u3
			if (m[7] * m[7] < Eps)
			{
			}
			else
			{
				if (m[4] * m[4] < Eps)
				{
					tmp[3] = m[3];
					tmp[4] = m[4];
					tmp[5] = m[5];
					m[3] = m[6];
					// zero
					m[4] = m[7];
					m[5] = m[8];
					m[6] = -tmp[3];
					// zero
					m[7] = -tmp[4];
					// zero
					m[8] = -tmp[5];
					tmp[3] = u1[3];
					tmp[4] = u1[4];
					tmp[5] = u1[5];
					u1[3] = u1[6];
					u1[4] = u1[7];
					u1[5] = u1[8];
					u1[6] = -tmp[3];
					// zero
					u1[7] = -tmp[4];
					u1[8] = -tmp[5];
				}
				else
				{
					g = 1.0 / Math.Sqrt(m[4] * m[4] + m[7] * m[7]);
					c4 = m[4] * g;
					s4 = m[7] * g;
					tmp[3] = c4 * m[3] + s4 * m[6];
					m[6] = -s4 * m[3] + c4 * m[6];
					// zero
					m[3] = tmp[3];
					tmp[4] = c4 * m[4] + s4 * m[7];
					m[7] = -s4 * m[4] + c4 * m[7];
					m[4] = tmp[4];
					tmp[5] = c4 * m[5] + s4 * m[8];
					m[8] = -s4 * m[5] + c4 * m[8];
					m[5] = tmp[5];
					tmp[3] = c4 * u1[3] + s4 * u1[6];
					u1[6] = -s4 * u1[3] + c4 * u1[6];
					u1[3] = tmp[3];
					tmp[4] = c4 * u1[4] + s4 * u1[7];
					u1[7] = -s4 * u1[4] + c4 * u1[7];
					u1[4] = tmp[4];
					tmp[5] = c4 * u1[5] + s4 * u1[8];
					u1[8] = -s4 * u1[5] + c4 * u1[8];
					u1[5] = tmp[5];
				}
			}
			single_values[0] = m[0];
			single_values[1] = m[4];
			single_values[2] = m[8];
			e[0] = m[1];
			e[1] = m[5];
			if (e[0] * e[0] < Eps && e[1] * e[1] < Eps)
			{
			}
			else
			{
				Compute_qr(single_values, e, u1, v1);
			}
			scales[0] = single_values[0];
			scales[1] = single_values[1];
			scales[2] = single_values[2];
			// Do some optimization here. If scale is unity, simply return the rotation matric.
			if (AlmostEqual(Math.Abs(scales[0]), 1.0) && AlmostEqual(Math.Abs(scales[1]), 1.0
				) && AlmostEqual(Math.Abs(scales[2]), 1.0))
			{
				//  System.out.println("Scale components almost to 1.0");
				for (i = 0; i < 3; i++)
				{
					if (scales[i] < 0.0)
					{
						negCnt++;
					}
				}
				if ((negCnt == 0) || (negCnt == 2))
				{
					//System.out.println("Optimize!!");
					outScale[0] = outScale[1] = outScale[2] = 1.0;
					for (i = 0; i < 9; i++)
					{
						outRot[i] = rot[i];
					}
					return;
				}
			}
			Transpose_mat(u1, t1);
			Transpose_mat(v1, t2);
			SvdReorder(m, t1, t2, scales, outRot, outScale);
		}

		internal static void SvdReorder(double[] m, double[] t1, double[] t2, double[] scales
			, double[] outRot, double[] outScale)
		{
			int[] @out = new int[3];
			int[] @in = new int[3];
			int in0;
			int in1;
			int in2;
			int index;
			int i;
			double[] mag = new double[3];
			double[] rot = new double[9];
			// check for rotation information in the scales
			if (scales[0] < 0.0)
			{
				// move the rotation info to rotation matrix
				scales[0] = -scales[0];
				t2[0] = -t2[0];
				t2[1] = -t2[1];
				t2[2] = -t2[2];
			}
			if (scales[1] < 0.0)
			{
				// move the rotation info to rotation matrix
				scales[1] = -scales[1];
				t2[3] = -t2[3];
				t2[4] = -t2[4];
				t2[5] = -t2[5];
			}
			if (scales[2] < 0.0)
			{
				// move the rotation info to rotation matrix
				scales[2] = -scales[2];
				t2[6] = -t2[6];
				t2[7] = -t2[7];
				t2[8] = -t2[8];
			}
			Mat_mul(t1, t2, rot);
			// check for equal scales case  and do not reorder
			if (AlmostEqual(Math.Abs(scales[0]), Math.Abs(scales[1])) && AlmostEqual(Math.Abs
				(scales[1]), Math.Abs(scales[2])))
			{
				for (i = 0; i < 9; i++)
				{
					outRot[i] = rot[i];
				}
				for (i = 0; i < 3; i++)
				{
					outScale[i] = scales[i];
				}
			}
			else
			{
				// sort the order of the results of SVD
				if (scales[0] > scales[1])
				{
					if (scales[0] > scales[2])
					{
						if (scales[2] > scales[1])
						{
							@out[0] = 0;
							@out[1] = 2;
							@out[2] = 1;
						}
						else
						{
							// xzy
							@out[0] = 0;
							@out[1] = 1;
							@out[2] = 2;
						}
					}
					else
					{
						// xyz
						@out[0] = 2;
						@out[1] = 0;
						@out[2] = 1;
					}
				}
				else
				{
					// zxy
					// y > x
					if (scales[1] > scales[2])
					{
						if (scales[2] > scales[0])
						{
							@out[0] = 1;
							@out[1] = 2;
							@out[2] = 0;
						}
						else
						{
							// yzx
							@out[0] = 1;
							@out[1] = 0;
							@out[2] = 2;
						}
					}
					else
					{
						// yxz
						@out[0] = 2;
						@out[1] = 1;
						@out[2] = 0;
					}
				}
				// zyx
				// sort the order of the input matrix
				mag[0] = (m[0] * m[0] + m[1] * m[1] + m[2] * m[2]);
				mag[1] = (m[3] * m[3] + m[4] * m[4] + m[5] * m[5]);
				mag[2] = (m[6] * m[6] + m[7] * m[7] + m[8] * m[8]);
				if (mag[0] > mag[1])
				{
					if (mag[0] > mag[2])
					{
						if (mag[2] > mag[1])
						{
							// 0 - 2 - 1
							in0 = 0;
							in2 = 1;
							in1 = 2;
						}
						else
						{
							// xzy
							// 0 - 1 - 2
							in0 = 0;
							in1 = 1;
							in2 = 2;
						}
					}
					else
					{
						// xyz
						// 2 - 0 - 1
						in2 = 0;
						in0 = 1;
						in1 = 2;
					}
				}
				else
				{
					// zxy
					// y > x   1>0
					if (mag[1] > mag[2])
					{
						if (mag[2] > mag[0])
						{
							// 1 - 2 - 0
							in1 = 0;
							in2 = 1;
							in0 = 2;
						}
						else
						{
							// yzx
							// 1 - 0 - 2
							in1 = 0;
							in0 = 1;
							in2 = 2;
						}
					}
					else
					{
						// yxz
						// 2 - 1 - 0
						in2 = 0;
						in1 = 1;
						in0 = 2;
					}
				}
				// zyx
				index = @out[in0];
				outScale[0] = scales[index];
				index = @out[in1];
				outScale[1] = scales[index];
				index = @out[in2];
				outScale[2] = scales[index];
				index = @out[in0];
				outRot[0] = rot[index];
				index = @out[in0] + 3;
				outRot[0 + 3] = rot[index];
				index = @out[in0] + 6;
				outRot[0 + 6] = rot[index];
				index = @out[in1];
				outRot[1] = rot[index];
				index = @out[in1] + 3;
				outRot[1 + 3] = rot[index];
				index = @out[in1] + 6;
				outRot[1 + 6] = rot[index];
				index = @out[in2];
				outRot[2] = rot[index];
				index = @out[in2] + 3;
				outRot[2 + 3] = rot[index];
				index = @out[in2] + 6;
				outRot[2 + 6] = rot[index];
			}
		}

		internal static int Compute_qr(double[] s, double[] e, double[] u, double[] v)
		{
			int i;
			int j;
			int k;
			bool converged;
			double shift;
			double ssmin;
			double ssmax;
			double r;
			double[] cosl = new double[2];
			double[] cosr = new double[2];
			double[] sinl = new double[2];
			double[] sinr = new double[2];
			double[] m = new double[9];
			double utemp;
			double vtemp;
			double f;
			double g;
			int MaxInterations = 10;
			double ConvergeTol = 4.89E-15;
			double c_b48 = 1.0;
			double c_b71 = -1.0;
			int first;
			converged = false;
			first = 1;
			if (Math.Abs(e[1]) < ConvergeTol || Math.Abs(e[0]) < ConvergeTol)
			{
				converged = true;
			}
			for (k = 0; k < MaxInterations && !converged; k++)
			{
				shift = Compute_shift(s[1], e[1], s[2]);
				f = (Math.Abs(s[0]) - shift) * (D_sign(c_b48, s[0]) + shift / s[0]);
				g = e[0];
				r = Compute_rot(f, g, sinr, cosr, 0, first);
				f = cosr[0] * s[0] + sinr[0] * e[0];
				e[0] = cosr[0] * e[0] - sinr[0] * s[0];
				g = sinr[0] * s[1];
				s[1] = cosr[0] * s[1];
				r = Compute_rot(f, g, sinl, cosl, 0, first);
				first = 0;
				s[0] = r;
				f = cosl[0] * e[0] + sinl[0] * s[1];
				s[1] = cosl[0] * s[1] - sinl[0] * e[0];
				g = sinl[0] * e[1];
				e[1] = cosl[0] * e[1];
				r = Compute_rot(f, g, sinr, cosr, 1, first);
				e[0] = r;
				f = cosr[1] * s[1] + sinr[1] * e[1];
				e[1] = cosr[1] * e[1] - sinr[1] * s[1];
				g = sinr[1] * s[2];
				s[2] = cosr[1] * s[2];
				r = Compute_rot(f, g, sinl, cosl, 1, first);
				s[1] = r;
				f = cosl[1] * e[1] + sinl[1] * s[2];
				s[2] = cosl[1] * s[2] - sinl[1] * e[1];
				e[1] = f;
				// update u  matrices
				utemp = u[0];
				u[0] = cosl[0] * utemp + sinl[0] * u[3];
				u[3] = -sinl[0] * utemp + cosl[0] * u[3];
				utemp = u[1];
				u[1] = cosl[0] * utemp + sinl[0] * u[4];
				u[4] = -sinl[0] * utemp + cosl[0] * u[4];
				utemp = u[2];
				u[2] = cosl[0] * utemp + sinl[0] * u[5];
				u[5] = -sinl[0] * utemp + cosl[0] * u[5];
				utemp = u[3];
				u[3] = cosl[1] * utemp + sinl[1] * u[6];
				u[6] = -sinl[1] * utemp + cosl[1] * u[6];
				utemp = u[4];
				u[4] = cosl[1] * utemp + sinl[1] * u[7];
				u[7] = -sinl[1] * utemp + cosl[1] * u[7];
				utemp = u[5];
				u[5] = cosl[1] * utemp + sinl[1] * u[8];
				u[8] = -sinl[1] * utemp + cosl[1] * u[8];
				// update v  matrices
				vtemp = v[0];
				v[0] = cosr[0] * vtemp + sinr[0] * v[1];
				v[1] = -sinr[0] * vtemp + cosr[0] * v[1];
				vtemp = v[3];
				v[3] = cosr[0] * vtemp + sinr[0] * v[4];
				v[4] = -sinr[0] * vtemp + cosr[0] * v[4];
				vtemp = v[6];
				v[6] = cosr[0] * vtemp + sinr[0] * v[7];
				v[7] = -sinr[0] * vtemp + cosr[0] * v[7];
				vtemp = v[1];
				v[1] = cosr[1] * vtemp + sinr[1] * v[2];
				v[2] = -sinr[1] * vtemp + cosr[1] * v[2];
				vtemp = v[4];
				v[4] = cosr[1] * vtemp + sinr[1] * v[5];
				v[5] = -sinr[1] * vtemp + cosr[1] * v[5];
				vtemp = v[7];
				v[7] = cosr[1] * vtemp + sinr[1] * v[8];
				v[8] = -sinr[1] * vtemp + cosr[1] * v[8];
				m[0] = s[0];
				m[1] = e[0];
				m[2] = 0.0;
				m[3] = 0.0;
				m[4] = s[1];
				m[5] = e[1];
				m[6] = 0.0;
				m[7] = 0.0;
				m[8] = s[2];
				if (Math.Abs(e[1]) < ConvergeTol || Math.Abs(e[0]) < ConvergeTol)
				{
					converged = true;
				}
			}
			if (Math.Abs(e[1]) < ConvergeTol)
			{
				Compute_2X2(s[0], e[0], s[1], s, sinl, cosl, sinr, cosr, 0);
				utemp = u[0];
				u[0] = cosl[0] * utemp + sinl[0] * u[3];
				u[3] = -sinl[0] * utemp + cosl[0] * u[3];
				utemp = u[1];
				u[1] = cosl[0] * utemp + sinl[0] * u[4];
				u[4] = -sinl[0] * utemp + cosl[0] * u[4];
				utemp = u[2];
				u[2] = cosl[0] * utemp + sinl[0] * u[5];
				u[5] = -sinl[0] * utemp + cosl[0] * u[5];
				// update v  matrices
				vtemp = v[0];
				v[0] = cosr[0] * vtemp + sinr[0] * v[1];
				v[1] = -sinr[0] * vtemp + cosr[0] * v[1];
				vtemp = v[3];
				v[3] = cosr[0] * vtemp + sinr[0] * v[4];
				v[4] = -sinr[0] * vtemp + cosr[0] * v[4];
				vtemp = v[6];
				v[6] = cosr[0] * vtemp + sinr[0] * v[7];
				v[7] = -sinr[0] * vtemp + cosr[0] * v[7];
			}
			else
			{
				Compute_2X2(s[1], e[1], s[2], s, sinl, cosl, sinr, cosr, 1);
				utemp = u[3];
				u[3] = cosl[0] * utemp + sinl[0] * u[6];
				u[6] = -sinl[0] * utemp + cosl[0] * u[6];
				utemp = u[4];
				u[4] = cosl[0] * utemp + sinl[0] * u[7];
				u[7] = -sinl[0] * utemp + cosl[0] * u[7];
				utemp = u[5];
				u[5] = cosl[0] * utemp + sinl[0] * u[8];
				u[8] = -sinl[0] * utemp + cosl[0] * u[8];
				// update v  matrices
				vtemp = v[1];
				v[1] = cosr[0] * vtemp + sinr[0] * v[2];
				v[2] = -sinr[0] * vtemp + cosr[0] * v[2];
				vtemp = v[4];
				v[4] = cosr[0] * vtemp + sinr[0] * v[5];
				v[5] = -sinr[0] * vtemp + cosr[0] * v[5];
				vtemp = v[7];
				v[7] = cosr[0] * vtemp + sinr[0] * v[8];
				v[8] = -sinr[0] * vtemp + cosr[0] * v[8];
			}
			return (0);
		}

		internal static double Max(double a, double b)
		{
			if (a > b)
			{
				return (a);
			}
			else
			{
				return (b);
			}
		}

		internal static double Min(double a, double b)
		{
			if (a < b)
			{
				return (a);
			}
			else
			{
				return (b);
			}
		}

		internal static double D_sign(double a, double b)
		{
			double x;
			x = (a >= 0 ? a : -a);
			return (b >= 0 ? x : -x);
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
			return (ssmin);
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
					a = (s + r) * .5;
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
						a = (s + r) * .5;
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
			, int index, int first)
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
			sin[index] = sn;
			cos[index] = cs;
			return r;
		}

		internal static void Print_mat(double[] mat)
		{
			int i;
			for (i = 0; i < 3; i++)
			{
				System.Console.Out.WriteLine(mat[i * 3 + 0] + " " + mat[i * 3 + 1] + " " + mat[i 
					* 3 + 2] + "\n");
			}
		}

		internal static void Print_det(double[] mat)
		{
			double det;
			det = mat[0] * mat[4] * mat[8] + mat[1] * mat[5] * mat[6] + mat[2] * mat[3] * mat
				[7] - mat[2] * mat[4] * mat[6] - mat[0] * mat[5] * mat[7] - mat[1] * mat[3] * mat
				[8];
			System.Console.Out.WriteLine("det= " + det);
		}

		internal static void Mat_mul(double[] m1, double[] m2, double[] m3)
		{
			int i;
			double[] tmp = new double[9];
			tmp[0] = m1[0] * m2[0] + m1[1] * m2[3] + m1[2] * m2[6];
			tmp[1] = m1[0] * m2[1] + m1[1] * m2[4] + m1[2] * m2[7];
			tmp[2] = m1[0] * m2[2] + m1[1] * m2[5] + m1[2] * m2[8];
			tmp[3] = m1[3] * m2[0] + m1[4] * m2[3] + m1[5] * m2[6];
			tmp[4] = m1[3] * m2[1] + m1[4] * m2[4] + m1[5] * m2[7];
			tmp[5] = m1[3] * m2[2] + m1[4] * m2[5] + m1[5] * m2[8];
			tmp[6] = m1[6] * m2[0] + m1[7] * m2[3] + m1[8] * m2[6];
			tmp[7] = m1[6] * m2[1] + m1[7] * m2[4] + m1[8] * m2[7];
			tmp[8] = m1[6] * m2[2] + m1[7] * m2[5] + m1[8] * m2[8];
			for (i = 0; i < 9; i++)
			{
				m3[i] = tmp[i];
			}
		}

		internal static void Transpose_mat(double[] @in, double[] @out)
		{
			@out[0] = @in[0];
			@out[1] = @in[3];
			@out[2] = @in[6];
			@out[3] = @in[1];
			@out[4] = @in[4];
			@out[5] = @in[7];
			@out[6] = @in[2];
			@out[7] = @in[5];
			@out[8] = @in[8];
		}

		internal static double Max3(double[] values)
		{
			if (values[0] > values[1])
			{
				if (values[0] > values[2])
				{
					return (values[0]);
				}
				else
				{
					return (values[2]);
				}
			}
			else
			{
				if (values[1] > values[2])
				{
					return (values[1]);
				}
				else
				{
					return (values[2]);
				}
			}
		}

		private static bool AlmostEqual(double a, double b)
		{
			if (a == b)
			{
				return true;
			}
			double EpsilonAbsolute = 1.0e-6;
			double EpsilonRelative = 1.0e-4;
			double diff = Math.Abs(a - b);
			double absA = Math.Abs(a);
			double absB = Math.Abs(b);
			double max = (absA >= absB) ? absA : absB;
			if (diff < EpsilonAbsolute)
			{
				return true;
			}
			if ((diff / max) < EpsilonRelative)
			{
				return true;
			}
			return false;
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
			Matrix3d m1 = null;
			m1 = (Matrix3d)base.MemberwiseClone();
			// this shouldn't happen, since we are Cloneable
			// Also need to create new tmp arrays (no need to actually clone them)
			return m1;
		}

		/// <summary>Get the first matrix element in the first row.</summary>
		/// <remarks>Get the first matrix element in the first row.</remarks>
		/// <returns>Returns the m00.</returns>
		/// <since>vecmath 1.5</since>
		public double GetM00()
		{
			return m00;
		}

		/// <summary>Set the first matrix element in the first row.</summary>
		/// <remarks>Set the first matrix element in the first row.</remarks>
		/// <param name="m00">The m00 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM00(double m00)
		{
			this.m00 = m00;
		}

		/// <summary>Get the second matrix element in the first row.</summary>
		/// <remarks>Get the second matrix element in the first row.</remarks>
		/// <returns>Returns the m01.</returns>
		/// <since>vecmath 1.5</since>
		public double GetM01()
		{
			return m01;
		}

		/// <summary>Set the second matrix element in the first row.</summary>
		/// <remarks>Set the second matrix element in the first row.</remarks>
		/// <param name="m01">The m01 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM01(double m01)
		{
			this.m01 = m01;
		}

		/// <summary>Get the third matrix element in the first row.</summary>
		/// <remarks>Get the third matrix element in the first row.</remarks>
		/// <returns>Returns the m02.</returns>
		/// <since>vecmath 1.5</since>
		public double GetM02()
		{
			return m02;
		}

		/// <summary>Set the third matrix element in the first row.</summary>
		/// <remarks>Set the third matrix element in the first row.</remarks>
		/// <param name="m02">The m02 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM02(double m02)
		{
			this.m02 = m02;
		}

		/// <summary>Get first matrix element in the second row.</summary>
		/// <remarks>Get first matrix element in the second row.</remarks>
		/// <returns>Returns the m10.</returns>
		/// <since>vecmath 1.5</since>
		public double GetM10()
		{
			return m10;
		}

		/// <summary>Set first matrix element in the second row.</summary>
		/// <remarks>Set first matrix element in the second row.</remarks>
		/// <param name="m10">The m10 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM10(double m10)
		{
			this.m10 = m10;
		}

		/// <summary>Get second matrix element in the second row.</summary>
		/// <remarks>Get second matrix element in the second row.</remarks>
		/// <returns>Returns the m11.</returns>
		/// <since>vecmath 1.5</since>
		public double GetM11()
		{
			return m11;
		}

		/// <summary>Set the second matrix element in the second row.</summary>
		/// <remarks>Set the second matrix element in the second row.</remarks>
		/// <param name="m11">The m11 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM11(double m11)
		{
			this.m11 = m11;
		}

		/// <summary>Get the third matrix element in the second row.</summary>
		/// <remarks>Get the third matrix element in the second row.</remarks>
		/// <returns>Returns the m12.</returns>
		/// <since>vecmath 1.5</since>
		public double GetM12()
		{
			return m12;
		}

		/// <summary>Set the third matrix element in the second row.</summary>
		/// <remarks>Set the third matrix element in the second row.</remarks>
		/// <param name="m12">The m12 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM12(double m12)
		{
			this.m12 = m12;
		}

		/// <summary>Get the first matrix element in the third row.</summary>
		/// <remarks>Get the first matrix element in the third row.</remarks>
		/// <returns>Returns the m20.</returns>
		/// <since>vecmath 1.5</since>
		public double GetM20()
		{
			return m20;
		}

		/// <summary>Set the first matrix element in the third row.</summary>
		/// <remarks>Set the first matrix element in the third row.</remarks>
		/// <param name="m20">The m20 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM20(double m20)
		{
			this.m20 = m20;
		}

		/// <summary>Get the second matrix element in the third row.</summary>
		/// <remarks>Get the second matrix element in the third row.</remarks>
		/// <returns>Returns the m21.</returns>
		/// <since>vecmath 1.5</since>
		public double GetM21()
		{
			return m21;
		}

		/// <summary>Set the second matrix element in the third row.</summary>
		/// <remarks>Set the second matrix element in the third row.</remarks>
		/// <param name="m21">The m21 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM21(double m21)
		{
			this.m21 = m21;
		}

		/// <summary>Get the third matrix element in the third row .</summary>
		/// <remarks>Get the third matrix element in the third row .</remarks>
		/// <returns>Returns the m22.</returns>
		/// <since>vecmath 1.5</since>
		public double GetM22()
		{
			return m22;
		}

		/// <summary>Set the third matrix element in the third row.</summary>
		/// <remarks>Set the third matrix element in the third row.</remarks>
		/// <param name="m22">The m22 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM22(double m22)
		{
			this.m22 = m22;
		}
	}
}
