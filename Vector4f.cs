/*
 * Automated conversion
 */

using System;

namespace NVecMath
{
	/// <summary>
	/// A 4-element vector represented by single-precision floating point x,y,z,w
	/// coordinates.
	/// </summary>
	/// <remarks>
	/// A 4-element vector represented by single-precision floating point x,y,z,w
	/// coordinates.
	/// </remarks>
	[System.Serializable]
	public class Vector4f : Tuple4f
	{
		new internal const long serialVersionUID = 8749319902347760659L;

		/// <summary>Constructs and initializes a Vector4f from the specified xyzw coordinates.
		/// 	</summary>
		/// <remarks>Constructs and initializes a Vector4f from the specified xyzw coordinates.
		/// 	</remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		/// <param name="z">the z coordinate</param>
		/// <param name="w">the w coordinate</param>
		public Vector4f(float x, float y, float z, float w) : base(x, y, z, w)
		{
		}

		/// <summary>Constructs and initializes a Vector4f from the array of length 4.</summary>
		/// <remarks>Constructs and initializes a Vector4f from the array of length 4.</remarks>
		/// <param name="v">the array of length 4 containing xyzw in order</param>
		public Vector4f(float[] v) : base(v)
		{
		}

		/// <summary>Constructs and initializes a Vector4f from the specified Vector4f.</summary>
		/// <remarks>Constructs and initializes a Vector4f from the specified Vector4f.</remarks>
		/// <param name="v1">the Vector4f containing the initialization x y z w data</param>
		public Vector4f(Vector4f v1) : base(v1)
		{
		}

		/// <summary>Constructs and initializes a Vector4f from the specified Vector4d.</summary>
		/// <remarks>Constructs and initializes a Vector4f from the specified Vector4d.</remarks>
		/// <param name="v1">the Vector4d containing the initialization x y z w data</param>
		public Vector4f(Vector4d v1) : base(v1)
		{
		}

		/// <summary>Constructs and initializes a Vector4f from the specified Tuple4f.</summary>
		/// <remarks>Constructs and initializes a Vector4f from the specified Tuple4f.</remarks>
		/// <param name="t1">the Tuple4f containing the initialization x y z w data</param>
		public Vector4f(Tuple4f t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a Vector4f from the specified Tuple4d.</summary>
		/// <remarks>Constructs and initializes a Vector4f from the specified Tuple4d.</remarks>
		/// <param name="t1">the Tuple4d containing the initialization x y z w data</param>
		public Vector4f(Tuple4d t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a Vector4f from the specified Tuple3f.</summary>
		/// <remarks>
		/// Constructs and initializes a Vector4f from the specified Tuple3f.
		/// The x,y,z components of this vector are set to the corresponding
		/// components of tuple t1.  The w component of this vector
		/// is set to 0.
		/// </remarks>
		/// <param name="t1">the tuple to be copied</param>
		/// <since>vecmath 1.2</since>
		public Vector4f(Tuple3f t1) : base(t1.x, t1.y, t1.z, 0.0f)
		{
		}

		/// <summary>Constructs and initializes a Vector4f to (0,0,0,0).</summary>
		/// <remarks>Constructs and initializes a Vector4f to (0,0,0,0).</remarks>
		public Vector4f() : base()
		{
		}

		// Compatible with 1.1
		/// <summary>
		/// Sets the x,y,z components of this vector to the corresponding
		/// components of tuple t1.
		/// </summary>
		/// <remarks>
		/// Sets the x,y,z components of this vector to the corresponding
		/// components of tuple t1.  The w component of this vector
		/// is set to 0.
		/// </remarks>
		/// <param name="t1">the tuple to be copied</param>
		/// <since>vecmath 1.2</since>
		public void Set(Tuple3f t1)
		{
			this.x = t1.x;
			this.y = t1.y;
			this.z = t1.z;
			this.w = 0.0f;
		}

		/// <summary>Returns the length of this vector.</summary>
		/// <remarks>Returns the length of this vector.</remarks>
		/// <returns>the length of this vector as a float</returns>
		public float Length()
		{
			return (float)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this
				.w * this.w);
		}

		/// <summary>Returns the squared length of this vector</summary>
		/// <returns>the squared length of this vector as a float</returns>
		public float LengthSquared()
		{
			return (this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);
		}

		/// <summary>returns the dot product of this vector and v1</summary>
		/// <param name="v1">the other vector</param>
		/// <returns>the dot product of this vector and v1</returns>
		public float Dot(Vector4f v1)
		{
			return (this.x * v1.x + this.y * v1.y + this.z * v1.z + this.w * v1.w);
		}

		/// <summary>Sets the value of this vector to the normalization of vector v1.</summary>
		/// <remarks>Sets the value of this vector to the normalization of vector v1.</remarks>
		/// <param name="v1">the un-normalized vector</param>
		public void Normalize(Vector4f v1)
		{
			float norm;
			norm = (float)(1.0 / Math.Sqrt(v1.x * v1.x + v1.y * v1.y + v1.z * v1.z + v1.w * v1
				.w));
			this.x = v1.x * norm;
			this.y = v1.y * norm;
			this.z = v1.z * norm;
			this.w = v1.w * norm;
		}

		/// <summary>Normalizes this vector in place.</summary>
		/// <remarks>Normalizes this vector in place.</remarks>
		public void Normalize()
		{
			float norm;
			norm = (float)(1.0 / Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.
				z + this.w * this.w));
			this.x *= norm;
			this.y *= norm;
			this.z *= norm;
			this.w *= norm;
		}

		/// <summary>
		/// Returns the (4-space) angle in radians between this vector and
		/// the vector parameter; the return value is constrained to the
		/// range [0,PI].
		/// </summary>
		/// <remarks>
		/// Returns the (4-space) angle in radians between this vector and
		/// the vector parameter; the return value is constrained to the
		/// range [0,PI].
		/// </remarks>
		/// <param name="v1">the other vector</param>
		/// <returns>the angle in radians in the range [0,PI]</returns>
		public float Angle(Vector4f v1)
		{
			double vDot = this.Dot(v1) / (this.Length() * v1.Length());
			if (vDot < -1.0)
			{
				vDot = -1.0;
			}
			if (vDot > 1.0)
			{
				vDot = 1.0;
			}
			return ((float)(Math.Acos(vDot)));
		}
	}
}
