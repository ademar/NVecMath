/*
 * Automated conversion
 */

using System;
using System.Text;

namespace NVecMath
{
	/// <summary>
	/// A double precision, general, dynamically-resizable,
	/// one-dimensional vector class.
	/// </summary>
	/// <remarks>
	/// A double precision, general, dynamically-resizable,
	/// one-dimensional vector class.  Index numbering begins with zero.
	/// </remarks>
	[System.Serializable]
	public class GVector : ICloneable
	{
		private int length;

		internal double[] values;

		internal const long serialVersionUID = 1398850036893875112L;

		/// <summary>
		/// Constructs a new GVector of the specified
		/// length with all vector elements initialized to 0.
		/// </summary>
		/// <remarks>
		/// Constructs a new GVector of the specified
		/// length with all vector elements initialized to 0.
		/// </remarks>
		/// <param name="length">the number of elements in this GVector.</param>
		public GVector(int length)
		{
			// Compatible with 1.1
			int i;
			this.length = length;
			values = new double[length];
			for (i = 0; i < length; i++)
			{
				values[i] = 0.0;
			}
		}

		/// <summary>Constructs a new GVector from the specified array elements.</summary>
		/// <remarks>
		/// Constructs a new GVector from the specified array elements.
		/// The length of this GVector is set to the length of the
		/// specified array.  The array elements are copied into this new
		/// GVector.
		/// </remarks>
		/// <param name="vector">the values for the new GVector.</param>
		public GVector(double[] vector)
		{
			int i;
			length = vector.Length;
			values = new double[vector.Length];
			for (i = 0; i < length; i++)
			{
				values[i] = vector[i];
			}
		}

		/// <summary>Constructs a new GVector from the specified vector.</summary>
		/// <remarks>
		/// Constructs a new GVector from the specified vector.
		/// The vector elements are copied into this new GVector.
		/// </remarks>
		/// <param name="vector">the source GVector for this new GVector.</param>
		public GVector(GVector vector)
		{
			int i;
			values = new double[vector.length];
			length = vector.length;
			for (i = 0; i < length; i++)
			{
				values[i] = vector.values[i];
			}
		}

		/// <summary>
		/// Constructs a new GVector and copies the initial values
		/// from the specified tuple.
		/// </summary>
		/// <remarks>
		/// Constructs a new GVector and copies the initial values
		/// from the specified tuple.
		/// </remarks>
		/// <param name="tuple">the source for the new GVector's initial values</param>
		public GVector(Tuple2f tuple)
		{
			values = new double[2];
			values[0] = (double)tuple.x;
			values[1] = (double)tuple.y;
			length = 2;
		}

		/// <summary>
		/// Constructs a new GVector and copies the initial values
		/// from the specified tuple.
		/// </summary>
		/// <remarks>
		/// Constructs a new GVector and copies the initial values
		/// from the specified tuple.
		/// </remarks>
		/// <param name="tuple">the source for the new GVector's initial values</param>
		public GVector(Tuple3f tuple)
		{
			values = new double[3];
			values[0] = (double)tuple.x;
			values[1] = (double)tuple.y;
			values[2] = (double)tuple.z;
			length = 3;
		}

		/// <summary>
		/// Constructs a new GVector and copies the initial values
		/// from the specified tuple.
		/// </summary>
		/// <remarks>
		/// Constructs a new GVector and copies the initial values
		/// from the specified tuple.
		/// </remarks>
		/// <param name="tuple">the source for the new GVector's initial values</param>
		public GVector(Tuple3d tuple)
		{
			values = new double[3];
			values[0] = tuple.x;
			values[1] = tuple.y;
			values[2] = tuple.z;
			length = 3;
		}

		/// <summary>
		/// Constructs a new GVector and copies the initial values
		/// from the specified tuple.
		/// </summary>
		/// <remarks>
		/// Constructs a new GVector and copies the initial values
		/// from the specified tuple.
		/// </remarks>
		/// <param name="tuple">the source for the new GVector's initial values</param>
		public GVector(Tuple4f tuple)
		{
			values = new double[4];
			values[0] = (double)tuple.x;
			values[1] = (double)tuple.y;
			values[2] = (double)tuple.z;
			values[3] = (double)tuple.w;
			length = 4;
		}

		/// <summary>
		/// Constructs a new GVector and copies the initial values
		/// from the specified tuple.
		/// </summary>
		/// <remarks>
		/// Constructs a new GVector and copies the initial values
		/// from the specified tuple.
		/// </remarks>
		/// <param name="tuple">the source for the new GVector's initial values</param>
		public GVector(Tuple4d tuple)
		{
			values = new double[4];
			values[0] = tuple.x;
			values[1] = tuple.y;
			values[2] = tuple.z;
			values[3] = tuple.w;
			length = 4;
		}

		/// <summary>
		/// Constructs a new GVector of the specified length and
		/// initializes it by copying the specified number of elements from
		/// the specified array.
		/// </summary>
		/// <remarks>
		/// Constructs a new GVector of the specified length and
		/// initializes it by copying the specified number of elements from
		/// the specified array.  The array must contain at least
		/// <code>length</code> elements (i.e., <code>vector.length</code> &gt;=
		/// <code>length</code>.  The length of this new GVector is set to
		/// the specified length.
		/// </remarks>
		/// <param name="vector">The array from which the values will be copied.</param>
		/// <param name="length">The number of values copied from the array.</param>
		public GVector(double[] vector, int length)
		{
			int i;
			this.length = length;
			values = new double[length];
			for (i = 0; i < length; i++)
			{
				values[i] = vector[i];
			}
		}

		/// <summary>
		/// Returns the square root of the sum of the squares of this
		/// vector (its length in n-dimensional space).
		/// </summary>
		/// <remarks>
		/// Returns the square root of the sum of the squares of this
		/// vector (its length in n-dimensional space).
		/// </remarks>
		/// <returns>length of this vector</returns>
		public double Norm()
		{
			double sq = 0.0;
			int i;
			for (i = 0; i < length; i++)
			{
				sq += values[i] * values[i];
			}
			return (Math.Sqrt(sq));
		}

		/// <summary>
		/// Returns the sum of the squares of this
		/// vector (its length squared in n-dimensional space).
		/// </summary>
		/// <remarks>
		/// Returns the sum of the squares of this
		/// vector (its length squared in n-dimensional space).
		/// </remarks>
		/// <returns>length squared of this vector</returns>
		public double NormSquared()
		{
			double sq = 0.0;
			int i;
			for (i = 0; i < length; i++)
			{
				sq += values[i] * values[i];
			}
			return (sq);
		}

		/// <summary>Sets the value of this vector to the normalization of vector v1.</summary>
		/// <remarks>Sets the value of this vector to the normalization of vector v1.</remarks>
		/// <param name="v1">the un-normalized vector</param>
		public void Normalize(GVector v1)
		{
			double sq = 0.0;
			int i;
			if (length != v1.length)
			{
				throw new MismatchedSizeException("GVector.normalize( GVector) input vector and this vector lengths not matched");
			}
			for (i = 0; i < length; i++)
			{
				sq += v1.values[i] * v1.values[i];
			}
			double invMag;
			invMag = 1.0 / Math.Sqrt(sq);
			for (i = 0; i < length; i++)
			{
				values[i] = v1.values[i] * invMag;
			}
		}

		/// <summary>Normalizes this vector in place.</summary>
		/// <remarks>Normalizes this vector in place.</remarks>
		public void Normalize()
		{
			double sq = 0.0;
			int i;
			for (i = 0; i < length; i++)
			{
				sq += values[i] * values[i];
			}
			double invMag;
			invMag = 1.0 / Math.Sqrt(sq);
			for (i = 0; i < length; i++)
			{
				values[i] = values[i] * invMag;
			}
		}

		/// <summary>
		/// Sets the value of this vector to the scalar multiplication
		/// of the scale factor with the vector v1.
		/// </summary>
		/// <remarks>
		/// Sets the value of this vector to the scalar multiplication
		/// of the scale factor with the vector v1.
		/// </remarks>
		/// <param name="s">the scalar value</param>
		/// <param name="v1">the source vector</param>
		public void Scale(double s, GVector v1)
		{
			int i;
			if (length != v1.length)
			{
				throw new MismatchedSizeException("GVector.scale(double,  GVector) input vector and this vector lengths not matched");
			}
			for (i = 0; i < length; i++)
			{
				values[i] = v1.values[i] * s;
			}
		}

		/// <summary>Scales this vector by the scale factor s.</summary>
		/// <remarks>Scales this vector by the scale factor s.</remarks>
		/// <param name="s">the scalar value</param>
		public void Scale(double s)
		{
			int i;
			for (i = 0; i < length; i++)
			{
				values[i] = values[i] * s;
			}
		}

		/// <summary>
		/// Sets the value of this vector to the scalar multiplication by s
		/// of vector v1 plus vector v2 (this = s*v1 + v2).
		/// </summary>
		/// <remarks>
		/// Sets the value of this vector to the scalar multiplication by s
		/// of vector v1 plus vector v2 (this = s*v1 + v2).
		/// </remarks>
		/// <param name="s">the scalar value</param>
		/// <param name="v1">the vector to be multiplied</param>
		/// <param name="v2">the vector to be added</param>
		public void ScaleAdd(double s, GVector v1, GVector v2)
		{
			int i;
			if (v2.length != v1.length)
			{
				throw new MismatchedSizeException("GVector.scaleAdd(GVector, GVector) input vector dimensions not matched");
			}
			if (length != v1.length)
			{
				throw new MismatchedSizeException("GVector.scaleAdd(GVector, GVector) input vectors and  this vector dimensions not matched");
			}
			for (i = 0; i < length; i++)
			{
				values[i] = v1.values[i] * s + v2.values[i];
			}
		}

		/// <summary>
		/// Sets the value of this vector to sum of itself and the specified
		/// vector
		/// </summary>
		/// <param name="vector">the second vector</param>
		public void Add(GVector vector)
		{
			int i;
			if (length != vector.length)
			{
				throw new MismatchedSizeException("GVector.add(GVector) input vectors and  this vector dimensions not matched");
			}
			for (i = 0; i < length; i++)
			{
				this.values[i] += vector.values[i];
			}
		}

		/// <summary>
		/// Sets the value of this vector to the vector sum of vectors vector1
		/// and vector2.
		/// </summary>
		/// <remarks>
		/// Sets the value of this vector to the vector sum of vectors vector1
		/// and vector2.
		/// </remarks>
		/// <param name="vector1">the first vector</param>
		/// <param name="vector2">the second vector</param>
		public void Add(GVector vector1, GVector vector2)
		{
			int i;
			if (vector1.length != vector2.length)
			{
				throw new MismatchedSizeException("GVector.add(GVector, GVector) input vector dimensions not matched");
			}
			if (length != vector1.length)
			{
				throw new MismatchedSizeException("GVector.add(GVector, GVector) input vectors and  this vector dimensions not matched");
			}
			for (i = 0; i < length; i++)
			{
				this.values[i] = vector1.values[i] + vector2.values[i];
			}
		}

		/// <summary>
		/// Sets the value of this vector to the vector difference of itself
		/// and vector (this = this - vector).
		/// </summary>
		/// <remarks>
		/// Sets the value of this vector to the vector difference of itself
		/// and vector (this = this - vector).
		/// </remarks>
		/// <param name="vector">the other vector</param>
		public void Sub(GVector vector)
		{
			int i;
			if (length != vector.length)
			{
				throw new MismatchedSizeException("GVector.sub(GVector) input vector and  this vector dimensions not matched");
			}
			for (i = 0; i < length; i++)
			{
				this.values[i] -= vector.values[i];
			}
		}

		/// <summary>
		/// Sets the value of this vector to the vector difference
		/// of vectors vector1 and vector2 (this = vector1 - vector2).
		/// </summary>
		/// <remarks>
		/// Sets the value of this vector to the vector difference
		/// of vectors vector1 and vector2 (this = vector1 - vector2).
		/// </remarks>
		/// <param name="vector1">the first vector</param>
		/// <param name="vector2">the second vector</param>
		public void Sub(GVector vector1, GVector vector2)
		{
			int i;
			int l;
			if (vector1.length != vector2.length)
			{
				throw new MismatchedSizeException("GVector.sub(GVector,  GVector) input vector dimensions not matched");
			}
			if (length != vector1.length)
			{
				throw new MismatchedSizeException("GVector.sub(GMatrix,  GVector) input vectors and this vector dimensions not matched");
			}
			for (i = 0; i < length; i++)
			{
				this.values[i] = vector1.values[i] - vector2.values[i];
			}
		}

		/// <summary>
		/// Multiplies matrix m1 times Vector v1 and places the result
		/// into this vector (this = m1*v1).
		/// </summary>
		/// <remarks>
		/// Multiplies matrix m1 times Vector v1 and places the result
		/// into this vector (this = m1*v1).
		/// </remarks>
		/// <param name="m1">The matrix in the multiplication</param>
		/// <param name="v1">The vector that is multiplied</param>
		public void Mul(GMatrix m1, GVector v1)
		{
			if (m1.GetNumCol() != v1.length)
			{
				throw new MismatchedSizeException("GVector.mul(GMatrix,  GVector) matrix and vector dimensions not matched");
			}
			if (length != m1.GetNumRow())
			{
				throw new MismatchedSizeException("GVector.mul(GMatrix,  GVector) matrix this vector dimensions not matched");
			}
			double[] v;
			if (v1 != this)
			{
				v = v1.values;
			}
			else
			{
				v = (double[])values.Clone();
			}
			for (int j = length - 1; j >= 0; j--)
			{
				values[j] = 0.0;
				for (int i = v1.length - 1; i >= 0; i--)
				{
					values[j] += m1.values[j][i] * v[i];
				}
			}
		}

		/// <summary>
		/// Multiplies the transpose of vector v1 (ie, v1 becomes a row
		/// vector with respect to the multiplication) times matrix m1
		/// and places the result into this vector
		/// (this = transpose(v1)*m1).
		/// </summary>
		/// <remarks>
		/// Multiplies the transpose of vector v1 (ie, v1 becomes a row
		/// vector with respect to the multiplication) times matrix m1
		/// and places the result into this vector
		/// (this = transpose(v1)*m1).  The result is technically a
		/// row vector, but the GVector class only knows about column
		/// vectors, and so the result is stored as a column vector.
		/// </remarks>
		/// <param name="m1">The matrix in the multiplication</param>
		/// <param name="v1">The vector that is temporarily transposed</param>
		public void Mul(GVector v1, GMatrix m1)
		{
			if (m1.GetNumRow() != v1.length)
			{
				throw new MismatchedSizeException("GVector.mul(GVector, GMatrix) matrix and vector dimensions not matched");
			}
			if (length != m1.GetNumCol())
			{
				throw new MismatchedSizeException("GVector.mul(GVector, GMatrix) matrix this vector dimensions not matched");
			}
			double[] v;
			if (v1 != this)
			{
				v = v1.values;
			}
			else
			{
				v = (double[])values.Clone();
			}
			for (int j = length - 1; j >= 0; j--)
			{
				values[j] = 0.0;
				for (int i = v1.length - 1; i >= 0; i--)
				{
					values[j] += m1.values[i][j] * v[i];
				}
			}
		}

		/// <summary>Negates the value of this vector: this = -this.</summary>
		/// <remarks>Negates the value of this vector: this = -this.</remarks>
		public void Negate()
		{
			for (int i = length - 1; i >= 0; i--)
			{
				this.values[i] *= -1.0;
			}
		}

		/// <summary>Sets all the values in this vector to zero.</summary>
		/// <remarks>Sets all the values in this vector to zero.</remarks>
		public void Zero()
		{
			for (int i = 0; i < this.length; i++)
			{
				this.values[i] = 0.0;
			}
		}

		/// <summary>Changes the size of this vector dynamically.</summary>
		/// <remarks>
		/// Changes the size of this vector dynamically.  If the size is increased
		/// no data values will be lost.  If the size is decreased, only those data
		/// values whose vector positions were eliminated will be lost.
		/// </remarks>
		/// <param name="length">number of desired elements in this vector</param>
		public void SetSize(int length)
		{
			double[] tmp = new double[length];
			int i;
			int max;
			if (this.length < length)
			{
				max = this.length;
			}
			else
			{
				max = length;
			}
			for (i = 0; i < max; i++)
			{
				tmp[i] = values[i];
			}
			this.length = length;
			values = tmp;
		}

		/// <summary>
		/// Sets the value of this vector to the values found in the array
		/// parameter.
		/// </summary>
		/// <remarks>
		/// Sets the value of this vector to the values found in the array
		/// parameter. The array should be at least equal in length to
		/// the number of elements in the vector.
		/// </remarks>
		/// <param name="vector">the source array</param>
		public void Set(double[] vector)
		{
			for (int i = length - 1; i >= 0; i--)
			{
				values[i] = vector[i];
			}
		}

		/// <summary>Sets the value of this vector to the values found in vector vector.</summary>
		/// <remarks>Sets the value of this vector to the values found in vector vector.</remarks>
		/// <param name="vector">the source vector</param>
		public void Set(GVector vector)
		{
			int i;
			if (length < vector.length)
			{
				length = vector.length;
				values = new double[length];
				for (i = 0; i < length; i++)
				{
					values[i] = vector.values[i];
				}
			}
			else
			{
				for (i = 0; i < vector.length; i++)
				{
					values[i] = vector.values[i];
				}
				for (i = vector.length; i < length; i++)
				{
					values[i] = 0.0;
				}
			}
		}

		/// <summary>Sets the value of this vector to the values in tuple</summary>
		/// <param name="tuple">the source for the new GVector's new values</param>
		public void Set(Tuple2f tuple)
		{
			if (length < 2)
			{
				length = 2;
				values = new double[2];
			}
			values[0] = (double)tuple.x;
			values[1] = (double)tuple.y;
			for (int i = 2; i < length; i++)
			{
				values[i] = 0.0;
			}
		}

		/// <summary>Sets the value of this vector to the values in tuple</summary>
		/// <param name="tuple">the source for the new GVector's new values</param>
		public void Set(Tuple3f tuple)
		{
			if (length < 3)
			{
				length = 3;
				values = new double[3];
			}
			values[0] = (double)tuple.x;
			values[1] = (double)tuple.y;
			values[2] = (double)tuple.z;
			for (int i = 3; i < length; i++)
			{
				values[i] = 0.0;
			}
		}

		/// <summary>Sets the value of this vector to the values in tuple</summary>
		/// <param name="tuple">the source for the new GVector's new values</param>
		public void Set(Tuple3d tuple)
		{
			if (length < 3)
			{
				length = 3;
				values = new double[3];
			}
			values[0] = tuple.x;
			values[1] = tuple.y;
			values[2] = tuple.z;
			for (int i = 3; i < length; i++)
			{
				values[i] = 0.0;
			}
		}

		/// <summary>Sets the value of this vector to the values in tuple</summary>
		/// <param name="tuple">the source for the new GVector's new values</param>
		public void Set(Tuple4f tuple)
		{
			if (length < 4)
			{
				length = 4;
				values = new double[4];
			}
			values[0] = (double)tuple.x;
			values[1] = (double)tuple.y;
			values[2] = (double)tuple.z;
			values[3] = (double)tuple.w;
			for (int i = 4; i < length; i++)
			{
				values[i] = 0.0;
			}
		}

		/// <summary>Sets the value of this vector to the values in tuple</summary>
		/// <param name="tuple">the source for the new GVector's new values</param>
		public void Set(Tuple4d tuple)
		{
			if (length < 4)
			{
				length = 4;
				values = new double[4];
			}
			values[0] = tuple.x;
			values[1] = tuple.y;
			values[2] = tuple.z;
			values[3] = tuple.w;
			for (int i = 4; i < length; i++)
			{
				values[i] = 0.0;
			}
		}

		/// <summary>Returns the number of elements in this vector.</summary>
		/// <remarks>Returns the number of elements in this vector.</remarks>
		/// <returns>number of elements in this vector</returns>
		public int GetSize()
		{
			return values.Length;
		}

		/// <summary>Retrieves the value at the specified index value of this vector.</summary>
		/// <remarks>Retrieves the value at the specified index value of this vector.</remarks>
		/// <param name="index">the index of the element to retrieve (zero indexed)</param>
		/// <returns>the value at the indexed element</returns>
		public double GetElement(int index)
		{
			return values[index];
		}

		/// <summary>Modifies the value at the specified index of this vector.</summary>
		/// <remarks>Modifies the value at the specified index of this vector.</remarks>
		/// <param name="index">the index if the element to modify (zero indexed)</param>
		/// <param name="value">the new vector element value</param>
		public void SetElement(int index, double value)
		{
			values[index] = value;
		}

		/// <summary>Returns a string that contains the values of this GVector.</summary>
		/// <remarks>Returns a string that contains the values of this GVector.</remarks>
		/// <returns>the String representation</returns>
		public override string ToString()
		{
			StringBuilder buffer = new StringBuilder(length * 8);
			int i;
			for (i = 0; i < length; i++)
			{
				buffer.Append(values[i]).Append(" ");
			}
			return buffer.ToString();
		}

		/// <summary>
		/// Returns a hash code value based on the data values in this
		/// object.
		/// </summary>
		/// <remarks>
		/// Returns a hash code value based on the data values in this
		/// object.  Two different GVector objects with identical data
		/// values (i.e., GVector.equals returns true) will return the
		/// same hash number.  Two GVector objects with different data
		/// members may return the same hash value, although this is not
		/// likely.
		/// </remarks>
		/// <returns>the integer hash code value</returns>
		public override int GetHashCode()
		{
			long bits = 1L;
			for (int i = 0; i < length; i++)
			{
				bits = 31L * bits + VecMathUtil.DoubleToLongBits(values[i]);
			}
			return (int)(bits ^ (bits >> 32));
		}

		/// <summary>
		/// Returns true if all of the data members of GVector vector1 are
		/// equal to the corresponding data members in this GVector.
		/// </summary>
		/// <remarks>
		/// Returns true if all of the data members of GVector vector1 are
		/// equal to the corresponding data members in this GVector.
		/// </remarks>
		/// <param name="vector1">The vector with which the comparison is made.</param>
		/// <returns>true or false</returns>
		public virtual bool Equals(GVector vector1)
		{
			try
			{
				if (length != vector1.length)
				{
					return false;
				}
				for (int i = 0; i < length; i++)
				{
					if (values[i] != vector1.values[i])
					{
						return false;
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
				GVector v2 = (GVector)o1;
				if (length != v2.length)
				{
					return false;
				}
				for (int i = 0; i < length; i++)
				{
					if (values[i] != v2.values[i])
					{
						return false;
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

		/// <summary>
		/// Returns true if the L-infinite distance between this vector
		/// and vector v1 is less than or equal to the epsilon parameter,
		/// otherwise returns false.
		/// </summary>
		/// <remarks>
		/// Returns true if the L-infinite distance between this vector
		/// and vector v1 is less than or equal to the epsilon parameter,
		/// otherwise returns false.  The L-infinite
		/// distance is equal to
		/// MAX[abs(x1-x2), abs(y1-y2), . . .  ].
		/// </remarks>
		/// <param name="v1">The vector to be compared to this vector</param>
		/// <param name="epsilon">the threshold value</param>
		public virtual bool EpsilonEquals(GVector v1, double epsilon)
		{
			double diff;
			if (length != v1.length)
			{
				return false;
			}
			for (int i = 0; i < length; i++)
			{
				diff = values[i] - v1.values[i];
				if ((diff < 0 ? -diff : diff) > epsilon)
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>Returns the dot product of this vector and vector v1.</summary>
		/// <remarks>Returns the dot product of this vector and vector v1.</remarks>
		/// <param name="v1">the other vector</param>
		/// <returns>the dot product of this and v1</returns>
		public double Dot(GVector v1)
		{
			if (length != v1.length)
			{
				throw new MismatchedSizeException("GVector.dot(GVector) input vector and this vector have different sizes");
			}
			double result = 0.0;
			for (int i = 0; i < length; i++)
			{
				result += values[i] * v1.values[i];
			}
			return result;
		}

		/// <summary>
		/// Solves for x in Ax = b, where x is this vector (nx1), A is mxn,
		/// b is mx1, and A = U*W*transpose(V); U,W,V must
		/// be precomputed and can be found by taking the singular value
		/// decomposition (SVD) of A using the method SVD found in the
		/// GMatrix class.
		/// </summary>
		/// <remarks>
		/// Solves for x in Ax = b, where x is this vector (nx1), A is mxn,
		/// b is mx1, and A = U*W*transpose(V); U,W,V must
		/// be precomputed and can be found by taking the singular value
		/// decomposition (SVD) of A using the method SVD found in the
		/// GMatrix class.
		/// </remarks>
		/// <param name="U">The U matrix produced by the GMatrix method SVD</param>
		/// <param name="W">The W matrix produced by the GMatrix method SVD</param>
		/// <param name="V">The V matrix produced by the GMatrix method SVD</param>
		/// <param name="b">The b vector in the linear equation Ax = b</param>
		public void SVDBackSolve(GMatrix U, GMatrix W, GMatrix V, GVector b)
		{
			if (!(U.nRow == b.GetSize() && U.nRow == U.nCol && U.nRow == W.nRow))
			{
				throw new MismatchedSizeException("matrix dimensions are not compatible");
			}
			if (!(W.nCol == values.Length && W.nCol == V.nCol && W.nCol == V.nRow))
			{
				throw new MismatchedSizeException("matrix dimensions are not compatible");
			}
			GMatrix tmp = new GMatrix(U.nRow, W.nCol);
			tmp.Mul(U, V);
			tmp.MulTransposeRight(U, W);
			tmp.Invert();
			Mul(tmp, b);
		}

		/// <summary>
		/// LU Decomposition Back Solve; this method takes the LU matrix
		/// and the permutation vector produced by the GMatrix method LUD
		/// and solves the equation (LU)*x = b by placing the solution vector
		/// x into this vector.
		/// </summary>
		/// <remarks>
		/// LU Decomposition Back Solve; this method takes the LU matrix
		/// and the permutation vector produced by the GMatrix method LUD
		/// and solves the equation (LU)*x = b by placing the solution vector
		/// x into this vector.  This vector should be the same length or
		/// longer than b.
		/// </remarks>
		/// <param name="Lu">
		/// The matrix into which the lower and upper decompostions
		/// have been placed
		/// </param>
		/// <param name="b">The b vector in the equation (LU)*x = b</param>
		/// <param name="permutation">
		/// The row permuations that were necessary to
		/// produce the LU matrix parameter
		/// </param>
		public void LUDBackSolve(GMatrix Lu, GVector b, GVector permutation
			)
		{
			int size = Lu.nRow * Lu.nCol;
			double[] temp = new double[size];
			double[] result = new double[size];
			int[] row_perm = new int[b.GetSize()];
			int i;
			int j;
			if (Lu.nRow != b.GetSize())
			{
				throw new MismatchedSizeException("b vector does not match matrix dimension");
			}
			if (Lu.nRow != permutation.GetSize())
			{
				throw new MismatchedSizeException("permutation vector does not match matrix dimension");
			}
			if (Lu.nRow != Lu.nCol)
			{
				throw new MismatchedSizeException("LUDBackSolve non square matrix");
			}
			for (i = 0; i < Lu.nRow; i++)
			{
				for (j = 0; j < Lu.nCol; j++)
				{
					temp[i * Lu.nCol + j] = Lu.values[i][j];
				}
			}
			for (i = 0; i < size; i++)
			{
				result[i] = 0.0;
			}
			for (i = 0; i < Lu.nRow; i++)
			{
				result[i * Lu.nCol] = b.values[i];
			}
			for (i = 0; i < Lu.nCol; i++)
			{
				row_perm[i] = (int)permutation.values[i];
			}
			GMatrix.LuBacksubstitution(Lu.nRow, temp, row_perm, result);
			for (i = 0; i < Lu.nRow; i++)
			{
				this.values[i] = result[i * Lu.nCol];
			}
		}

		/// <summary>
		/// Returns the (n-space) angle in radians between this vector and
		/// the vector parameter; the return value is constrained to the
		/// range [0,PI].
		/// </summary>
		/// <remarks>
		/// Returns the (n-space) angle in radians between this vector and
		/// the vector parameter; the return value is constrained to the
		/// range [0,PI].
		/// </remarks>
		/// <param name="v1">The other vector</param>
		/// <returns>The angle in radians in the range [0,PI]</returns>
		public double Angle(GVector v1)
		{
			return (Math.Acos(this.Dot(v1) / (this.Norm() * v1.Norm())));
		}

		[System.ObsoleteAttribute(@"Use interpolate(GVector, GVector, double) instead")]
		public void Interpolate(GVector v1, GVector v2, float alpha)
		{
			Interpolate(v1, v2, (double)alpha);
		}

		[System.ObsoleteAttribute(@"Use interpolate(GVector, double) instead")]
		public void Interpolate(GVector v1, float alpha)
		{
			Interpolate(v1, (double)alpha);
		}

		/// <summary>
		/// Linearly interpolates between vectors v1 and v2 and places the
		/// result into this tuple:  this = (1-alpha)*v1 + alpha*v2.
		/// </summary>
		/// <remarks>
		/// Linearly interpolates between vectors v1 and v2 and places the
		/// result into this tuple:  this = (1-alpha)*v1 + alpha*v2.
		/// </remarks>
		/// <param name="v1">the first vector</param>
		/// <param name="v2">the second vector</param>
		/// <param name="alpha">the alpha interpolation parameter</param>
		public void Interpolate(GVector v1, GVector v2, double alpha)
		{
			if (v2.length != v1.length)
			{
				throw new MismatchedSizeException("GVector.interpolate(GVector, GVector, double) input vectors have different lengths");
			}
			if (length != v1.length)
			{
				throw new MismatchedSizeException("GVector.interpolate(GVector, GVector, double) input vectors and this vector have different lengths");
			}
			for (int i = 0; i < length; i++)
			{
				values[i] = (1 - alpha) * v1.values[i] + alpha * v2.values[i];
			}
		}

		/// <summary>
		/// Linearly interpolates between this vector and vector v1 and
		/// places the result into this tuple:  this = (1-alpha)*this + alpha*v1.
		/// </summary>
		/// <remarks>
		/// Linearly interpolates between this vector and vector v1 and
		/// places the result into this tuple:  this = (1-alpha)*this + alpha*v1.
		/// </remarks>
		/// <param name="v1">the first vector</param>
		/// <param name="alpha">the alpha interpolation parameter</param>
		public void Interpolate(GVector v1, double alpha)
		{
			if (v1.length != length)
			{
				throw new MismatchedSizeException("GVector.interpolate(GVector,  double) input vectors and this vector have different lengths");
			}
			for (int i = 0; i < length; i++)
			{
				values[i] = (1 - alpha) * values[i] + alpha * v1.values[i];
			}
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
			GVector v1 = null;
			v1 = (GVector)base.MemberwiseClone();
			// this shouldn't happen, since we are Cloneable
			// Also need to clone array of values
			v1.values = new double[length];
			for (int i = 0; i < length; i++)
			{
				v1.values[i] = values[i];
			}
			return v1;
		}
	}
}
