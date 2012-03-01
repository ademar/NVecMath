/*
 * Automated conversion
 */

using System;

namespace NVecMath
{
	/// <summary>A single precision floating point 3 by 3 matrix.</summary>
	/// <remarks>
	/// A single precision floating point 3 by 3 matrix.
	/// Primarily to support 3D rotations.
	/// </remarks>
	[System.Serializable]
	public class Matrix3f : ICloneable
	{
		internal const long serialVersionUID = 329697160112089834L;

		/// <summary>The first matrix element in the first row.</summary>
		/// <remarks>The first matrix element in the first row.</remarks>
		public float m00;

		/// <summary>The second matrix element in the first row.</summary>
		/// <remarks>The second matrix element in the first row.</remarks>
		public float m01;

		/// <summary>The third matrix element in the first row.</summary>
		/// <remarks>The third matrix element in the first row.</remarks>
		public float m02;

		/// <summary>The first matrix element in the second row.</summary>
		/// <remarks>The first matrix element in the second row.</remarks>
		public float m10;

		/// <summary>The second matrix element in the second row.</summary>
		/// <remarks>The second matrix element in the second row.</remarks>
		public float m11;

		/// <summary>The third matrix element in the second row.</summary>
		/// <remarks>The third matrix element in the second row.</remarks>
		public float m12;

		/// <summary>The first matrix element in the third row.</summary>
		/// <remarks>The first matrix element in the third row.</remarks>
		public float m20;

		/// <summary>The second matrix element in the third row.</summary>
		/// <remarks>The second matrix element in the third row.</remarks>
		public float m21;

		/// <summary>The third matrix element in the third row.</summary>
		/// <remarks>The third matrix element in the third row.</remarks>
		public float m22;

		private const double Eps = 1.0E-8;

		/// <summary>Constructs and initializes a Matrix3f from the specified nine values.</summary>
		/// <remarks>Constructs and initializes a Matrix3f from the specified nine values.</remarks>
		/// <param name="m00">the [0][0] element</param>
		/// <param name="m01">the [0][1] element</param>
		/// <param name="m02">the [0][2] element</param>
		/// <param name="m10">the [1][0] element</param>
		/// <param name="m11">the [1][1] element</param>
		/// <param name="m12">the [1][2] element</param>
		/// <param name="m20">the [2][0] element</param>
		/// <param name="m21">the [2][1] element</param>
		/// <param name="m22">the [2][2] element</param>
		public Matrix3f(float m00, float m01, float m02, float m10, float m11, float m12, 
			float m20, float m21, float m22)
		{
			// Compatible with 1.1
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
		/// Constructs and initializes a Matrix3f from the specified
		/// nine-element array.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a Matrix3f from the specified
		/// nine-element array.   this.m00 =v[0], this.m01=v[1], etc.
		/// </remarks>
		/// <param name="v">the array of length 9 containing in order</param>
		public Matrix3f(float[] v)
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
		public Matrix3f(Matrix3d m1)
		{
			this.m00 = (float)m1.m00;
			this.m01 = (float)m1.m01;
			this.m02 = (float)m1.m02;
			this.m10 = (float)m1.m10;
			this.m11 = (float)m1.m11;
			this.m12 = (float)m1.m12;
			this.m20 = (float)m1.m20;
			this.m21 = (float)m1.m21;
			this.m22 = (float)m1.m22;
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
		public Matrix3f(Matrix3f m1)
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

		/// <summary>Constructs and initializes a Matrix3f to all zeros.</summary>
		/// <remarks>Constructs and initializes a Matrix3f to all zeros.</remarks>
		public Matrix3f()
		{
			this.m00 = (float)0.0;
			this.m01 = (float)0.0;
			this.m02 = (float)0.0;
			this.m10 = (float)0.0;
			this.m11 = (float)0.0;
			this.m12 = (float)0.0;
			this.m20 = (float)0.0;
			this.m21 = (float)0.0;
			this.m22 = (float)0.0;
		}

		/// <summary>Returns a string that contains the values of this Matrix3f.</summary>
		/// <remarks>Returns a string that contains the values of this Matrix3f.</remarks>
		/// <returns>the String representation</returns>
		public override string ToString()
		{
			return this.m00 + ", " + this.m01 + ", " + this.m02 + "\n" + this.m10 + ", " + this
				.m11 + ", " + this.m12 + "\n" + this.m20 + ", " + this.m21 + ", " + this.m22 + "\n";
		}

		/// <summary>Sets this Matrix3f to identity.</summary>
		/// <remarks>Sets this Matrix3f to identity.</remarks>
		public void SetIdentity()
		{
			this.m00 = (float)1.0;
			this.m01 = (float)0.0;
			this.m02 = (float)0.0;
			this.m10 = (float)0.0;
			this.m11 = (float)1.0;
			this.m12 = (float)0.0;
			this.m20 = (float)0.0;
			this.m21 = (float)0.0;
			this.m22 = (float)1.0;
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
		public void SetScale(float scale)
		{
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			GetScaleRotate(tmp_scale, tmp_rot);
			this.m00 = (float)(tmp_rot[0] * scale);
			this.m01 = (float)(tmp_rot[1] * scale);
			this.m02 = (float)(tmp_rot[2] * scale);
			this.m10 = (float)(tmp_rot[3] * scale);
			this.m11 = (float)(tmp_rot[4] * scale);
			this.m12 = (float)(tmp_rot[5] * scale);
			this.m20 = (float)(tmp_rot[6] * scale);
			this.m21 = (float)(tmp_rot[7] * scale);
			this.m22 = (float)(tmp_rot[8] * scale);
		}

		/// <summary>Sets the specified element of this matrix3f to the value provided.</summary>
		/// <remarks>Sets the specified element of this matrix3f to the value provided.</remarks>
		/// <param name="row">the row number to be modified (zero indexed)</param>
		/// <param name="column">the column number to be modified (zero indexed)</param>
		/// <param name="value">the new value</param>
		public void SetElement(int row, int column, float value)
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
							throw new IndexOutOfRangeException("Matrix3f setElement");
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
							throw new IndexOutOfRangeException("Matrix3f setElement");
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
							throw new IndexOutOfRangeException("Matrix3f setElement");
						}
					}
					break;
				}

				default:
				{
					throw new IndexOutOfRangeException("Matrix3f setElement");
				}
			}
		}

		/// <summary>Copies the matrix values in the specified row into the vector parameter.
		/// 	</summary>
		/// <remarks>Copies the matrix values in the specified row into the vector parameter.
		/// 	</remarks>
		/// <param name="row">the matrix row</param>
		/// <param name="v">the vector into which the matrix row values will be copied</param>
		public void GetRow(int row, Vector3f v)
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
		public void GetRow(int row, float[] v)
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
		public void GetColumn(int column, Vector3f v)
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
		public void GetColumn(int column, float[] v)
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

		/// <summary>
		/// Retrieves the value at the specified row and column of this
		/// matrix.
		/// </summary>
		/// <remarks>
		/// Retrieves the value at the specified row and column of this
		/// matrix.
		/// </remarks>
		/// <param name="row">the row number to be retrieved (zero indexed)</param>
		/// <param name="column">the column number to be retrieved (zero indexed)</param>
		/// <returns>the value at the indexed element.</returns>
		public float GetElement(int row, int column)
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
			throw new IndexOutOfRangeException("Matrix3f getElement");
		}

		/// <summary>Sets the specified row of this matrix3f to the three values provided.</summary>
		/// <remarks>Sets the specified row of this matrix3f to the three values provided.</remarks>
		/// <param name="row">the row number to be modified (zero indexed)</param>
		/// <param name="x">the first column element</param>
		/// <param name="y">the second column element</param>
		/// <param name="z">the third column element</param>
		public void SetRow(int row, float x, float y, float z)
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
					throw new IndexOutOfRangeException("Matrix3f setRow");
				}
			}
		}

		/// <summary>Sets the specified row of this matrix3f to the Vector provided.</summary>
		/// <remarks>Sets the specified row of this matrix3f to the Vector provided.</remarks>
		/// <param name="row">the row number to be modified (zero indexed)</param>
		/// <param name="v">the replacement row</param>
		public void SetRow(int row, Vector3f v)
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
					throw new IndexOutOfRangeException("Matrix3f setRow");
				}
			}
		}

		/// <summary>Sets the specified row of this matrix3f to the three values provided.</summary>
		/// <remarks>Sets the specified row of this matrix3f to the three values provided.</remarks>
		/// <param name="row">the row number to be modified (zero indexed)</param>
		/// <param name="v">the replacement row</param>
		public void SetRow(int row, float[] v)
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
					throw new IndexOutOfRangeException("Matrix3f setRow");
				}
			}
		}

		/// <summary>Sets the specified column of this matrix3f to the three values provided.
		/// 	</summary>
		/// <remarks>Sets the specified column of this matrix3f to the three values provided.
		/// 	</remarks>
		/// <param name="column">the column number to be modified (zero indexed)</param>
		/// <param name="x">the first row element</param>
		/// <param name="y">the second row element</param>
		/// <param name="z">the third row element</param>
		public void SetColumn(int column, float x, float y, float z)
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
					throw new IndexOutOfRangeException("Matrix3f setColumn");
				}
			}
		}

		/// <summary>Sets the specified column of this matrix3f to the vector provided.</summary>
		/// <remarks>Sets the specified column of this matrix3f to the vector provided.</remarks>
		/// <param name="column">the column number to be modified (zero indexed)</param>
		/// <param name="v">the replacement column</param>
		public void SetColumn(int column, Vector3f v)
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
					throw new IndexOutOfRangeException("Matrix3f setColumn");
				}
			}
		}

		/// <summary>Sets the specified column of this matrix3f to the three values provided.
		/// 	</summary>
		/// <remarks>Sets the specified column of this matrix3f to the three values provided.
		/// 	</remarks>
		/// <param name="column">the column number to be modified (zero indexed)</param>
		/// <param name="v">the replacement column</param>
		public void SetColumn(int column, float[] v)
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
					throw new IndexOutOfRangeException("Matrix3f setColumn");
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
		public float GetScale()
		{
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			GetScaleRotate(tmp_scale, tmp_rot);
			return ((float)Matrix3d.Max3(tmp_scale));
		}

		/// <summary>Adds a scalar to each component of this matrix.</summary>
		/// <remarks>Adds a scalar to each component of this matrix.</remarks>
		/// <param name="scalar">the scalar adder</param>
		public void Add(float scalar)
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
		/// <param name="scalar">the scalar adder.</param>
		/// <param name="m1">the original matrix values</param>
		public void Add(float scalar, Matrix3f m1)
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
		public void Add(Matrix3f m1, Matrix3f m2)
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

		/// <summary>
		/// Sets the value of this matrix to the matrix sum of itself and
		/// matrix m1.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the matrix sum of itself and
		/// matrix m1.
		/// </remarks>
		/// <param name="m1">the other matrix</param>
		public void Add(Matrix3f m1)
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
		public void Sub(Matrix3f m1, Matrix3f m2)
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
		/// Sets the value of this matrix to the matrix difference
		/// of itself and matrix m1 (this = this - m1).
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the matrix difference
		/// of itself and matrix m1 (this = this - m1).
		/// </remarks>
		/// <param name="m1">the other matrix</param>
		public void Sub(Matrix3f m1)
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
			float temp;
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
		public void Transpose(Matrix3f m1)
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
		/// (single precision) quaternion argument.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the matrix conversion of the
		/// (single precision) quaternion argument.
		/// </remarks>
		/// <param name="q1">the quaternion to be converted</param>
		public void Set(Quat4f q1)
		{
			this.m00 = 1.0f - 2.0f * q1.y * q1.y - 2.0f * q1.z * q1.z;
			this.m10 = 2.0f * (q1.x * q1.y + q1.w * q1.z);
			this.m20 = 2.0f * (q1.x * q1.z - q1.w * q1.y);
			this.m01 = 2.0f * (q1.x * q1.y - q1.w * q1.z);
			this.m11 = 1.0f - 2.0f * q1.x * q1.x - 2.0f * q1.z * q1.z;
			this.m21 = 2.0f * (q1.y * q1.z + q1.w * q1.x);
			this.m02 = 2.0f * (q1.x * q1.z + q1.w * q1.y);
			this.m12 = 2.0f * (q1.y * q1.z - q1.w * q1.x);
			this.m22 = 1.0f - 2.0f * q1.x * q1.x - 2.0f * q1.y * q1.y;
		}

		/// <summary>
		/// Sets the value of this matrix to the matrix conversion of the
		/// (single precision) axis and angle argument.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the matrix conversion of the
		/// (single precision) axis and angle argument.
		/// </remarks>
		/// <param name="a1">the axis and angle to be converted</param>
		public void Set(AxisAngle4f a1)
		{
			float mag = (float)Math.Sqrt(a1.x * a1.x + a1.y * a1.y + a1.z * a1.z);
			if (mag < Eps)
			{
				m00 = 1.0f;
				m01 = 0.0f;
				m02 = 0.0f;
				m10 = 0.0f;
				m11 = 1.0f;
				m12 = 0.0f;
				m20 = 0.0f;
				m21 = 0.0f;
				m22 = 1.0f;
			}
			else
			{
				mag = 1.0f / mag;
				float ax = a1.x * mag;
				float ay = a1.y * mag;
				float az = a1.z * mag;
				float sinTheta = (float)Math.Sin((float)a1.angle);
				float cosTheta = (float)Math.Cos((float)a1.angle);
				float t = (float)1.0 - cosTheta;
				float xz = ax * az;
				float xy = ax * ay;
				float yz = ay * az;
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
		/// (double precision) axis and angle argument.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the matrix conversion of the
		/// (double precision) axis and angle argument.
		/// </remarks>
		/// <param name="a1">the axis and angle to be converted</param>
		public void Set(AxisAngle4d a1)
		{
			double mag = Math.Sqrt(a1.x * a1.x + a1.y * a1.y + a1.z * a1.z);
			if (mag < Eps)
			{
				m00 = 1.0f;
				m01 = 0.0f;
				m02 = 0.0f;
				m10 = 0.0f;
				m11 = 1.0f;
				m12 = 0.0f;
				m20 = 0.0f;
				m21 = 0.0f;
				m22 = 1.0f;
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
				m00 = (float)(t * ax * ax + cosTheta);
				m01 = (float)(t * xy - sinTheta * az);
				m02 = (float)(t * xz + sinTheta * ay);
				m10 = (float)(t * xy + sinTheta * az);
				m11 = (float)(t * ay * ay + cosTheta);
				m12 = (float)(t * yz - sinTheta * ax);
				m20 = (float)(t * xz - sinTheta * ay);
				m21 = (float)(t * yz + sinTheta * ax);
				m22 = (float)(t * az * az + cosTheta);
			}
		}

		/// <summary>
		/// Sets the value of this matrix to the matrix conversion of the
		/// (single precision) quaternion argument.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the matrix conversion of the
		/// (single precision) quaternion argument.
		/// </remarks>
		/// <param name="q1">the quaternion to be converted</param>
		public void Set(Quat4d q1)
		{
			this.m00 = (float)(1.0 - 2.0 * q1.y * q1.y - 2.0 * q1.z * q1.z);
			this.m10 = (float)(2.0 * (q1.x * q1.y + q1.w * q1.z));
			this.m20 = (float)(2.0 * (q1.x * q1.z - q1.w * q1.y));
			this.m01 = (float)(2.0 * (q1.x * q1.y - q1.w * q1.z));
			this.m11 = (float)(1.0 - 2.0 * q1.x * q1.x - 2.0 * q1.z * q1.z);
			this.m21 = (float)(2.0 * (q1.y * q1.z + q1.w * q1.x));
			this.m02 = (float)(2.0 * (q1.x * q1.z + q1.w * q1.y));
			this.m12 = (float)(2.0 * (q1.y * q1.z - q1.w * q1.x));
			this.m22 = (float)(1.0 - 2.0 * q1.x * q1.x - 2.0 * q1.y * q1.y);
		}

		/// <summary>
		/// Sets the values in this Matrix3f equal to the row-major
		/// array parameter (ie, the first three elements of the
		/// array will be copied into the first row of this matrix, etc.).
		/// </summary>
		/// <remarks>
		/// Sets the values in this Matrix3f equal to the row-major
		/// array parameter (ie, the first three elements of the
		/// array will be copied into the first row of this matrix, etc.).
		/// </remarks>
		/// <param name="m">the single precision array of length 9</param>
		public void Set(float[] m)
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
		/// Sets the value of this matrix to the value of the Matrix3f
		/// argument.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the value of the Matrix3f
		/// argument.
		/// </remarks>
		/// <param name="m1">the source matrix3f</param>
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
		/// Sets the value of this matrix to the float value of the Matrix3d
		/// argument.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the float value of the Matrix3d
		/// argument.
		/// </remarks>
		/// <param name="m1">the source matrix3d</param>
		public void Set(Matrix3d m1)
		{
			this.m00 = (float)m1.m00;
			this.m01 = (float)m1.m01;
			this.m02 = (float)m1.m02;
			this.m10 = (float)m1.m10;
			this.m11 = (float)m1.m11;
			this.m12 = (float)m1.m12;
			this.m20 = (float)m1.m20;
			this.m21 = (float)m1.m21;
			this.m22 = (float)m1.m22;
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
		public void Invert(Matrix3f m1)
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
		private void InvertGeneral(Matrix3f m1)
		{
			double[] temp = new double[9];
			double[] result = new double[9];
			int[] row_perm = new int[3];
			int i;
			int r;
			int c;
			// Use LU decomposition and backsubstitution code specifically
			// for floating-point 3x3 matrices.
			// Copy source matrix to t1tmp 
			temp[0] = (double)m1.m00;
			temp[1] = (double)m1.m01;
			temp[2] = (double)m1.m02;
			temp[3] = (double)m1.m10;
			temp[4] = (double)m1.m11;
			temp[5] = (double)m1.m12;
			temp[6] = (double)m1.m20;
			temp[7] = (double)m1.m21;
			temp[8] = (double)m1.m22;
			// Calculate LU decomposition: Is the matrix singular? 
			if (!LuDecomposition(temp, row_perm))
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
			LuBacksubstitution(temp, row_perm, result);
			this.m00 = (float)result[0];
			this.m01 = (float)result[1];
			this.m02 = (float)result[2];
			this.m10 = (float)result[3];
			this.m11 = (float)result[4];
			this.m12 = (float)result[5];
			this.m20 = (float)result[6];
			this.m21 = (float)result[7];
			this.m22 = (float)result[8];
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
		/// <returns>the determinant of this matrix</returns>
		public float Determinant()
		{
			float total;
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
		public void Set(float scale)
		{
			this.m00 = scale;
			this.m01 = (float)0.0;
			this.m02 = (float)0.0;
			this.m10 = (float)0.0;
			this.m11 = scale;
			this.m12 = (float)0.0;
			this.m20 = (float)0.0;
			this.m21 = (float)0.0;
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
		public void RotX(float angle)
		{
			float sinAngle;
			float cosAngle;
			sinAngle = (float)Math.Sin((double)angle);
			cosAngle = (float)Math.Cos((double)angle);
			this.m00 = (float)1.0;
			this.m01 = (float)0.0;
			this.m02 = (float)0.0;
			this.m10 = (float)0.0;
			this.m11 = cosAngle;
			this.m12 = -sinAngle;
			this.m20 = (float)0.0;
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
		public void RotY(float angle)
		{
			float sinAngle;
			float cosAngle;
			sinAngle = (float)Math.Sin((double)angle);
			cosAngle = (float)Math.Cos((double)angle);
			this.m00 = cosAngle;
			this.m01 = (float)0.0;
			this.m02 = sinAngle;
			this.m10 = (float)0.0;
			this.m11 = (float)1.0;
			this.m12 = (float)0.0;
			this.m20 = -sinAngle;
			this.m21 = (float)0.0;
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
		public void RotZ(float angle)
		{
			float sinAngle;
			float cosAngle;
			sinAngle = (float)Math.Sin((double)angle);
			cosAngle = (float)Math.Cos((double)angle);
			this.m00 = cosAngle;
			this.m01 = -sinAngle;
			this.m02 = (float)0.0;
			this.m10 = sinAngle;
			this.m11 = cosAngle;
			this.m12 = (float)0.0;
			this.m20 = (float)0.0;
			this.m21 = (float)0.0;
			this.m22 = (float)1.0;
		}

		/// <summary>Multiplies each element of this matrix by a scalar.</summary>
		/// <remarks>Multiplies each element of this matrix by a scalar.</remarks>
		/// <param name="scalar">the scalar multiplier</param>
		public void Mul(float scalar)
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
		public void Mul(float scalar, Matrix3f m1)
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
		public void Mul(Matrix3f m1)
		{
			float m00;
			float m01;
			float m02;
			float m10;
			float m11;
			float m12;
			float m20;
			float m21;
			float m22;
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
		public void Mul(Matrix3f m1, Matrix3f m2)
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
				float m00;
				float m01;
				float m02;
				float m10;
				float m11;
				float m12;
				float m20;
				float m21;
				float m22;
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
		/// of the result, and places the result back into this matrix.
		/// </summary>
		/// <remarks>
		/// Multiplies this matrix by matrix m1, does an SVD normalization
		/// of the result, and places the result back into this matrix.
		/// this = SVDnorm(this*m1).
		/// </remarks>
		/// <param name="m1">the matrix on the right hand side of the multiplication</param>
		public void MulNormalize(Matrix3f m1)
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
			Matrix3d.Compute_svd(tmp, tmp_scale, tmp_rot);
			this.m00 = (float)(tmp_rot[0]);
			this.m01 = (float)(tmp_rot[1]);
			this.m02 = (float)(tmp_rot[2]);
			this.m10 = (float)(tmp_rot[3]);
			this.m11 = (float)(tmp_rot[4]);
			this.m12 = (float)(tmp_rot[5]);
			this.m20 = (float)(tmp_rot[6]);
			this.m21 = (float)(tmp_rot[7]);
			this.m22 = (float)(tmp_rot[8]);
		}

		/// <summary>
		/// Multiplies matrix m1 by matrix m2, does an SVD normalization
		/// of the result, and places the result into this matrix.
		/// </summary>
		/// <remarks>
		/// Multiplies matrix m1 by matrix m2, does an SVD normalization
		/// of the result, and places the result into this matrix.
		/// this = SVDnorm(m1*m2).
		/// </remarks>
		/// <param name="m1">the matrix on the left hand side of the multiplication</param>
		/// <param name="m2">the matrix on the right hand side of the multiplication</param>
		public void MulNormalize(Matrix3f m1, Matrix3f m2)
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
			Matrix3d.Compute_svd(tmp, tmp_scale, tmp_rot);
			this.m00 = (float)(tmp_rot[0]);
			this.m01 = (float)(tmp_rot[1]);
			this.m02 = (float)(tmp_rot[2]);
			this.m10 = (float)(tmp_rot[3]);
			this.m11 = (float)(tmp_rot[4]);
			this.m12 = (float)(tmp_rot[5]);
			this.m20 = (float)(tmp_rot[6]);
			this.m21 = (float)(tmp_rot[7]);
			this.m22 = (float)(tmp_rot[8]);
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
		public void MulTransposeBoth(Matrix3f m1, Matrix3f m2)
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
				float m00;
				float m01;
				float m02;
				float m10;
				float m11;
				float m12;
				float m20;
				float m21;
				float m22;
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
		public void MulTransposeRight(Matrix3f m1, Matrix3f m2)
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
				float m00;
				float m01;
				float m02;
				float m10;
				float m11;
				float m12;
				float m20;
				float m21;
				float m22;
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
		public void MulTransposeLeft(Matrix3f m1, Matrix3f m2)
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
				float m00;
				float m01;
				float m02;
				float m10;
				float m11;
				float m12;
				float m20;
				float m21;
				float m22;
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
			this.m00 = (float)tmp_rot[0];
			this.m01 = (float)tmp_rot[1];
			this.m02 = (float)tmp_rot[2];
			this.m10 = (float)tmp_rot[3];
			this.m11 = (float)tmp_rot[4];
			this.m12 = (float)tmp_rot[5];
			this.m20 = (float)tmp_rot[6];
			this.m21 = (float)tmp_rot[7];
			this.m22 = (float)tmp_rot[8];
		}

		/// <summary>
		/// Perform singular value decomposition normalization of matrix m1
		/// and place the normalized values into this.
		/// </summary>
		/// <remarks>
		/// Perform singular value decomposition normalization of matrix m1
		/// and place the normalized values into this.
		/// </remarks>
		/// <param name="m1">the matrix values to be normalized</param>
		public void Normalize(Matrix3f m1)
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
			Matrix3d.Compute_svd(tmp, tmp_scale, tmp_rot);
			this.m00 = (float)(tmp_rot[0]);
			this.m01 = (float)(tmp_rot[1]);
			this.m02 = (float)(tmp_rot[2]);
			this.m10 = (float)(tmp_rot[3]);
			this.m11 = (float)(tmp_rot[4]);
			this.m12 = (float)(tmp_rot[5]);
			this.m20 = (float)(tmp_rot[6]);
			this.m21 = (float)(tmp_rot[7]);
			this.m22 = (float)(tmp_rot[8]);
		}

		/// <summary>Perform cross product normalization of this matrix.</summary>
		/// <remarks>Perform cross product normalization of this matrix.</remarks>
		public void NormalizeCP()
		{
			float mag = 1.0f / (float)Math.Sqrt(m00 * m00 + m10 * m10 + m20 * m20);
			m00 = m00 * mag;
			m10 = m10 * mag;
			m20 = m20 * mag;
			mag = 1.0f / (float)Math.Sqrt(m01 * m01 + m11 * m11 + m21 * m21);
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
		public void NormalizeCP(Matrix3f m1)
		{
			float mag = 1.0f / (float)Math.Sqrt(m1.m00 * m1.m00 + m1.m10 * m1.m10 + m1.m20 * 
				m1.m20);
			m00 = m1.m00 * mag;
			m10 = m1.m10 * mag;
			m20 = m1.m20 * mag;
			mag = 1.0f / (float)Math.Sqrt(m1.m01 * m1.m01 + m1.m11 * m1.m11 + m1.m21 * m1.m21
				);
			m01 = m1.m01 * mag;
			m11 = m1.m11 * mag;
			m21 = m1.m21 * mag;
			m02 = m10 * m21 - m11 * m20;
			m12 = m01 * m20 - m00 * m21;
			m22 = m00 * m11 - m01 * m10;
		}

		/// <summary>
		/// Returns true if all of the data members of Matrix3f m1 are
		/// equal to the corresponding data members in this Matrix3f.
		/// </summary>
		/// <remarks>
		/// Returns true if all of the data members of Matrix3f m1 are
		/// equal to the corresponding data members in this Matrix3f.
		/// </remarks>
		/// <param name="m1">the matrix with which the comparison is made</param>
		/// <returns>true or false</returns>
		public virtual bool Equals(Matrix3f m1)
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
		/// Returns true if the Object o1 is of type Matrix3f and all of the
		/// data members of o1 are equal to the corresponding data members in
		/// this Matrix3f.
		/// </summary>
		/// <remarks>
		/// Returns true if the Object o1 is of type Matrix3f and all of the
		/// data members of o1 are equal to the corresponding data members in
		/// this Matrix3f.
		/// </remarks>
		/// <param name="o1">the object with which the comparison is made</param>
		/// <returns>true or false</returns>
		public override bool Equals(object o1)
		{
			try
			{
				Matrix3f m2 = (Matrix3f)o1;
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
		public virtual bool EpsilonEquals(Matrix3f m1, float epsilon)
		{
			bool status = true;
			if (Math.Abs(this.m00 - m1.m00) > epsilon)
			{
				status = false;
			}
			if (Math.Abs(this.m01 - m1.m01) > epsilon)
			{
				status = false;
			}
			if (Math.Abs(this.m02 - m1.m02) > epsilon)
			{
				status = false;
			}
			if (Math.Abs(this.m10 - m1.m10) > epsilon)
			{
				status = false;
			}
			if (Math.Abs(this.m11 - m1.m11) > epsilon)
			{
				status = false;
			}
			if (Math.Abs(this.m12 - m1.m12) > epsilon)
			{
				status = false;
			}
			if (Math.Abs(this.m20 - m1.m20) > epsilon)
			{
				status = false;
			}
			if (Math.Abs(this.m21 - m1.m21) > epsilon)
			{
				status = false;
			}
			if (Math.Abs(this.m22 - m1.m22) > epsilon)
			{
				status = false;
			}
			return (status);
		}

		/// <summary>
		/// Returns a hash code value based on the data values in this
		/// object.
		/// </summary>
		/// <remarks>
		/// Returns a hash code value based on the data values in this
		/// object.  Two different Matrix3f objects with identical data values
		/// (i.e., Matrix3f.equals returns true) will return the same hash
		/// code value.  Two objects with different data members may return the
		/// same hash value, although this is not likely.
		/// </remarks>
		/// <returns>the integer hash code value</returns>
		public override int GetHashCode()
		{
			long bits = 1L;
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m00);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m01);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m02);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m10);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m11);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m12);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m20);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m21);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m22);
			return (int)(bits ^ (bits >> 32));
		}

		/// <summary>Sets this matrix to all zeros.</summary>
		/// <remarks>Sets this matrix to all zeros.</remarks>
		public void SetZero()
		{
			m00 = 0.0f;
			m01 = 0.0f;
			m02 = 0.0f;
			m10 = 0.0f;
			m11 = 0.0f;
			m12 = 0.0f;
			m20 = 0.0f;
			m21 = 0.0f;
			m22 = 0.0f;
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
		/// of the Matrix3f parameter.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix equal to the negation of
		/// of the Matrix3f parameter.
		/// </remarks>
		/// <param name="m1">the source matrix</param>
		public void Negate(Matrix3f m1)
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
		public void Transform(Tuple3f t)
		{
			float x;
			float y;
			float z;
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
		public void Transform(Tuple3f t, Tuple3f result)
		{
			float x;
			float y;
			float z;
			x = m00 * t.x + m01 * t.y + m02 * t.z;
			y = m10 * t.x + m11 * t.y + m12 * t.z;
			result.z = m20 * t.x + m21 * t.y + m22 * t.z;
			result.x = x;
			result.y = y;
		}

		/// <summary>perform SVD (if necessary to get rotational component</summary>
		internal virtual void GetScaleRotate(double[] scales, double[] rot)
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
			Matrix3d.Compute_svd(tmp, scales, rot);
			return;
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
			Matrix3f m1 = null;
			m1 = (Matrix3f)base.MemberwiseClone();
			// this shouldn't happen, since we are Cloneable
			return m1;
		}

		/// <summary>Get the first matrix element in the first row.</summary>
		/// <remarks>Get the first matrix element in the first row.</remarks>
		/// <returns>Returns the m00.</returns>
		/// <since>vecmath 1.5</since>
		public float GetM00()
		{
			return m00;
		}

		/// <summary>Set the first matrix element in the first row.</summary>
		/// <remarks>Set the first matrix element in the first row.</remarks>
		/// <param name="m00">The m00 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM00(float m00)
		{
			this.m00 = m00;
		}

		/// <summary>Get the second matrix element in the first row.</summary>
		/// <remarks>Get the second matrix element in the first row.</remarks>
		/// <returns>Returns the m01.</returns>
		/// <since>vecmath 1.5</since>
		public float GetM01()
		{
			return m01;
		}

		/// <summary>Set the second matrix element in the first row.</summary>
		/// <remarks>Set the second matrix element in the first row.</remarks>
		/// <param name="m01">The m01 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM01(float m01)
		{
			this.m01 = m01;
		}

		/// <summary>Get the third matrix element in the first row.</summary>
		/// <remarks>Get the third matrix element in the first row.</remarks>
		/// <returns>Returns the m02.</returns>
		/// <since>vecmath 1.5</since>
		public float GetM02()
		{
			return m02;
		}

		/// <summary>Set the third matrix element in the first row.</summary>
		/// <remarks>Set the third matrix element in the first row.</remarks>
		/// <param name="m02">The m02 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM02(float m02)
		{
			this.m02 = m02;
		}

		/// <summary>Get first matrix element in the second row.</summary>
		/// <remarks>Get first matrix element in the second row.</remarks>
		/// <returns>Returns the m10.</returns>
		/// <since>vecmath 1.5</since>
		public float GetM10()
		{
			return m10;
		}

		/// <summary>Set first matrix element in the second row.</summary>
		/// <remarks>Set first matrix element in the second row.</remarks>
		/// <param name="m10">The m10 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM10(float m10)
		{
			this.m10 = m10;
		}

		/// <summary>Get second matrix element in the second row.</summary>
		/// <remarks>Get second matrix element in the second row.</remarks>
		/// <returns>Returns the m11.</returns>
		/// <since>vecmath 1.5</since>
		public float GetM11()
		{
			return m11;
		}

		/// <summary>Set the second matrix element in the second row.</summary>
		/// <remarks>Set the second matrix element in the second row.</remarks>
		/// <param name="m11">The m11 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM11(float m11)
		{
			this.m11 = m11;
		}

		/// <summary>Get the third matrix element in the second row.</summary>
		/// <remarks>Get the third matrix element in the second row.</remarks>
		/// <returns>Returns the m12.</returns>
		/// <since>vecmath 1.5</since>
		public float GetM12()
		{
			return m12;
		}

		/// <summary>Set the third matrix element in the second row.</summary>
		/// <remarks>Set the third matrix element in the second row.</remarks>
		/// <param name="m12">The m12 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM12(float m12)
		{
			this.m12 = m12;
		}

		/// <summary>Get the first matrix element in the third row.</summary>
		/// <remarks>Get the first matrix element in the third row.</remarks>
		/// <returns>Returns the m20.</returns>
		/// <since>vecmath 1.5</since>
		public float GetM20()
		{
			return m20;
		}

		/// <summary>Set the first matrix element in the third row.</summary>
		/// <remarks>Set the first matrix element in the third row.</remarks>
		/// <param name="m20">The m20 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM20(float m20)
		{
			this.m20 = m20;
		}

		/// <summary>Get the second matrix element in the third row.</summary>
		/// <remarks>Get the second matrix element in the third row.</remarks>
		/// <returns>Returns the m21.</returns>
		/// <since>vecmath 1.5</since>
		public float GetM21()
		{
			return m21;
		}

		/// <summary>Set the second matrix element in the third row.</summary>
		/// <remarks>Set the second matrix element in the third row.</remarks>
		/// <param name="m21">The m21 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM21(float m21)
		{
			this.m21 = m21;
		}

		/// <summary>Get the third matrix element in the third row .</summary>
		/// <remarks>Get the third matrix element in the third row .</remarks>
		/// <returns>Returns the m22.</returns>
		/// <since>vecmath 1.5</since>
		public float GetM22()
		{
			return m22;
		}

		/// <summary>Set the third matrix element in the third row.</summary>
		/// <remarks>Set the third matrix element in the third row.</remarks>
		/// <param name="m22">The m22 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM22(float m22)
		{
			this.m22 = m22;
		}
	}
}
