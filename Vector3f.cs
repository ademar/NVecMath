/*
 * Automated conversion
 */

using System;

namespace NVecMath
{
	/// <summary>
	/// A 3-element vector that is represented by single-precision floating point
	/// x,y,z coordinates.
	/// </summary>
	/// <remarks>
	/// A 3-element vector that is represented by single-precision floating point
	/// x,y,z coordinates.  If this value represents a normal, then it should
	/// be normalized.
	/// </remarks>
	[System.Serializable]
	public class Vector3f : Tuple3f
	{
		new internal const long serialVersionUID = -7031930069184524614L;

		/// <summary>Constructs and initializes a Vector3f from the specified xyz coordinates.
		/// 	</summary>
		/// <remarks>Constructs and initializes a Vector3f from the specified xyz coordinates.
		/// 	</remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		/// <param name="z">the z coordinate</param>
		public Vector3f(float x, float y, float z) : base(x, y, z)
		{
		}

		/// <summary>Constructs and initializes a Vector3f from the array of length 3.</summary>
		/// <remarks>Constructs and initializes a Vector3f from the array of length 3.</remarks>
		/// <param name="v">the array of length 3 containing xyz in order</param>
		public Vector3f(float[] v) : base(v)
		{
		}

		/// <summary>Constructs and initializes a Vector3f from the specified Vector3f.</summary>
		/// <remarks>Constructs and initializes a Vector3f from the specified Vector3f.</remarks>
		/// <param name="v1">the Vector3f containing the initialization x y z data</param>
		public Vector3f(Vector3f v1) : base(v1)
		{
		}

		/// <summary>Constructs and initializes a Vector3f from the specified Vector3d.</summary>
		/// <remarks>Constructs and initializes a Vector3f from the specified Vector3d.</remarks>
		/// <param name="v1">the Vector3d containing the initialization x y z data</param>
		public Vector3f(Vector3d v1) : base(v1)
		{
		}

		/// <summary>Constructs and initializes a Vector3f from the specified Tuple3f.</summary>
		/// <remarks>Constructs and initializes a Vector3f from the specified Tuple3f.</remarks>
		/// <param name="t1">the Tuple3f containing the initialization x y z data</param>
		public Vector3f(Tuple3f t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a Vector3f from the specified Tuple3d.</summary>
		/// <remarks>Constructs and initializes a Vector3f from the specified Tuple3d.</remarks>
		/// <param name="t1">the Tuple3d containing the initialization x y z data</param>
		public Vector3f(Tuple3d t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a Vector3f to (0,0,0).</summary>
		/// <remarks>Constructs and initializes a Vector3f to (0,0,0).</remarks>
		public Vector3f() : base()
		{
		}

		// Combatible with 1.1
		/// <summary>Returns the squared length of this vector.</summary>
		/// <remarks>Returns the squared length of this vector.</remarks>
		/// <returns>the squared length of this vector</returns>
		public float LengthSquared()
		{
			return (this.x * this.x + this.y * this.y + this.z * this.z);
		}

		/// <summary>Returns the length of this vector.</summary>
		/// <remarks>Returns the length of this vector.</remarks>
		/// <returns>the length of this vector</returns>
		public float Length()
		{
			return (float)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
		}

		/// <summary>Sets this vector to be the vector cross product of vectors v1 and v2.</summary>
		/// <remarks>Sets this vector to be the vector cross product of vectors v1 and v2.</remarks>
		/// <param name="v1">the first vector</param>
		/// <param name="v2">the second vector</param>
		public void Cross(Vector3f v1, Vector3f v2)
		{
			float x;
			float y;
			x = v1.y * v2.z - v1.z * v2.y;
			y = v2.x * v1.z - v2.z * v1.x;
			this.z = v1.x * v2.y - v1.y * v2.x;
			this.x = x;
			this.y = y;
		}

		/// <summary>Computes the dot product of this vector and vector v1.</summary>
		/// <remarks>Computes the dot product of this vector and vector v1.</remarks>
		/// <param name="v1">the other vector</param>
		/// <returns>the dot product of this vector and v1</returns>
		public float Dot(Vector3f v1)
		{
			return (this.x * v1.x + this.y * v1.y + this.z * v1.z);
		}

		/// <summary>Sets the value of this vector to the normalization of vector v1.</summary>
		/// <remarks>Sets the value of this vector to the normalization of vector v1.</remarks>
		/// <param name="v1">the un-normalized vector</param>
		public void Normalize(Vector3f v1)
		{
			float norm;
			norm = (float)(1.0 / Math.Sqrt(v1.x * v1.x + v1.y * v1.y + v1.z * v1.z));
			this.x = v1.x * norm;
			this.y = v1.y * norm;
			this.z = v1.z * norm;
		}

		/// <summary>Normalizes this vector in place.</summary>
		/// <remarks>Normalizes this vector in place.</remarks>
		public void Normalize()
		{
			float norm;
			norm = (float)(1.0 / Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.
				z));
			this.x *= norm;
			this.y *= norm;
			this.z *= norm;
		}

		/// <summary>
		/// Returns the angle in radians between this vector and the vector
		/// parameter; the return value is constrained to the range [0,PI].
		/// </summary>
		/// <remarks>
		/// Returns the angle in radians between this vector and the vector
		/// parameter; the return value is constrained to the range [0,PI].
		/// </remarks>
		/// <param name="v1">the other vector</param>
		/// <returns>the angle in radians in the range [0,PI]</returns>
		public float Angle(Vector3f v1)
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
