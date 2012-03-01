/*
 * Automated conversion
 */

using System;

namespace NVecMath
{
	/// <summary>
	/// A 2-element vector that is represented by double-precision floating
	/// point x,y coordinates.
	/// </summary>
	/// <remarks>
	/// A 2-element vector that is represented by double-precision floating
	/// point x,y coordinates.
	/// </remarks>
	[System.Serializable]
	public class Vector2d : Tuple2d
	{
		new internal const long serialVersionUID = 8572646365302599857L;

		/// <summary>Constructs and initializes a Vector2d from the specified xy coordinates.
		/// 	</summary>
		/// <remarks>Constructs and initializes a Vector2d from the specified xy coordinates.
		/// 	</remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		public Vector2d(double x, double y) : base(x, y)
		{
		}

		/// <summary>Constructs and initializes a Vector2d from the specified array.</summary>
		/// <remarks>Constructs and initializes a Vector2d from the specified array.</remarks>
		/// <param name="v">the array of length 2 containing xy in order</param>
		public Vector2d(double[] v) : base(v)
		{
		}

		/// <summary>Constructs and initializes a Vector2d from the specified Vector2d.</summary>
		/// <remarks>Constructs and initializes a Vector2d from the specified Vector2d.</remarks>
		/// <param name="v1">the Vector2d containing the initialization x y data</param>
		public Vector2d(Vector2d v1) : base(v1)
		{
		}

		/// <summary>Constructs and initializes a Vector2d from the specified Vector2f.</summary>
		/// <remarks>Constructs and initializes a Vector2d from the specified Vector2f.</remarks>
		/// <param name="v1">the Vector2f containing the initialization x y data</param>
		public Vector2d(Vector2f v1) : base(v1)
		{
		}

		/// <summary>Constructs and initializes a Vector2d from the specified Tuple2d.</summary>
		/// <remarks>Constructs and initializes a Vector2d from the specified Tuple2d.</remarks>
		/// <param name="t1">the Tuple2d containing the initialization x y data</param>
		public Vector2d(Tuple2d t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a Vector2d from the specified Tuple2f.</summary>
		/// <remarks>Constructs and initializes a Vector2d from the specified Tuple2f.</remarks>
		/// <param name="t1">the Tuple2f containing the initialization x y data</param>
		public Vector2d(Tuple2f t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a Vector2d to (0,0).</summary>
		/// <remarks>Constructs and initializes a Vector2d to (0,0).</remarks>
		public Vector2d() : base()
		{
		}

		// Combatible with 1.1
		/// <summary>Computes the dot product of the this vector and vector v1.</summary>
		/// <remarks>Computes the dot product of the this vector and vector v1.</remarks>
		/// <param name="v1">the other vector</param>
		public double Dot(Vector2d v1)
		{
			return (this.x * v1.x + this.y * v1.y);
		}

		/// <summary>Returns the length of this vector.</summary>
		/// <remarks>Returns the length of this vector.</remarks>
		/// <returns>the length of this vector</returns>
		public double Length()
		{
			return (double)Math.Sqrt(this.x * this.x + this.y * this.y);
		}

		/// <summary>Returns the squared length of this vector.</summary>
		/// <remarks>Returns the squared length of this vector.</remarks>
		/// <returns>the squared length of this vector</returns>
		public double LengthSquared()
		{
			return (this.x * this.x + this.y * this.y);
		}

		/// <summary>Sets the value of this vector to the normalization of vector v1.</summary>
		/// <remarks>Sets the value of this vector to the normalization of vector v1.</remarks>
		/// <param name="v1">the un-normalized vector</param>
		public void Normalize(Vector2d v1)
		{
			double norm;
			norm = (double)(1.0 / Math.Sqrt(v1.x * v1.x + v1.y * v1.y));
			this.x = v1.x * norm;
			this.y = v1.y * norm;
		}

		/// <summary>Normalizes this vector in place.</summary>
		/// <remarks>Normalizes this vector in place.</remarks>
		public void Normalize()
		{
			double norm;
			norm = (double)(1.0 / Math.Sqrt(this.x * this.x + this.y * this.y));
			this.x *= norm;
			this.y *= norm;
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
		public double Angle(Vector2d v1)
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
			return ((double)(Math.Acos(vDot)));
		}
	}
}
