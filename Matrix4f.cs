/*
 * Automated conversion
 */

using System;

namespace NVecMath
{
	/// <summary>A single precision floating point 4 by 4 matrix.</summary>
	/// <remarks>
	/// A single precision floating point 4 by 4 matrix.
	/// Primarily to support 3D rotations.
	/// </remarks>
	[System.Serializable]
	public class Matrix4f : ICloneable
	{
		internal const long serialVersionUID = -8405036035410109353L;

		/// <summary>The first element of the first row.</summary>
		/// <remarks>The first element of the first row.</remarks>
		public float m00;

		/// <summary>The second element of the first row.</summary>
		/// <remarks>The second element of the first row.</remarks>
		public float m01;

		/// <summary>The third element of the first row.</summary>
		/// <remarks>The third element of the first row.</remarks>
		public float m02;

		/// <summary>The fourth element of the first row.</summary>
		/// <remarks>The fourth element of the first row.</remarks>
		public float m03;

		/// <summary>The first element of the second row.</summary>
		/// <remarks>The first element of the second row.</remarks>
		public float m10;

		/// <summary>The second element of the second row.</summary>
		/// <remarks>The second element of the second row.</remarks>
		public float m11;

		/// <summary>The third element of the second row.</summary>
		/// <remarks>The third element of the second row.</remarks>
		public float m12;

		/// <summary>The fourth element of the second row.</summary>
		/// <remarks>The fourth element of the second row.</remarks>
		public float m13;

		/// <summary>The first element of the third row.</summary>
		/// <remarks>The first element of the third row.</remarks>
		public float m20;

		/// <summary>The second element of the third row.</summary>
		/// <remarks>The second element of the third row.</remarks>
		public float m21;

		/// <summary>The third element of the third row.</summary>
		/// <remarks>The third element of the third row.</remarks>
		public float m22;

		/// <summary>The fourth element of the third row.</summary>
		/// <remarks>The fourth element of the third row.</remarks>
		public float m23;

		/// <summary>The first element of the fourth row.</summary>
		/// <remarks>The first element of the fourth row.</remarks>
		public float m30;

		/// <summary>The second element of the fourth row.</summary>
		/// <remarks>The second element of the fourth row.</remarks>
		public float m31;

		/// <summary>The third element of the fourth row.</summary>
		/// <remarks>The third element of the fourth row.</remarks>
		public float m32;

		/// <summary>The fourth element of the fourth row.</summary>
		/// <remarks>The fourth element of the fourth row.</remarks>
		public float m33;

		private const double Eps = 1.0E-8;

		/// <summary>Constructs and initializes a Matrix4f from the specified 16 values.</summary>
		/// <remarks>Constructs and initializes a Matrix4f from the specified 16 values.</remarks>
		/// <param name="m00">the [0][0] element</param>
		/// <param name="m01">the [0][1] element</param>
		/// <param name="m02">the [0][2] element</param>
		/// <param name="m03">the [0][3] element</param>
		/// <param name="m10">the [1][0] element</param>
		/// <param name="m11">the [1][1] element</param>
		/// <param name="m12">the [1][2] element</param>
		/// <param name="m13">the [1][3] element</param>
		/// <param name="m20">the [2][0] element</param>
		/// <param name="m21">the [2][1] element</param>
		/// <param name="m22">the [2][2] element</param>
		/// <param name="m23">the [2][3] element</param>
		/// <param name="m30">the [3][0] element</param>
		/// <param name="m31">the [3][1] element</param>
		/// <param name="m32">the [3][2] element</param>
		/// <param name="m33">the [3][3] element</param>
		public Matrix4f(float m00, float m01, float m02, float m03, float m10, float m11, 
			float m12, float m13, float m20, float m21, float m22, float m23, float m30, float
			 m31, float m32, float m33)
		{
			// Compatible with 1.1
			this.m00 = m00;
			this.m01 = m01;
			this.m02 = m02;
			this.m03 = m03;
			this.m10 = m10;
			this.m11 = m11;
			this.m12 = m12;
			this.m13 = m13;
			this.m20 = m20;
			this.m21 = m21;
			this.m22 = m22;
			this.m23 = m23;
			this.m30 = m30;
			this.m31 = m31;
			this.m32 = m32;
			this.m33 = m33;
		}

		/// <summary>
		/// Constructs and initializes a Matrix4f from the specified 16
		/// element array.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a Matrix4f from the specified 16
		/// element array.  this.m00 =v[0], this.m01=v[1], etc.
		/// </remarks>
		/// <param name="v">the array of length 16 containing in order</param>
		public Matrix4f(float[] v)
		{
			this.m00 = v[0];
			this.m01 = v[1];
			this.m02 = v[2];
			this.m03 = v[3];
			this.m10 = v[4];
			this.m11 = v[5];
			this.m12 = v[6];
			this.m13 = v[7];
			this.m20 = v[8];
			this.m21 = v[9];
			this.m22 = v[10];
			this.m23 = v[11];
			this.m30 = v[12];
			this.m31 = v[13];
			this.m32 = v[14];
			this.m33 = v[15];
		}

		/// <summary>
		/// Constructs and initializes a Matrix4f from the quaternion,
		/// translation, and scale values; the scale is applied only to the
		/// rotational components of the matrix (upper 3x3) and not to the
		/// translational components.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a Matrix4f from the quaternion,
		/// translation, and scale values; the scale is applied only to the
		/// rotational components of the matrix (upper 3x3) and not to the
		/// translational components.
		/// </remarks>
		/// <param name="q1">the quaternion value representing the rotational component</param>
		/// <param name="t1">the translational component of the matrix</param>
		/// <param name="s">the scale value applied to the rotational components</param>
		public Matrix4f(Quat4f q1, Vector3f t1, float s)
		{
			m00 = (float)(s * (1.0 - 2.0 * q1.y * q1.y - 2.0 * q1.z * q1.z));
			m10 = (float)(s * (2.0 * (q1.x * q1.y + q1.w * q1.z)));
			m20 = (float)(s * (2.0 * (q1.x * q1.z - q1.w * q1.y)));
			m01 = (float)(s * (2.0 * (q1.x * q1.y - q1.w * q1.z)));
			m11 = (float)(s * (1.0 - 2.0 * q1.x * q1.x - 2.0 * q1.z * q1.z));
			m21 = (float)(s * (2.0 * (q1.y * q1.z + q1.w * q1.x)));
			m02 = (float)(s * (2.0 * (q1.x * q1.z + q1.w * q1.y)));
			m12 = (float)(s * (2.0 * (q1.y * q1.z - q1.w * q1.x)));
			m22 = (float)(s * (1.0 - 2.0 * q1.x * q1.x - 2.0 * q1.y * q1.y));
			m03 = t1.x;
			m13 = t1.y;
			m23 = t1.z;
			m30 = 0.0f;
			m31 = 0.0f;
			m32 = 0.0f;
			m33 = 1.0f;
		}

		/// <summary>
		/// Constructs a new matrix with the same values as the
		/// Matrix4d parameter.
		/// </summary>
		/// <remarks>
		/// Constructs a new matrix with the same values as the
		/// Matrix4d parameter.
		/// </remarks>
		/// <param name="m1">the source matrix</param>
		public Matrix4f(Matrix4d m1)
		{
			this.m00 = (float)m1.m00;
			this.m01 = (float)m1.m01;
			this.m02 = (float)m1.m02;
			this.m03 = (float)m1.m03;
			this.m10 = (float)m1.m10;
			this.m11 = (float)m1.m11;
			this.m12 = (float)m1.m12;
			this.m13 = (float)m1.m13;
			this.m20 = (float)m1.m20;
			this.m21 = (float)m1.m21;
			this.m22 = (float)m1.m22;
			this.m23 = (float)m1.m23;
			this.m30 = (float)m1.m30;
			this.m31 = (float)m1.m31;
			this.m32 = (float)m1.m32;
			this.m33 = (float)m1.m33;
		}

		/// <summary>
		/// Constructs a new matrix with the same values as the
		/// Matrix4f parameter.
		/// </summary>
		/// <remarks>
		/// Constructs a new matrix with the same values as the
		/// Matrix4f parameter.
		/// </remarks>
		/// <param name="m1">the source matrix</param>
		public Matrix4f(Matrix4f m1)
		{
			this.m00 = m1.m00;
			this.m01 = m1.m01;
			this.m02 = m1.m02;
			this.m03 = m1.m03;
			this.m10 = m1.m10;
			this.m11 = m1.m11;
			this.m12 = m1.m12;
			this.m13 = m1.m13;
			this.m20 = m1.m20;
			this.m21 = m1.m21;
			this.m22 = m1.m22;
			this.m23 = m1.m23;
			this.m30 = m1.m30;
			this.m31 = m1.m31;
			this.m32 = m1.m32;
			this.m33 = m1.m33;
		}

		/// <summary>
		/// Constructs and initializes a Matrix4f from the rotation matrix,
		/// translation, and scale values; the scale is applied only to the
		/// rotational components of the matrix (upper 3x3) and not to the
		/// translational components of the matrix.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a Matrix4f from the rotation matrix,
		/// translation, and scale values; the scale is applied only to the
		/// rotational components of the matrix (upper 3x3) and not to the
		/// translational components of the matrix.
		/// </remarks>
		/// <param name="m1">the rotation matrix representing the rotational components</param>
		/// <param name="t1">the translational components of the matrix</param>
		/// <param name="s">the scale value applied to the rotational components</param>
		public Matrix4f(Matrix3f m1, Vector3f t1, float s)
		{
			this.m00 = m1.m00 * s;
			this.m01 = m1.m01 * s;
			this.m02 = m1.m02 * s;
			this.m03 = t1.x;
			this.m10 = m1.m10 * s;
			this.m11 = m1.m11 * s;
			this.m12 = m1.m12 * s;
			this.m13 = t1.y;
			this.m20 = m1.m20 * s;
			this.m21 = m1.m21 * s;
			this.m22 = m1.m22 * s;
			this.m23 = t1.z;
			this.m30 = 0.0f;
			this.m31 = 0.0f;
			this.m32 = 0.0f;
			this.m33 = 1.0f;
		}

		/// <summary>Constructs and initializes a Matrix4f to all zeros.</summary>
		/// <remarks>Constructs and initializes a Matrix4f to all zeros.</remarks>
		public Matrix4f()
		{
			this.m00 = (float)0.0;
			this.m01 = (float)0.0;
			this.m02 = (float)0.0;
			this.m03 = (float)0.0;
			this.m10 = (float)0.0;
			this.m11 = (float)0.0;
			this.m12 = (float)0.0;
			this.m13 = (float)0.0;
			this.m20 = (float)0.0;
			this.m21 = (float)0.0;
			this.m22 = (float)0.0;
			this.m23 = (float)0.0;
			this.m30 = (float)0.0;
			this.m31 = (float)0.0;
			this.m32 = (float)0.0;
			this.m33 = (float)0.0;
		}

		/// <summary>Returns a string that contains the values of this Matrix4f.</summary>
		/// <remarks>Returns a string that contains the values of this Matrix4f.</remarks>
		/// <returns>the String representation</returns>
		public override string ToString()
		{
			return this.m00 + ", " + this.m01 + ", " + this.m02 + ", " + this.m03 + "\n" + this
				.m10 + ", " + this.m11 + ", " + this.m12 + ", " + this.m13 + "\n" + this.m20 + ", "
				 + this.m21 + ", " + this.m22 + ", " + this.m23 + "\n" + this.m30 + ", " + this.
				m31 + ", " + this.m32 + ", " + this.m33 + "\n";
		}

		/// <summary>Sets this Matrix4f to identity.</summary>
		/// <remarks>Sets this Matrix4f to identity.</remarks>
		public void SetIdentity()
		{
			this.m00 = (float)1.0;
			this.m01 = (float)0.0;
			this.m02 = (float)0.0;
			this.m03 = (float)0.0;
			this.m10 = (float)0.0;
			this.m11 = (float)1.0;
			this.m12 = (float)0.0;
			this.m13 = (float)0.0;
			this.m20 = (float)0.0;
			this.m21 = (float)0.0;
			this.m22 = (float)1.0;
			this.m23 = (float)0.0;
			this.m30 = (float)0.0;
			this.m31 = (float)0.0;
			this.m32 = (float)0.0;
			this.m33 = (float)1.0;
		}

		/// <summary>Sets the specified element of this matrix4f to the value provided.</summary>
		/// <remarks>Sets the specified element of this matrix4f to the value provided.</remarks>
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

						case 3:
						{
							this.m03 = value;
							break;
						}

						default:
						{
							throw new IndexOutOfRangeException("Matrix4f setElement");
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

						case 3:
						{
							this.m13 = value;
							break;
						}

						default:
						{
							throw new IndexOutOfRangeException("Matrix4f setElement");
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

						case 3:
						{
							this.m23 = value;
							break;
						}

						default:
						{
							throw new IndexOutOfRangeException("Matrix4f setElement");
						}
					}
					break;
				}

				case 3:
				{
					switch (column)
					{
						case 0:
						{
							this.m30 = value;
							break;
						}

						case 1:
						{
							this.m31 = value;
							break;
						}

						case 2:
						{
							this.m32 = value;
							break;
						}

						case 3:
						{
							this.m33 = value;
							break;
						}

						default:
						{
							throw new IndexOutOfRangeException("Matrix4f setElement");
						}
					}
					break;
				}

				default:
				{
					throw new IndexOutOfRangeException("Matrix4f setElement");
				}
			}
		}

		/// <summary>Retrieves the value at the specified row and column of this matrix.</summary>
		/// <remarks>Retrieves the value at the specified row and column of this matrix.</remarks>
		/// <param name="row">the row number to be retrieved (zero indexed)</param>
		/// <param name="column">the column number to be retrieved (zero indexed)</param>
		/// <returns>the value at the indexed element</returns>
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

						case 3:
						{
							return (this.m03);
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

						case 3:
						{
							return (this.m13);
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

						case 3:
						{
							return (this.m23);
						}

						default:
						{
							break;
							break;
						}
					}
					break;
				}

				case 3:
				{
					switch (column)
					{
						case 0:
						{
							return (this.m30);
						}

						case 1:
						{
							return (this.m31);
						}

						case 2:
						{
							return (this.m32);
						}

						case 3:
						{
							return (this.m33);
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
			throw new IndexOutOfRangeException("Matrix4f getElement");
		}

		/// <summary>Copies the matrix values in the specified row into the vector parameter.
		/// 	</summary>
		/// <remarks>Copies the matrix values in the specified row into the vector parameter.
		/// 	</remarks>
		/// <param name="row">the matrix row</param>
		/// <param name="v">the vector into which the matrix row values will be copied</param>
		public void GetRow(int row, Vector4f v)
		{
			if (row == 0)
			{
				v.x = m00;
				v.y = m01;
				v.z = m02;
				v.w = m03;
			}
			else
			{
				if (row == 1)
				{
					v.x = m10;
					v.y = m11;
					v.z = m12;
					v.w = m13;
				}
				else
				{
					if (row == 2)
					{
						v.x = m20;
						v.y = m21;
						v.z = m22;
						v.w = m23;
					}
					else
					{
						if (row == 3)
						{
							v.x = m30;
							v.y = m31;
							v.z = m32;
							v.w = m33;
						}
						else
						{
							throw new IndexOutOfRangeException("Matrix4f getRow");
						}
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
				v[3] = m03;
			}
			else
			{
				if (row == 1)
				{
					v[0] = m10;
					v[1] = m11;
					v[2] = m12;
					v[3] = m13;
				}
				else
				{
					if (row == 2)
					{
						v[0] = m20;
						v[1] = m21;
						v[2] = m22;
						v[3] = m23;
					}
					else
					{
						if (row == 3)
						{
							v[0] = m30;
							v[1] = m31;
							v[2] = m32;
							v[3] = m33;
						}
						else
						{
							throw new IndexOutOfRangeException("Matrix4f getRow");
						}
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
		public void GetColumn(int column, Vector4f v)
		{
			if (column == 0)
			{
				v.x = m00;
				v.y = m10;
				v.z = m20;
				v.w = m30;
			}
			else
			{
				if (column == 1)
				{
					v.x = m01;
					v.y = m11;
					v.z = m21;
					v.w = m31;
				}
				else
				{
					if (column == 2)
					{
						v.x = m02;
						v.y = m12;
						v.z = m22;
						v.w = m32;
					}
					else
					{
						if (column == 3)
						{
							v.x = m03;
							v.y = m13;
							v.z = m23;
							v.w = m33;
						}
						else
						{
							throw new IndexOutOfRangeException("Matrix4f getColumn");
						}
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
				v[3] = m30;
			}
			else
			{
				if (column == 1)
				{
					v[0] = m01;
					v[1] = m11;
					v[2] = m21;
					v[3] = m31;
				}
				else
				{
					if (column == 2)
					{
						v[0] = m02;
						v[1] = m12;
						v[2] = m22;
						v[3] = m32;
					}
					else
					{
						if (column == 3)
						{
							v[0] = m03;
							v[1] = m13;
							v[2] = m23;
							v[3] = m33;
						}
						else
						{
							throw new IndexOutOfRangeException("Matrix4f getColumn");
						}
					}
				}
			}
		}

		/// <summary>
		/// Sets the scale component of the current matrix by factoring
		/// out the current scale (by doing an SVD) from the rotational
		/// component and multiplying by the new scale.
		/// </summary>
		/// <remarks>
		/// Sets the scale component of the current matrix by factoring
		/// out the current scale (by doing an SVD) from the rotational
		/// component and multiplying by the new scale.
		/// </remarks>
		/// <param name="scale">the new scale amount</param>
		public void SetScale(float scale)
		{
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			GetScaleRotate(tmp_scale, tmp_rot);
			m00 = (float)(tmp_rot[0] * scale);
			m01 = (float)(tmp_rot[1] * scale);
			m02 = (float)(tmp_rot[2] * scale);
			m10 = (float)(tmp_rot[3] * scale);
			m11 = (float)(tmp_rot[4] * scale);
			m12 = (float)(tmp_rot[5] * scale);
			m20 = (float)(tmp_rot[6] * scale);
			m21 = (float)(tmp_rot[7] * scale);
			m22 = (float)(tmp_rot[8] * scale);
		}

		/// <summary>
		/// Performs an SVD normalization of this matrix in order to acquire
		/// the normalized rotational component; the values are placed into
		/// the Matrix3d parameter.
		/// </summary>
		/// <remarks>
		/// Performs an SVD normalization of this matrix in order to acquire
		/// the normalized rotational component; the values are placed into
		/// the Matrix3d parameter.
		/// </remarks>
		/// <param name="m1">matrix into which the rotational component is placed</param>
		public void Get(Matrix3d m1)
		{
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			GetScaleRotate(tmp_scale, tmp_rot);
			m1.m00 = tmp_rot[0];
			m1.m01 = tmp_rot[1];
			m1.m02 = tmp_rot[2];
			m1.m10 = tmp_rot[3];
			m1.m11 = tmp_rot[4];
			m1.m12 = tmp_rot[5];
			m1.m20 = tmp_rot[6];
			m1.m21 = tmp_rot[7];
			m1.m22 = tmp_rot[8];
		}

		/// <summary>
		/// Performs an SVD normalization of this matrix in order to acquire
		/// the normalized rotational component; the values are placed into
		/// the Matrix3f parameter.
		/// </summary>
		/// <remarks>
		/// Performs an SVD normalization of this matrix in order to acquire
		/// the normalized rotational component; the values are placed into
		/// the Matrix3f parameter.
		/// </remarks>
		/// <param name="m1">matrix into which the rotational component is placed</param>
		public void Get(Matrix3f m1)
		{
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			GetScaleRotate(tmp_scale, tmp_rot);
			m1.m00 = (float)tmp_rot[0];
			m1.m01 = (float)tmp_rot[1];
			m1.m02 = (float)tmp_rot[2];
			m1.m10 = (float)tmp_rot[3];
			m1.m11 = (float)tmp_rot[4];
			m1.m12 = (float)tmp_rot[5];
			m1.m20 = (float)tmp_rot[6];
			m1.m21 = (float)tmp_rot[7];
			m1.m22 = (float)tmp_rot[8];
		}

		/// <summary>
		/// Performs an SVD normalization of this matrix to calculate
		/// the rotation as a 3x3 matrix, the translation, and the scale.
		/// </summary>
		/// <remarks>
		/// Performs an SVD normalization of this matrix to calculate
		/// the rotation as a 3x3 matrix, the translation, and the scale.
		/// None of the matrix values are modified.
		/// </remarks>
		/// <param name="m1">the normalized matrix representing the rotation</param>
		/// <param name="t1">the translation component</param>
		/// <returns>the scale component of this transform</returns>
		public float Get(Matrix3f m1, Vector3f t1)
		{
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			GetScaleRotate(tmp_scale, tmp_rot);
			m1.m00 = (float)tmp_rot[0];
			m1.m01 = (float)tmp_rot[1];
			m1.m02 = (float)tmp_rot[2];
			m1.m10 = (float)tmp_rot[3];
			m1.m11 = (float)tmp_rot[4];
			m1.m12 = (float)tmp_rot[5];
			m1.m20 = (float)tmp_rot[6];
			m1.m21 = (float)tmp_rot[7];
			m1.m22 = (float)tmp_rot[8];
			t1.x = m03;
			t1.y = m13;
			t1.z = m23;
			return ((float)Matrix3d.Max3(tmp_scale));
		}

		/// <summary>
		/// Performs an SVD normalization of this matrix in order to acquire
		/// the normalized rotational component; the values are placed into
		/// the Quat4f parameter.
		/// </summary>
		/// <remarks>
		/// Performs an SVD normalization of this matrix in order to acquire
		/// the normalized rotational component; the values are placed into
		/// the Quat4f parameter.
		/// </remarks>
		/// <param name="q1">quaternion into which the rotation component is placed</param>
		public void Get(Quat4f q1)
		{
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			GetScaleRotate(tmp_scale, tmp_rot);
			double ww;
			ww = 0.25 * (1.0 + tmp_rot[0] + tmp_rot[4] + tmp_rot[8]);
			if (!((ww < 0 ? -ww : ww) < 1.0e-30))
			{
				q1.w = (float)Math.Sqrt(ww);
				ww = 0.25 / q1.w;
				q1.x = (float)((tmp_rot[7] - tmp_rot[5]) * ww);
				q1.y = (float)((tmp_rot[2] - tmp_rot[6]) * ww);
				q1.z = (float)((tmp_rot[3] - tmp_rot[1]) * ww);
				return;
			}
			q1.w = 0.0f;
			ww = -0.5 * (tmp_rot[4] + tmp_rot[8]);
			if (!((ww < 0 ? -ww : ww) < 1.0e-30))
			{
				q1.x = (float)Math.Sqrt(ww);
				ww = 0.5 / q1.x;
				q1.y = (float)(tmp_rot[3] * ww);
				q1.z = (float)(tmp_rot[6] * ww);
				return;
			}
			q1.x = 0.0f;
			ww = 0.5 * (1.0 - tmp_rot[8]);
			if (!((ww < 0 ? -ww : ww) < 1.0e-30))
			{
				q1.y = (float)(Math.Sqrt(ww));
				q1.z = (float)(tmp_rot[7] / (2.0 * q1.y));
				return;
			}
			q1.y = 0.0f;
			q1.z = 1.0f;
		}

		/// <summary>Retrieves the translational components of this matrix.</summary>
		/// <remarks>Retrieves the translational components of this matrix.</remarks>
		/// <param name="trans">the vector that will receive the translational component</param>
		public void Get(Vector3f trans)
		{
			trans.x = m03;
			trans.y = m13;
			trans.z = m23;
		}

		/// <summary>
		/// Gets the upper 3x3 values of this matrix and places them into
		/// the matrix m1.
		/// </summary>
		/// <remarks>
		/// Gets the upper 3x3 values of this matrix and places them into
		/// the matrix m1.
		/// </remarks>
		/// <param name="m1">the matrix that will hold the values</param>
		public void GetRotationScale(Matrix3f m1)
		{
			m1.m00 = m00;
			m1.m01 = m01;
			m1.m02 = m02;
			m1.m10 = m10;
			m1.m11 = m11;
			m1.m12 = m12;
			m1.m20 = m20;
			m1.m21 = m21;
			m1.m22 = m22;
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

		/// <summary>
		/// Replaces the upper 3x3 matrix values of this matrix with the
		/// values in the matrix m1.
		/// </summary>
		/// <remarks>
		/// Replaces the upper 3x3 matrix values of this matrix with the
		/// values in the matrix m1.
		/// </remarks>
		/// <param name="m1">the matrix that will be the new upper 3x3</param>
		public void SetRotationScale(Matrix3f m1)
		{
			m00 = m1.m00;
			m01 = m1.m01;
			m02 = m1.m02;
			m10 = m1.m10;
			m11 = m1.m11;
			m12 = m1.m12;
			m20 = m1.m20;
			m21 = m1.m21;
			m22 = m1.m22;
		}

		/// <summary>Sets the specified row of this matrix4f to the four values provided.</summary>
		/// <remarks>Sets the specified row of this matrix4f to the four values provided.</remarks>
		/// <param name="row">the row number to be modified (zero indexed)</param>
		/// <param name="x">the first column element</param>
		/// <param name="y">the second column element</param>
		/// <param name="z">the third column element</param>
		/// <param name="w">the fourth column element</param>
		public void SetRow(int row, float x, float y, float z, float w)
		{
			switch (row)
			{
				case 0:
				{
					this.m00 = x;
					this.m01 = y;
					this.m02 = z;
					this.m03 = w;
					break;
				}

				case 1:
				{
					this.m10 = x;
					this.m11 = y;
					this.m12 = z;
					this.m13 = w;
					break;
				}

				case 2:
				{
					this.m20 = x;
					this.m21 = y;
					this.m22 = z;
					this.m23 = w;
					break;
				}

				case 3:
				{
					this.m30 = x;
					this.m31 = y;
					this.m32 = z;
					this.m33 = w;
					break;
				}

				default:
				{
					throw new IndexOutOfRangeException("Matrix4f setRow");
				}
			}
		}

		/// <summary>Sets the specified row of this matrix4f to the Vector provided.</summary>
		/// <remarks>Sets the specified row of this matrix4f to the Vector provided.</remarks>
		/// <param name="row">the row number to be modified (zero indexed)</param>
		/// <param name="v">the replacement row</param>
		public void SetRow(int row, Vector4f v)
		{
			switch (row)
			{
				case 0:
				{
					this.m00 = v.x;
					this.m01 = v.y;
					this.m02 = v.z;
					this.m03 = v.w;
					break;
				}

				case 1:
				{
					this.m10 = v.x;
					this.m11 = v.y;
					this.m12 = v.z;
					this.m13 = v.w;
					break;
				}

				case 2:
				{
					this.m20 = v.x;
					this.m21 = v.y;
					this.m22 = v.z;
					this.m23 = v.w;
					break;
				}

				case 3:
				{
					this.m30 = v.x;
					this.m31 = v.y;
					this.m32 = v.z;
					this.m33 = v.w;
					break;
				}

				default:
				{
					throw new IndexOutOfRangeException("Matrix4f setRow");
				}
			}
		}

		/// <summary>
		/// Sets the specified row of this matrix4f to the four values provided
		/// in the passed array.
		/// </summary>
		/// <remarks>
		/// Sets the specified row of this matrix4f to the four values provided
		/// in the passed array.
		/// </remarks>
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
					this.m03 = v[3];
					break;
				}

				case 1:
				{
					this.m10 = v[0];
					this.m11 = v[1];
					this.m12 = v[2];
					this.m13 = v[3];
					break;
				}

				case 2:
				{
					this.m20 = v[0];
					this.m21 = v[1];
					this.m22 = v[2];
					this.m23 = v[3];
					break;
				}

				case 3:
				{
					this.m30 = v[0];
					this.m31 = v[1];
					this.m32 = v[2];
					this.m33 = v[3];
					break;
				}

				default:
				{
					throw new IndexOutOfRangeException("Matrix4f setRow");
				}
			}
		}

		/// <summary>Sets the specified column of this matrix4f to the four values provided.</summary>
		/// <remarks>Sets the specified column of this matrix4f to the four values provided.</remarks>
		/// <param name="column">the column number to be modified (zero indexed)</param>
		/// <param name="x">the first row element</param>
		/// <param name="y">the second row element</param>
		/// <param name="z">the third row element</param>
		/// <param name="w">the fourth row element</param>
		public void SetColumn(int column, float x, float y, float z, float w)
		{
			switch (column)
			{
				case 0:
				{
					this.m00 = x;
					this.m10 = y;
					this.m20 = z;
					this.m30 = w;
					break;
				}

				case 1:
				{
					this.m01 = x;
					this.m11 = y;
					this.m21 = z;
					this.m31 = w;
					break;
				}

				case 2:
				{
					this.m02 = x;
					this.m12 = y;
					this.m22 = z;
					this.m32 = w;
					break;
				}

				case 3:
				{
					this.m03 = x;
					this.m13 = y;
					this.m23 = z;
					this.m33 = w;
					break;
				}

				default:
				{
					throw new IndexOutOfRangeException("Matrix4f setColumn");
				}
			}
		}

		/// <summary>Sets the specified column of this matrix4f to the vector provided.</summary>
		/// <remarks>Sets the specified column of this matrix4f to the vector provided.</remarks>
		/// <param name="column">the column number to be modified (zero indexed)</param>
		/// <param name="v">the replacement column</param>
		public void SetColumn(int column, Vector4f v)
		{
			switch (column)
			{
				case 0:
				{
					this.m00 = v.x;
					this.m10 = v.y;
					this.m20 = v.z;
					this.m30 = v.w;
					break;
				}

				case 1:
				{
					this.m01 = v.x;
					this.m11 = v.y;
					this.m21 = v.z;
					this.m31 = v.w;
					break;
				}

				case 2:
				{
					this.m02 = v.x;
					this.m12 = v.y;
					this.m22 = v.z;
					this.m32 = v.w;
					break;
				}

				case 3:
				{
					this.m03 = v.x;
					this.m13 = v.y;
					this.m23 = v.z;
					this.m33 = v.w;
					break;
				}

				default:
				{
					throw new IndexOutOfRangeException("Matrix4f setColumn");
				}
			}
		}

		/// <summary>Sets the specified column of this matrix4f to the four values provided.</summary>
		/// <remarks>Sets the specified column of this matrix4f to the four values provided.</remarks>
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
					this.m30 = v[3];
					break;
				}

				case 1:
				{
					this.m01 = v[0];
					this.m11 = v[1];
					this.m21 = v[2];
					this.m31 = v[3];
					break;
				}

				case 2:
				{
					this.m02 = v[0];
					this.m12 = v[1];
					this.m22 = v[2];
					this.m32 = v[3];
					break;
				}

				case 3:
				{
					this.m03 = v[0];
					this.m13 = v[1];
					this.m23 = v[2];
					this.m33 = v[3];
					break;
				}

				default:
				{
					throw new IndexOutOfRangeException("Matrix4f setColumn");
				}
			}
		}

		/// <summary>Adds a scalar to each component of this matrix.</summary>
		/// <remarks>Adds a scalar to each component of this matrix.</remarks>
		/// <param name="scalar">the scalar adder</param>
		public void Add(float scalar)
		{
			m00 += scalar;
			m01 += scalar;
			m02 += scalar;
			m03 += scalar;
			m10 += scalar;
			m11 += scalar;
			m12 += scalar;
			m13 += scalar;
			m20 += scalar;
			m21 += scalar;
			m22 += scalar;
			m23 += scalar;
			m30 += scalar;
			m31 += scalar;
			m32 += scalar;
			m33 += scalar;
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
		public void Add(float scalar, Matrix4f m1)
		{
			this.m00 = m1.m00 + scalar;
			this.m01 = m1.m01 + scalar;
			this.m02 = m1.m02 + scalar;
			this.m03 = m1.m03 + scalar;
			this.m10 = m1.m10 + scalar;
			this.m11 = m1.m11 + scalar;
			this.m12 = m1.m12 + scalar;
			this.m13 = m1.m13 + scalar;
			this.m20 = m1.m20 + scalar;
			this.m21 = m1.m21 + scalar;
			this.m22 = m1.m22 + scalar;
			this.m23 = m1.m23 + scalar;
			this.m30 = m1.m30 + scalar;
			this.m31 = m1.m31 + scalar;
			this.m32 = m1.m32 + scalar;
			this.m33 = m1.m33 + scalar;
		}

		/// <summary>Sets the value of this matrix to the matrix sum of matrices m1 and m2.</summary>
		/// <remarks>Sets the value of this matrix to the matrix sum of matrices m1 and m2.</remarks>
		/// <param name="m1">the first matrix</param>
		/// <param name="m2">the second matrix</param>
		public void Add(Matrix4f m1, Matrix4f m2)
		{
			this.m00 = m1.m00 + m2.m00;
			this.m01 = m1.m01 + m2.m01;
			this.m02 = m1.m02 + m2.m02;
			this.m03 = m1.m03 + m2.m03;
			this.m10 = m1.m10 + m2.m10;
			this.m11 = m1.m11 + m2.m11;
			this.m12 = m1.m12 + m2.m12;
			this.m13 = m1.m13 + m2.m13;
			this.m20 = m1.m20 + m2.m20;
			this.m21 = m1.m21 + m2.m21;
			this.m22 = m1.m22 + m2.m22;
			this.m23 = m1.m23 + m2.m23;
			this.m30 = m1.m30 + m2.m30;
			this.m31 = m1.m31 + m2.m31;
			this.m32 = m1.m32 + m2.m32;
			this.m33 = m1.m33 + m2.m33;
		}

		/// <summary>Sets the value of this matrix to the sum of itself and matrix m1.</summary>
		/// <remarks>Sets the value of this matrix to the sum of itself and matrix m1.</remarks>
		/// <param name="m1">the other matrix</param>
		public void Add(Matrix4f m1)
		{
			this.m00 += m1.m00;
			this.m01 += m1.m01;
			this.m02 += m1.m02;
			this.m03 += m1.m03;
			this.m10 += m1.m10;
			this.m11 += m1.m11;
			this.m12 += m1.m12;
			this.m13 += m1.m13;
			this.m20 += m1.m20;
			this.m21 += m1.m21;
			this.m22 += m1.m22;
			this.m23 += m1.m23;
			this.m30 += m1.m30;
			this.m31 += m1.m31;
			this.m32 += m1.m32;
			this.m33 += m1.m33;
		}

		/// <summary>
		/// Performs an element-by-element subtraction of matrix m2 from
		/// matrix m1 and places the result into matrix this (this =
		/// m2 - m1).
		/// </summary>
		/// <remarks>
		/// Performs an element-by-element subtraction of matrix m2 from
		/// matrix m1 and places the result into matrix this (this =
		/// m2 - m1).
		/// </remarks>
		/// <param name="m1">the first matrix</param>
		/// <param name="m2">the second matrix</param>
		public void Sub(Matrix4f m1, Matrix4f m2)
		{
			this.m00 = m1.m00 - m2.m00;
			this.m01 = m1.m01 - m2.m01;
			this.m02 = m1.m02 - m2.m02;
			this.m03 = m1.m03 - m2.m03;
			this.m10 = m1.m10 - m2.m10;
			this.m11 = m1.m11 - m2.m11;
			this.m12 = m1.m12 - m2.m12;
			this.m13 = m1.m13 - m2.m13;
			this.m20 = m1.m20 - m2.m20;
			this.m21 = m1.m21 - m2.m21;
			this.m22 = m1.m22 - m2.m22;
			this.m23 = m1.m23 - m2.m23;
			this.m30 = m1.m30 - m2.m30;
			this.m31 = m1.m31 - m2.m31;
			this.m32 = m1.m32 - m2.m32;
			this.m33 = m1.m33 - m2.m33;
		}

		/// <summary>
		/// Sets this matrix to the matrix difference of itself and
		/// matrix m1 (this = this - m1).
		/// </summary>
		/// <remarks>
		/// Sets this matrix to the matrix difference of itself and
		/// matrix m1 (this = this - m1).
		/// </remarks>
		/// <param name="m1">the other matrix</param>
		public void Sub(Matrix4f m1)
		{
			this.m00 -= m1.m00;
			this.m01 -= m1.m01;
			this.m02 -= m1.m02;
			this.m03 -= m1.m03;
			this.m10 -= m1.m10;
			this.m11 -= m1.m11;
			this.m12 -= m1.m12;
			this.m13 -= m1.m13;
			this.m20 -= m1.m20;
			this.m21 -= m1.m21;
			this.m22 -= m1.m22;
			this.m23 -= m1.m23;
			this.m30 -= m1.m30;
			this.m31 -= m1.m31;
			this.m32 -= m1.m32;
			this.m33 -= m1.m33;
		}

		/// <summary>Sets the value of this matrix to its transpose in place.</summary>
		/// <remarks>Sets the value of this matrix to its transpose in place.</remarks>
		public void Transpose()
		{
			float temp;
			temp = this.m10;
			this.m10 = this.m01;
			this.m01 = temp;
			temp = this.m20;
			this.m20 = this.m02;
			this.m02 = temp;
			temp = this.m30;
			this.m30 = this.m03;
			this.m03 = temp;
			temp = this.m21;
			this.m21 = this.m12;
			this.m12 = temp;
			temp = this.m31;
			this.m31 = this.m13;
			this.m13 = temp;
			temp = this.m32;
			this.m32 = this.m23;
			this.m23 = temp;
		}

		/// <summary>Sets the value of this matrix to the transpose of the argument matrix.</summary>
		/// <remarks>Sets the value of this matrix to the transpose of the argument matrix.</remarks>
		/// <param name="m1">the matrix to be transposed</param>
		public void Transpose(Matrix4f m1)
		{
			if (this != m1)
			{
				this.m00 = m1.m00;
				this.m01 = m1.m10;
				this.m02 = m1.m20;
				this.m03 = m1.m30;
				this.m10 = m1.m01;
				this.m11 = m1.m11;
				this.m12 = m1.m21;
				this.m13 = m1.m31;
				this.m20 = m1.m02;
				this.m21 = m1.m12;
				this.m22 = m1.m22;
				this.m23 = m1.m32;
				this.m30 = m1.m03;
				this.m31 = m1.m13;
				this.m32 = m1.m23;
				this.m33 = m1.m33;
			}
			else
			{
				this.Transpose();
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
			this.m00 = (1.0f - 2.0f * q1.y * q1.y - 2.0f * q1.z * q1.z);
			this.m10 = (2.0f * (q1.x * q1.y + q1.w * q1.z));
			this.m20 = (2.0f * (q1.x * q1.z - q1.w * q1.y));
			this.m01 = (2.0f * (q1.x * q1.y - q1.w * q1.z));
			this.m11 = (1.0f - 2.0f * q1.x * q1.x - 2.0f * q1.z * q1.z);
			this.m21 = (2.0f * (q1.y * q1.z + q1.w * q1.x));
			this.m02 = (2.0f * (q1.x * q1.z + q1.w * q1.y));
			this.m12 = (2.0f * (q1.y * q1.z - q1.w * q1.x));
			this.m22 = (1.0f - 2.0f * q1.x * q1.x - 2.0f * q1.y * q1.y);
			this.m03 = (float)0.0;
			this.m13 = (float)0.0;
			this.m23 = (float)0.0;
			this.m30 = (float)0.0;
			this.m31 = (float)0.0;
			this.m32 = (float)0.0;
			this.m33 = (float)1.0;
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
				float sinTheta = (float)Math.Sin((double)a1.angle);
				float cosTheta = (float)Math.Cos((double)a1.angle);
				float t = 1.0f - cosTheta;
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
			m03 = 0.0f;
			m13 = 0.0f;
			m23 = 0.0f;
			m30 = 0.0f;
			m31 = 0.0f;
			m32 = 0.0f;
			m33 = 1.0f;
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
			this.m00 = (float)(1.0 - 2.0 * q1.y * q1.y - 2.0 * q1.z * q1.z);
			this.m10 = (float)(2.0 * (q1.x * q1.y + q1.w * q1.z));
			this.m20 = (float)(2.0 * (q1.x * q1.z - q1.w * q1.y));
			this.m01 = (float)(2.0 * (q1.x * q1.y - q1.w * q1.z));
			this.m11 = (float)(1.0 - 2.0 * q1.x * q1.x - 2.0 * q1.z * q1.z);
			this.m21 = (float)(2.0 * (q1.y * q1.z + q1.w * q1.x));
			this.m02 = (float)(2.0 * (q1.x * q1.z + q1.w * q1.y));
			this.m12 = (float)(2.0 * (q1.y * q1.z - q1.w * q1.x));
			this.m22 = (float)(1.0 - 2.0 * q1.x * q1.x - 2.0 * q1.y * q1.y);
			this.m03 = (float)0.0;
			this.m13 = (float)0.0;
			this.m23 = (float)0.0;
			this.m30 = (float)0.0;
			this.m31 = (float)0.0;
			this.m32 = (float)0.0;
			this.m33 = (float)1.0;
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
				float sinTheta = (float)Math.Sin(a1.angle);
				float cosTheta = (float)Math.Cos(a1.angle);
				float t = 1.0f - cosTheta;
				float xz = (float)(ax * az);
				float xy = (float)(ax * ay);
				float yz = (float)(ay * az);
				this.m00 = t * (float)(ax * ax) + cosTheta;
				this.m01 = t * xy - sinTheta * (float)az;
				this.m02 = t * xz + sinTheta * (float)ay;
				this.m10 = t * xy + sinTheta * (float)az;
				this.m11 = t * (float)(ay * ay) + cosTheta;
				this.m12 = t * yz - sinTheta * (float)ax;
				this.m20 = t * xz - sinTheta * (float)ay;
				this.m21 = t * yz + sinTheta * (float)ax;
				this.m22 = t * (float)(az * az) + cosTheta;
			}
			this.m03 = 0.0f;
			this.m13 = 0.0f;
			this.m23 = 0.0f;
			this.m30 = 0.0f;
			this.m31 = 0.0f;
			this.m32 = 0.0f;
			this.m33 = 1.0f;
		}

		/// <summary>
		/// Sets the value of this matrix from the rotation expressed
		/// by the quaternion q1, the translation t1, and the scale s.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix from the rotation expressed
		/// by the quaternion q1, the translation t1, and the scale s.
		/// </remarks>
		/// <param name="q1">the rotation expressed as a quaternion</param>
		/// <param name="t1">the translation</param>
		/// <param name="s">the scale value</param>
		public void Set(Quat4d q1, Vector3d t1, double s)
		{
			this.m00 = (float)(s * (1.0 - 2.0 * q1.y * q1.y - 2.0 * q1.z * q1.z));
			this.m10 = (float)(s * (2.0 * (q1.x * q1.y + q1.w * q1.z)));
			this.m20 = (float)(s * (2.0 * (q1.x * q1.z - q1.w * q1.y)));
			this.m01 = (float)(s * (2.0 * (q1.x * q1.y - q1.w * q1.z)));
			this.m11 = (float)(s * (1.0 - 2.0 * q1.x * q1.x - 2.0 * q1.z * q1.z));
			this.m21 = (float)(s * (2.0 * (q1.y * q1.z + q1.w * q1.x)));
			this.m02 = (float)(s * (2.0 * (q1.x * q1.z + q1.w * q1.y)));
			this.m12 = (float)(s * (2.0 * (q1.y * q1.z - q1.w * q1.x)));
			this.m22 = (float)(s * (1.0 - 2.0 * q1.x * q1.x - 2.0 * q1.y * q1.y));
			this.m03 = (float)t1.x;
			this.m13 = (float)t1.y;
			this.m23 = (float)t1.z;
			this.m30 = (float)0.0;
			this.m31 = (float)0.0;
			this.m32 = (float)0.0;
			this.m33 = (float)1.0;
		}

		/// <summary>
		/// Sets the value of this matrix from the rotation expressed
		/// by the quaternion q1, the translation t1, and the scale s.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix from the rotation expressed
		/// by the quaternion q1, the translation t1, and the scale s.
		/// </remarks>
		/// <param name="q1">the rotation expressed as a quaternion</param>
		/// <param name="t1">the translation</param>
		/// <param name="s">the scale value</param>
		public void Set(Quat4f q1, Vector3f t1, float s)
		{
			this.m00 = (s * (1.0f - 2.0f * q1.y * q1.y - 2.0f * q1.z * q1.z));
			this.m10 = (s * (2.0f * (q1.x * q1.y + q1.w * q1.z)));
			this.m20 = (s * (2.0f * (q1.x * q1.z - q1.w * q1.y)));
			this.m01 = (s * (2.0f * (q1.x * q1.y - q1.w * q1.z)));
			this.m11 = (s * (1.0f - 2.0f * q1.x * q1.x - 2.0f * q1.z * q1.z));
			this.m21 = (s * (2.0f * (q1.y * q1.z + q1.w * q1.x)));
			this.m02 = (s * (2.0f * (q1.x * q1.z + q1.w * q1.y)));
			this.m12 = (s * (2.0f * (q1.y * q1.z - q1.w * q1.x)));
			this.m22 = (s * (1.0f - 2.0f * q1.x * q1.x - 2.0f * q1.y * q1.y));
			this.m03 = t1.x;
			this.m13 = t1.y;
			this.m23 = t1.z;
			this.m30 = (float)0.0;
			this.m31 = (float)0.0;
			this.m32 = (float)0.0;
			this.m33 = (float)1.0;
		}

		/// <summary>
		/// Sets the value of this matrix to the float value of the
		/// passed matrix4d m1.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the float value of the
		/// passed matrix4d m1.
		/// </remarks>
		/// <param name="m1">the matrix4d to be converted to float</param>
		public void Set(Matrix4d m1)
		{
			this.m00 = (float)m1.m00;
			this.m01 = (float)m1.m01;
			this.m02 = (float)m1.m02;
			this.m03 = (float)m1.m03;
			this.m10 = (float)m1.m10;
			this.m11 = (float)m1.m11;
			this.m12 = (float)m1.m12;
			this.m13 = (float)m1.m13;
			this.m20 = (float)m1.m20;
			this.m21 = (float)m1.m21;
			this.m22 = (float)m1.m22;
			this.m23 = (float)m1.m23;
			this.m30 = (float)m1.m30;
			this.m31 = (float)m1.m31;
			this.m32 = (float)m1.m32;
			this.m33 = (float)m1.m33;
		}

		/// <summary>
		/// Sets the value of this matrix to a copy of the
		/// passed matrix m1.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to a copy of the
		/// passed matrix m1.
		/// </remarks>
		/// <param name="m1">the matrix to be copied</param>
		public void Set(Matrix4f m1)
		{
			this.m00 = m1.m00;
			this.m01 = m1.m01;
			this.m02 = m1.m02;
			this.m03 = m1.m03;
			this.m10 = m1.m10;
			this.m11 = m1.m11;
			this.m12 = m1.m12;
			this.m13 = m1.m13;
			this.m20 = m1.m20;
			this.m21 = m1.m21;
			this.m22 = m1.m22;
			this.m23 = m1.m23;
			this.m30 = m1.m30;
			this.m31 = m1.m31;
			this.m32 = m1.m32;
			this.m33 = m1.m33;
		}

		/// <summary>
		/// Sets the value of this matrix to the matrix inverse
		/// of the passed (user declared) matrix m1.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to the matrix inverse
		/// of the passed (user declared) matrix m1.
		/// </remarks>
		/// <param name="m1">the matrix to be inverted</param>
		public void Invert(Matrix4f m1)
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
		internal void InvertGeneral(Matrix4f m1)
		{
			double[] temp = new double[16];
			double[] result = new double[16];
			int[] row_perm = new int[4];
			int i;
			int r;
			int c;
			// Use LU decomposition and backsubstitution code specifically
			// for floating-point 4x4 matrices.
			// Copy source matrix to t1tmp 
			temp[0] = m1.m00;
			temp[1] = m1.m01;
			temp[2] = m1.m02;
			temp[3] = m1.m03;
			temp[4] = m1.m10;
			temp[5] = m1.m11;
			temp[6] = m1.m12;
			temp[7] = m1.m13;
			temp[8] = m1.m20;
			temp[9] = m1.m21;
			temp[10] = m1.m22;
			temp[11] = m1.m23;
			temp[12] = m1.m30;
			temp[13] = m1.m31;
			temp[14] = m1.m32;
			temp[15] = m1.m33;
			// Calculate LU decomposition: Is the matrix singular? 
			if (!LuDecomposition(temp, row_perm))
			{
				// Matrix has no inverse 
				throw new SingularMatrixException("cannot invert matrix");
			}
			// Perform back substitution on the identity matrix 
			for (i = 0; i < 16; i++)
			{
				result[i] = 0.0;
			}
			result[0] = 1.0;
			result[5] = 1.0;
			result[10] = 1.0;
			result[15] = 1.0;
			LuBacksubstitution(temp, row_perm, result);
			this.m00 = (float)result[0];
			this.m01 = (float)result[1];
			this.m02 = (float)result[2];
			this.m03 = (float)result[3];
			this.m10 = (float)result[4];
			this.m11 = (float)result[5];
			this.m12 = (float)result[6];
			this.m13 = (float)result[7];
			this.m20 = (float)result[8];
			this.m21 = (float)result[9];
			this.m22 = (float)result[10];
			this.m23 = (float)result[11];
			this.m30 = (float)result[12];
			this.m31 = (float)result[13];
			this.m32 = (float)result[14];
			this.m33 = (float)result[15];
		}

		/// <summary>
		/// Given a 4x4 array "matrix0", this function replaces it with the
		/// LU decomposition of a row-wise permutation of itself.
		/// </summary>
		/// <remarks>
		/// Given a 4x4 array "matrix0", this function replaces it with the
		/// LU decomposition of a row-wise permutation of itself.  The input
		/// parameters are "matrix0" and "dimen".  The array "matrix0" is also
		/// an output parameter.  The vector "row_perm[4]" is an output
		/// parameter that contains the row permutations resulting from partial
		/// pivoting.  The output parameter "even_row_xchg" is 1 when the
		/// number of row exchanges is even, or -1 otherwise.  Assumes data
		/// type is always double.
		/// This function is similar to luDecomposition, except that it
		/// is tuned specifically for 4x4 matrices.
		/// </remarks>
		/// <returns>true if the matrix is nonsingular, or false otherwise.</returns>
		internal static bool LuDecomposition(double[] matrix0, int[] row_perm)
		{
			//
			// Reference: Press, Flannery, Teukolsky, Vetterling, 
			//	      _Numerical_Recipes_in_C_, Cambridge University Press, 
			//	      1988, pp 40-45.
			//
			double[] row_scale = new double[4];
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
				i = 4;
				while (i-- != 0)
				{
					big = 0.0;
					// For each column, find the largest element in the row 
					j = 4;
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
				for (j = 0; j < 4; j++)
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
						target = mtx + (4 * i) + j;
						sum = matrix0[target];
						k = i;
						p1 = mtx + (4 * i);
						p2 = mtx + j;
						while (k-- != 0)
						{
							sum -= matrix0[p1] * matrix0[p2];
							p1++;
							p2 += 4;
						}
						matrix0[target] = sum;
					}
					// Search for largest pivot element and calculate
					// intermediate elements of lower diagonal matrix L.
					big = 0.0;
					imax = -1;
					for (i = j; i < 4; i++)
					{
						target = mtx + (4 * i) + j;
						sum = matrix0[target];
						k = j;
						p1 = mtx + (4 * i);
						p2 = mtx + j;
						while (k-- != 0)
						{
							sum -= matrix0[p1] * matrix0[p2];
							p1++;
							p2 += 4;
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
						k = 4;
						p1 = mtx + (4 * imax);
						p2 = mtx + (4 * j);
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
					if (matrix0[(mtx + (4 * j) + j)] == 0.0)
					{
						return false;
					}
					// Divide elements of lower diagonal matrix L by pivot 
					if (j != (4 - 1))
					{
						temp = 1.0 / (matrix0[(mtx + (4 * j) + j)]);
						target = mtx + (4 * (j + 1)) + j;
						i = 3 - j;
						while (i-- != 0)
						{
							matrix0[target] *= temp;
							target += 4;
						}
					}
				}
			}
			return true;
		}

		/// <summary>Solves a set of linear equations.</summary>
		/// <remarks>
		/// Solves a set of linear equations.  The input parameters "matrix1",
		/// and "row_perm" come from luDecompostionD4x4 and do not change
		/// here.  The parameter "matrix2" is a set of column vectors assembled
		/// into a 4x4 matrix of floating-point values.  The procedure takes each
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
			for (k = 0; k < 4; k++)
			{
				//	    cv = &(matrix2[0][k]);
				cv = k;
				ii = -1;
				// Forward substitution 
				for (i = 0; i < 4; i++)
				{
					double sum;
					ip = row_perm[rp + i];
					sum = matrix2[cv + 4 * ip];
					matrix2[cv + 4 * ip] = matrix2[cv + 4 * i];
					if (ii >= 0)
					{
						//		    rv = &(matrix1[i][0]);
						rv = i * 4;
						for (j = ii; j <= i - 1; j++)
						{
							sum -= matrix1[rv + j] * matrix2[cv + 4 * j];
						}
					}
					else
					{
						if (sum != 0.0)
						{
							ii = i;
						}
					}
					matrix2[cv + 4 * i] = sum;
				}
				// Backsubstitution 
				//	    rv = &(matrix1[3][0]);
				rv = 3 * 4;
				matrix2[cv + 4 * 3] /= matrix1[rv + 3];
				rv -= 4;
				matrix2[cv + 4 * 2] = (matrix2[cv + 4 * 2] - matrix1[rv + 3] * matrix2[cv + 4 * 3
					]) / matrix1[rv + 2];
				rv -= 4;
				matrix2[cv + 4 * 1] = (matrix2[cv + 4 * 1] - matrix1[rv + 2] * matrix2[cv + 4 * 2
					] - matrix1[rv + 3] * matrix2[cv + 4 * 3]) / matrix1[rv + 1];
				rv -= 4;
				matrix2[cv + 4 * 0] = (matrix2[cv + 4 * 0] - matrix1[rv + 1] * matrix2[cv + 4 * 1
					] - matrix1[rv + 2] * matrix2[cv + 4 * 2] - matrix1[rv + 3] * matrix2[cv + 4 * 3
					]) / matrix1[rv + 0];
			}
		}

		/// <summary>Computes the determinate of this matrix.</summary>
		/// <remarks>Computes the determinate of this matrix.</remarks>
		/// <returns>the determinate of the matrix</returns>
		public float Determinant()
		{
			float det;
			// cofactor exapainsion along first row 
			det = m00 * (m11 * m22 * m33 + m12 * m23 * m31 + m13 * m21 * m32 - m13 * m22 * m31
				 - m11 * m23 * m32 - m12 * m21 * m33);
			det -= m01 * (m10 * m22 * m33 + m12 * m23 * m30 + m13 * m20 * m32 - m13 * m22 * m30
				 - m10 * m23 * m32 - m12 * m20 * m33);
			det += m02 * (m10 * m21 * m33 + m11 * m23 * m30 + m13 * m20 * m31 - m13 * m21 * m30
				 - m10 * m23 * m31 - m11 * m20 * m33);
			det -= m03 * (m10 * m21 * m32 + m11 * m22 * m30 + m12 * m20 * m31 - m12 * m21 * m30
				 - m10 * m22 * m31 - m11 * m20 * m32);
			return (det);
		}

		/// <summary>
		/// Sets the rotational component (upper 3x3) of this matrix to the
		/// matrix values in the single precision Matrix3f argument; the other
		/// elements of this matrix are initialized as if this were an identity
		/// matrix (i.e., affine matrix with no translational component).
		/// </summary>
		/// <remarks>
		/// Sets the rotational component (upper 3x3) of this matrix to the
		/// matrix values in the single precision Matrix3f argument; the other
		/// elements of this matrix are initialized as if this were an identity
		/// matrix (i.e., affine matrix with no translational component).
		/// </remarks>
		/// <param name="m1">the single-precision 3x3 matrix</param>
		public void Set(Matrix3f m1)
		{
			m00 = m1.m00;
			m01 = m1.m01;
			m02 = m1.m02;
			m03 = 0.0f;
			m10 = m1.m10;
			m11 = m1.m11;
			m12 = m1.m12;
			m13 = 0.0f;
			m20 = m1.m20;
			m21 = m1.m21;
			m22 = m1.m22;
			m23 = 0.0f;
			m30 = 0.0f;
			m31 = 0.0f;
			m32 = 0.0f;
			m33 = 1.0f;
		}

		/// <summary>
		/// Sets the rotational component (upper 3x3) of this matrix to the
		/// matrix values in the double precision Matrix3d argument; the other
		/// elements of this matrix are initialized as if this were an identity
		/// matrix (i.e., affine matrix with no translational component).
		/// </summary>
		/// <remarks>
		/// Sets the rotational component (upper 3x3) of this matrix to the
		/// matrix values in the double precision Matrix3d argument; the other
		/// elements of this matrix are initialized as if this were an identity
		/// matrix (i.e., affine matrix with no translational component).
		/// </remarks>
		/// <param name="m1">the double-precision 3x3 matrix</param>
		public void Set(Matrix3d m1)
		{
			m00 = (float)m1.m00;
			m01 = (float)m1.m01;
			m02 = (float)m1.m02;
			m03 = 0.0f;
			m10 = (float)m1.m10;
			m11 = (float)m1.m11;
			m12 = (float)m1.m12;
			m13 = 0.0f;
			m20 = (float)m1.m20;
			m21 = (float)m1.m21;
			m22 = (float)m1.m22;
			m23 = 0.0f;
			m30 = 0.0f;
			m31 = 0.0f;
			m32 = 0.0f;
			m33 = 1.0f;
		}

		/// <summary>
		/// Sets the value of this matrix to a scale matrix with the
		/// the passed scale amount.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to a scale matrix with the
		/// the passed scale amount.
		/// </remarks>
		/// <param name="scale">the scale factor for the matrix</param>
		public void Set(float scale)
		{
			this.m00 = scale;
			this.m01 = (float)0.0;
			this.m02 = (float)0.0;
			this.m03 = (float)0.0;
			this.m10 = (float)0.0;
			this.m11 = scale;
			this.m12 = (float)0.0;
			this.m13 = (float)0.0;
			this.m20 = (float)0.0;
			this.m21 = (float)0.0;
			this.m22 = scale;
			this.m23 = (float)0.0;
			this.m30 = (float)0.0;
			this.m31 = (float)0.0;
			this.m32 = (float)0.0;
			this.m33 = (float)1.0;
		}

		/// <summary>
		/// Sets the values in this Matrix4f equal to the row-major
		/// array parameter (ie, the first four elements of the
		/// array will be copied into the first row of this matrix, etc.).
		/// </summary>
		/// <remarks>
		/// Sets the values in this Matrix4f equal to the row-major
		/// array parameter (ie, the first four elements of the
		/// array will be copied into the first row of this matrix, etc.).
		/// </remarks>
		/// <param name="m">the single precision array of length 16</param>
		public void Set(float[] m)
		{
			m00 = m[0];
			m01 = m[1];
			m02 = m[2];
			m03 = m[3];
			m10 = m[4];
			m11 = m[5];
			m12 = m[6];
			m13 = m[7];
			m20 = m[8];
			m21 = m[9];
			m22 = m[10];
			m23 = m[11];
			m30 = m[12];
			m31 = m[13];
			m32 = m[14];
			m33 = m[15];
		}

		/// <summary>
		/// Sets the value of this matrix to a translate matrix with
		/// the passed translation value.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix to a translate matrix with
		/// the passed translation value.
		/// </remarks>
		/// <param name="v1">the translation amount</param>
		public void Set(Vector3f v1)
		{
			this.m00 = (float)1.0;
			this.m01 = (float)0.0;
			this.m02 = (float)0.0;
			this.m03 = v1.x;
			this.m10 = (float)0.0;
			this.m11 = (float)1.0;
			this.m12 = (float)0.0;
			this.m13 = v1.y;
			this.m20 = (float)0.0;
			this.m21 = (float)0.0;
			this.m22 = (float)1.0;
			this.m23 = v1.z;
			this.m30 = (float)0.0;
			this.m31 = (float)0.0;
			this.m32 = (float)0.0;
			this.m33 = (float)1.0;
		}

		/// <summary>
		/// Sets the value of this transform to a scale and translation matrix;
		/// the scale is not applied to the translation and all of the matrix
		/// values are modified.
		/// </summary>
		/// <remarks>
		/// Sets the value of this transform to a scale and translation matrix;
		/// the scale is not applied to the translation and all of the matrix
		/// values are modified.
		/// </remarks>
		/// <param name="scale">the scale factor for the matrix</param>
		/// <param name="t1">the translation amount</param>
		public void Set(float scale, Vector3f t1)
		{
			this.m00 = scale;
			this.m01 = (float)0.0;
			this.m02 = (float)0.0;
			this.m03 = t1.x;
			this.m10 = (float)0.0;
			this.m11 = scale;
			this.m12 = (float)0.0;
			this.m13 = t1.y;
			this.m20 = (float)0.0;
			this.m21 = (float)0.0;
			this.m22 = scale;
			this.m23 = t1.z;
			this.m30 = (float)0.0;
			this.m31 = (float)0.0;
			this.m32 = (float)0.0;
			this.m33 = (float)1.0;
		}

		/// <summary>
		/// Sets the value of this transform to a scale and translation matrix;
		/// the translation is scaled by the scale factor and all of the matrix
		/// values are modified.
		/// </summary>
		/// <remarks>
		/// Sets the value of this transform to a scale and translation matrix;
		/// the translation is scaled by the scale factor and all of the matrix
		/// values are modified.
		/// </remarks>
		/// <param name="t1">the translation amount</param>
		/// <param name="scale">the scale factor for the matrix</param>
		public void Set(Vector3f t1, float scale)
		{
			this.m00 = scale;
			this.m01 = (float)0.0;
			this.m02 = (float)0.0;
			this.m03 = scale * t1.x;
			this.m10 = (float)0.0;
			this.m11 = scale;
			this.m12 = (float)0.0;
			this.m13 = scale * t1.y;
			this.m20 = (float)0.0;
			this.m21 = (float)0.0;
			this.m22 = scale;
			this.m23 = scale * t1.z;
			this.m30 = (float)0.0;
			this.m31 = (float)0.0;
			this.m32 = (float)0.0;
			this.m33 = (float)1.0;
		}

		/// <summary>
		/// Sets the value of this matrix from the rotation expressed by
		/// the rotation matrix m1, the translation t1, and the scale factor.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix from the rotation expressed by
		/// the rotation matrix m1, the translation t1, and the scale factor.
		/// The translation is not modified by the scale.
		/// </remarks>
		/// <param name="m1">the rotation component</param>
		/// <param name="t1">the translation component</param>
		/// <param name="scale">the scale component</param>
		public void Set(Matrix3f m1, Vector3f t1, float scale)
		{
			this.m00 = m1.m00 * scale;
			this.m01 = m1.m01 * scale;
			this.m02 = m1.m02 * scale;
			this.m03 = t1.x;
			this.m10 = m1.m10 * scale;
			this.m11 = m1.m11 * scale;
			this.m12 = m1.m12 * scale;
			this.m13 = t1.y;
			this.m20 = m1.m20 * scale;
			this.m21 = m1.m21 * scale;
			this.m22 = m1.m22 * scale;
			this.m23 = t1.z;
			this.m30 = 0.0f;
			this.m31 = 0.0f;
			this.m32 = 0.0f;
			this.m33 = 1.0f;
		}

		/// <summary>
		/// Sets the value of this matrix from the rotation expressed by
		/// the rotation matrix m1, the translation t1, and the scale factor.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix from the rotation expressed by
		/// the rotation matrix m1, the translation t1, and the scale factor.
		/// The translation is not modified by the scale.
		/// </remarks>
		/// <param name="m1">the rotation component</param>
		/// <param name="t1">the translation component</param>
		/// <param name="scale">the scale factor</param>
		public void Set(Matrix3d m1, Vector3d t1, double scale)
		{
			this.m00 = (float)(m1.m00 * scale);
			this.m01 = (float)(m1.m01 * scale);
			this.m02 = (float)(m1.m02 * scale);
			this.m03 = (float)t1.x;
			this.m10 = (float)(m1.m10 * scale);
			this.m11 = (float)(m1.m11 * scale);
			this.m12 = (float)(m1.m12 * scale);
			this.m13 = (float)t1.y;
			this.m20 = (float)(m1.m20 * scale);
			this.m21 = (float)(m1.m21 * scale);
			this.m22 = (float)(m1.m22 * scale);
			this.m23 = (float)t1.z;
			this.m30 = 0.0f;
			this.m31 = 0.0f;
			this.m32 = 0.0f;
			this.m33 = 1.0f;
		}

		/// <summary>
		/// Modifies the translational components of this matrix to the values
		/// of the Vector3f argument; the other values of this matrix are not
		/// modified.
		/// </summary>
		/// <remarks>
		/// Modifies the translational components of this matrix to the values
		/// of the Vector3f argument; the other values of this matrix are not
		/// modified.
		/// </remarks>
		/// <param name="trans">the translational component</param>
		public void SetTranslation(Vector3f trans)
		{
			m03 = trans.x;
			m13 = trans.y;
			m23 = trans.z;
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
			this.m03 = (float)0.0;
			this.m10 = (float)0.0;
			this.m11 = cosAngle;
			this.m12 = -sinAngle;
			this.m13 = (float)0.0;
			this.m20 = (float)0.0;
			this.m21 = sinAngle;
			this.m22 = cosAngle;
			this.m23 = (float)0.0;
			this.m30 = (float)0.0;
			this.m31 = (float)0.0;
			this.m32 = (float)0.0;
			this.m33 = (float)1.0;
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
			this.m03 = (float)0.0;
			this.m10 = (float)0.0;
			this.m11 = (float)1.0;
			this.m12 = (float)0.0;
			this.m13 = (float)0.0;
			this.m20 = -sinAngle;
			this.m21 = (float)0.0;
			this.m22 = cosAngle;
			this.m23 = (float)0.0;
			this.m30 = (float)0.0;
			this.m31 = (float)0.0;
			this.m32 = (float)0.0;
			this.m33 = (float)1.0;
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
			this.m03 = (float)0.0;
			this.m10 = sinAngle;
			this.m11 = cosAngle;
			this.m12 = (float)0.0;
			this.m13 = (float)0.0;
			this.m20 = (float)0.0;
			this.m21 = (float)0.0;
			this.m22 = (float)1.0;
			this.m23 = (float)0.0;
			this.m30 = (float)0.0;
			this.m31 = (float)0.0;
			this.m32 = (float)0.0;
			this.m33 = (float)1.0;
		}

		/// <summary>Multiplies each element of this matrix by a scalar.</summary>
		/// <remarks>Multiplies each element of this matrix by a scalar.</remarks>
		/// <param name="scalar">the scalar multiplier.</param>
		public void Mul(float scalar)
		{
			m00 *= scalar;
			m01 *= scalar;
			m02 *= scalar;
			m03 *= scalar;
			m10 *= scalar;
			m11 *= scalar;
			m12 *= scalar;
			m13 *= scalar;
			m20 *= scalar;
			m21 *= scalar;
			m22 *= scalar;
			m23 *= scalar;
			m30 *= scalar;
			m31 *= scalar;
			m32 *= scalar;
			m33 *= scalar;
		}

		/// <summary>
		/// Multiplies each element of matrix m1 by a scalar and places
		/// the result into this.
		/// </summary>
		/// <remarks>
		/// Multiplies each element of matrix m1 by a scalar and places
		/// the result into this.  Matrix m1 is not modified.
		/// </remarks>
		/// <param name="scalar">the scalar multiplier.</param>
		/// <param name="m1">the original matrix.</param>
		public void Mul(float scalar, Matrix4f m1)
		{
			this.m00 = m1.m00 * scalar;
			this.m01 = m1.m01 * scalar;
			this.m02 = m1.m02 * scalar;
			this.m03 = m1.m03 * scalar;
			this.m10 = m1.m10 * scalar;
			this.m11 = m1.m11 * scalar;
			this.m12 = m1.m12 * scalar;
			this.m13 = m1.m13 * scalar;
			this.m20 = m1.m20 * scalar;
			this.m21 = m1.m21 * scalar;
			this.m22 = m1.m22 * scalar;
			this.m23 = m1.m23 * scalar;
			this.m30 = m1.m30 * scalar;
			this.m31 = m1.m31 * scalar;
			this.m32 = m1.m32 * scalar;
			this.m33 = m1.m33 * scalar;
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
		public void Mul(Matrix4f m1)
		{
			float m00;
			float m01;
			float m02;
			float m03;
			float m10;
			float m11;
			float m12;
			float m13;
			float m20;
			float m21;
			float m22;
			float m23;
			float m30;
			float m31;
			float m32;
			float m33;
			// vars for temp result matrix
			m00 = this.m00 * m1.m00 + this.m01 * m1.m10 + this.m02 * m1.m20 + this.m03 * m1.m30;
			m01 = this.m00 * m1.m01 + this.m01 * m1.m11 + this.m02 * m1.m21 + this.m03 * m1.m31;
			m02 = this.m00 * m1.m02 + this.m01 * m1.m12 + this.m02 * m1.m22 + this.m03 * m1.m32;
			m03 = this.m00 * m1.m03 + this.m01 * m1.m13 + this.m02 * m1.m23 + this.m03 * m1.m33;
			m10 = this.m10 * m1.m00 + this.m11 * m1.m10 + this.m12 * m1.m20 + this.m13 * m1.m30;
			m11 = this.m10 * m1.m01 + this.m11 * m1.m11 + this.m12 * m1.m21 + this.m13 * m1.m31;
			m12 = this.m10 * m1.m02 + this.m11 * m1.m12 + this.m12 * m1.m22 + this.m13 * m1.m32;
			m13 = this.m10 * m1.m03 + this.m11 * m1.m13 + this.m12 * m1.m23 + this.m13 * m1.m33;
			m20 = this.m20 * m1.m00 + this.m21 * m1.m10 + this.m22 * m1.m20 + this.m23 * m1.m30;
			m21 = this.m20 * m1.m01 + this.m21 * m1.m11 + this.m22 * m1.m21 + this.m23 * m1.m31;
			m22 = this.m20 * m1.m02 + this.m21 * m1.m12 + this.m22 * m1.m22 + this.m23 * m1.m32;
			m23 = this.m20 * m1.m03 + this.m21 * m1.m13 + this.m22 * m1.m23 + this.m23 * m1.m33;
			m30 = this.m30 * m1.m00 + this.m31 * m1.m10 + this.m32 * m1.m20 + this.m33 * m1.m30;
			m31 = this.m30 * m1.m01 + this.m31 * m1.m11 + this.m32 * m1.m21 + this.m33 * m1.m31;
			m32 = this.m30 * m1.m02 + this.m31 * m1.m12 + this.m32 * m1.m22 + this.m33 * m1.m32;
			m33 = this.m30 * m1.m03 + this.m31 * m1.m13 + this.m32 * m1.m23 + this.m33 * m1.m33;
			this.m00 = m00;
			this.m01 = m01;
			this.m02 = m02;
			this.m03 = m03;
			this.m10 = m10;
			this.m11 = m11;
			this.m12 = m12;
			this.m13 = m13;
			this.m20 = m20;
			this.m21 = m21;
			this.m22 = m22;
			this.m23 = m23;
			this.m30 = m30;
			this.m31 = m31;
			this.m32 = m32;
			this.m33 = m33;
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
		public void Mul(Matrix4f m1, Matrix4f m2)
		{
			if (this != m1 && this != m2)
			{
				this.m00 = m1.m00 * m2.m00 + m1.m01 * m2.m10 + m1.m02 * m2.m20 + m1.m03 * m2.m30;
				this.m01 = m1.m00 * m2.m01 + m1.m01 * m2.m11 + m1.m02 * m2.m21 + m1.m03 * m2.m31;
				this.m02 = m1.m00 * m2.m02 + m1.m01 * m2.m12 + m1.m02 * m2.m22 + m1.m03 * m2.m32;
				this.m03 = m1.m00 * m2.m03 + m1.m01 * m2.m13 + m1.m02 * m2.m23 + m1.m03 * m2.m33;
				this.m10 = m1.m10 * m2.m00 + m1.m11 * m2.m10 + m1.m12 * m2.m20 + m1.m13 * m2.m30;
				this.m11 = m1.m10 * m2.m01 + m1.m11 * m2.m11 + m1.m12 * m2.m21 + m1.m13 * m2.m31;
				this.m12 = m1.m10 * m2.m02 + m1.m11 * m2.m12 + m1.m12 * m2.m22 + m1.m13 * m2.m32;
				this.m13 = m1.m10 * m2.m03 + m1.m11 * m2.m13 + m1.m12 * m2.m23 + m1.m13 * m2.m33;
				this.m20 = m1.m20 * m2.m00 + m1.m21 * m2.m10 + m1.m22 * m2.m20 + m1.m23 * m2.m30;
				this.m21 = m1.m20 * m2.m01 + m1.m21 * m2.m11 + m1.m22 * m2.m21 + m1.m23 * m2.m31;
				this.m22 = m1.m20 * m2.m02 + m1.m21 * m2.m12 + m1.m22 * m2.m22 + m1.m23 * m2.m32;
				this.m23 = m1.m20 * m2.m03 + m1.m21 * m2.m13 + m1.m22 * m2.m23 + m1.m23 * m2.m33;
				this.m30 = m1.m30 * m2.m00 + m1.m31 * m2.m10 + m1.m32 * m2.m20 + m1.m33 * m2.m30;
				this.m31 = m1.m30 * m2.m01 + m1.m31 * m2.m11 + m1.m32 * m2.m21 + m1.m33 * m2.m31;
				this.m32 = m1.m30 * m2.m02 + m1.m31 * m2.m12 + m1.m32 * m2.m22 + m1.m33 * m2.m32;
				this.m33 = m1.m30 * m2.m03 + m1.m31 * m2.m13 + m1.m32 * m2.m23 + m1.m33 * m2.m33;
			}
			else
			{
				float m00;
				float m01;
				float m02;
				float m03;
				float m10;
				float m11;
				float m12;
				float m13;
				float m20;
				float m21;
				float m22;
				float m23;
				float m30;
				float m31;
				float m32;
				float m33;
				// vars for temp result matrix
				m00 = m1.m00 * m2.m00 + m1.m01 * m2.m10 + m1.m02 * m2.m20 + m1.m03 * m2.m30;
				m01 = m1.m00 * m2.m01 + m1.m01 * m2.m11 + m1.m02 * m2.m21 + m1.m03 * m2.m31;
				m02 = m1.m00 * m2.m02 + m1.m01 * m2.m12 + m1.m02 * m2.m22 + m1.m03 * m2.m32;
				m03 = m1.m00 * m2.m03 + m1.m01 * m2.m13 + m1.m02 * m2.m23 + m1.m03 * m2.m33;
				m10 = m1.m10 * m2.m00 + m1.m11 * m2.m10 + m1.m12 * m2.m20 + m1.m13 * m2.m30;
				m11 = m1.m10 * m2.m01 + m1.m11 * m2.m11 + m1.m12 * m2.m21 + m1.m13 * m2.m31;
				m12 = m1.m10 * m2.m02 + m1.m11 * m2.m12 + m1.m12 * m2.m22 + m1.m13 * m2.m32;
				m13 = m1.m10 * m2.m03 + m1.m11 * m2.m13 + m1.m12 * m2.m23 + m1.m13 * m2.m33;
				m20 = m1.m20 * m2.m00 + m1.m21 * m2.m10 + m1.m22 * m2.m20 + m1.m23 * m2.m30;
				m21 = m1.m20 * m2.m01 + m1.m21 * m2.m11 + m1.m22 * m2.m21 + m1.m23 * m2.m31;
				m22 = m1.m20 * m2.m02 + m1.m21 * m2.m12 + m1.m22 * m2.m22 + m1.m23 * m2.m32;
				m23 = m1.m20 * m2.m03 + m1.m21 * m2.m13 + m1.m22 * m2.m23 + m1.m23 * m2.m33;
				m30 = m1.m30 * m2.m00 + m1.m31 * m2.m10 + m1.m32 * m2.m20 + m1.m33 * m2.m30;
				m31 = m1.m30 * m2.m01 + m1.m31 * m2.m11 + m1.m32 * m2.m21 + m1.m33 * m2.m31;
				m32 = m1.m30 * m2.m02 + m1.m31 * m2.m12 + m1.m32 * m2.m22 + m1.m33 * m2.m32;
				m33 = m1.m30 * m2.m03 + m1.m31 * m2.m13 + m1.m32 * m2.m23 + m1.m33 * m2.m33;
				this.m00 = m00;
				this.m01 = m01;
				this.m02 = m02;
				this.m03 = m03;
				this.m10 = m10;
				this.m11 = m11;
				this.m12 = m12;
				this.m13 = m13;
				this.m20 = m20;
				this.m21 = m21;
				this.m22 = m22;
				this.m23 = m23;
				this.m30 = m30;
				this.m31 = m31;
				this.m32 = m32;
				this.m33 = m33;
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
		/// <param name="m1">the matrix on the left hand side of the multiplication</param>
		/// <param name="m2">the matrix on the right hand side of the multiplication</param>
		public void MulTransposeBoth(Matrix4f m1, Matrix4f m2)
		{
			if (this != m1 && this != m2)
			{
				this.m00 = m1.m00 * m2.m00 + m1.m10 * m2.m01 + m1.m20 * m2.m02 + m1.m30 * m2.m03;
				this.m01 = m1.m00 * m2.m10 + m1.m10 * m2.m11 + m1.m20 * m2.m12 + m1.m30 * m2.m13;
				this.m02 = m1.m00 * m2.m20 + m1.m10 * m2.m21 + m1.m20 * m2.m22 + m1.m30 * m2.m23;
				this.m03 = m1.m00 * m2.m30 + m1.m10 * m2.m31 + m1.m20 * m2.m32 + m1.m30 * m2.m33;
				this.m10 = m1.m01 * m2.m00 + m1.m11 * m2.m01 + m1.m21 * m2.m02 + m1.m31 * m2.m03;
				this.m11 = m1.m01 * m2.m10 + m1.m11 * m2.m11 + m1.m21 * m2.m12 + m1.m31 * m2.m13;
				this.m12 = m1.m01 * m2.m20 + m1.m11 * m2.m21 + m1.m21 * m2.m22 + m1.m31 * m2.m23;
				this.m13 = m1.m01 * m2.m30 + m1.m11 * m2.m31 + m1.m21 * m2.m32 + m1.m31 * m2.m33;
				this.m20 = m1.m02 * m2.m00 + m1.m12 * m2.m01 + m1.m22 * m2.m02 + m1.m32 * m2.m03;
				this.m21 = m1.m02 * m2.m10 + m1.m12 * m2.m11 + m1.m22 * m2.m12 + m1.m32 * m2.m13;
				this.m22 = m1.m02 * m2.m20 + m1.m12 * m2.m21 + m1.m22 * m2.m22 + m1.m32 * m2.m23;
				this.m23 = m1.m02 * m2.m30 + m1.m12 * m2.m31 + m1.m22 * m2.m32 + m1.m32 * m2.m33;
				this.m30 = m1.m03 * m2.m00 + m1.m13 * m2.m01 + m1.m23 * m2.m02 + m1.m33 * m2.m03;
				this.m31 = m1.m03 * m2.m10 + m1.m13 * m2.m11 + m1.m23 * m2.m12 + m1.m33 * m2.m13;
				this.m32 = m1.m03 * m2.m20 + m1.m13 * m2.m21 + m1.m23 * m2.m22 + m1.m33 * m2.m23;
				this.m33 = m1.m03 * m2.m30 + m1.m13 * m2.m31 + m1.m23 * m2.m32 + m1.m33 * m2.m33;
			}
			else
			{
				float m00;
				float m01;
				float m02;
				float m03;
				float m10;
				float m11;
				float m12;
				float m13;
				float m20;
				float m21;
				float m22;
				float m23;
				float m30;
				float m31;
				float m32;
				float m33;
				// vars for temp result matrix
				m00 = m1.m00 * m2.m00 + m1.m10 * m2.m01 + m1.m20 * m2.m02 + m1.m30 * m2.m03;
				m01 = m1.m00 * m2.m10 + m1.m10 * m2.m11 + m1.m20 * m2.m12 + m1.m30 * m2.m13;
				m02 = m1.m00 * m2.m20 + m1.m10 * m2.m21 + m1.m20 * m2.m22 + m1.m30 * m2.m23;
				m03 = m1.m00 * m2.m30 + m1.m10 * m2.m31 + m1.m20 * m2.m32 + m1.m30 * m2.m33;
				m10 = m1.m01 * m2.m00 + m1.m11 * m2.m01 + m1.m21 * m2.m02 + m1.m31 * m2.m03;
				m11 = m1.m01 * m2.m10 + m1.m11 * m2.m11 + m1.m21 * m2.m12 + m1.m31 * m2.m13;
				m12 = m1.m01 * m2.m20 + m1.m11 * m2.m21 + m1.m21 * m2.m22 + m1.m31 * m2.m23;
				m13 = m1.m01 * m2.m30 + m1.m11 * m2.m31 + m1.m21 * m2.m32 + m1.m31 * m2.m33;
				m20 = m1.m02 * m2.m00 + m1.m12 * m2.m01 + m1.m22 * m2.m02 + m1.m32 * m2.m03;
				m21 = m1.m02 * m2.m10 + m1.m12 * m2.m11 + m1.m22 * m2.m12 + m1.m32 * m2.m13;
				m22 = m1.m02 * m2.m20 + m1.m12 * m2.m21 + m1.m22 * m2.m22 + m1.m32 * m2.m23;
				m23 = m1.m02 * m2.m30 + m1.m12 * m2.m31 + m1.m22 * m2.m32 + m1.m32 * m2.m33;
				m30 = m1.m03 * m2.m00 + m1.m13 * m2.m01 + m1.m23 * m2.m02 + m1.m33 * m2.m03;
				m31 = m1.m03 * m2.m10 + m1.m13 * m2.m11 + m1.m23 * m2.m12 + m1.m33 * m2.m13;
				m32 = m1.m03 * m2.m20 + m1.m13 * m2.m21 + m1.m23 * m2.m22 + m1.m33 * m2.m23;
				m33 = m1.m03 * m2.m30 + m1.m13 * m2.m31 + m1.m23 * m2.m32 + m1.m33 * m2.m33;
				this.m00 = m00;
				this.m01 = m01;
				this.m02 = m02;
				this.m03 = m03;
				this.m10 = m10;
				this.m11 = m11;
				this.m12 = m12;
				this.m13 = m13;
				this.m20 = m20;
				this.m21 = m21;
				this.m22 = m22;
				this.m23 = m23;
				this.m30 = m30;
				this.m31 = m31;
				this.m32 = m32;
				this.m33 = m33;
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
		public void MulTransposeRight(Matrix4f m1, Matrix4f m2)
		{
			if (this != m1 && this != m2)
			{
				this.m00 = m1.m00 * m2.m00 + m1.m01 * m2.m01 + m1.m02 * m2.m02 + m1.m03 * m2.m03;
				this.m01 = m1.m00 * m2.m10 + m1.m01 * m2.m11 + m1.m02 * m2.m12 + m1.m03 * m2.m13;
				this.m02 = m1.m00 * m2.m20 + m1.m01 * m2.m21 + m1.m02 * m2.m22 + m1.m03 * m2.m23;
				this.m03 = m1.m00 * m2.m30 + m1.m01 * m2.m31 + m1.m02 * m2.m32 + m1.m03 * m2.m33;
				this.m10 = m1.m10 * m2.m00 + m1.m11 * m2.m01 + m1.m12 * m2.m02 + m1.m13 * m2.m03;
				this.m11 = m1.m10 * m2.m10 + m1.m11 * m2.m11 + m1.m12 * m2.m12 + m1.m13 * m2.m13;
				this.m12 = m1.m10 * m2.m20 + m1.m11 * m2.m21 + m1.m12 * m2.m22 + m1.m13 * m2.m23;
				this.m13 = m1.m10 * m2.m30 + m1.m11 * m2.m31 + m1.m12 * m2.m32 + m1.m13 * m2.m33;
				this.m20 = m1.m20 * m2.m00 + m1.m21 * m2.m01 + m1.m22 * m2.m02 + m1.m23 * m2.m03;
				this.m21 = m1.m20 * m2.m10 + m1.m21 * m2.m11 + m1.m22 * m2.m12 + m1.m23 * m2.m13;
				this.m22 = m1.m20 * m2.m20 + m1.m21 * m2.m21 + m1.m22 * m2.m22 + m1.m23 * m2.m23;
				this.m23 = m1.m20 * m2.m30 + m1.m21 * m2.m31 + m1.m22 * m2.m32 + m1.m23 * m2.m33;
				this.m30 = m1.m30 * m2.m00 + m1.m31 * m2.m01 + m1.m32 * m2.m02 + m1.m33 * m2.m03;
				this.m31 = m1.m30 * m2.m10 + m1.m31 * m2.m11 + m1.m32 * m2.m12 + m1.m33 * m2.m13;
				this.m32 = m1.m30 * m2.m20 + m1.m31 * m2.m21 + m1.m32 * m2.m22 + m1.m33 * m2.m23;
				this.m33 = m1.m30 * m2.m30 + m1.m31 * m2.m31 + m1.m32 * m2.m32 + m1.m33 * m2.m33;
			}
			else
			{
				float m00;
				float m01;
				float m02;
				float m03;
				float m10;
				float m11;
				float m12;
				float m13;
				float m20;
				float m21;
				float m22;
				float m23;
				float m30;
				float m31;
				float m32;
				float m33;
				// vars for temp result matrix
				m00 = m1.m00 * m2.m00 + m1.m01 * m2.m01 + m1.m02 * m2.m02 + m1.m03 * m2.m03;
				m01 = m1.m00 * m2.m10 + m1.m01 * m2.m11 + m1.m02 * m2.m12 + m1.m03 * m2.m13;
				m02 = m1.m00 * m2.m20 + m1.m01 * m2.m21 + m1.m02 * m2.m22 + m1.m03 * m2.m23;
				m03 = m1.m00 * m2.m30 + m1.m01 * m2.m31 + m1.m02 * m2.m32 + m1.m03 * m2.m33;
				m10 = m1.m10 * m2.m00 + m1.m11 * m2.m01 + m1.m12 * m2.m02 + m1.m13 * m2.m03;
				m11 = m1.m10 * m2.m10 + m1.m11 * m2.m11 + m1.m12 * m2.m12 + m1.m13 * m2.m13;
				m12 = m1.m10 * m2.m20 + m1.m11 * m2.m21 + m1.m12 * m2.m22 + m1.m13 * m2.m23;
				m13 = m1.m10 * m2.m30 + m1.m11 * m2.m31 + m1.m12 * m2.m32 + m1.m13 * m2.m33;
				m20 = m1.m20 * m2.m00 + m1.m21 * m2.m01 + m1.m22 * m2.m02 + m1.m23 * m2.m03;
				m21 = m1.m20 * m2.m10 + m1.m21 * m2.m11 + m1.m22 * m2.m12 + m1.m23 * m2.m13;
				m22 = m1.m20 * m2.m20 + m1.m21 * m2.m21 + m1.m22 * m2.m22 + m1.m23 * m2.m23;
				m23 = m1.m20 * m2.m30 + m1.m21 * m2.m31 + m1.m22 * m2.m32 + m1.m23 * m2.m33;
				m30 = m1.m30 * m2.m00 + m1.m31 * m2.m01 + m1.m32 * m2.m02 + m1.m33 * m2.m03;
				m31 = m1.m30 * m2.m10 + m1.m31 * m2.m11 + m1.m32 * m2.m12 + m1.m33 * m2.m13;
				m32 = m1.m30 * m2.m20 + m1.m31 * m2.m21 + m1.m32 * m2.m22 + m1.m33 * m2.m23;
				m33 = m1.m30 * m2.m30 + m1.m31 * m2.m31 + m1.m32 * m2.m32 + m1.m33 * m2.m33;
				this.m00 = m00;
				this.m01 = m01;
				this.m02 = m02;
				this.m03 = m03;
				this.m10 = m10;
				this.m11 = m11;
				this.m12 = m12;
				this.m13 = m13;
				this.m20 = m20;
				this.m21 = m21;
				this.m22 = m22;
				this.m23 = m23;
				this.m30 = m30;
				this.m31 = m31;
				this.m32 = m32;
				this.m33 = m33;
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
		public void MulTransposeLeft(Matrix4f m1, Matrix4f m2)
		{
			if (this != m1 && this != m2)
			{
				this.m00 = m1.m00 * m2.m00 + m1.m10 * m2.m10 + m1.m20 * m2.m20 + m1.m30 * m2.m30;
				this.m01 = m1.m00 * m2.m01 + m1.m10 * m2.m11 + m1.m20 * m2.m21 + m1.m30 * m2.m31;
				this.m02 = m1.m00 * m2.m02 + m1.m10 * m2.m12 + m1.m20 * m2.m22 + m1.m30 * m2.m32;
				this.m03 = m1.m00 * m2.m03 + m1.m10 * m2.m13 + m1.m20 * m2.m23 + m1.m30 * m2.m33;
				this.m10 = m1.m01 * m2.m00 + m1.m11 * m2.m10 + m1.m21 * m2.m20 + m1.m31 * m2.m30;
				this.m11 = m1.m01 * m2.m01 + m1.m11 * m2.m11 + m1.m21 * m2.m21 + m1.m31 * m2.m31;
				this.m12 = m1.m01 * m2.m02 + m1.m11 * m2.m12 + m1.m21 * m2.m22 + m1.m31 * m2.m32;
				this.m13 = m1.m01 * m2.m03 + m1.m11 * m2.m13 + m1.m21 * m2.m23 + m1.m31 * m2.m33;
				this.m20 = m1.m02 * m2.m00 + m1.m12 * m2.m10 + m1.m22 * m2.m20 + m1.m32 * m2.m30;
				this.m21 = m1.m02 * m2.m01 + m1.m12 * m2.m11 + m1.m22 * m2.m21 + m1.m32 * m2.m31;
				this.m22 = m1.m02 * m2.m02 + m1.m12 * m2.m12 + m1.m22 * m2.m22 + m1.m32 * m2.m32;
				this.m23 = m1.m02 * m2.m03 + m1.m12 * m2.m13 + m1.m22 * m2.m23 + m1.m32 * m2.m33;
				this.m30 = m1.m03 * m2.m00 + m1.m13 * m2.m10 + m1.m23 * m2.m20 + m1.m33 * m2.m30;
				this.m31 = m1.m03 * m2.m01 + m1.m13 * m2.m11 + m1.m23 * m2.m21 + m1.m33 * m2.m31;
				this.m32 = m1.m03 * m2.m02 + m1.m13 * m2.m12 + m1.m23 * m2.m22 + m1.m33 * m2.m32;
				this.m33 = m1.m03 * m2.m03 + m1.m13 * m2.m13 + m1.m23 * m2.m23 + m1.m33 * m2.m33;
			}
			else
			{
				float m00;
				float m01;
				float m02;
				float m03;
				float m10;
				float m11;
				float m12;
				float m13;
				float m20;
				float m21;
				float m22;
				float m23;
				float m30;
				float m31;
				float m32;
				float m33;
				// vars for temp result matrix
				m00 = m1.m00 * m2.m00 + m1.m10 * m2.m10 + m1.m20 * m2.m20 + m1.m30 * m2.m30;
				m01 = m1.m00 * m2.m01 + m1.m10 * m2.m11 + m1.m20 * m2.m21 + m1.m30 * m2.m31;
				m02 = m1.m00 * m2.m02 + m1.m10 * m2.m12 + m1.m20 * m2.m22 + m1.m30 * m2.m32;
				m03 = m1.m00 * m2.m03 + m1.m10 * m2.m13 + m1.m20 * m2.m23 + m1.m30 * m2.m33;
				m10 = m1.m01 * m2.m00 + m1.m11 * m2.m10 + m1.m21 * m2.m20 + m1.m31 * m2.m30;
				m11 = m1.m01 * m2.m01 + m1.m11 * m2.m11 + m1.m21 * m2.m21 + m1.m31 * m2.m31;
				m12 = m1.m01 * m2.m02 + m1.m11 * m2.m12 + m1.m21 * m2.m22 + m1.m31 * m2.m32;
				m13 = m1.m01 * m2.m03 + m1.m11 * m2.m13 + m1.m21 * m2.m23 + m1.m31 * m2.m33;
				m20 = m1.m02 * m2.m00 + m1.m12 * m2.m10 + m1.m22 * m2.m20 + m1.m32 * m2.m30;
				m21 = m1.m02 * m2.m01 + m1.m12 * m2.m11 + m1.m22 * m2.m21 + m1.m32 * m2.m31;
				m22 = m1.m02 * m2.m02 + m1.m12 * m2.m12 + m1.m22 * m2.m22 + m1.m32 * m2.m32;
				m23 = m1.m02 * m2.m03 + m1.m12 * m2.m13 + m1.m22 * m2.m23 + m1.m32 * m2.m33;
				m30 = m1.m03 * m2.m00 + m1.m13 * m2.m10 + m1.m23 * m2.m20 + m1.m33 * m2.m30;
				m31 = m1.m03 * m2.m01 + m1.m13 * m2.m11 + m1.m23 * m2.m21 + m1.m33 * m2.m31;
				m32 = m1.m03 * m2.m02 + m1.m13 * m2.m12 + m1.m23 * m2.m22 + m1.m33 * m2.m32;
				m33 = m1.m03 * m2.m03 + m1.m13 * m2.m13 + m1.m23 * m2.m23 + m1.m33 * m2.m33;
				this.m00 = m00;
				this.m01 = m01;
				this.m02 = m02;
				this.m03 = m03;
				this.m10 = m10;
				this.m11 = m11;
				this.m12 = m12;
				this.m13 = m13;
				this.m20 = m20;
				this.m21 = m21;
				this.m22 = m22;
				this.m23 = m23;
				this.m30 = m30;
				this.m31 = m31;
				this.m32 = m32;
				this.m33 = m33;
			}
		}

		/// <summary>
		/// Returns true if all of the data members of Matrix4f m1 are
		/// equal to the corresponding data members in this Matrix4f.
		/// </summary>
		/// <remarks>
		/// Returns true if all of the data members of Matrix4f m1 are
		/// equal to the corresponding data members in this Matrix4f.
		/// </remarks>
		/// <param name="m1">the matrix with which the comparison is made.</param>
		/// <returns>true or false</returns>
		public virtual bool Equals(Matrix4f m1)
		{
			try
			{
				return (this.m00 == m1.m00 && this.m01 == m1.m01 && this.m02 == m1.m02 && this.m03
					 == m1.m03 && this.m10 == m1.m10 && this.m11 == m1.m11 && this.m12 == m1.m12 && 
					this.m13 == m1.m13 && this.m20 == m1.m20 && this.m21 == m1.m21 && this.m22 == m1
					.m22 && this.m23 == m1.m23 && this.m30 == m1.m30 && this.m31 == m1.m31 && this.m32
					 == m1.m32 && this.m33 == m1.m33);
			}
			catch (ArgumentNullException)
			{
				return false;
			}
		}

		/// <summary>
		/// Returns true if the Object t1 is of type Matrix4f and all of the
		/// data members of t1 are equal to the corresponding data members in
		/// this Matrix4f.
		/// </summary>
		/// <remarks>
		/// Returns true if the Object t1 is of type Matrix4f and all of the
		/// data members of t1 are equal to the corresponding data members in
		/// this Matrix4f.
		/// </remarks>
		/// <param name="t1">the matrix with which the comparison is made.</param>
		/// <returns>true or false</returns>
		public override bool Equals(object t1)
		{
			try
			{
				Matrix4f m2 = (Matrix4f)t1;
				return (this.m00 == m2.m00 && this.m01 == m2.m01 && this.m02 == m2.m02 && this.m03
					 == m2.m03 && this.m10 == m2.m10 && this.m11 == m2.m11 && this.m12 == m2.m12 && 
					this.m13 == m2.m13 && this.m20 == m2.m20 && this.m21 == m2.m21 && this.m22 == m2
					.m22 && this.m23 == m2.m23 && this.m30 == m2.m30 && this.m31 == m2.m31 && this.m32
					 == m2.m32 && this.m33 == m2.m33);
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
		/// MAX[i=0,1,2,3 ; j=0,1,2,3 ; abs(this.m(i,j) - m1.m(i,j)]
		/// </remarks>
		/// <param name="m1">the matrix to be compared to this matrix</param>
		/// <param name="epsilon">the threshold value</param>
		public virtual bool EpsilonEquals(Matrix4f m1, float epsilon)
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
			if (Math.Abs(this.m03 - m1.m03) > epsilon)
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
			if (Math.Abs(this.m13 - m1.m13) > epsilon)
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
			if (Math.Abs(this.m23 - m1.m23) > epsilon)
			{
				status = false;
			}
			if (Math.Abs(this.m30 - m1.m30) > epsilon)
			{
				status = false;
			}
			if (Math.Abs(this.m31 - m1.m31) > epsilon)
			{
				status = false;
			}
			if (Math.Abs(this.m32 - m1.m32) > epsilon)
			{
				status = false;
			}
			if (Math.Abs(this.m33 - m1.m33) > epsilon)
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
		/// object.  Two different Matrix4f objects with identical data values
		/// (i.e., Matrix4f.equals returns true) will return the same hash
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
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m03);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m10);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m11);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m12);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m13);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m20);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m21);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m22);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m23);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m30);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m31);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m32);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(m33);
			return (int)(bits ^ (bits >> 32));
		}

		/// <summary>
		/// Transform the vector vec using this Matrix4f and place the
		/// result into vecOut.
		/// </summary>
		/// <remarks>
		/// Transform the vector vec using this Matrix4f and place the
		/// result into vecOut.
		/// </remarks>
		/// <param name="vec">the single precision vector to be transformed</param>
		/// <param name="vecOut">the vector into which the transformed values are placed</param>
		public void Transform(Tuple4f vec, Tuple4f vecOut)
		{
			float x;
			float y;
			float z;
			x = m00 * vec.x + m01 * vec.y + m02 * vec.z + m03 * vec.w;
			y = m10 * vec.x + m11 * vec.y + m12 * vec.z + m13 * vec.w;
			z = m20 * vec.x + m21 * vec.y + m22 * vec.z + m23 * vec.w;
			vecOut.w = m30 * vec.x + m31 * vec.y + m32 * vec.z + m33 * vec.w;
			vecOut.x = x;
			vecOut.y = y;
			vecOut.z = z;
		}

		/// <summary>
		/// Transform the vector vec using this Transform and place the
		/// result back into vec.
		/// </summary>
		/// <remarks>
		/// Transform the vector vec using this Transform and place the
		/// result back into vec.
		/// </remarks>
		/// <param name="vec">the single precision vector to be transformed</param>
		public void Transform(Tuple4f vec)
		{
			float x;
			float y;
			float z;
			x = m00 * vec.x + m01 * vec.y + m02 * vec.z + m03 * vec.w;
			y = m10 * vec.x + m11 * vec.y + m12 * vec.z + m13 * vec.w;
			z = m20 * vec.x + m21 * vec.y + m22 * vec.z + m23 * vec.w;
			vec.w = m30 * vec.x + m31 * vec.y + m32 * vec.z + m33 * vec.w;
			vec.x = x;
			vec.y = y;
			vec.z = z;
		}

		/// <summary>
		/// Transforms the point parameter with this Matrix4f and
		/// places the result into pointOut.
		/// </summary>
		/// <remarks>
		/// Transforms the point parameter with this Matrix4f and
		/// places the result into pointOut.  The fourth element of the
		/// point input paramter is assumed to be one.
		/// </remarks>
		/// <param name="point">the input point to be transformed.</param>
		/// <param name="pointOut">the transformed point</param>
		public void Transform(Point3f point, Point3f pointOut)
		{
			float x;
			float y;
			x = m00 * point.x + m01 * point.y + m02 * point.z + m03;
			y = m10 * point.x + m11 * point.y + m12 * point.z + m13;
			pointOut.z = m20 * point.x + m21 * point.y + m22 * point.z + m23;
			pointOut.x = x;
			pointOut.y = y;
		}

		/// <summary>
		/// Transforms the point parameter with this Matrix4f and
		/// places the result back into point.
		/// </summary>
		/// <remarks>
		/// Transforms the point parameter with this Matrix4f and
		/// places the result back into point.  The fourth element of the
		/// point input paramter is assumed to be one.
		/// </remarks>
		/// <param name="point">the input point to be transformed.</param>
		public void Transform(Point3f point)
		{
			float x;
			float y;
			x = m00 * point.x + m01 * point.y + m02 * point.z + m03;
			y = m10 * point.x + m11 * point.y + m12 * point.z + m13;
			point.z = m20 * point.x + m21 * point.y + m22 * point.z + m23;
			point.x = x;
			point.y = y;
		}

		/// <summary>
		/// Transforms the normal parameter by this Matrix4f and places the value
		/// into normalOut.
		/// </summary>
		/// <remarks>
		/// Transforms the normal parameter by this Matrix4f and places the value
		/// into normalOut.  The fourth element of the normal is assumed to be zero.
		/// </remarks>
		/// <param name="normal">the input normal to be transformed.</param>
		/// <param name="normalOut">the transformed normal</param>
		public void Transform(Vector3f normal, Vector3f normalOut)
		{
			float x;
			float y;
			x = m00 * normal.x + m01 * normal.y + m02 * normal.z;
			y = m10 * normal.x + m11 * normal.y + m12 * normal.z;
			normalOut.z = m20 * normal.x + m21 * normal.y + m22 * normal.z;
			normalOut.x = x;
			normalOut.y = y;
		}

		/// <summary>
		/// Transforms the normal parameter by this transform and places the value
		/// back into normal.
		/// </summary>
		/// <remarks>
		/// Transforms the normal parameter by this transform and places the value
		/// back into normal.  The fourth element of the normal is assumed to be zero.
		/// </remarks>
		/// <param name="normal">the input normal to be transformed.</param>
		public void Transform(Vector3f normal)
		{
			float x;
			float y;
			x = m00 * normal.x + m01 * normal.y + m02 * normal.z;
			y = m10 * normal.x + m11 * normal.y + m12 * normal.z;
			normal.z = m20 * normal.x + m21 * normal.y + m22 * normal.z;
			normal.x = x;
			normal.y = y;
		}

		/// <summary>
		/// Sets the rotational component (upper 3x3) of this matrix to the
		/// matrix values in the double precision Matrix3d argument; the other
		/// elements of this matrix are unchanged; a singular value
		/// decomposition is performed on this object's upper 3x3 matrix to
		/// factor out the scale, then this object's upper 3x3 matrix components
		/// are replaced by the passed rotation components,
		/// and then the scale is reapplied to the rotational components.
		/// </summary>
		/// <remarks>
		/// Sets the rotational component (upper 3x3) of this matrix to the
		/// matrix values in the double precision Matrix3d argument; the other
		/// elements of this matrix are unchanged; a singular value
		/// decomposition is performed on this object's upper 3x3 matrix to
		/// factor out the scale, then this object's upper 3x3 matrix components
		/// are replaced by the passed rotation components,
		/// and then the scale is reapplied to the rotational components.
		/// </remarks>
		/// <param name="m1">double precision 3x3 matrix</param>
		public void SetRotation(Matrix3d m1)
		{
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			GetScaleRotate(tmp_scale, tmp_rot);
			m00 = (float)(m1.m00 * tmp_scale[0]);
			m01 = (float)(m1.m01 * tmp_scale[1]);
			m02 = (float)(m1.m02 * tmp_scale[2]);
			m10 = (float)(m1.m10 * tmp_scale[0]);
			m11 = (float)(m1.m11 * tmp_scale[1]);
			m12 = (float)(m1.m12 * tmp_scale[2]);
			m20 = (float)(m1.m20 * tmp_scale[0]);
			m21 = (float)(m1.m21 * tmp_scale[1]);
			m22 = (float)(m1.m22 * tmp_scale[2]);
		}

		/// <summary>
		/// Sets the rotational component (upper 3x3) of this matrix to the
		/// matrix values in the single precision Matrix3f argument; the other
		/// elements of this matrix are unchanged; a singular value
		/// decomposition is performed on this object's upper 3x3 matrix to
		/// factor out the scale, then this object's upper 3x3 matrix components
		/// are replaced by the passed rotation components,
		/// and then the scale is reapplied to the rotational components.
		/// </summary>
		/// <remarks>
		/// Sets the rotational component (upper 3x3) of this matrix to the
		/// matrix values in the single precision Matrix3f argument; the other
		/// elements of this matrix are unchanged; a singular value
		/// decomposition is performed on this object's upper 3x3 matrix to
		/// factor out the scale, then this object's upper 3x3 matrix components
		/// are replaced by the passed rotation components,
		/// and then the scale is reapplied to the rotational components.
		/// </remarks>
		/// <param name="m1">single precision 3x3 matrix</param>
		public void SetRotation(Matrix3f m1)
		{
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			GetScaleRotate(tmp_scale, tmp_rot);
			m00 = (float)(m1.m00 * tmp_scale[0]);
			m01 = (float)(m1.m01 * tmp_scale[1]);
			m02 = (float)(m1.m02 * tmp_scale[2]);
			m10 = (float)(m1.m10 * tmp_scale[0]);
			m11 = (float)(m1.m11 * tmp_scale[1]);
			m12 = (float)(m1.m12 * tmp_scale[2]);
			m20 = (float)(m1.m20 * tmp_scale[0]);
			m21 = (float)(m1.m21 * tmp_scale[1]);
			m22 = (float)(m1.m22 * tmp_scale[2]);
		}

		/// <summary>
		/// Sets the rotational component (upper 3x3) of this matrix to the
		/// matrix equivalent values of the quaternion argument; the other
		/// elements of this matrix are unchanged; a singular value
		/// decomposition is performed on this object's upper 3x3 matrix to
		/// factor out the scale, then this object's upper 3x3 matrix components
		/// are replaced by the matrix equivalent of the quaternion,
		/// and then the scale is reapplied to the rotational components.
		/// </summary>
		/// <remarks>
		/// Sets the rotational component (upper 3x3) of this matrix to the
		/// matrix equivalent values of the quaternion argument; the other
		/// elements of this matrix are unchanged; a singular value
		/// decomposition is performed on this object's upper 3x3 matrix to
		/// factor out the scale, then this object's upper 3x3 matrix components
		/// are replaced by the matrix equivalent of the quaternion,
		/// and then the scale is reapplied to the rotational components.
		/// </remarks>
		/// <param name="q1">the quaternion that specifies the rotation</param>
		public void SetRotation(Quat4f q1)
		{
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			GetScaleRotate(tmp_scale, tmp_rot);
			m00 = (float)((1.0f - 2.0f * q1.y * q1.y - 2.0f * q1.z * q1.z) * tmp_scale[0]);
			m10 = (float)((2.0f * (q1.x * q1.y + q1.w * q1.z)) * tmp_scale[0]);
			m20 = (float)((2.0f * (q1.x * q1.z - q1.w * q1.y)) * tmp_scale[0]);
			m01 = (float)((2.0f * (q1.x * q1.y - q1.w * q1.z)) * tmp_scale[1]);
			m11 = (float)((1.0f - 2.0f * q1.x * q1.x - 2.0f * q1.z * q1.z) * tmp_scale[1]);
			m21 = (float)((2.0f * (q1.y * q1.z + q1.w * q1.x)) * tmp_scale[1]);
			m02 = (float)((2.0f * (q1.x * q1.z + q1.w * q1.y)) * tmp_scale[2]);
			m12 = (float)((2.0f * (q1.y * q1.z - q1.w * q1.x)) * tmp_scale[2]);
			m22 = (float)((1.0f - 2.0f * q1.x * q1.x - 2.0f * q1.y * q1.y) * tmp_scale[2]);
		}

		/// <summary>
		/// Sets the rotational component (upper 3x3) of this matrix to the
		/// matrix equivalent values of the quaternion argument; the other
		/// elements of this matrix are unchanged; a singular value
		/// decomposition is performed on this object's upper 3x3 matrix to
		/// factor out the scale, then this object's upper 3x3 matrix components
		/// are replaced by the matrix equivalent of the quaternion,
		/// and then the scale is reapplied to the rotational components.
		/// </summary>
		/// <remarks>
		/// Sets the rotational component (upper 3x3) of this matrix to the
		/// matrix equivalent values of the quaternion argument; the other
		/// elements of this matrix are unchanged; a singular value
		/// decomposition is performed on this object's upper 3x3 matrix to
		/// factor out the scale, then this object's upper 3x3 matrix components
		/// are replaced by the matrix equivalent of the quaternion,
		/// and then the scale is reapplied to the rotational components.
		/// </remarks>
		/// <param name="q1">the quaternion that specifies the rotation</param>
		public void SetRotation(Quat4d q1)
		{
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			GetScaleRotate(tmp_scale, tmp_rot);
			m00 = (float)((1.0f - 2.0f * q1.y * q1.y - 2.0f * q1.z * q1.z) * tmp_scale[0]);
			m10 = (float)((2.0f * (q1.x * q1.y + q1.w * q1.z)) * tmp_scale[0]);
			m20 = (float)((2.0f * (q1.x * q1.z - q1.w * q1.y)) * tmp_scale[0]);
			m01 = (float)((2.0f * (q1.x * q1.y - q1.w * q1.z)) * tmp_scale[1]);
			m11 = (float)((1.0f - 2.0f * q1.x * q1.x - 2.0f * q1.z * q1.z) * tmp_scale[1]);
			m21 = (float)((2.0f * (q1.y * q1.z + q1.w * q1.x)) * tmp_scale[1]);
			m02 = (float)((2.0f * (q1.x * q1.z + q1.w * q1.y)) * tmp_scale[2]);
			m12 = (float)((2.0f * (q1.y * q1.z - q1.w * q1.x)) * tmp_scale[2]);
			m22 = (float)((1.0f - 2.0f * q1.x * q1.x - 2.0f * q1.y * q1.y) * tmp_scale[2]);
		}

		/// <summary>
		/// Sets the rotational component (upper 3x3) of this matrix to the
		/// matrix equivalent values of the axis-angle argument; the other
		/// elements of this matrix are unchanged; a singular value
		/// decomposition is performed on this object's upper 3x3 matrix to
		/// factor out the scale, then this object's upper 3x3 matrix components
		/// are replaced by the matrix equivalent of the axis-angle,
		/// and then the scale is reapplied to the rotational components.
		/// </summary>
		/// <remarks>
		/// Sets the rotational component (upper 3x3) of this matrix to the
		/// matrix equivalent values of the axis-angle argument; the other
		/// elements of this matrix are unchanged; a singular value
		/// decomposition is performed on this object's upper 3x3 matrix to
		/// factor out the scale, then this object's upper 3x3 matrix components
		/// are replaced by the matrix equivalent of the axis-angle,
		/// and then the scale is reapplied to the rotational components.
		/// </remarks>
		/// <param name="a1">the axis-angle to be converted (x, y, z, angle)</param>
		public void SetRotation(AxisAngle4f a1)
		{
			double[] tmp_rot = new double[9];
			// scratch matrix
			double[] tmp_scale = new double[3];
			// scratch matrix
			GetScaleRotate(tmp_scale, tmp_rot);
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
				double xz = a1.x * a1.z;
				double xy = a1.x * a1.y;
				double yz = a1.y * a1.z;
				m00 = (float)((t * ax * ax + cosTheta) * tmp_scale[0]);
				m01 = (float)((t * xy - sinTheta * az) * tmp_scale[1]);
				m02 = (float)((t * xz + sinTheta * ay) * tmp_scale[2]);
				m10 = (float)((t * xy + sinTheta * az) * tmp_scale[0]);
				m11 = (float)((t * ay * ay + cosTheta) * tmp_scale[1]);
				m12 = (float)((t * yz - sinTheta * ax) * tmp_scale[2]);
				m20 = (float)((t * xz - sinTheta * ay) * tmp_scale[0]);
				m21 = (float)((t * yz + sinTheta * ax) * tmp_scale[1]);
				m22 = (float)((t * az * az + cosTheta) * tmp_scale[2]);
			}
		}

		/// <summary>Sets this matrix to all zeros.</summary>
		/// <remarks>Sets this matrix to all zeros.</remarks>
		public void SetZero()
		{
			m00 = 0.0f;
			m01 = 0.0f;
			m02 = 0.0f;
			m03 = 0.0f;
			m10 = 0.0f;
			m11 = 0.0f;
			m12 = 0.0f;
			m13 = 0.0f;
			m20 = 0.0f;
			m21 = 0.0f;
			m22 = 0.0f;
			m23 = 0.0f;
			m30 = 0.0f;
			m31 = 0.0f;
			m32 = 0.0f;
			m33 = 0.0f;
		}

		/// <summary>Negates the value of this matrix: this = -this.</summary>
		/// <remarks>Negates the value of this matrix: this = -this.</remarks>
		public void Negate()
		{
			m00 = -m00;
			m01 = -m01;
			m02 = -m02;
			m03 = -m03;
			m10 = -m10;
			m11 = -m11;
			m12 = -m12;
			m13 = -m13;
			m20 = -m20;
			m21 = -m21;
			m22 = -m22;
			m23 = -m23;
			m30 = -m30;
			m31 = -m31;
			m32 = -m32;
			m33 = -m33;
		}

		/// <summary>
		/// Sets the value of this matrix equal to the negation of
		/// of the Matrix4f parameter.
		/// </summary>
		/// <remarks>
		/// Sets the value of this matrix equal to the negation of
		/// of the Matrix4f parameter.
		/// </remarks>
		/// <param name="m1">the source matrix</param>
		public void Negate(Matrix4f m1)
		{
			this.m00 = -m1.m00;
			this.m01 = -m1.m01;
			this.m02 = -m1.m02;
			this.m03 = -m1.m03;
			this.m10 = -m1.m10;
			this.m11 = -m1.m11;
			this.m12 = -m1.m12;
			this.m13 = -m1.m13;
			this.m20 = -m1.m20;
			this.m21 = -m1.m21;
			this.m22 = -m1.m22;
			this.m23 = -m1.m23;
			this.m30 = -m1.m30;
			this.m31 = -m1.m31;
			this.m32 = -m1.m32;
			this.m33 = -m1.m33;
		}

		private void GetScaleRotate(double[] scales, double[] rots)
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
			Matrix3d.Compute_svd(tmp, scales, rots);
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
			Matrix4f m1 = null;
			m1 = (Matrix4f)base.MemberwiseClone();
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

		/// <summary>Get the third matrix element in the third row.</summary>
		/// <remarks>Get the third matrix element in the third row.</remarks>
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

		/// <summary>Get the fourth element of the first row.</summary>
		/// <remarks>Get the fourth element of the first row.</remarks>
		/// <returns>Returns the m03.</returns>
		/// <since>vecmath 1.5</since>
		public float GetM03()
		{
			return m03;
		}

		/// <summary>Set the fourth element of the first row.</summary>
		/// <remarks>Set the fourth element of the first row.</remarks>
		/// <param name="m03">The m03 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM03(float m03)
		{
			this.m03 = m03;
		}

		/// <summary>Get the fourth element of the second row.</summary>
		/// <remarks>Get the fourth element of the second row.</remarks>
		/// <returns>Returns the m13.</returns>
		/// <since>vecmath 1.5</since>
		public float GetM13()
		{
			return m13;
		}

		/// <summary>Set the fourth element of the second row.</summary>
		/// <remarks>Set the fourth element of the second row.</remarks>
		/// <param name="m13">The m13 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM13(float m13)
		{
			this.m13 = m13;
		}

		/// <summary>Get the fourth element of the third row.</summary>
		/// <remarks>Get the fourth element of the third row.</remarks>
		/// <returns>Returns the m23.</returns>
		/// <since>vecmath 1.5</since>
		public float GetM23()
		{
			return m23;
		}

		/// <summary>Set the fourth element of the third row.</summary>
		/// <remarks>Set the fourth element of the third row.</remarks>
		/// <param name="m23">The m23 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM23(float m23)
		{
			this.m23 = m23;
		}

		/// <summary>Get the first element of the fourth row.</summary>
		/// <remarks>Get the first element of the fourth row.</remarks>
		/// <returns>Returns the m30.</returns>
		/// <since>vecmath 1.5</since>
		public float GetM30()
		{
			return m30;
		}

		/// <summary>Set the first element of the fourth row.</summary>
		/// <remarks>Set the first element of the fourth row.</remarks>
		/// <param name="m30">The m30 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM30(float m30)
		{
			this.m30 = m30;
		}

		/// <summary>Get the second element of the fourth row.</summary>
		/// <remarks>Get the second element of the fourth row.</remarks>
		/// <returns>Returns the m31.</returns>
		/// <since>vecmath 1.5</since>
		public float GetM31()
		{
			return m31;
		}

		/// <summary>Set the second element of the fourth row.</summary>
		/// <remarks>Set the second element of the fourth row.</remarks>
		/// <param name="m31">The m31 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM31(float m31)
		{
			this.m31 = m31;
		}

		/// <summary>Get the third element of the fourth row.</summary>
		/// <remarks>Get the third element of the fourth row.</remarks>
		/// <returns>Returns the m32.</returns>
		/// <since>vecmath 1.5</since>
		public float GetM32()
		{
			return m32;
		}

		/// <summary>Set the third element of the fourth row.</summary>
		/// <remarks>Set the third element of the fourth row.</remarks>
		/// <param name="m32">The m32 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM32(float m32)
		{
			this.m32 = m32;
		}

		/// <summary>Get the fourth element of the fourth row.</summary>
		/// <remarks>Get the fourth element of the fourth row.</remarks>
		/// <returns>Returns the m33.</returns>
		/// <since>vecmath 1.5</since>
		public float GetM33()
		{
			return m33;
		}

		/// <summary>Set the fourth element of the fourth row.</summary>
		/// <remarks>Set the fourth element of the fourth row.</remarks>
		/// <param name="m33">The m33 to set.</param>
		/// <since>vecmath 1.5</since>
		public void SetM33(float m33)
		{
			this.m33 = m33;
		}
	}
}
